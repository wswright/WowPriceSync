using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scott.WoWAPI.APIModel.AuctionDataFile;
using System.Collections;

namespace WoWPriceSyncUI
{
    public partial class ucAuctionDisplay : UserControl
    {
        public enum Faction {Alliance, Horde, Neutral};

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("The Faction for the auction data"), Category("Data")]
        public Faction AuctionHouse
        {
            get
            {
                return _auctionHouse;
            }
            set
            {
                _auctionHouse = value;
            }
        }
        public Faction _auctionHouse;

        public ucAuctionDisplay()
        {
            InitializeComponent();
        }

        public void UpdateData(AuctionDataFile aucDF)
        {
            if (aucDF == null)
                return;
            //switch (_auctionHouse)
            //{
            //    case Faction.Alliance:
            //        DisplayCount(aucDF.alliance.auctions);
            //        break;
            //    case Faction.Horde:
            //        DisplayCount(aucDF.horde.auctions);
            //        break;
            //    case Faction.Neutral:
            //        DisplayCount(aucDF.neutral.auctions);
            //        break;
            //    default:
            //        break;
            //}
        }

        private void DisplayCount(IList<Auction> auctions)
        {
            lblItem.Text = string.Format("{0:n0}", auctions.Count);
            lblDistinctItems.Text = GetUniqueItems(auctions).ToString();
        }

        private int GetUniqueItems(IList<Auction> auctions)
        {
            //<ID, Count>
            Dictionary<int, int> counts = new Dictionary<int, int>();
            var distinctItems = auctions.GroupBy(a => a.item).Select(group => group.First());
            return distinctItems.Count();
        }

        private void ucAuctionDisplay_Load(object sender, EventArgs e)
        {
            //switch (_auctionHouse)
            //{
            //    case Faction.Alliance:
            //        lblFaction.Text = "Alliance";
            //        break;
            //    case Faction.Horde:
            //        lblFaction.Text = "Horde";
            //        break;
            //    case Faction.Neutral:
            //        lblFaction.Text = "Neutral";
            //        break;
            //    default:
            //        lblFaction.Text = "Unknown...???";
            //        break;
            //}
        }
    }
}
