namespace WoWPriceSyncUI
{
    partial class ucRawItemData
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
            this.dataGridViewRawData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRawData)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRawData
            // 
            this.dataGridViewRawData.AllowUserToAddRows = false;
            this.dataGridViewRawData.AllowUserToDeleteRows = false;
            this.dataGridViewRawData.AllowUserToOrderColumns = true;
            this.dataGridViewRawData.AllowUserToResizeRows = false;
            this.dataGridViewRawData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRawData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewRawData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRawData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRawData.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRawData.Name = "dataGridViewRawData";
            this.dataGridViewRawData.ReadOnly = true;
            this.dataGridViewRawData.RowHeadersVisible = false;
            this.dataGridViewRawData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewRawData.Size = new System.Drawing.Size(812, 484);
            this.dataGridViewRawData.TabIndex = 0;
            // 
            // ucRawItemData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewRawData);
            this.Name = "ucRawItemData";
            this.Size = new System.Drawing.Size(812, 484);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRawData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRawData;
    }
}
