namespace WoWPriceSyncUI
{
    partial class frmRulesManager
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucRulesCollectionEditor1 = new WoWPriceSyncUI.ucRulesCollectionEditor();
            this.SuspendLayout();
            // 
            // ucRulesCollectionEditor1
            // 
            this.ucRulesCollectionEditor1.Location = new System.Drawing.Point(462, 12);
            this.ucRulesCollectionEditor1.MinimumSize = new System.Drawing.Size(522, 66);
            this.ucRulesCollectionEditor1.Name = "ucRulesCollectionEditor1";
            this.ucRulesCollectionEditor1.Size = new System.Drawing.Size(522, 511);
            this.ucRulesCollectionEditor1.TabIndex = 0;
            // 
            // frmRulesManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 535);
            this.Controls.Add(this.ucRulesCollectionEditor1);
            this.Name = "frmRulesManager";
            this.Text = "Rules Manager";
            this.Load += new System.EventHandler(this.frmRulesManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucRulesCollectionEditor ucRulesCollectionEditor1;


    }
}