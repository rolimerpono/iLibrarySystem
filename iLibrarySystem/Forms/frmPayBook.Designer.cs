namespace iLibrarySystem.Forms
{
    partial class frmPayBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayBook));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMClose = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBorrowerID = new System.Windows.Forms.TextBox();
            this.txtFulllname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.iPaymentWindow = new iPaymentWindow.iPaymentWindow();
            this.pnlBooks = new System.Windows.Forms.Panel();
            this.iGridControl = new iControlGrid.iGridControl();
            this.dgBooks = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdDamage = new System.Windows.Forms.RadioButton();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.panel2.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(6, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 53;
            this.label11.Text = "BORROWER ID";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.panel2.Controls.Add(this.lblMClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(939, 27);
            this.panel2.TabIndex = 38;
            // 
            // lblMClose
            // 
            this.lblMClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMClose.AutoSize = true;
            this.lblMClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMClose.ForeColor = System.Drawing.Color.White;
            this.lblMClose.Location = new System.Drawing.Point(888, 6);
            this.lblMClose.Name = "lblMClose";
            this.lblMClose.Size = new System.Drawing.Size(47, 13);
            this.lblMClose.TabIndex = 6;
            this.lblMClose.Text = "CLOSE";
            this.lblMClose.Click += new System.EventHandler(this.lblMClose_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 380);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(941, 36);
            this.pnlBottom.TabIndex = 27;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(793, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(143, 24);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "SETTLE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBorrowerID
            // 
            this.txtBorrowerID.BackColor = System.Drawing.Color.White;
            this.txtBorrowerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBorrowerID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBorrowerID.Location = new System.Drawing.Point(105, 44);
            this.txtBorrowerID.Multiline = true;
            this.txtBorrowerID.Name = "txtBorrowerID";
            this.txtBorrowerID.Size = new System.Drawing.Size(218, 24);
            this.txtBorrowerID.TabIndex = 0;
            this.txtBorrowerID.TextChanged += new System.EventHandler(this.txtBorrowerID_TextChanged);
            this.txtBorrowerID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBorrowerID_KeyPress);
            // 
            // txtFulllname
            // 
            this.txtFulllname.BackColor = System.Drawing.Color.White;
            this.txtFulllname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFulllname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFulllname.Location = new System.Drawing.Point(105, 72);
            this.txtFulllname.Multiline = true;
            this.txtFulllname.Name = "txtFulllname";
            this.txtFulllname.Size = new System.Drawing.Size(218, 24);
            this.txtFulllname.TabIndex = 2;
            this.txtFulllname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFulllname_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "FULLNAME";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlBody.Controls.Add(this.pnlMain);
            this.pnlBody.Controls.Add(this.pnlBottom);
            this.pnlBody.Location = new System.Drawing.Point(3, 3);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(941, 416);
            this.pnlBody.TabIndex = 4;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.iPaymentWindow);
            this.pnlMain.Controls.Add(this.pnlBooks);
            this.pnlMain.Controls.Add(this.radioButton1);
            this.pnlMain.Controls.Add(this.rdDamage);
            this.pnlMain.Controls.Add(this.btnBrowse);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtFulllname);
            this.pnlMain.Controls.Add(this.txtBorrowerID);
            this.pnlMain.Controls.Add(this.label11);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.shapeContainer1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(941, 380);
            this.pnlMain.TabIndex = 28;
            // 
            // iPaymentWindow
            // 
            this.iPaymentWindow.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iPaymentWindow.BookPrice = 0D;
            this.iPaymentWindow.Change = 0D;
            this.iPaymentWindow.DateBorrowed = new System.DateTime(((long)(0)));
            this.iPaymentWindow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iPaymentWindow.LDInterest = 0D;
            this.iPaymentWindow.Location = new System.Drawing.Point(648, 106);
            this.iPaymentWindow.Name = "iPaymentWindow";
            this.iPaymentWindow.PenaltyInterest = 0D;
            this.iPaymentWindow.ReceiveAmount = 0D;
            this.iPaymentWindow.RentPrice = 0D;
            this.iPaymentWindow.Size = new System.Drawing.Size(292, 273);
            this.iPaymentWindow.TabIndex = 4;
            this.iPaymentWindow.TotalDue = 0D;
            this.iPaymentWindow.TotalDueInterest = 0D;
            this.iPaymentWindow.TotalInterest = 0D;
            this.iPaymentWindow.TotalLDInterest = 0D;
            this.iPaymentWindow.TransactionList = ((System.Collections.Generic.List<Model.Transaction>)(resources.GetObject("iPaymentWindow.TransactionList")));
            // 
            // pnlBooks
            // 
            this.pnlBooks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBooks.Controls.Add(this.iGridControl);
            this.pnlBooks.Controls.Add(this.dgBooks);
            this.pnlBooks.Location = new System.Drawing.Point(-1, 140);
            this.pnlBooks.Name = "pnlBooks";
            this.pnlBooks.Size = new System.Drawing.Size(649, 239);
            this.pnlBooks.TabIndex = 85;
            // 
            // iGridControl
            // 
            this.iGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iGridControl.BackColor = System.Drawing.Color.White;
            this.iGridControl.BookCommonData = ((Model.Transaction)(resources.GetObject("iGridControl.BookCommonData")));
            this.iGridControl.BookListData = ((System.Collections.Generic.List<Model.Transaction>)(resources.GetObject("iGridControl.BookListData")));
            this.iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.NONE;
            this.iGridControl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iGridControl.Location = new System.Drawing.Point(337, 20);
            this.iGridControl.Name = "iGridControl";
            this.iGridControl.SetCheckBoxColumnVisible = false;
            this.iGridControl.SetDeleteColumnVisible = false;
            this.iGridControl.SetFooterVisible = false;
            this.iGridControl.SetHeaderVisible = false;
            this.iGridControl.SetRemaksColumnVisible = false;
            this.iGridControl.SetStatusColumnVisible = false;
            this.iGridControl.Size = new System.Drawing.Size(311, 143);
            this.iGridControl.TabIndex = 13;
            this.iGridControl.Visible = false;
            // 
            // dgBooks
            // 
            this.dgBooks.AllowUserToAddRows = false;
            this.dgBooks.AllowUserToDeleteRows = false;
            this.dgBooks.AllowUserToResizeColumns = false;
            this.dgBooks.AllowUserToResizeRows = false;
            this.dgBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgBooks.ColumnHeadersHeight = 20;
            this.dgBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column9,
            this.Column11,
            this.Column10,
            this.Column5});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBooks.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBooks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgBooks.EnableHeadersVisualStyles = false;
            this.dgBooks.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgBooks.Location = new System.Drawing.Point(0, 0);
            this.dgBooks.Name = "dgBooks";
            this.dgBooks.ReadOnly = true;
            this.dgBooks.RowHeadersVisible = false;
            this.dgBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBooks.Size = new System.Drawing.Size(647, 237);
            this.dgBooks.TabIndex = 3;
            this.dgBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBooks_CellClick);
            this.dgBooks.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBooks_CellEnter);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "ID";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "TITLE";
            this.Column1.MinimumWidth = 200;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "SUBJECT";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            this.Column2.Width = 84;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "DATE BORROWED";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 135;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "BOOK PRICE";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 106;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "RENT PRICE";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 102;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "INTEREST RATE";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 122;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column9.HeaderText = "LD INTEREST";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 108;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column11.HeaderText = "TOTAL QTY";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 95;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column10.HeaderText = "TOTAL DAYS";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 104;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "";
            this.Column5.Image = global::iLibrarySystem.Resource._search;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 20;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(719, 81);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 17);
            this.radioButton1.TabIndex = 84;
            this.radioButton1.Text = "LOST";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdDamage
            // 
            this.rdDamage.AutoSize = true;
            this.rdDamage.Checked = true;
            this.rdDamage.Location = new System.Drawing.Point(640, 81);
            this.rdDamage.Name = "rdDamage";
            this.rdDamage.Size = new System.Drawing.Size(75, 17);
            this.rdDamage.TabIndex = 83;
            this.rdDamage.TabStop = true;
            this.rdDamage.Text = "DAMAGE";
            this.rdDamage.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
            this.btnBrowse.Location = new System.Drawing.Point(325, 43);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 25);
            this.btnBrowse.TabIndex = 82;
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "LIST OF BOOK(S)";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(939, 378);
            this.shapeContainer1.TabIndex = 79;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.DimGray;
            this.rectangleShape1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rectangleShape1.Location = new System.Drawing.Point(-10, 106);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(951, 6);
            // 
            // frmPayBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(216)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(947, 422);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmPayBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmPayBook_KeyPress);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMClose;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtBorrowerID;
        public System.Windows.Forms.TextBox txtFulllname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlBody;
        public System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdDamage;
        public System.Windows.Forms.Panel pnlBooks;
        public System.Windows.Forms.DataGridView dgBooks;
        private iControlGrid.iGridControl iGridControl;
        private iPaymentWindow.iPaymentWindow iPaymentWindow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewImageColumn Column5;
        
        
        
        
        
        
    }
}