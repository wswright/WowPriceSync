namespace WoWPriceSyncUI
{
    partial class ucMoneyDisplay
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
            this.lblGold = new System.Windows.Forms.Label();
            this.picGold = new System.Windows.Forms.PictureBox();
            this.lblSilver = new System.Windows.Forms.Label();
            this.picSilver = new System.Windows.Forms.PictureBox();
            this.picCopper = new System.Windows.Forms.PictureBox();
            this.lblCopper = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSilver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCopper)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGold
            // 
            this.lblGold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGold.Location = new System.Drawing.Point(3, 0);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(63, 21);
            this.lblGold.TabIndex = 0;
            this.lblGold.Text = "0";
            this.lblGold.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // picGold
            // 
            this.picGold.Image = global::WoWPriceSyncUI.Properties.Resources.UI_GoldIcon;
            this.picGold.Location = new System.Drawing.Point(64, 2);
            this.picGold.Name = "picGold";
            this.picGold.Size = new System.Drawing.Size(16, 16);
            this.picGold.TabIndex = 1;
            this.picGold.TabStop = false;
            // 
            // lblSilver
            // 
            this.lblSilver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSilver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSilver.Location = new System.Drawing.Point(84, 0);
            this.lblSilver.Name = "lblSilver";
            this.lblSilver.Size = new System.Drawing.Size(27, 21);
            this.lblSilver.TabIndex = 2;
            this.lblSilver.Text = "0";
            this.lblSilver.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // picSilver
            // 
            this.picSilver.Image = global::WoWPriceSyncUI.Properties.Resources.UI_SilverIcon;
            this.picSilver.Location = new System.Drawing.Point(111, 2);
            this.picSilver.Name = "picSilver";
            this.picSilver.Size = new System.Drawing.Size(16, 16);
            this.picSilver.TabIndex = 3;
            this.picSilver.TabStop = false;
            // 
            // picCopper
            // 
            this.picCopper.Image = global::WoWPriceSyncUI.Properties.Resources.UI_CopperIcon;
            this.picCopper.Location = new System.Drawing.Point(157, 2);
            this.picCopper.Name = "picCopper";
            this.picCopper.Size = new System.Drawing.Size(16, 16);
            this.picCopper.TabIndex = 5;
            this.picCopper.TabStop = false;
            // 
            // lblCopper
            // 
            this.lblCopper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCopper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopper.Location = new System.Drawing.Point(130, 0);
            this.lblCopper.Name = "lblCopper";
            this.lblCopper.Size = new System.Drawing.Size(27, 21);
            this.lblCopper.TabIndex = 4;
            this.lblCopper.Text = "0";
            this.lblCopper.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ucMoneyDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picCopper);
            this.Controls.Add(this.lblCopper);
            this.Controls.Add(this.picSilver);
            this.Controls.Add(this.lblSilver);
            this.Controls.Add(this.picGold);
            this.Controls.Add(this.lblGold);
            this.Name = "ucMoneyDisplay";
            this.Size = new System.Drawing.Size(176, 21);
            ((System.ComponentModel.ISupportInitialize)(this.picGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSilver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCopper)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.PictureBox picGold;
        private System.Windows.Forms.Label lblSilver;
        private System.Windows.Forms.PictureBox picSilver;
        private System.Windows.Forms.PictureBox picCopper;
        private System.Windows.Forms.Label lblCopper;
    }
}
