namespace iLibrarySystem.Forms
{
    partial class frmResetData
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
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.optRequest = new System.Windows.Forms.RadioButton();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rdAudit = new System.Windows.Forms.RadioButton();
            this.pnlBody.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlBody.Controls.Add(this.btnDelete);
            this.pnlBody.Controls.Add(this.pnlInfo);
            this.pnlBody.Controls.Add(this.panel3);
            this.pnlBody.Location = new System.Drawing.Point(3, 3);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(374, 284);
            this.pnlBody.TabIndex = 36;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.Location = new System.Drawing.Point(275, 256);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 24);
            this.btnDelete.TabIndex = 36;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.rdAudit);
            this.pnlInfo.Controls.Add(this.optRequest);
            this.pnlInfo.Controls.Add(this.dtTo);
            this.pnlInfo.Controls.Add(this.label4);
            this.pnlInfo.Controls.Add(this.dtFrom);
            this.pnlInfo.Controls.Add(this.label1);
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Controls.Add(this.shapeContainer1);
            this.pnlInfo.Location = new System.Drawing.Point(2, 25);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(373, 228);
            this.pnlInfo.TabIndex = 34;
            this.pnlInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInfo_Paint);
            // 
            // optRequest
            // 
            this.optRequest.Checked = true;
            this.optRequest.Location = new System.Drawing.Point(54, 128);
            this.optRequest.Name = "optRequest";
            this.optRequest.Size = new System.Drawing.Size(309, 44);
            this.optRequest.TabIndex = 138;
            this.optRequest.Text = "DELETE ALL UNSETTLED REQUEST TRANSACTIONS.";
            this.optRequest.UseVisualStyleBackColor = true;
            // 
            // dtTo
            // 
            this.dtTo.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtTo.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.dtTo.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtTo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(54, 98);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(309, 24);
            this.dtTo.TabIndex = 137;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 136;
            this.label4.Text = "TO";
            // 
            // dtFrom
            // 
            this.dtFrom.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtFrom.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.dtFrom.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtFrom.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(54, 68);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(309, 24);
            this.dtFrom.TabIndex = 135;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 134;
            this.label1.Text = "FROM";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 30);
            this.label2.TabIndex = 131;
            this.label2.Text = "THIS FUNCTION ONLY USE WHEN NECESSARY. WILL ONLY DELETE THOSE TEMPORARY RECORDS T" +
    "HAT IS NOT NEEDED.";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(373, 228);
            this.shapeContainer1.TabIndex = 133;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.rectangleShape1.FillColor = System.Drawing.SystemColors.ControlDark;
            this.rectangleShape1.Location = new System.Drawing.Point(-3, 51);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(380, 6);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.panel3.Controls.Add(this.lblClose);
            this.panel3.Controls.Add(this.lblTitle);
            this.panel3.Location = new System.Drawing.Point(2, -2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(374, 24);
            this.panel3.TabIndex = 13;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(308, 7);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(59, 13);
            this.lblClose.TabIndex = 12;
            this.lblClose.Text = "[CLOSE]";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(5, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(158, 13);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "DELETE TEMPORARY DATA";
            // 
            // rdAudit
            // 
            this.rdAudit.Enabled = false;
            this.rdAudit.Location = new System.Drawing.Point(54, 169);
            this.rdAudit.Name = "rdAudit";
            this.rdAudit.Size = new System.Drawing.Size(309, 44);
            this.rdAudit.TabIndex = 139;
            this.rdAudit.Text = "DELETE USER AUDIT TRAIL.";
            this.rdAudit.UseVisualStyleBackColor = true;
            // 
            // frmResetData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(216)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(380, 291);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmResetData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlBody.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label label2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.RadioButton optRequest;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.RadioButton rdAudit;
    }
}