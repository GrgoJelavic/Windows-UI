namespace WindowsUI
{
    partial class AboutControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.descLabel = new System.Windows.Forms.Label();
            this.copyrighLtabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.assemblyLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.descLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.copyrighLtabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.versionLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.assemblyLabel, 0, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Enabled = false;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1540, 180);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.descLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descLabel.Enabled = false;
            this.descLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descLabel.ForeColor = System.Drawing.Color.White;
            this.descLabel.Location = new System.Drawing.Point(0, 135);
            this.descLabel.Margin = new System.Windows.Forms.Padding(0);
            this.descLabel.Name = "descLabel";
            this.descLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.descLabel.Size = new System.Drawing.Size(1540, 45);
            this.descLabel.TabIndex = 3;
            this.descLabel.Text = "description";
            this.descLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.descLabel.Click += new System.EventHandler(this.descLabel_Click);
            // 
            // copyrighLtabel
            // 
            this.copyrighLtabel.AutoSize = true;
            this.copyrighLtabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.copyrighLtabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyrighLtabel.Enabled = false;
            this.copyrighLtabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyrighLtabel.ForeColor = System.Drawing.Color.White;
            this.copyrighLtabel.Location = new System.Drawing.Point(0, 90);
            this.copyrighLtabel.Margin = new System.Windows.Forms.Padding(0);
            this.copyrighLtabel.Name = "copyrighLtabel";
            this.copyrighLtabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.copyrighLtabel.Size = new System.Drawing.Size(1540, 45);
            this.copyrighLtabel.TabIndex = 2;
            this.copyrighLtabel.Text = "copyright";
            this.copyrighLtabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.copyrighLtabel.Click += new System.EventHandler(this.copyrighLtabel_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.versionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionLabel.Enabled = false;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.Color.White;
            this.versionLabel.Location = new System.Drawing.Point(0, 45);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.versionLabel.Size = new System.Drawing.Size(1540, 45);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "version";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click);
            // 
            // assemblyLabel
            // 
            this.assemblyLabel.AutoSize = true;
            this.assemblyLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.assemblyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assemblyLabel.Enabled = false;
            this.assemblyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assemblyLabel.ForeColor = System.Drawing.Color.White;
            this.assemblyLabel.Location = new System.Drawing.Point(0, 0);
            this.assemblyLabel.Margin = new System.Windows.Forms.Padding(0);
            this.assemblyLabel.Name = "assemblyLabel";
            this.assemblyLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.assemblyLabel.Size = new System.Drawing.Size(1540, 45);
            this.assemblyLabel.TabIndex = 0;
            this.assemblyLabel.Text = "assembly";
            this.assemblyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.assemblyLabel.Click += new System.EventHandler(this.assemblyLabel_Click);
            // 
            // AboutControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AboutControl";
            this.Size = new System.Drawing.Size(1540, 180);
            this.Load += new System.EventHandler(this.AboutControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Label copyrighLtabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label assemblyLabel;
    }
}
