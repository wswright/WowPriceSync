using Scott.WoWAPI.APIModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWPriceSyncUI
{
    public class DuplicateAuctionRemover
    {
        private const string duplicateQuery = @"SELECT TOP {0} * FROM AuctionData as a WHERE a.time <> (SELECT TOP 1 time FROM AuctionData as b WHERE b.auc = a.auc AND (SELECT COUNT(auc) as [auccount] FROM AuctionData as c WHERE c.auc = a.auc) > 1 ORDER BY b.time DESC)";
        private const int DEFAULT_ROWS_TO_RETRIEVE = 5000;
        private int _rowsToRetrieve;
        private static DBManager _dbMan;

        private bool _noDuplicatesFound = false;

        public bool NoMoreDuplicates
        {
            get { return _noDuplicatesFound; }
        }

        public int RowsToRetrieve
        {
            get
            {
                return _rowsToRetrieve;
            }
        }

        public DuplicateAuctionRemover(int rowsToRetrieve = DEFAULT_ROWS_TO_RETRIEVE)
        {
            _rowsToRetrieve = rowsToRetrieve;

            if (_dbMan == null)
            {
                _dbMan = new DBManager();
                _dbMan.Warmup();
            }
        }

        private AuctionEntry[] GetDuplicates()
        {
            string qry = string.Format(duplicateQuery, _rowsToRetrieve);
            try
            {
                DataTable rawData = _dbMan.ExecuteQuerySynchronous(new SqlCommand(qry));
                List<AuctionEntry> tmpDuplicates = new List<AuctionEntry>();

                foreach (DataRow dr in rawData.Rows)
                {
                    AuctionEntry entry = AuctionEntry.AuctionEntryFromDataRow(dr);
                    if (entry != null)
                        tmpDuplicates.Add(entry);
                }
                return tmpDuplicates.ToArray();
            }
            catch (Exception eX)
            {
                Logger.Log("Failed to fetch duplicate auctions to remove! Message: " + eX.Message);
                return new AuctionEntry[0];
            }
        }

        public bool RemoveDuplicates()
        {
            int chunkSize = 50;
            int i = 0;
            AuctionEntry[] duplicates = GetDuplicates();
            if (duplicates.Length == 0)
            {
                _noDuplicatesFound = true;
                return true;
            }
            while (i < duplicates.Count())
            {
                if (!Remove(duplicates.Skip(i).Take(chunkSize).ToArray()))
                    return false;
                i += chunkSize;
            }
            return true;
        }

        private bool Remove(AuctionEntry[] duplicates)
        {
            string removeQry = "(auc=@auc{0} AND time=@time{0})";
            string preQry = "DELETE FROM AuctionData WHERE ";
            string ors = string.Empty;

            List<SqlParameter> sParams = new List<SqlParameter>();

            int i = 0;
            int count = duplicates.Count();
            foreach (AuctionEntry e in duplicates)
            {
                if (i > 0)
                    ors += " OR ";
                ors += string.Format(removeQry, i);
                string aucParam = string.Format("@auc{0}", i);
                string timeParam = string.Format("@time{0}", i);

                sParams.Add(new SqlParameter(aucParam, e.auc));
                sParams.Add(new SqlParameter(timeParam, e.time));
                i++;
            }

            string fullQuery = preQry + ors;
            SqlCommand cmd = new SqlCommand(fullQuery);
            cmd.Parameters.AddRange(sParams.ToArray());

            try
            {
                int affected = _dbMan.ExecuteNonQuery(cmd);
                if (affected != count)
                {
                    Logger.Log(string.Format("Expected {0} deleted rows but got {1}!", count, affected), Logger.Level.Warning);
                    return false;
                }
            }
            catch (Exception eX)
            {
                Logger.Log("Failed to delete duplicates! Message: " + eX.Message);
                return false;
            }
            return true;
        }
    }
}
