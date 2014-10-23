using Scott.WoWAPI;
using Scott.WoWAPI.APIModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace WoWPriceSyncUI.DataProviders
{
    public class VolumeProvider : WowDataProvider
    {
        const string CATEGORY_NAME = "VolumeProvider";
        private Item _item;
        private IEnumerable<AuctionEntry> _allData;
        private DBManager _dbMan;

        [CategoryAttribute(CATEGORY_NAME)]
        new public Faction[] Factions //New b/c we want to override the CategoryAttribute
        {
            get
            {
                return _factions;
            }
            set
            {
                _factions = value;
            }
        }

        public override string GetTitle()
        {
            if (_item == null)
                return "Volume";
            return string.Format("Volume - {0}", _item.name);
        }

        public override string GetXAxisTitle()
        {
            return "Time";
        }

        public override string GetYAxisTitle()
        {
            return "Volume";
        }

        public VolumeProvider(Item item) : base()
        {
            if (item == null)
                throw new ArgumentNullException("item");
            _item = item;
            _allData = new List<AuctionEntry>();
        }

        public async override Task<DataCurveDescriptor[]> GetData()
        {
            //Refresh data if there isn't any
            if (_allData == null || _allData.Count() == 0)
                await RefreshData();

            PointPairList ppl = new PointPairList();
            var data = from auc in _allData
                       group auc by auc.time into gAuc  //linq, u so sexy
                       orderby gAuc.Key descending
                       select new
                       {
                           time = gAuc.Key,
                           volume = gAuc.Sum(quantity => quantity.quantity)
                       };
            foreach (var dataEntry in data)
            {
                ppl.Add(dataEntry.time.ToOADate(), dataEntry.volume);
            }

            DataCurveDescriptor[] curves = new DataCurveDescriptor[1];
            curves[0] = new DataCurveDescriptor(ppl)
            {
                DoAntiAlias = true,
                DoFill = true,
                LineWidth = 2.0F,
                Symbol = SymbolType.Circle,
                Title = "Volume"
            };

            return curves;
        }

        public async override Task RefreshData()
        {
            if (_dbMan == null)
            {
                _dbMan = new DBManager();
                _dbMan.Warmup();
            }

            string qry = string.Format("SELECT time, auc, item, owner, ownerrealm, bid, buyout, quantity, timeleft FROM AuctionData WHERE item={0}", _item.id);
            DataTable tbl = await (_dbMan as IDBLayer).ExecuteQuery(new SqlCommand(qry));
            if (tbl == null || tbl.Rows.Count == 0)
            {
                Logger.Log(string.Format("Failed to load VolumeProvider data for item #{0}! Data was null or empty.", _item.id), Logger.Level.Warning);
                return;
            }

            List<AuctionEntry> auctions = new List<AuctionEntry>();
            foreach (DataRow dr in tbl.Rows)
            {
                auctions.Add(AuctionEntry.AuctionEntryFromDataRow(dr));
            }
            _allData = auctions;
        }

        public override void PropertyChanged(object sender, PropertyValueChangedEventArgs e)
        {
            base.PropertyChanged(sender, e);
        }

        public override string GetCategoryName()
        {
            return CATEGORY_NAME;
        }

        public override Item GetItem()
        {
            return _item;
        }

        public override AxisType GetXAxisType()
        {
            return AxisType.Date;
        }
    }
}
