using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scott.WoWAPI.APIModel;

namespace WoWPriceSyncUI
{
    public partial class ucItemInfo : UserControl
    {
        public ucItemInfo()
        {
            InitializeComponent();
        }

        public void SetItem(Item item)
        {
            if (item == null)
                return;
            picIcon.Image = ImageCache.GetImageSimple(item.icon);
            ucSellAmount.SetAmount(item.sellPrice);
            lblID.Text = item.id.ToString();
            lblName.Text = item.name;
            lblDescription.Text = item.description;
        }
    }
}
