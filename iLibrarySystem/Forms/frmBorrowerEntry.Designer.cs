namespace iLibrarySystem.Forms
{
    partial class frmBorrowerEntry
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblUpload = new System.Windows.Forms.Label();
            this.pImage = new System.Windows.Forms.PictureBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBorrowerID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.dtDOB = new System.Windows.Forms.DateTimePicker();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlBody.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlMain);
            this.pnlBody.Controls.Add(this.pnlBottom);
            this.pnlBody.Location = new System.Drawing.Point(3, 2);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(868, 347);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.lblUpload);
            this.pnlMain.Controls.Add(this.pImage);
            this.pnlMain.Controls.Add(this.txtAge);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.txtBorrowerID);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.dtDOB);
            this.pnlMain.Controls.Add(this.txtAddress);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.txtContactNo);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.txtLname);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.txtMname);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.txtFname);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(868, 311);
            this.pnlMain.TabIndex = 26;
            // 
            // lblUpload
            // 
            this.lblUpload.AutoSize = true;
            this.lblUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUpload.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpload.ForeColor = System.Drawing.Color.Black;
            this.lblUpload.Location = new System.Drawing.Point(29, 127);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(94, 12);
            this.lblUpload.TabIndex = 0;
            this.lblUpload.Text = "UPLOAD PHOTO";
            this.lblUpload.Click += new System.EventHandler(this.lblUpload_Click);
            // 
            // pImage
            // 
            this.pImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pImage.Location = new System.Drawing.Point(17, 37);
            this.pImage.Name = "pImage";
            this.pImage.Size = new System.Drawing.Size(114, 89);
            this.pImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pImage.TabIndex = 42;
            this.pImage.TabStop = false;
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.Color.White;
            this.txtAge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.ForeColor = System.Drawing.Color.Black;
            this.txtAge.Location = new System.Drawing.Point(548, 132);
            this.txtAge.Multiline = true;
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(309, 24);
            this.txtAge.TabIndex = 6;
            this.txtAge.Text = "0";
            this.txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAge_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(449, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "AGE";
            // 
            // txtBorrowerID
            // 
            this.txtBorrowerID.BackColor = System.Drawing.Color.White;
            this.txtBorrowerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBorrowerID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBorrowerID.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtBorrowerID.Location = new System.Drawing.Point(133, 163);
            this.txtBorrowerID.Multiline = true;
            this.txtBorrowerID.Name = "txtBorrowerID";
            this.txtBorrowerID.Size = new System.Drawing.Size(291, 24);
            this.txtBorrowerID.TabIndex = 1;
            this.txtBorrowerID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBorrowerID_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(15, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "BORROWER ID";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.panel1.Controls.Add(this.lblClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 26);
            this.panel1.TabIndex = 38;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(804, 5);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(59, 13);
            this.lblClose.TabIndex = 7;
            this.lblClose.Text = "[CLOSE]";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // dtDOB
            // 
            this.dtDOB.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDOB.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtDOB.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.dtDOB.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtDOB.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDOB.Location = new System.Drawing.Point(548, 101);
            this.dtDOB.Name = "dtDOB";
            this.dtDOB.Size = new System.Drawing.Size(309, 24);
            this.dtDOB.TabIndex = 5;
            this.dtDOB.ValueChanged += new System.EventHandler(this.dtDOB_ValueChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(548, 191);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(310, 94);
            this.txtAddress.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(450, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "ADDRESS";
            // 
            // txtContactNo
            // 
            this.txtContactNo.BackColor = System.Drawing.Color.White;
            this.txtContactNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNo.Location = new System.Drawing.Point(548, 161);
            this.txtContactNo.Multiline = true;
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(310, 24);
            this.txtContactNo.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(448, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "CONTACT NO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(449, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "DOB";
            // 
            // txtLname
            // 
            this.txtLname.BackColor = System.Drawing.Color.White;
            this.txtLname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLname.Location = new System.Drawing.Point(133, 251);
            this.txtLname.Multiline = true;
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(291, 24);
            this.txtLname.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "LAST NAME";
            // 
            // txtMname
            // 
            this.txtMname.BackColor = System.Drawing.Color.White;
            this.txtMname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMname.Location = new System.Drawing.Point(134, 222);
            this.txtMname.Multiline = true;
            this.txtMname.Name = "txtMname";
            this.txtMname.Size = new System.Drawing.Size(291, 24);
            this.txtMname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "MIDDLE NAME";
            // 
            // txtFname
            // 
            this.txtFname.BackColor = System.Drawing.Color.White;
            this.txtFname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFname.Location = new System.Drawing.Point(134, 193);
            this.txtFname.Multiline = true;
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(290, 24);
            this.txtFname.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "FIRST NAME";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlBottom.Controls.Add(this.btnClear);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 311);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(868, 36);
            this.pnlBottom.TabIndex = 25;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClear.Location = new System.Drawing.Point(778, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 24);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(691, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 24);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmBorrowerEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(216)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(873, 351);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBorrowerEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmStudentEntry_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBorrowerID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtDOB;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.PictureBox pImage;


    }
}