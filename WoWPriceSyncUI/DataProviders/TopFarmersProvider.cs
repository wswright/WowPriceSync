using Scott.WoWAPI;
using Scott.WoWAPI.APIModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace WoWPriceSyncUI.DataProviders
{
#region CharacterQuantityEntry
    public struct CharacterQuantityEntry
    {
        public string owner;
        public double value;

        /// <summary>
        /// Creates a ChracterQuantityEntry from a DataRow that contains the columns: 'owner', 'value'
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static CharacterQuantityEntry FromDataRow(DataRow dr)
        {
            CharacterQuantityEntry c = new CharacterQuantityEntry();
            c.owner = "ERROR";
            try
            {
                c.owner = (string)dr["owner"];
                if(dr["value"] is double)
                    c.value = (double)dr["value"];
                if(dr["value"] is int)
                    c.value = (double)(int)dr["value"];
            }
            catch (Exception eX)
            {
                Logger.Log(string.Format("Failed to parse DataRow into CharacterQuantityEntry! Looking for columns: 'owner', 'value'! Message: {0}", eX.Message), Logger.Level.Error);
            }
            return c;
        }
    }
#endregion CharacterQuantityEntry

    public class TopFarmersProvider : WowDataProvider
    {
        private const string CATEGORY_NAME = "TopFarmersProvider";
        private Item _item;
        private DBManager _dbMan;
        private IEnumerable<CharacterQuantityEntry> _allData;

        private int _topFarmersCount = 10;
        public int TopFarmersCount
        {
            get
            {
                return _topFarmersCount;
            }
            set {
                _topFarmersCount = value;
            }
        }

        public TopFarmersProvider(Item item) : base()
        {
            if (item == null)
                throw new ArgumentNullException("item");
            _item = item;
        }

        public override Item GetItem()
        {
            return _item;
        }

        public override string GetTitle()
        {
            if (_item == null)
                return "Top Farmers";
            return string.Format("Top {0} Farmers - {1}", _topFarmersCount, _item.name);
        }

        public override string GetXAxisTitle()
        {
            return "Farmers";
        }

        public override string GetYAxisTitle()
        {
            return "Amount";
        }

        public async override Task RefreshData()
        {
            if (_dbMan == null)
            {
                _dbMan = new DBManager();
                _dbMan.Warmup();
            }

            string qry = string.Format(@"SELECT TOP {0} owner, sum(quantity) as value FROM AuctionData WHERE item={1} GROUP BY owner ORDER BY sum(quantity) DESC", _topFarmersCount, _item.id);
            DataTable tbl = await (_dbMan as IDBLayer).ExecuteQuery(new SqlCommand(qry));
            List<CharacterQuantityEntry> entries = new List<CharacterQuantityEntry>();
            foreach (DataRow dr in tbl.Rows)
                entries.Add(CharacterQuantityEntry.FromDataRow(dr));
            _allData = entries;
        }

        public async override Task<DataCurveDescriptor[]> GetData()
        {
            if (_allData == null || _allData.Count() == 0)
                await RefreshData();

            DataCurveDescriptor[] curves = new DataCurveDescriptor[_allData.Count()];
            int i = 0;
            foreach (CharacterQuantityEntry c in _allData)
            {
                PointPairList tmpPPL = new PointPairList();
                tmpPPL.Add(0, c.value);
                curves[i] = new DataCurveDescriptor(tmpPPL)
                {
                    Title = c.owner,
                    Symbol = SymbolType.None
                };
                
                i++;
            }
            return curves;
        }

        public override string GetCategoryName()
        {
            return CATEGORY_NAME;
        }

        public override AxisType GetXAxisType()
        {
            return AxisType.Text;
        }
    }
}
