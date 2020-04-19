namespace iLibrarySystem.Reports
{
    partial class frmRecordList
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblClose = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.ReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlTop.Controls.Add(this.btnGenerate);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.dtDateTo);
            this.pnlTop.Controls.Add(this.dtDateFrom);
            this.pnlTop.Controls.Add(this.lblClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(899, 41);
            this.pnlTop.TabIndex = 26;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGenerate.Location = new System.Drawing.Point(365, 9);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(152, 23);
            this.btnGenerate.TabIndex = 46;
            this.btnGenerate.Text = "GENERATE";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(197, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "TO :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "FROM :";
            // 
            // dtDateTo
            // 
            this.dtDateTo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(236, 9);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(123, 23);
            this.dtDateTo.TabIndex = 43;
            this.dtDateTo.Value = new System.DateTime(2020, 1, 15, 0, 0, 0, 0);
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(68, 9);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(123, 23);
            this.dtDateFrom.TabIndex = 42;
            this.dtDateFrom.Value = new System.DateTime(2020, 1, 15, 0, 0, 0, 0);
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(832, 12);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(59, 13);
            this.lblClose.TabIndex = 30;
            this.lblClose.Text = "[CLOSE]";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 592);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(899, 41);
            this.pnlBottom.TabIndex = 28;
            // 
            // ReportViewer
            // 
            this.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer.LocalReport.ReportEmbeddedResource = "iLibrarySystem.Reports.rptStudentList.rdlc";
            this.ReportViewer.Location = new System.Drawing.Point(0, 41);
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.ShowContextMenu = false;
            this.ReportViewer.ShowCredentialPrompts = false;
            this.ReportViewer.ShowDocumentMapButton = false;
            this.ReportViewer.ShowFindControls = false;
            this.ReportViewer.ShowProgress = false;
            this.ReportViewer.ShowPromptAreaButton = false;
            this.ReportViewer.ShowStopButton = false;
            this.ReportViewer.Size = new System.Drawing.Size(899, 551);
            this.ReportViewer.TabIndex = 29;
            // 
            // frmRecordList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(899, 633);
            this.Controls.Add(this.ReportViewer);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRecordList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtDateTo;
        public System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel pnlBottom;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer;
        
    }
}