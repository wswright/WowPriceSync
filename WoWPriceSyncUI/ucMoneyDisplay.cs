using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoWPriceSyncUI
{
    public partial class ucMoneyDisplay : UserControl
    {
        public ucMoneyDisplay()
        {
            InitializeComponent();
        }

        public void SetAmount(long amt)
        {
            if (amt == 0)
            {
                lblCopper.Text = lblSilver.Text = lblGold.Text = "0";
                return;
            }
            int gold, silver, copper;
            copper = (int)amt % 100;
            silver = (int)(amt % 10000) / 100;
            gold = (int)(amt % 1000000) / 100 / 100;
            
            lblCopper.Text = copper.ToString();
            lblSilver.Text = silver.ToString();
            lblGold.Text = gold.ToString();
        }
    }
}
