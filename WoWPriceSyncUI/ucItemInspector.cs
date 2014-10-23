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
    public partial class ucItemInspector : UserControl
    {
        ImageCache imgCache;
        List<Item> currentItems;
        public static bool IsInitialLoadingComplete = false;

        public ucItemInspector()
        {
            InitializeComponent();
            
        }


        private void ucItemInspector_Load(object sender, EventArgs e)
        {
            imgCache = new ImageCache();
            //PopulateAllItems();

            this.Invoke((MethodInvoker) delegate {
                PopulateAllItems();
            });
        }

        private async void PopulateAllItems()
        {
            if (!this.DesignMode)   //VS -WILL- crash if you remove this.
            {
                DBManager dbMan = new DBManager();
                dbMan.Warmup();

                //Bitmap bmp = imgCache.GetImage("INV_Misc_QuestionMark");
                //dataGridView1.Rows.Add(bmp, "Unknown");
                if (!IsInitialLoadingComplete)
                    await imgCache.PreloadImages();
                List<Item> items = await Item.GetItems(dbMan);

                //Sort items so that favorites are at the top, then sort by id
                var sortedItems = from i in items
                                  orderby i.IsFavorite descending, i.id ascending
                                  select i;

                currentItems = sortedItems.ToList();
                PopulateItems(currentItems);

                if(SettingsManager.DoIconSync)
                    if (!IsInitialLoadingComplete)
                        await imgCache.SaveImagesToDatabase();

                IsInitialLoadingComplete = true;
            }
        }

        private void PopulateItems(IEnumerable<Item> items)
        {
            StopWatch sWatch = new StopWatch();
            sWatch.Start();
            dataGridView1.Rows.Clear();
            //currentItems = items.ToList();

            DataGridViewRow[] rows = new DataGridViewRow[items.Count()];
            int index = 0;
            foreach (Item i in items)
            {
                Bitmap iBmp = imgCache.GetImage(i.icon);
                DataGridViewRow dg = (DataGridViewRow)dataGridView1.RowTemplate.Clone();
                dg.CreateCells(dataGridView1, iBmp, i.name);
                dg.Tag = i;
                rows[index++] = dg;
            }
            dataGridView1.Rows.AddRange(rows);

            sWatch.Lap("Items added");
            txtFilter.AutoCompleteCustomSource = CreateAutoCompleteStringCollection(currentItems);
            sWatch.Stop();
            sWatch.LogLaps("PopulateItems");
        }

        private AutoCompleteStringCollection CreateAutoCompleteStringCollection(List<Item> items)
        {
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            var names = from i in items
                        select i.name;
            col.AddRange(names.ToArray());
            return col;            
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            PopulateAllItems();
        }

        /// <summary>
        /// Multiple items were selected
        /// </summary>
        /// <param name="rowItems"></param>
        private void ItemsSelected(List<Item> rowItems)
        {
            throw new NotImplementedException();
        }


        //A single item was selected
        private void ItemSelected(Item item)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0://info
                    ucItemInfo1.SetItem(item);
                    break;
                case 1://wowhead
                    webBrowserWowhead.Navigate(string.Format("http://wowhead.com/item={0}", item.id));
                    break;
                case 2://Charting
                    ucCharting1.LoadItem(item);
                    break;
                case 3://Farmers
                    ucFarmers1.LoadItem(item);
                    break;
                case 4://Raw Data
                    ucRawItemData1.LoadItem(item);
                    break;
                default:
                    break;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dRow = dataGridView1.Rows[e.RowIndex];
            if (dRow == null || dRow.Tag == null)
                return;
            ItemSelected(dRow.Tag as Item);
        }

        private void txtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (string.IsNullOrWhiteSpace(txtFilter.Text))
                //    return;
                string filterText = txtFilter.Text;
                FilterItems(filterText);
            }
        }

        private void FilterItems(string filterText)
        {
            if (string.IsNullOrWhiteSpace(filterText))
            {
                PopulateItems(currentItems);
                return;
            }

            var filteredItems = from i in currentItems
                                where i.name.Contains(filterText)
                                select i;
            PopulateItems(filteredItems);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            Item i = GetSelectedItem();
            if (i != null)
                ItemSelected(i);
            
        }

        private Item GetSelectedItem()
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                DataGridViewCell dCell = dataGridView1.SelectedCells[0];
                DataGridViewRow dRow = dCell.OwningRow;
                if (dRow == null || dRow.Tag == null)
                    return null;
                return dRow.Tag as Item;
            }
            return null;
        }

        private void favoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Get item
            Item i = GetSelectedItem();
            if (i != null)
                ToggleFavorite(i);
        }

        private async Task ToggleFavorite(Item i)
        {
            DBManager dbMan = new DBManager();
            dbMan.Warmup();
            i.IsFavorite = !i.IsFavorite;
            bool success = await i.Update(dbMan);
            string msg = i.IsFavorite ? "Set" : "Removed";
            if (success)
                Logger.Log(string.Format("{0} {1} as a favorite!", msg, i.name), Logger.Level.Info);
            else
                Logger.Log(string.Format("Failed to update item #{0} - {1}!", i.id, i.name), Logger.Level.Error);
        }


    }
}
