using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WoWPriceSyncUI.RulesEngine;
using System.Reflection;
using Scott.WoWAPI.APIModel;

namespace WoWPriceSyncUI
{
    public partial class ucRulesEditor : UserControl
    {
        BaseRule _rule;

        public ucRulesEditor()
        {
            InitializeComponent();
        }

        private void ucRulesEditor_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            DBManager _dbMan = new DBManager();
            _dbMan.Warmup();

            Item item = Item.GetItem(72092, _dbMan);
            ItemHelper ruleItem = new ItemHelper(item);
            string[] propNames = ItemHelper.GetPropertyNames();
            cmbProperties.Items.AddRange(propNames);
            cmbOperators.Items.AddRange(BaseRule.GetOperators());
        }

        public BaseRule GetRule()
        {
            return _rule;
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            (this.Parent as FlowLayoutPanel).Controls.Remove(this);
        }

        
    }
}
