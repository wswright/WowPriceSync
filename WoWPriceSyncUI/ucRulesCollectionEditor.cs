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
using Scott.WoWAPI.APIModel;

namespace WoWPriceSyncUI
{
    public partial class ucRulesCollectionEditor : UserControl
    {
        private BaseRuleCollection _rules;
        private Item _item;

        public ucRulesCollectionEditor()
        {
            InitializeComponent();
        }

        public ucRulesCollectionEditor(Item item) : this()
        {
            _item = item;
            _rules = new BaseRuleCollection(_item);
        }

        private void ucRulesCollectionEditor_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            flowControls.Controls.Add(new ucRulesEditor());
        }
    }
}
