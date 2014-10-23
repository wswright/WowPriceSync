using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel.AuctionDataFile
{
    public class AuctionDataFile
    {
        private const string DB_TABLE_NAME = "AuctionData";

        public DateTime lastModified { get; set; }
        public Realm realm { get; set; }
        public Auctions auctions { get; set; }
        //public Alliance alliance { get; set; }
        //public Horde horde { get; set; }
        //public Neutral neutral { get; set; }

        /// <summary>
        /// Saves the AuctionDataFile to a database via BulkInsert.
        /// </summary>
        /// <param name="db">The IDBLayer providing DB access.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public async Task<bool> Save(IDBLayer db)
        {
            try
            {
                //Sanity check
                if (lastModified == DateTime.MinValue)
                    lastModified = DateTime.Now;

                DataTable tbl = GetFormattedDataTable();
                AddAuctions(ref tbl, auctions.auctions, lastModified);
                return await db.BulkInsert(tbl, DB_TABLE_NAME);
            }
            catch(Exception eX)
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a list of auctions to the given datatable.
        /// </summary>
        /// <param name="tbl">(By Ref) - The datatable</param>
        /// <param name="auctions">The list of Auctions to add</param>
        public static void AddAuctions(ref DataTable tbl, List<Auction> auctions, DateTime time)
        {
            foreach (Auction auc in auctions)
            {
                tbl.Rows.Add(time,
                             auc.auc,
                             auc.item,
                             auc.owner,
                             auc.ownerRealm,
                             auc.bid,
                             auc.buyout,
                             auc.quantity,
                             auc.timeLeft);
            }
        }

        /// <summary>
        /// Returns a data table with named/typed columns that represents an AuctionDataFile
        /// </summary>
        /// <returns></returns>
        private static DataTable GetFormattedDataTable()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.AddRange(new DataColumn[] {
                new DataColumn("time", typeof(DateTime)),
                new DataColumn("auc", typeof(int)),
                new DataColumn("item", typeof(int)),
                new DataColumn("owner", typeof(string)),
                new DataColumn("ownerrealm", typeof(string)),
                new DataColumn("bid", typeof(long)),
                new DataColumn("buyout", typeof(long)),
                new DataColumn("quantity", typeof(int)),
                new DataColumn("timeleft", typeof(string)),
            });
            return tbl;
        }
    }

    public class Realm
    {
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class Auctions
    {
        public List<Auction> auctions { get; set; }
    }

    //This models the json returned from the API, NOT how it is stored in the database
    public class Auction
    {
        public int auc { get; set; }
        public int item { get; set; }
        public string owner { get; set; }
        public string ownerRealm { get; set; }
        public Int64 bid { get; set; }
        public Int64 buyout { get; set; }
        public int quantity { get; set; }
        public string timeLeft { get; set; }
        public int rand { get; set; }
        public object seed { get; set; }
        public int? petSpeciesId { get; set; }
        public int? petBreedId { get; set; }
        public int? petLevel { get; set; }
        public int? petQualityId { get; set; }

       
    }

    //public class Alliance
    //{
    //    public List<Auction> auctions { get; set; }
    //}


    //public class Horde
    //{
    //    public List<Auction> auctions { get; set; }
    //}

    //public class Neutral
    //{
    //    public List<Auction> auctions { get; set; }
    //}
}
