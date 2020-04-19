namespace iLibrarySystem.Forms
{
    partial class frmUserAccess
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlAccess = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBookEntry = new System.Windows.Forms.CheckBox();
            this.chkUserRole = new System.Windows.Forms.CheckBox();
            this.chkBorrowerEntry = new System.Windows.Forms.CheckBox();
            this.chkRBorrowerList = new System.Windows.Forms.CheckBox();
            this.chkRBookList = new System.Windows.Forms.CheckBox();
            this.chkImportExport = new System.Windows.Forms.CheckBox();
            this.chkUserAccess = new System.Windows.Forms.CheckBox();
            this.chkUserAccount = new System.Windows.Forms.CheckBox();
            this.chkBorrowerRequest = new System.Windows.Forms.CheckBox();
            this.chkReturnBook = new System.Windows.Forms.CheckBox();
            this.chkPayBook = new System.Windows.Forms.CheckBox();
            this.chkBorrowBook = new System.Windows.Forms.CheckBox();
            this.chkBorrowerDetails = new System.Windows.Forms.CheckBox();
            this.chkPolicy = new System.Windows.Forms.CheckBox();
            this.chkLocation = new System.Windows.Forms.CheckBox();
            this.chkCategory = new System.Windows.Forms.CheckBox();
            this.chkAuthor = new System.Windows.Forms.CheckBox();
            this.chkBookDetail = new System.Windows.Forms.CheckBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgDetails = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlAccess.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetails)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlHeader);
            this.pnlBody.Controls.Add(this.pnlMain);
            this.pnlBody.Controls.Add(this.pnlBottom);
            this.pnlBody.Location = new System.Drawing.Point(3, 3);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(746, 406);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlHeader.Controls.Add(this.lblClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(746, 27);
            this.pnlHeader.TabIndex = 43;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(683, 6);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(59, 13);
            this.lblClose.TabIndex = 20;
            this.lblClose.Text = "[CLOSE]";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.pnlAccess);
            this.pnlMain.Controls.Add(this.chkSelectAll);
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(746, 374);
            this.pnlMain.TabIndex = 45;
            // 
            // pnlAccess
            // 
            this.pnlAccess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAccess.Controls.Add(this.label1);
            this.pnlAccess.Controls.Add(this.chkBookEntry);
            this.pnlAccess.Controls.Add(this.chkUserRole);
            this.pnlAccess.Controls.Add(this.chkBorrowerEntry);
            this.pnlAccess.Controls.Add(this.chkRBorrowerList);
            this.pnlAccess.Controls.Add(this.chkRBookList);
            this.pnlAccess.Controls.Add(this.chkImportExport);
            this.pnlAccess.Controls.Add(this.chkUserAccess);
            this.pnlAccess.Controls.Add(this.chkUserAccount);
            this.pnlAccess.Controls.Add(this.chkBorrowerRequest);
            this.pnlAccess.Controls.Add(this.chkReturnBook);
            this.pnlAccess.Controls.Add(this.chkPayBook);
            this.pnlAccess.Controls.Add(this.chkBorrowBook);
            this.pnlAccess.Controls.Add(this.chkBorrowerDetails);
            this.pnlAccess.Controls.Add(this.chkPolicy);
            this.pnlAccess.Controls.Add(this.chkLocation);
            this.pnlAccess.Controls.Add(this.chkCategory);
            this.pnlAccess.Controls.Add(this.chkAuthor);
            this.pnlAccess.Controls.Add(this.chkBookDetail);
            this.pnlAccess.Location = new System.Drawing.Point(-1, 157);
            this.pnlAccess.Name = "pnlAccess";
            this.pnlAccess.Size = new System.Drawing.Size(746, 186);
            this.pnlAccess.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "MODULE ACCESS";
            // 
            // chkBookEntry
            // 
            this.chkBookEntry.AutoSize = true;
            this.chkBookEntry.Location = new System.Drawing.Point(9, 61);
            this.chkBookEntry.Name = "chkBookEntry";
            this.chkBookEntry.Size = new System.Drawing.Size(89, 17);
            this.chkBookEntry.TabIndex = 2;
            this.chkBookEntry.Text = "Book Entry";
            this.chkBookEntry.UseVisualStyleBackColor = true;
            // 
            // chkUserRole
            // 
            this.chkUserRole.AutoSize = true;
            this.chkUserRole.Location = new System.Drawing.Point(291, 84);
            this.chkUserRole.Name = "chkUserRole";
            this.chkUserRole.Size = new System.Drawing.Size(81, 17);
            this.chkUserRole.TabIndex = 15;
            this.chkUserRole.Text = "User Role";
            this.chkUserRole.UseVisualStyleBackColor = true;
            // 
            // chkBorrowerEntry
            // 
            this.chkBorrowerEntry.AutoSize = true;
            this.chkBorrowerEntry.Location = new System.Drawing.Point(146, 61);
            this.chkBorrowerEntry.Name = "chkBorrowerEntry";
            this.chkBorrowerEntry.Size = new System.Drawing.Size(113, 17);
            this.chkBorrowerEntry.TabIndex = 8;
            this.chkBorrowerEntry.Text = "Borrower Entry";
            this.chkBorrowerEntry.UseVisualStyleBackColor = true;
            // 
            // chkRBorrowerList
            // 
            this.chkRBorrowerList.AutoSize = true;
            this.chkRBorrowerList.Location = new System.Drawing.Point(523, 63);
            this.chkRBorrowerList.Name = "chkRBorrowerList";
            this.chkRBorrowerList.Size = new System.Drawing.Size(102, 17);
            this.chkRBorrowerList.TabIndex = 18;
            this.chkRBorrowerList.Text = "Borrower List";
            this.chkRBorrowerList.UseVisualStyleBackColor = true;
            // 
            // chkRBookList
            // 
            this.chkRBookList.AutoSize = true;
            this.chkRBookList.Location = new System.Drawing.Point(524, 40);
            this.chkRBookList.Name = "chkRBookList";
            this.chkRBookList.Size = new System.Drawing.Size(85, 17);
            this.chkRBookList.TabIndex = 17;
            this.chkRBookList.Text = "Boook List";
            this.chkRBookList.UseVisualStyleBackColor = true;
            // 
            // chkImportExport
            // 
            this.chkImportExport.AutoSize = true;
            this.chkImportExport.Location = new System.Drawing.Point(411, 40);
            this.chkImportExport.Name = "chkImportExport";
            this.chkImportExport.Size = new System.Drawing.Size(107, 17);
            this.chkImportExport.TabIndex = 16;
            this.chkImportExport.Text = "Import/Export";
            this.chkImportExport.UseVisualStyleBackColor = true;
            // 
            // chkUserAccess
            // 
            this.chkUserAccess.AutoSize = true;
            this.chkUserAccess.Location = new System.Drawing.Point(291, 63);
            this.chkUserAccess.Name = "chkUserAccess";
            this.chkUserAccess.Size = new System.Drawing.Size(95, 17);
            this.chkUserAccess.TabIndex = 14;
            this.chkUserAccess.Text = "User Access";
            this.chkUserAccess.UseVisualStyleBackColor = true;
            // 
            // chkUserAccount
            // 
            this.chkUserAccount.AutoSize = true;
            this.chkUserAccount.Location = new System.Drawing.Point(292, 40);
            this.chkUserAccount.Name = "chkUserAccount";
            this.chkUserAccount.Size = new System.Drawing.Size(101, 17);
            this.chkUserAccount.TabIndex = 13;
            this.chkUserAccount.Text = "User Account";
            this.chkUserAccount.UseVisualStyleBackColor = true;
            // 
            // chkBorrowerRequest
            // 
            this.chkBorrowerRequest.AutoSize = true;
            this.chkBorrowerRequest.Location = new System.Drawing.Point(146, 153);
            this.chkBorrowerRequest.Name = "chkBorrowerRequest";
            this.chkBorrowerRequest.Size = new System.Drawing.Size(129, 17);
            this.chkBorrowerRequest.TabIndex = 12;
            this.chkBorrowerRequest.Text = "Borrower Request";
            this.chkBorrowerRequest.UseVisualStyleBackColor = true;
            // 
            // chkReturnBook
            // 
            this.chkReturnBook.AutoSize = true;
            this.chkReturnBook.Location = new System.Drawing.Point(146, 130);
            this.chkReturnBook.Name = "chkReturnBook";
            this.chkReturnBook.Size = new System.Drawing.Size(97, 17);
            this.chkReturnBook.TabIndex = 11;
            this.chkReturnBook.Text = "Return Book";
            this.chkReturnBook.UseVisualStyleBackColor = true;
            // 
            // chkPayBook
            // 
            this.chkPayBook.AutoSize = true;
            this.chkPayBook.Location = new System.Drawing.Point(146, 107);
            this.chkPayBook.Name = "chkPayBook";
            this.chkPayBook.Size = new System.Drawing.Size(80, 17);
            this.chkPayBook.TabIndex = 10;
            this.chkPayBook.Text = "Pay Book";
            this.chkPayBook.UseVisualStyleBackColor = true;
            // 
            // chkBorrowBook
            // 
            this.chkBorrowBook.AutoSize = true;
            this.chkBorrowBook.Location = new System.Drawing.Point(146, 84);
            this.chkBorrowBook.Name = "chkBorrowBook";
            this.chkBorrowBook.Size = new System.Drawing.Size(100, 17);
            this.chkBorrowBook.TabIndex = 9;
            this.chkBorrowBook.Text = "Borrow Book";
            this.chkBorrowBook.UseVisualStyleBackColor = true;
            // 
            // chkBorrowerDetails
            // 
            this.chkBorrowerDetails.AutoSize = true;
            this.chkBorrowerDetails.Location = new System.Drawing.Point(146, 40);
            this.chkBorrowerDetails.Name = "chkBorrowerDetails";
            this.chkBorrowerDetails.Size = new System.Drawing.Size(122, 17);
            this.chkBorrowerDetails.TabIndex = 7;
            this.chkBorrowerDetails.Text = "Borrower Details";
            this.chkBorrowerDetails.UseVisualStyleBackColor = true;
            // 
            // chkPolicy
            // 
            this.chkPolicy.AutoSize = true;
            this.chkPolicy.Location = new System.Drawing.Point(9, 153);
            this.chkPolicy.Name = "chkPolicy";
            this.chkPolicy.Size = new System.Drawing.Size(92, 17);
            this.chkPolicy.TabIndex = 6;
            this.chkPolicy.Text = "Book Policy";
            this.chkPolicy.UseVisualStyleBackColor = true;
            // 
            // chkLocation
            // 
            this.chkLocation.AutoSize = true;
            this.chkLocation.Location = new System.Drawing.Point(9, 130);
            this.chkLocation.Name = "chkLocation";
            this.chkLocation.Size = new System.Drawing.Size(106, 17);
            this.chkLocation.TabIndex = 5;
            this.chkLocation.Text = "Book Location";
            this.chkLocation.UseVisualStyleBackColor = true;
            // 
            // chkCategory
            // 
            this.chkCategory.AutoSize = true;
            this.chkCategory.Location = new System.Drawing.Point(9, 107);
            this.chkCategory.Name = "chkCategory";
            this.chkCategory.Size = new System.Drawing.Size(112, 17);
            this.chkCategory.TabIndex = 4;
            this.chkCategory.Text = "Book Category";
            this.chkCategory.UseVisualStyleBackColor = true;
            // 
            // chkAuthor
            // 
            this.chkAuthor.AutoSize = true;
            this.chkAuthor.Location = new System.Drawing.Point(9, 84);
            this.chkAuthor.Name = "chkAuthor";
            this.chkAuthor.Size = new System.Drawing.Size(97, 17);
            this.chkAuthor.TabIndex = 3;
            this.chkAuthor.Text = "Book Author";
            this.chkAuthor.UseVisualStyleBackColor = true;
            // 
            // chkBookDetail
            // 
            this.chkBookDetail.AutoSize = true;
            this.chkBookDetail.Location = new System.Drawing.Point(10, 40);
            this.chkBookDetail.Name = "chkBookDetail";
            this.chkBookDetail.Size = new System.Drawing.Size(98, 17);
            this.chkBookDetail.TabIndex = 1;
            this.chkBookDetail.Text = "Book Details";
            this.chkBookDetail.UseVisualStyleBackColor = true;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.Location = new System.Drawing.Point(8, 349);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(87, 17);
            this.chkSelectAll.TabIndex = 21;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Click += new System.EventHandler(this.chkSelectAll_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.dgDetails);
            this.pnlGrid.Location = new System.Drawing.Point(0, -1);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(745, 159);
            this.pnlGrid.TabIndex = 96;
            // 
            // dgDetails
            // 
            this.dgDetails.AllowUserToAddRows = false;
            this.dgDetails.AllowUserToDeleteRows = false;
            this.dgDetails.AllowUserToResizeColumns = false;
            this.dgDetails.AllowUserToResizeRows = false;
            this.dgDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDetails.ColumnHeadersHeight = 30;
            this.dgDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgDetails.EnableHeadersVisualStyles = false;
            this.dgDetails.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgDetails.Location = new System.Drawing.Point(-1, 21);
            this.dgDetails.Name = "dgDetails";
            this.dgDetails.ReadOnly = true;
            this.dgDetails.RowHeadersVisible = false;
            this.dgDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetails.Size = new System.Drawing.Size(744, 135);
            this.dgDetails.TabIndex = 0;
            this.dgDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetails_CellClick);
            this.dgDetails.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetails_CellEnter);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 374);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(746, 32);
            this.pnlBottom.TabIndex = 44;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(655, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 24);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "UPDATE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Visible = false;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "ROLE";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "STATUS";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 57;
            // 
            // frmUserAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(216)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(752, 411);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserAccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUserRole";
            this.Load += new System.EventHandler(this.frmUserRole_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlAccess.ResumeLayout(false);
            this.pnlAccess.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetails)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgDetails;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Panel pnlAccess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBookEntry;
        private System.Windows.Forms.CheckBox chkUserRole;
        private System.Windows.Forms.CheckBox chkBorrowerEntry;
        private System.Windows.Forms.CheckBox chkRBorrowerList;
        private System.Windows.Forms.CheckBox chkRBookList;
        private System.Windows.Forms.CheckBox chkImportExport;
        private System.Windows.Forms.CheckBox chkUserAccess;
        private System.Windows.Forms.CheckBox chkUserAccount;
        private System.Windows.Forms.CheckBox chkBorrowerRequest;
        private System.Windows.Forms.CheckBox chkReturnBook;
        private System.Windows.Forms.CheckBox chkPayBook;
        private System.Windows.Forms.CheckBox chkBorrowBook;
        private System.Windows.Forms.CheckBox chkBorrowerDetails;
        private System.Windows.Forms.CheckBox chkPolicy;
        private System.Windows.Forms.CheckBox chkLocation;
        private System.Windows.Forms.CheckBox chkCategory;
        private System.Windows.Forms.CheckBox chkAuthor;
        private System.Windows.Forms.CheckBox chkBookDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;



    }
}