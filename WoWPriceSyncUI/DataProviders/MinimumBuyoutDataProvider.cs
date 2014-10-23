using Scott.WoWAPI;
using Scott.WoWAPI.APIModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace WoWPriceSyncUI.DataProviders
{
    public struct TimeValueEntry
    {
        public DateTime time;
        public double value;
    }

    public class MinimumBuyoutDataProvider : WowDataProvider
    {
        const string CATEGORY_NAME = "MinimumBuyoutProvider";
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

        [CategoryAttribute(CATEGORY_NAME)]
        public bool ShowFullStackPrice { get; set; }

        [CategoryAttribute(CATEGORY_NAME)]
        public double MaxIncreasePercent { get; set; }

        [CategoryAttribute(CATEGORY_NAME)]
        public bool ShowMovingAverage { get; set; }

        [CategoryAttribute(CATEGORY_NAME)]
        public int MovingAveragePoints { get; set; }

        [CategoryAttribute(CATEGORY_NAME)]
        [Description("The buyout cutoff. No auctions above this price will be shown.")]
        public double BuyoutCutoff { get; set; }

        [CategoryAttribute(CATEGORY_NAME)]
        [Description("Toggles display of Exponential Moving Average.")]
        public bool ShowEMA { get; set; }

        [CategoryAttribute(CATEGORY_NAME)]
        [Description("The number of points for calculating the Exponential Moving Average.")]
        public int EMAPoints { get; set; }

        [CategoryAttribute(CATEGORY_NAME)]
        public bool ShowOnlyFullStacks { get; set; }

        public MinimumBuyoutDataProvider(Item item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            _item = item;
            _allData = new List<AuctionEntry>();
            MovingAveragePoints = MovingAverageHelper.DEFAULT_MAX_POINTS;
            EMAPoints = ExponentialMovingAverageHelper.DEFAULT_NUMBER_OF_POINTS;
            ShowEMA = true;
            ShowMovingAverage = true;
            ShowFullStackPrice = true;
            MaxIncreasePercent = _item.MaxIncreasePercent;
            BuyoutCutoff = _item.BuyoutCutoff;
        }

        public override string GetTitle()
        {
            if (_item == null)
                return "Minimum Buyout";
            return string.Format("Minimum Buyout - {0}", _item.name);
        }

        public override string GetXAxisTitle()
        {
            return "Time";
        }

        public override string GetYAxisTitle()
        {
            return "Price";
        }

        public override async Task RefreshData()
        {
            StopWatch sWatch = new StopWatch();
            sWatch.Start();

            if (_dbMan == null)
            {
                _dbMan = new DBManager();
                _dbMan.Warmup();
            }

            sWatch.Lap("DB Warmup");

            string qry = string.Format("SELECT time, auc, item, owner, ownerrealm, bid, buyout, quantity, timeleft FROM AuctionData WHERE item={0}", _item.id);
            DataTable tbl = await(_dbMan as IDBLayer).ExecuteQuery(new SqlCommand(qry));
            if (tbl == null || tbl.Rows.Count == 0)
            {
                Logger.Log(string.Format("Failed to load MinimumBuyoutProvider data for item #{0}! Data was null or empty.", _item.id), Logger.Level.Warning);
                return;
            }

            sWatch.Lap("DataTable from Qry");

            List<AuctionEntry> auctions = new List<AuctionEntry>();
            foreach (DataRow dr in tbl.Rows)
            {
                auctions.Add(AuctionEntry.AuctionEntryFromDataRow(dr));
            }
            _allData = auctions;
            
            sWatch.Stop();
            sWatch.LogLaps("MinProvider");
        }

        public override async Task<DataCurveDescriptor[]> GetData()
        {
            //Refresh data if there isn't any
            if (_allData == null || _allData.Count() == 0)
                await RefreshData();

            int minStackSize = 1;
            if (ShowOnlyFullStacks)
                minStackSize = _item.stackable;

            PointPairList ppl = new PointPairList();
            var tmpData = from auc in _allData
                       where  auc.buyout > 0 && auc.quantity >= minStackSize && (auc.buyout /auc.quantity) * _item.stackable < BuyoutCutoff
                       group auc by auc.time into gAuc  //linq, u so sexy
                       orderby gAuc.Key descending
                       select new TimeValueEntry()
                       {
                           time = gAuc.Key,
                           value = gAuc.Min(min => ((min.buyout/100.0/100.0)/ min.quantity) * (ShowFullStackPrice ? _item.stackable : 1))
                           
                       };

            var data = ScrubData(tmpData);


            foreach (var dataEntry in data)
            {
                ppl.Add(dataEntry.time.ToOADate(), dataEntry.value);
            }

            List<DataCurveDescriptor> dataCurves = new List<DataCurveDescriptor>();

            if (ShowMovingAverage)
            {
                MovingAverageHelper mavg = new MovingAverageHelper(data, MovingAveragePoints);
                dataCurves.Add(new DataCurveDescriptor(mavg.Calculate())
                {
                    DoAntiAlias = true,
                    DoFill = false,
                    LineWidth = 4.0f,
                    Title = "Moving Average",
                    Symbol = SymbolType.None
                });
            }

            if (ShowEMA)
            {
                ExponentialMovingAverageHelper emaHelper = new ExponentialMovingAverageHelper(data, EMAPoints);
                dataCurves.Add(new DataCurveDescriptor(emaHelper.Calculate())
                {
                    DoAntiAlias = true,
                    DoFill = false,
                    LineWidth = 4.0f,
                    Title = string.Format("{0}-Point EMA", EMAPoints),
                    Symbol = SymbolType.None
                });
            }

            dataCurves.Add(new DataCurveDescriptor(ppl)
            {
                DoAntiAlias = true,
                DoFill = true,
                LineWidth = 2.0f,
                Title = "Minimum Buyout",
                Symbol = SymbolType.Circle
            });

            
            return dataCurves.ToArray();
        }

        private IEnumerable<TimeValueEntry> ScrubData(IEnumerable<TimeValueEntry> tmpData)
        {
            double prevValue = 0.0;
            foreach (TimeValueEntry tv in tmpData)
            {
                if (prevValue == 0.0)
                {
                    prevValue = tv.value;
                    yield return tv;
                }
                else
                {
                    if (tv.value == 1200)
                        Logger.Log("HERE");
                    double maxTolerableAmount = prevValue * (1.0 + (MaxIncreasePercent / 100.0));
                    if (tv.value > maxTolerableAmount)
                        continue;
                    prevValue = tv.value;
                    yield return tv;
                }
            }
        }


        public async override void PropertyChanged(object sender, System.Windows.Forms.PropertyValueChangedEventArgs e)
        {
            base.PropertyChanged(sender, e);
            _item.MaxIncreasePercent = MaxIncreasePercent;
            _item.BuyoutCutoff = BuyoutCutoff;
            await _item.Update(_dbMan);
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
