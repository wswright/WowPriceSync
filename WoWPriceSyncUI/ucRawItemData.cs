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
using Scott.WoWAPI;
using System.Data.SqlClient;

namespace WoWPriceSyncUI
{
    public partial class ucRawItemData : UserControl
    {
        private Item _item;
        private DBManager _dbMan;
        private IEnumerable<AuctionEntry> _allData;
        private SortableBindingList<AuctionEntry> _bindAuctions;
        
        private bool loading;

        public ucRawItemData()
        {
            InitializeComponent();
        }

        public async void LoadItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (loading)
                return;
            loading = true;

            _item = item;
            Logger.Log(string.Format("Loading Raw Data for {0}!", _item.name), Logger.Level.Info);
            if (_dbMan == null)
            {
                _dbMan = new DBManager();
                _dbMan.Warmup();
            }
            await RefreshData();
            loading = false;
            _bindAuctions = new SortableBindingList<AuctionEntry>(_allData.ToList());
            dataGridViewRawData.DataSource = _bindAuctions;
        }

        private async Task RefreshData()
        {
            string qry = "SELECT * FROM AuctionData WHERE item={0}";
            qry = string.Format(qry, _item.id);
            DataTable data = await (_dbMan as IDBLayer).ExecuteQuery(new SqlCommand(qry));
            _allData = ParseData(data);
            
        }

        private IEnumerable<AuctionEntry> ParseData(DataTable data)
        {
            foreach (DataRow dr in data.Rows)
                yield return AuctionEntry.AuctionEntryFromDataRow(dr);
        }
    }
}
