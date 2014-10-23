namespace WoWPriceSyncUI
{
    partial class ucCharting
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.pnlChartContainer = new System.Windows.Forms.Panel();
            this.propChartProperties = new System.Windows.Forms.PropertyGrid();
            this.btnProvider = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.btnChangeProvider = new System.Windows.Forms.Button();
            this.pnlChartContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.IsShowPointValues = true;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(446, 400);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // pnlChartContainer
            // 
            this.pnlChartContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChartContainer.Controls.Add(this.zedGraphControl1);
            this.pnlChartContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlChartContainer.Name = "pnlChartContainer";
            this.pnlChartContainer.Size = new System.Drawing.Size(446, 400);
            this.pnlChartContainer.TabIndex = 2;
            // 
            // propChartProperties
            // 
            this.propChartProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propChartProperties.Location = new System.Drawing.Point(452, 0);
            this.propChartProperties.Name = "propChartProperties";
            this.propChartProperties.Size = new System.Drawing.Size(189, 340);
            this.propChartProperties.TabIndex = 6;
            this.propChartProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propChartProperties_PropertyValueChanged);
            // 
            // btnProvider
            // 
            this.btnProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProvider.Location = new System.Drawing.Point(547, 374);
            this.btnProvider.Name = "btnProvider";
            this.btnProvider.Size = new System.Drawing.Size(95, 26);
            this.btnProvider.TabIndex = 8;
            this.btnProvider.Text = "Edit Provider";
            this.btnProvider.UseVisualStyleBackColor = true;
            this.btnProvider.Click += new System.EventHandler(this.btnProvider_Click);
            // 
            // btnChart
            // 
            this.btnChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChart.Location = new System.Drawing.Point(451, 374);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(95, 26);
            this.btnChart.TabIndex = 9;
            this.btnChart.Text = "Edit Chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // btnChangeProvider
            // 
            this.btnChangeProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeProvider.Location = new System.Drawing.Point(451, 346);
            this.btnChangeProvider.Name = "btnChangeProvider";
            this.btnChangeProvider.Size = new System.Drawing.Size(190, 22);
            this.btnChangeProvider.TabIndex = 10;
            this.btnChangeProvider.Text = "Change Provider";
            this.btnChangeProvider.UseVisualStyleBackColor = true;
            this.btnChangeProvider.Click += new System.EventHandler(this.btnChangeProvider_Click);
            // 
            // ucCharting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnChangeProvider);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.btnProvider);
            this.Controls.Add(this.propChartProperties);
            this.Controls.Add(this.pnlChartContainer);
            this.Name = "ucCharting";
            this.Size = new System.Drawing.Size(641, 400);
            this.pnlChartContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Panel pnlChartContainer;
        private System.Windows.Forms.PropertyGrid propChartProperties;
        private System.Windows.Forms.Button btnProvider;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Button btnChangeProvider;
    }
}
