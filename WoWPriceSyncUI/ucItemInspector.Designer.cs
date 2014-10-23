namespace WoWPriceSyncUI
{
    partial class ucItemInspector
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.favoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageItemInfo = new System.Windows.Forms.TabPage();
            this.tabPageWowhead = new System.Windows.Forms.TabPage();
            this.webBrowserWowhead = new System.Windows.Forms.WebBrowser();
            this.tabPageCharts = new System.Windows.Forms.TabPage();
            this.tabPageFarmers = new System.Windows.Forms.TabPage();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.btnReload = new System.Windows.Forms.Button();
            this.ucItemInfo1 = new WoWPriceSyncUI.ucItemInfo();
            this.ucCharting1 = new WoWPriceSyncUI.ucCharting();
            this.ucFarmers1 = new WoWPriceSyncUI.ucFarmers();
            this.ucRawItemData1 = new WoWPriceSyncUI.ucRawItemData();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.itemContextStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageItemInfo.SuspendLayout();
            this.tabPageWowhead.SuspendLayout();
            this.tabPageCharts.SuspendLayout();
            this.tabPageFarmers.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colName});
            this.dataGridView1.ContextMenuStrip = this.itemContextStrip;
            this.dataGridView1.Location = new System.Drawing.Point(0, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(209, 440);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // colImage
            // 
            this.colImage.HeaderText = "Icon";
            this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Width = 32;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // itemContextStrip
            // 
            this.itemContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.favoriteToolStripMenuItem});
            this.itemContextStrip.Name = "itemContextStrip";
            this.itemContextStrip.Size = new System.Drawing.Size(157, 26);
            // 
            // favoriteToolStripMenuItem
            // 
            this.favoriteToolStripMenuItem.Name = "favoriteToolStripMenuItem";
            this.favoriteToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.favoriteToolStripMenuItem.Text = "Toggle Favorite";
            this.favoriteToolStripMenuItem.Click += new System.EventHandler(this.favoriteToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageItemInfo);
            this.tabControl1.Controls.Add(this.tabPageWowhead);
            this.tabControl1.Controls.Add(this.tabPageCharts);
            this.tabControl1.Controls.Add(this.tabPageFarmers);
            this.tabControl1.Controls.Add(this.tabPageData);
            this.tabControl1.Location = new System.Drawing.Point(211, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(671, 462);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPageItemInfo
            // 
            this.tabPageItemInfo.Controls.Add(this.ucItemInfo1);
            this.tabPageItemInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageItemInfo.Name = "tabPageItemInfo";
            this.tabPageItemInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItemInfo.Size = new System.Drawing.Size(663, 436);
            this.tabPageItemInfo.TabIndex = 0;
            this.tabPageItemInfo.Text = "Item Info";
            this.tabPageItemInfo.UseVisualStyleBackColor = true;
            // 
            // tabPageWowhead
            // 
            this.tabPageWowhead.Controls.Add(this.webBrowserWowhead);
            this.tabPageWowhead.Location = new System.Drawing.Point(4, 22);
            this.tabPageWowhead.Name = "tabPageWowhead";
            this.tabPageWowhead.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWowhead.Size = new System.Drawing.Size(663, 436);
            this.tabPageWowhead.TabIndex = 1;
            this.tabPageWowhead.Text = "Wowhead";
            this.tabPageWowhead.UseVisualStyleBackColor = true;
            // 
            // webBrowserWowhead
            // 
            this.webBrowserWowhead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserWowhead.Location = new System.Drawing.Point(3, 3);
            this.webBrowserWowhead.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserWowhead.Name = "webBrowserWowhead";
            this.webBrowserWowhead.ScriptErrorsSuppressed = true;
            this.webBrowserWowhead.Size = new System.Drawing.Size(657, 430);
            this.webBrowserWowhead.TabIndex = 0;
            // 
            // tabPageCharts
            // 
            this.tabPageCharts.Controls.Add(this.ucCharting1);
            this.tabPageCharts.Location = new System.Drawing.Point(4, 22);
            this.tabPageCharts.Name = "tabPageCharts";
            this.tabPageCharts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCharts.Size = new System.Drawing.Size(663, 436);
            this.tabPageCharts.TabIndex = 2;
            this.tabPageCharts.Text = "Charts";
            this.tabPageCharts.UseVisualStyleBackColor = true;
            // 
            // tabPageFarmers
            // 
            this.tabPageFarmers.Controls.Add(this.ucFarmers1);
            this.tabPageFarmers.Location = new System.Drawing.Point(4, 22);
            this.tabPageFarmers.Name = "tabPageFarmers";
            this.tabPageFarmers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFarmers.Size = new System.Drawing.Size(663, 436);
            this.tabPageFarmers.TabIndex = 3;
            this.tabPageFarmers.Text = "Top Farmers";
            this.tabPageFarmers.UseVisualStyleBackColor = true;
            // 
            // txtFilter
            // 
            this.txtFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFilter.Location = new System.Drawing.Point(0, 1);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(187, 20);
            this.txtFilter.TabIndex = 4;
            this.txtFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyUp);
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.ucRawItemData1);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(663, 436);
            this.tabPageData.TabIndex = 4;
            this.tabPageData.Text = "Raw Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            this.btnReload.BackgroundImage = global::WoWPriceSyncUI.Properties.Resources.refresh_blank_32;
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Location = new System.Drawing.Point(190, 1);
            this.btnReload.Margin = new System.Windows.Forms.Padding(0);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(20, 20);
            this.btnReload.TabIndex = 2;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // ucItemInfo1
            // 
            this.ucItemInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucItemInfo1.Location = new System.Drawing.Point(3, 3);
            this.ucItemInfo1.Name = "ucItemInfo1";
            this.ucItemInfo1.Size = new System.Drawing.Size(657, 430);
            this.ucItemInfo1.TabIndex = 0;
            // 
            // ucCharting1
            // 
            this.ucCharting1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCharting1.Location = new System.Drawing.Point(3, 3);
            this.ucCharting1.Name = "ucCharting1";
            this.ucCharting1.Size = new System.Drawing.Size(657, 430);
            this.ucCharting1.TabIndex = 0;
            // 
            // ucFarmers1
            // 
            this.ucFarmers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFarmers1.Location = new System.Drawing.Point(3, 3);
            this.ucFarmers1.Name = "ucFarmers1";
            this.ucFarmers1.Size = new System.Drawing.Size(657, 430);
            this.ucFarmers1.TabIndex = 0;
            // 
            // ucRawItemData1
            // 
            this.ucRawItemData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRawItemData1.Location = new System.Drawing.Point(3, 3);
            this.ucRawItemData1.Name = "ucRawItemData1";
            this.ucRawItemData1.Size = new System.Drawing.Size(657, 430);
            this.ucRawItemData1.TabIndex = 0;
            // 
            // ucItemInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ucItemInspector";
            this.Size = new System.Drawing.Size(882, 462);
            this.Load += new System.EventHandler(this.ucItemInspector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.itemContextStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageItemInfo.ResumeLayout(false);
            this.tabPageWowhead.ResumeLayout(false);
            this.tabPageCharts.ResumeLayout(false);
            this.tabPageFarmers.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageItemInfo;
        private System.Windows.Forms.TabPage tabPageWowhead;
        private System.Windows.Forms.WebBrowser webBrowserWowhead;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.TabPage tabPageCharts;
        private ucItemInfo ucItemInfo1;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private ucCharting ucCharting1;
        private System.Windows.Forms.ContextMenuStrip itemContextStrip;
        private System.Windows.Forms.ToolStripMenuItem favoriteToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageFarmers;
        private ucFarmers ucFarmers1;
        private System.Windows.Forms.TabPage tabPageData;
        private ucRawItemData ucRawItemData1;

    }
}
