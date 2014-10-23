namespace WoWPriceSyncUI
{
    partial class ucRulesEditor
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
            this.numValue = new System.Windows.Forms.NumericUpDown();
            this.cmbOperators = new System.Windows.Forms.ComboBox();
            this.cmbProperties = new System.Windows.Forms.ComboBox();
            this.btnRed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).BeginInit();
            this.SuspendLayout();
            // 
            // numValue
            // 
            this.numValue.DecimalPlaces = 3;
            this.numValue.Location = new System.Drawing.Point(343, 4);
            this.numValue.Name = "numValue";
            this.numValue.Size = new System.Drawing.Size(127, 20);
            this.numValue.TabIndex = 5;
            // 
            // cmbOperators
            // 
            this.cmbOperators.FormattingEnabled = true;
            this.cmbOperators.Location = new System.Drawing.Point(186, 3);
            this.cmbOperators.Name = "cmbOperators";
            this.cmbOperators.Size = new System.Drawing.Size(151, 21);
            this.cmbOperators.TabIndex = 4;
            // 
            // cmbProperties
            // 
            this.cmbProperties.FormattingEnabled = true;
            this.cmbProperties.Location = new System.Drawing.Point(3, 3);
            this.cmbProperties.Name = "cmbProperties";
            this.cmbProperties.Size = new System.Drawing.Size(177, 21);
            this.cmbProperties.TabIndex = 3;
            // 
            // btnRed
            // 
            this.btnRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRed.ForeColor = System.Drawing.Color.DarkRed;
            this.btnRed.Location = new System.Drawing.Point(476, 4);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(20, 20);
            this.btnRed.TabIndex = 6;
            this.btnRed.Text = "X";
            this.btnRed.UseVisualStyleBackColor = true;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // ucRulesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRed);
            this.Controls.Add(this.numValue);
            this.Controls.Add(this.cmbOperators);
            this.Controls.Add(this.cmbProperties);
            this.MinimumSize = new System.Drawing.Size(499, 28);
            this.Name = "ucRulesEditor";
            this.Size = new System.Drawing.Size(499, 28);
            this.Load += new System.EventHandler(this.ucRulesEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numValue;
        private System.Windows.Forms.ComboBox cmbOperators;
        private System.Windows.Forms.ComboBox cmbProperties;
        private System.Windows.Forms.Button btnRed;
    }
}
