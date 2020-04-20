namespace iLibrarySystem.Forms
{
    partial class frmBorrowBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBorrowBook));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pnlOther = new System.Windows.Forms.Panel();
            this.pnlBooks = new System.Windows.Forms.Panel();
            this.iGridControl = new iControlGrid.iGridControl();
            this.dgBooks = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFind = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtBirthDate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.txtMname = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.btnBrowseBorrower = new System.Windows.Forms.Button();
            this.txtBorrowerID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Column12 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBody.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlOther.SuspendLayout();
            this.pnlBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBooks)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlMain);
            this.pnlBody.Controls.Add(this.pnlBottom);
            this.pnlBody.Location = new System.Drawing.Point(2, 2);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(852, 418);
            this.pnlBody.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.txtMessage);
            this.pnlMain.Controls.Add(this.btnBrowse);
            this.pnlMain.Controls.Add(this.pnlOther);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.txtAddress);
            this.pnlMain.Controls.Add(this.txtContactNo);
            this.pnlMain.Controls.Add(this.txtAge);
            this.pnlMain.Controls.Add(this.txtBirthDate);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtLname);
            this.pnlMain.Controls.Add(this.txtMname);
            this.pnlMain.Controls.Add(this.txtFname);
            this.pnlMain.Controls.Add(this.btnBrowseBorrower);
            this.pnlMain.Controls.Add(this.txtBorrowerID);
            this.pnlMain.Controls.Add(this.label11);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.shapeContainer1);
            this.pnlMain.Controls.Add(this.textBox1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(852, 382);
            this.pnlMain.TabIndex = 28;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMessage.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(60, 193);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(676, 31);
            this.txtMessage.TabIndex = 9;
            this.txtMessage.Text = "PLEASE CLICK \'BROWSE\' BUTTON TO FIND BOOKS AND DOUBLE CLICK \'COPIES TO BORROW\' FI" +
    "ELD TO MODIFY THE VALUE. THANK YOU.";
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrowse.Location = new System.Drawing.Point(738, 193);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(102, 26);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "BROWSE";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pnlOther
            // 
            this.pnlOther.BackColor = System.Drawing.Color.Transparent;
            this.pnlOther.Controls.Add(this.pnlBooks);
            this.pnlOther.Location = new System.Drawing.Point(7, 222);
            this.pnlOther.Name = "pnlOther";
            this.pnlOther.Size = new System.Drawing.Size(836, 149);
            this.pnlOther.TabIndex = 78;
            // 
            // pnlBooks
            // 
            this.pnlBooks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBooks.Controls.Add(this.iGridControl);
            this.pnlBooks.Controls.Add(this.dgBooks);
            this.pnlBooks.Location = new System.Drawing.Point(4, 3);
            this.pnlBooks.Name = "pnlBooks";
            this.pnlBooks.Size = new System.Drawing.Size(829, 143);
            this.pnlBooks.TabIndex = 79;
            // 
            // iGridControl
            // 
            this.iGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iGridControl.BackColor = System.Drawing.Color.White;
            this.iGridControl.BookCommonData = ((Model.Transaction)(resources.GetObject("iGridControl.BookCommonData")));
            this.iGridControl.BookListData = ((System.Collections.Generic.List<Model.Transaction>)(resources.GetObject("iGridControl.BookListData")));
            this.iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.NONE;
            this.iGridControl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iGridControl.Location = new System.Drawing.Point(426, -1);
            this.iGridControl.Name = "iGridControl";
            this.iGridControl.SetCheckBoxColumnVisible = false;
            this.iGridControl.SetDeleteColumnVisible = false;
            this.iGridControl.SetFooterVisible = false;
            this.iGridControl.SetHeaderVisible = false;
            this.iGridControl.SetRemaksColumnVisible = false;
            this.iGridControl.SetStatusColumnVisible = false;
            this.iGridControl.Size = new System.Drawing.Size(402, 143);
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
            this.Column5,
            this.Column6,
            this.Column10,
            this.Column7,
            this.Column9,
            this.Column13,
            this.colFind,
            this.colDel});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBooks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBooks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgBooks.EnableHeadersVisualStyles = false;
            this.dgBooks.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgBooks.Location = new System.Drawing.Point(0, 0);
            this.dgBooks.Name = "dgBooks";
            this.dgBooks.ReadOnly = true;
            this.dgBooks.RowHeadersVisible = false;
            this.dgBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBooks.Size = new System.Drawing.Size(827, 141);
            this.dgBooks.TabIndex = 12;
            this.dgBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBooks_CellClick);
            this.dgBooks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBooks_CellDoubleClick);
            this.dgBooks.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBooks_CellEndEdit);
            this.dgBooks.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgBooks_EditingControlShowing);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "ID";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "TITLE";
            this.Column1.MinimumWidth = 250;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "SUBJECT";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Visible = false;
            this.Column2.Width = 65;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "CATEGORY";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Visible = false;
            this.Column3.Width = 76;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "AUTHOR";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 61;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "PUBLISH DATE";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "LOCATION";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "BOOK_PRICE";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "RENT_PRICE";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.NullValue = "\"\"";
            this.Column9.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column9.HeaderText = "QUANTITY";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 72;
            // 
            // Column13
            // 
            this.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column13.HeaderText = "NO OF DAYS";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column13.Width = 85;
            // 
            // colFind
            // 
            this.colFind.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFind.Description = "Show ISBN";
            this.colFind.HeaderText = "";
            this.colFind.Image = global::iLibrarySystem.Resource._add;
            this.colFind.Name = "colFind";
            this.colFind.ReadOnly = true;
            this.colFind.ToolTipText = "Show IBSN";
            this.colFind.Width = 5;
            // 
            // colDel
            // 
            this.colDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDel.HeaderText = "";
            this.colDel.Image = global::iLibrarySystem.Resource._delete;
            this.colDel.Name = "colDel";
            this.colDel.ReadOnly = true;
            this.colDel.Width = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(452, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "ADDRESS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(452, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 72;
            this.label5.Text = "CONTACT NO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(452, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 71;
            this.label7.Text = "AGE";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(549, 123);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(288, 44);
            this.txtAddress.TabIndex = 8;
            // 
            // txtContactNo
            // 
            this.txtContactNo.BackColor = System.Drawing.Color.White;
            this.txtContactNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNo.Location = new System.Drawing.Point(550, 94);
            this.txtContactNo.Multiline = true;
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(288, 24);
            this.txtContactNo.TabIndex = 7;
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.Color.White;
            this.txtAge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(549, 65);
            this.txtAge.Multiline = true;
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(289, 24);
            this.txtAge.TabIndex = 6;
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.BackColor = System.Drawing.Color.White;
            this.txtBirthDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBirthDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBirthDate.Location = new System.Drawing.Point(550, 37);
            this.txtBirthDate.Multiline = true;
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.Size = new System.Drawing.Size(288, 24);
            this.txtBirthDate.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(452, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 67;
            this.label9.Text = "BIRTH DATE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "LAST NAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "MIDDLE NAME";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "FIRST NAME";
            // 
            // txtLname
            // 
            this.txtLname.BackColor = System.Drawing.Color.White;
            this.txtLname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLname.Location = new System.Drawing.Point(106, 129);
            this.txtLname.Multiline = true;
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(286, 24);
            this.txtLname.TabIndex = 4;
            // 
            // txtMname
            // 
            this.txtMname.BackColor = System.Drawing.Color.White;
            this.txtMname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMname.Location = new System.Drawing.Point(107, 100);
            this.txtMname.Multiline = true;
            this.txtMname.Name = "txtMname";
            this.txtMname.Size = new System.Drawing.Size(286, 24);
            this.txtMname.TabIndex = 3;
            // 
            // txtFname
            // 
            this.txtFname.BackColor = System.Drawing.Color.White;
            this.txtFname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFname.Location = new System.Drawing.Point(106, 71);
            this.txtFname.Multiline = true;
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(287, 24);
            this.txtFname.TabIndex = 2;
            // 
            // btnBrowseBorrower
            // 
            this.btnBrowseBorrower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnBrowseBorrower.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseBorrower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseBorrower.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrowseBorrower.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseBorrower.Image")));
            this.btnBrowseBorrower.Location = new System.Drawing.Point(364, 41);
            this.btnBrowseBorrower.Name = "btnBrowseBorrower";
            this.btnBrowseBorrower.Size = new System.Drawing.Size(31, 25);
            this.btnBrowseBorrower.TabIndex = 1;
            this.btnBrowseBorrower.UseVisualStyleBackColor = false;
            this.btnBrowseBorrower.Click += new System.EventHandler(this.btnBrowseBorrower_Click);
            // 
            // txtBorrowerID
            // 
            this.txtBorrowerID.BackColor = System.Drawing.Color.White;
            this.txtBorrowerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBorrowerID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBorrowerID.Location = new System.Drawing.Point(107, 42);
            this.txtBorrowerID.Multiline = true;
            this.txtBorrowerID.Name = "txtBorrowerID";
            this.txtBorrowerID.Size = new System.Drawing.Size(255, 24);
            this.txtBorrowerID.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(8, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 53;
            this.label11.Text = "BORROWER ID";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.panel2.Controls.Add(this.lblClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(850, 27);
            this.panel2.TabIndex = 38;
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(790, 5);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(59, 13);
            this.lblClose.TabIndex = 15;
            this.lblClose.Text = "[CLOSE]";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(850, 380);
            this.shapeContainer1.TabIndex = 79;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(-10, 173);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(866, 6);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(9, 196);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 16);
            this.textBox1.TabIndex = 80;
            this.textBox1.Text = "NOTE :";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlBottom.Controls.Add(this.btnClear);
            this.pnlBottom.Controls.Add(this.btnContinue);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 382);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(852, 36);
            this.pnlBottom.TabIndex = 27;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClear.Location = new System.Drawing.Point(762, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 24);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnContinue.Location = new System.Drawing.Point(674, 5);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(84, 24);
            this.btnContinue.TabIndex = 13;
            this.btnContinue.Text = "CONTINUE";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(212, 19);
            this.panel4.TabIndex = 57;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(212, 140);
            this.panel3.TabIndex = 3;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "";
            this.Column12.Image = ((System.Drawing.Image)(resources.GetObject("Column12.Image")));
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "ISBN_NUMBER";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "BOOK_NO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "ID";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // frmBorrowBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(216)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(857, 422);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBorrowBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmBorrowBook_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlOther.ResumeLayout(false);
            this.pnlBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBooks)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        
        private System.Windows.Forms.Panel panel3;
        
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewImageColumn Column12;
        private System.Windows.Forms.Panel panel4;
        
        public System.Windows.Forms.Panel pnlMain;
        public System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnBrowse;
        public System.Windows.Forms.Panel pnlOther;
        public System.Windows.Forms.Panel pnlBooks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtAddress;
        public System.Windows.Forms.TextBox txtContactNo;
        public System.Windows.Forms.TextBox txtAge;
        public System.Windows.Forms.TextBox txtBirthDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtLname;
        public System.Windows.Forms.TextBox txtMname;
        public System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Button btnBrowseBorrower;
        public System.Windows.Forms.TextBox txtBorrowerID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Button btnClear;
        private iControlGrid.iGridControl iGridControl;
        public System.Windows.Forms.DataGridView dgBooks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewImageColumn colFind;
        private System.Windows.Forms.DataGridViewImageColumn colDel;
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
      
        
        
    }
}