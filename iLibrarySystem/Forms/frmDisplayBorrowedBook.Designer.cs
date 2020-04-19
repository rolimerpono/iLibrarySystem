namespace iLibrarySystem.Forms
{
    partial class frmDisplayBorrowedBook
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgBooks = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPayBook = new System.Windows.Forms.Button();
            this.btnBorrowBook = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBooks)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.dgBooks);
            this.pnlBody.Controls.Add(this.panel2);
            this.pnlBody.Controls.Add(this.pnlHeader);
            this.pnlBody.Location = new System.Drawing.Point(3, 3);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(831, 295);
            this.pnlBody.TabIndex = 0;
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
            this.dgBooks.ColumnHeadersHeight = 25;
            this.dgBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column9,
            this.Column13});
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
            this.dgBooks.Location = new System.Drawing.Point(0, 26);
            this.dgBooks.Name = "dgBooks";
            this.dgBooks.ReadOnly = true;
            this.dgBooks.RowHeadersVisible = false;
            this.dgBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBooks.Size = new System.Drawing.Size(831, 234);
            this.dgBooks.TabIndex = 17;
            this.dgBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBooks_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.panel2.Controls.Add(this.btnPayBook);
            this.panel2.Controls.Add(this.btnBorrowBook);
            this.panel2.Controls.Add(this.btnReturnBook);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 260);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(831, 35);
            this.panel2.TabIndex = 16;
            // 
            // btnPayBook
            // 
            this.btnPayBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnPayBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayBook.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPayBook.Location = new System.Drawing.Point(565, 5);
            this.btnPayBook.Name = "btnPayBook";
            this.btnPayBook.Size = new System.Drawing.Size(129, 24);
            this.btnPayBook.TabIndex = 7;
            this.btnPayBook.Text = "PAY BOOK";
            this.btnPayBook.UseVisualStyleBackColor = false;
            this.btnPayBook.Click += new System.EventHandler(this.btnPayBook_Click);
            // 
            // btnBorrowBook
            // 
            this.btnBorrowBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnBorrowBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrowBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrowBook.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBorrowBook.Location = new System.Drawing.Point(433, 5);
            this.btnBorrowBook.Name = "btnBorrowBook";
            this.btnBorrowBook.Size = new System.Drawing.Size(129, 24);
            this.btnBorrowBook.TabIndex = 6;
            this.btnBorrowBook.Text = "BORROW BOOK";
            this.btnBorrowBook.UseVisualStyleBackColor = false;
            this.btnBorrowBook.Click += new System.EventHandler(this.btnBorrowBook_Click);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnReturnBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnBook.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReturnBook.Location = new System.Drawing.Point(697, 5);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(129, 24);
            this.btnReturnBook.TabIndex = 5;
            this.btnReturnBook.Text = "RETURN BOOK";
            this.btnReturnBook.UseVisualStyleBackColor = false;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlHeader.Controls.Add(this.lblClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(831, 26);
            this.pnlHeader.TabIndex = 14;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(768, 7);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(59, 13);
            this.lblClose.TabIndex = 11;
            this.lblClose.Text = "[CLOSE]";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
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
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "AUTHOR";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 61;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "DATE BORROWED";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 116;
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
            // frmDisplayBorrowedBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(216)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(836, 300);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDisplayBorrowedBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDisplayBorrowedBook_Load);
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBooks)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblClose;
        public System.Windows.Forms.DataGridView dgBooks;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBorrowBook;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnPayBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
    }
}