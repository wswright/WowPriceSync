namespace WoWPriceSyncUI
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.btnSync = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timerSync = new System.Windows.Forms.Timer(this.components);
            this.timerItemSync = new System.Windows.Forms.Timer(this.components);
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnItemSync = new System.Windows.Forms.Button();
            this.btnRules = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRealmStatus = new System.Windows.Forms.Label();
            this.timRealmStatus = new System.Windows.Forms.Timer(this.components);
            this.timRemoveDuplicateAuctions = new System.Windows.Forms.Timer(this.components);
            this.backgroundRemoveDuplicates = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripItemCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripAuctionCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.ucItemInspector1 = new WoWPriceSyncUI.ucItemInspector();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSync.Location = new System.Drawing.Point(699, 475);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 23);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "&Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 475);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar1.Size = new System.Drawing.Size(681, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // timerSync
            // 
            this.timerSync.Enabled = true;
            this.timerSync.Interval = 300000;
            this.timerSync.Tick += new System.EventHandler(this.timerSync_Tick);
            // 
            // timerItemSync
            // 
            this.timerItemSync.Interval = 1;
            this.timerItemSync.Tick += new System.EventHandler(this.timerItemSync_Tick);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 400);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(843, 69);
            this.txtLog.TabIndex = 5;
            // 
            // btnItemSync
            // 
            this.btnItemSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItemSync.Location = new System.Drawing.Point(780, 475);
            this.btnItemSync.Name = "btnItemSync";
            this.btnItemSync.Size = new System.Drawing.Size(75, 23);
            this.btnItemSync.TabIndex = 6;
            this.btnItemSync.Text = "&Item Sync";
            this.btnItemSync.UseVisualStyleBackColor = true;
            this.btnItemSync.Click += new System.EventHandler(this.btnItemSync_Click);
            // 
            // btnRules
            // 
            this.btnRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRules.Location = new System.Drawing.Point(780, 2);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(75, 23);
            this.btnRules.TabIndex = 8;
            this.btnRules.Text = "&Rules";
            this.btnRules.UseVisualStyleBackColor = true;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(680, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Fenris:";
            // 
            // lblRealmStatus
            // 
            this.lblRealmStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRealmStatus.AutoSize = true;
            this.lblRealmStatus.Location = new System.Drawing.Point(724, 9);
            this.lblRealmStatus.Name = "lblRealmStatus";
            this.lblRealmStatus.Size = new System.Drawing.Size(50, 13);
            this.lblRealmStatus.TabIndex = 10;
            this.lblRealmStatus.Text = "STATUS";
            // 
            // timRealmStatus
            // 
            this.timRealmStatus.Enabled = true;
            this.timRealmStatus.Interval = 2000;
            this.timRealmStatus.Tick += new System.EventHandler(this.timRealmStatus_Tick);
            // 
            // timRemoveDuplicateAuctions
            // 
            this.timRemoveDuplicateAuctions.Interval = 50;
            this.timRemoveDuplicateAuctions.Tick += new System.EventHandler(this.timRemoveDuplicateAuctions_Tick);
            // 
            // backgroundRemoveDuplicates
            // 
            this.backgroundRemoveDuplicates.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundRemoveDuplicates_DoWork);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripItemCount,
            this.toolStripStatusLabel3,
            this.toolStripAuctionCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 501);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(867, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.DoubleClick += new System.EventHandler(this.statusStrip1_DoubleClick);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel1.Text = "Items:";
            // 
            // toolStripItemCount
            // 
            this.toolStripItemCount.AutoSize = false;
            this.toolStripItemCount.Name = "toolStripItemCount";
            this.toolStripItemCount.Size = new System.Drawing.Size(75, 17);
            this.toolStripItemCount.Text = "-";
            this.toolStripItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabel3.Text = "Auctions:";
            // 
            // toolStripAuctionCount
            // 
            this.toolStripAuctionCount.AutoSize = false;
            this.toolStripAuctionCount.Name = "toolStripAuctionCount";
            this.toolStripAuctionCount.Size = new System.Drawing.Size(75, 17);
            this.toolStripAuctionCount.Text = "-";
            this.toolStripAuctionCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucItemInspector1
            // 
            this.ucItemInspector1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucItemInspector1.Location = new System.Drawing.Point(12, 31);
            this.ucItemInspector1.Name = "ucItemInspector1";
            this.ucItemInspector1.Size = new System.Drawing.Size(843, 363);
            this.ucItemInspector1.TabIndex = 7;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 523);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblRealmStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRules);
            this.Controls.Add(this.ucItemInspector1);
            this.Controls.Add(this.btnItemSync);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSync);
            this.MinimumSize = new System.Drawing.Size(650, 39);
            this.Name = "frmMain";
            this.Text = "WoW Price Sync UI";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timerSync;
        private System.Windows.Forms.Timer timerItemSync;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnItemSync;
        private ucItemInspector ucItemInspector1;
        private System.Windows.Forms.Button btnRules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRealmStatus;
        private System.Windows.Forms.Timer timRealmStatus;
        private System.Windows.Forms.Timer timRemoveDuplicateAuctions;
        private System.ComponentModel.BackgroundWorker backgroundRemoveDuplicates;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripItemCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripAuctionCount;
    }
}

