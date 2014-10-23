namespace WoWPriceSyncUI
{
    partial class ucAuctionDisplay
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
            this.lblFaction = new System.Windows.Forms.Label();
            this.lblItemLabel = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblDistinctItems = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFaction
            // 
            this.lblFaction.AutoSize = true;
            this.lblFaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaction.Location = new System.Drawing.Point(3, 0);
            this.lblFaction.Name = "lblFaction";
            this.lblFaction.Size = new System.Drawing.Size(85, 20);
            this.lblFaction.TabIndex = 0;
            this.lblFaction.Text = "FACTION";
            // 
            // lblItemLabel
            // 
            this.lblItemLabel.AutoSize = true;
            this.lblItemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemLabel.Location = new System.Drawing.Point(75, 20);
            this.lblItemLabel.Name = "lblItemLabel";
            this.lblItemLabel.Size = new System.Drawing.Size(41, 13);
            this.lblItemLabel.TabIndex = 1;
            this.lblItemLabel.Text = "Items:";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(122, 20);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(16, 13);
            this.lblItem.TabIndex = 2;
            this.lblItem.Text = "...";
            // 
            // lblDistinctItems
            // 
            this.lblDistinctItems.AutoSize = true;
            this.lblDistinctItems.Location = new System.Drawing.Point(122, 33);
            this.lblDistinctItems.Name = "lblDistinctItems";
            this.lblDistinctItems.Size = new System.Drawing.Size(16, 13);
            this.lblDistinctItems.TabIndex = 4;
            this.lblDistinctItems.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Unique:";
            // 
            // ucAuctionDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDistinctItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.lblItemLabel);
            this.Controls.Add(this.lblFaction);
            this.Name = "ucAuctionDisplay";
            this.Size = new System.Drawing.Size(202, 50);
            this.Load += new System.EventHandler(this.ucAuctionDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFaction;
        private System.Windows.Forms.Label lblItemLabel;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblDistinctItems;
        private System.Windows.Forms.Label label2;
    }
}
