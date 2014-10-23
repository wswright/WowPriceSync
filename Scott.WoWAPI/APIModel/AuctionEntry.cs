using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.WoWAPI.APIModel
{
    /// <summary>
    /// This class models how the Auction data is actually stored in the database.
    /// </summary>
    public class AuctionEntry
    {
        public DateTime time { get; set; }
        public int auc { get; set; }
        public int item { get; set; }
        public string owner { get; set; }
        public string ownerRealm { get; set; }
        public Int64 bid { get; set; }
        public Int64 buyout { get; set; }
        public int quantity { get; set; }
        public string timeLeft { get; set; }

        /// <summary>
        /// Creates an AuctionEntry from a datarow that contains all of the fields.
        /// NOTE: The datarow MUST have all of the fields.
        /// </summary>
        /// <param name="dr">The datarow to parse.</param>
        /// <returns>Returns an AuctionEntry. On fail returns null.</returns>
        public static AuctionEntry AuctionEntryFromDataRow(DataRow dr)
        {
            try
            {
                AuctionEntry a = new AuctionEntry();
                a.time = (DateTime)dr["time"];
                a.auc = (int)dr["auc"];
                a.item = (int)dr["item"];
                a.owner = (string)dr["owner"];
                a.ownerRealm = (string)dr["ownerrealm"];
                a.bid = (Int64)dr["bid"];
                a.buyout = (Int64)dr["buyout"];
                a.quantity = (int)dr["quantity"];
                a.timeLeft = (string)dr["timeleft"];
                return a;
            }
            catch (Exception eX)
            {
                return null;
            }
        }
    }
}
