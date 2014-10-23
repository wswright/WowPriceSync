using Scott.WoWAPI.APIModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WoWPriceSyncUI.RulesEngine
{
    public class ItemHelper
    {
        private Item _item;

        private DBManager _dbMan;
        private DBManager db
        {
            get
            {
                if (_dbMan == null)
                {
                    _dbMan = new DBManager();
                    _dbMan.Warmup();
                }
                return _dbMan;
            }
        }

        public ItemHelper(Item item)
        {
            _item = item;
        }

        public double Average30Days
        {
            get
            {
                return GetNDayAverage(30);
            }
        }

        public double Average14Days
        {
            get
            {
                return GetNDayAverage(14);
            }
        }        

        public double Average7Days
        {
            get
            {
                return GetNDayAverage(7);
            }
        }

        public double Average5Days
        {
            get
            {
                return GetNDayAverage(5);
            }
        }

        public double Average
        {
            get
            {
                return GetNDayAverage(1);
            }
        }

        public double Minimum
        {
            get { return GetMinimum(); }
        }

        public double Maximum
        {
            get { return GetMaximum(); }
        }

        public Item GetItem()
        {
            return _item;
        }

        private double GetNDayAverage(int days)
        {
            string qry = string.Format("SELECT AVG(buyout/quantity*{0}) FROM AuctionData WHERE item={1} AND time >= DATEADD(DAY, -{2}, GETDATE()) AND buyout > 0  AND buyout < (SELECT MIN(buyout/quantity*{0})*100 From AuctionData WHERE time >=  DATEADD(DAY, -{2}, GETDATE()) AND buyout > 0 and quantity > 0 AND item={1})", (double)_item.stackable, _item.id, days);
            double? val = db.ExecuteQuery_ScalarDoubleSynchronous(new SqlCommand(qry));
            
            if (val == null || !val.HasValue)
            {
                Logger.Log(string.Format("Error getting {0} day average for item #{1} - {2}! Value was null!", days, _item.id, _item.name), Logger.Level.Warning);
                return 0.0;
            }
            return val.Value;
        }

        /// <summary>
        /// Gets the minimum buyout for a stack of the item. Ignores Bid-only auctions.
        /// </summary>
        /// <returns>Returns the minimum buyout for a stack. If there isn't one, returns 0.0.</returns>
        private double GetMinimum()
        {
            string qry = string.Format("SELECT MIN((buyout/100.0/100.0)/quantity * {0}) FROM AuctionData WHERE item={1} AND time = (SELECT MAX(time) FROM AuctionData WHERE item={1} AND buyout > 0) AND buyout > 0", _item.stackable, _item.id);
            double? val = db.ExecuteQuery_ScalarDoubleSynchronous(new SqlCommand(qry));

            if (val == null || !val.HasValue)
            {
                Logger.Log(string.Format("Error getting minimum for item #{1} - {2}! Value was null!", _item.id, _item.name), Logger.Level.Warning);
                return 0.0;
            }
            return val.Value;
        }

        /// <summary>
        /// Gets the maximum buyout for a stack of the item. Ignores Bid-only auctions.
        /// </summary>
        /// <returns>Returns the maximum buyout for a stack. If there isn't one, returns 0.0.</returns>
        private double GetMaximum()
        {
            string qry = string.Format("SELECT MAX((buyout/100.0/100.0)/quantity * {0}) FROM AuctionData WHERE item={1} AND time = (SELECT MAX(time) FROM AuctionData WHERE item={1} AND buyout > 0) AND buyout > 0", _item.stackable, _item.id);
            double? val = db.ExecuteQuery_ScalarDoubleSynchronous(new SqlCommand(qry));

            if (val == null || !val.HasValue)
            {
                Logger.Log(string.Format("Error getting maximum for item #{1} - {2}! Value was null!", _item.id, _item.name), Logger.Level.Warning);
                return 0.0;
            }
            return val.Value;
        }

        public static string[] GetPropertyNames()
        {
            Type t = typeof(ItemHelper);
            PropertyInfo[] pInfo = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return (from p in pInfo
                    select p.Name).ToArray();
        }
    }
}
