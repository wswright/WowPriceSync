namespace WoWPriceSyncUI
{
    partial class ucFarmers
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
            this.zedGraphControlFarmers = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zedGraphControlFarmers
            // 
            this.zedGraphControlFarmers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlFarmers.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControlFarmers.Name = "zedGraphControlFarmers";
            this.zedGraphControlFarmers.ScrollGrace = 0D;
            this.zedGraphControlFarmers.ScrollMaxX = 0D;
            this.zedGraphControlFarmers.ScrollMaxY = 0D;
            this.zedGraphControlFarmers.ScrollMaxY2 = 0D;
            this.zedGraphControlFarmers.ScrollMinX = 0D;
            this.zedGraphControlFarmers.ScrollMinY = 0D;
            this.zedGraphControlFarmers.ScrollMinY2 = 0D;
            this.zedGraphControlFarmers.Size = new System.Drawing.Size(645, 435);
            this.zedGraphControlFarmers.TabIndex = 0;
            // 
            // ucFarmers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zedGraphControlFarmers);
            this.Name = "ucFarmers";
            this.Size = new System.Drawing.Size(645, 435);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControlFarmers;
    }
}
