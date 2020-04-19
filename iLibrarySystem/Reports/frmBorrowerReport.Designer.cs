namespace iLibrarySystem.Reports
{
    partial class frmBorrowerReport
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.ReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblClose = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 600);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(899, 33);
            this.pnlBottom.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "STATUS :";
            // 
            // cboStatus
            // 
            this.cboStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "BORROWER RECORD LIST",
            "UNRETURNED BOOKS",
            "REQUESTED BOOKS",
            "TOP BORROWERS LIST"});
            this.cboStatus.Location = new System.Drawing.Point(83, 39);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(292, 24);
            this.cboStatus.TabIndex = 47;
            this.cboStatus.Text = "BORROWER RECORD LIST";
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            this.cboStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboStatus_KeyPress);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGenerate.Location = new System.Drawing.Point(381, 9);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(88, 54);
            this.btnGenerate.TabIndex = 46;
            this.btnGenerate.Text = "GENERATE";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // ReportViewer
            // 
            this.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer.LocalReport.ReportEmbeddedResource = "iLibrarySystem.Reports.rptStudentList.rdlc";
            this.ReportViewer.Location = new System.Drawing.Point(0, 71);
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.ShowContextMenu = false;
            this.ReportViewer.ShowCredentialPrompts = false;
            this.ReportViewer.ShowDocumentMapButton = false;
            this.ReportViewer.ShowFindControls = false;
            this.ReportViewer.ShowProgress = false;
            this.ReportViewer.ShowPromptAreaButton = false;
            this.ReportViewer.ShowStopButton = false;
            this.ReportViewer.Size = new System.Drawing.Size(899, 562);
            this.ReportViewer.TabIndex = 35;
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
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.cboStatus);
            this.pnlTop.Controls.Add(this.btnGenerate);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.dtDateTo);
            this.pnlTop.Controls.Add(this.dtDateFrom);
            this.pnlTop.Controls.Add(this.lblClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(899, 71);
            this.pnlTop.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(213, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "TO :";
            // 
            // dtDateTo
            // 
            this.dtDateTo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(252, 9);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(123, 23);
            this.dtDateTo.TabIndex = 43;
            this.dtDateTo.Value = new System.DateTime(2020, 1, 15, 0, 0, 0, 0);
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(83, 9);
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
            this.lblClose.Location = new System.Drawing.Point(829, 29);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(59, 13);
            this.lblClose.TabIndex = 30;
            this.lblClose.Text = "[CLOSE]";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // frmBorrowerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 633);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.ReportViewer);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBorrowerReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBorrowerReport_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnGenerate;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtDateTo;
        public System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.Label lblClose;
    }
}