namespace iLibrarySystem.Forms
{
    partial class frmDashBoard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblBorrowedBooks = new System.Windows.Forms.Label();
            this.lblBorrowedCaption = new System.Windows.Forms.Label();
            this.lblRequestCaption = new System.Windows.Forms.Label();
            this.lblRequestBook = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlGridview = new System.Windows.Forms.Panel();
            this.dgDetails = new System.Windows.Forms.DataGridView();
            this.lblNote = new System.Windows.Forms.Label();
            this.pnlStatus.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlGridview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlStatus.Controls.Add(this.lblBorrowedBooks);
            this.pnlStatus.Controls.Add(this.lblBorrowedCaption);
            this.pnlStatus.Controls.Add(this.lblRequestCaption);
            this.pnlStatus.Controls.Add(this.lblRequestBook);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatus.Location = new System.Drawing.Point(0, 0);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(830, 85);
            this.pnlStatus.TabIndex = 10;
            // 
            // lblBorrowedBooks
            // 
            this.lblBorrowedBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBorrowedBooks.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrowedBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.lblBorrowedBooks.Location = new System.Drawing.Point(140, 28);
            this.lblBorrowedBooks.Margin = new System.Windows.Forms.Padding(0);
            this.lblBorrowedBooks.Name = "lblBorrowedBooks";
            this.lblBorrowedBooks.Size = new System.Drawing.Size(78, 46);
            this.lblBorrowedBooks.TabIndex = 14;
            this.lblBorrowedBooks.Text = "0";
            this.lblBorrowedBooks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBorrowedBooks.Click += new System.EventHandler(this.lblBorrowedBooks_Click);
            // 
            // lblBorrowedCaption
            // 
            this.lblBorrowedCaption.AutoSize = true;
            this.lblBorrowedCaption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBorrowedCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrowedCaption.ForeColor = System.Drawing.Color.White;
            this.lblBorrowedCaption.Location = new System.Drawing.Point(137, 15);
            this.lblBorrowedCaption.Name = "lblBorrowedCaption";
            this.lblBorrowedCaption.Size = new System.Drawing.Size(85, 13);
            this.lblBorrowedCaption.TabIndex = 7;
            this.lblBorrowedCaption.Text = "BORROWERS";
            this.lblBorrowedCaption.Click += new System.EventHandler(this.lblBorrowedCaption_Click);
            // 
            // lblRequestCaption
            // 
            this.lblRequestCaption.AutoSize = true;
            this.lblRequestCaption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRequestCaption.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestCaption.ForeColor = System.Drawing.Color.White;
            this.lblRequestCaption.Location = new System.Drawing.Point(14, 15);
            this.lblRequestCaption.Name = "lblRequestCaption";
            this.lblRequestCaption.Size = new System.Drawing.Size(65, 13);
            this.lblRequestCaption.TabIndex = 6;
            this.lblRequestCaption.Text = "REQUEST";
            this.lblRequestCaption.Click += new System.EventHandler(this.lblRequestCaption_Click);
            // 
            // lblRequestBook
            // 
            this.lblRequestBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRequestBook.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(212)))), ((int)(((byte)(250)))));
            this.lblRequestBook.Location = new System.Drawing.Point(9, 28);
            this.lblRequestBook.Margin = new System.Windows.Forms.Padding(0);
            this.lblRequestBook.Name = "lblRequestBook";
            this.lblRequestBook.Size = new System.Drawing.Size(78, 46);
            this.lblRequestBook.TabIndex = 12;
            this.lblRequestBook.Text = "0";
            this.lblRequestBook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRequestBook.Click += new System.EventHandler(this.lblRequestBook_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblNote);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 85);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(830, 31);
            this.pnlHeader.TabIndex = 11;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.lblTotalRecord);
            this.pnlFooter.Controls.Add(this.label4);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 432);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(830, 31);
            this.pnlFooter.TabIndex = 12;
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotalRecord.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecord.ForeColor = System.Drawing.Color.White;
            this.lblTotalRecord.Location = new System.Drawing.Point(119, 7);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(15, 13);
            this.lblTotalRecord.TabIndex = 8;
            this.lblTotalRecord.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "TOTAL RECORD :";
            // 
            // pnlGridview
            // 
            this.pnlGridview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGridview.Controls.Add(this.dgDetails);
            this.pnlGridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridview.Location = new System.Drawing.Point(0, 116);
            this.pnlGridview.Name = "pnlGridview";
            this.pnlGridview.Size = new System.Drawing.Size(830, 316);
            this.pnlGridview.TabIndex = 13;
            // 
            // dgDetails
            // 
            this.dgDetails.AllowUserToAddRows = false;
            this.dgDetails.AllowUserToDeleteRows = false;
            this.dgDetails.AllowUserToResizeColumns = false;
            this.dgDetails.AllowUserToResizeRows = false;
            this.dgDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgDetails.ColumnHeadersHeight = 30;
            this.dgDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDetails.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgDetails.EnableHeadersVisualStyles = false;
            this.dgDetails.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgDetails.Location = new System.Drawing.Point(0, 0);
            this.dgDetails.Name = "dgDetails";
            this.dgDetails.ReadOnly = true;
            this.dgDetails.RowHeadersVisible = false;
            this.dgDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetails.Size = new System.Drawing.Size(828, 314);
            this.dgDetails.TabIndex = 9;
            this.dgDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetails_CellClick);
            this.dgDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetails_CellDoubleClick);
            this.dgDetails.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetails_CellEnter);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNote.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.White;
            this.lblNote.Location = new System.Drawing.Point(7, 9);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(418, 13);
            this.lblNote.TabIndex = 9;
            this.lblNote.Text = "DOUBLE CLICK ON THE RECORD LIST TO PROCEED TRANSACTION.";
            // 
            // frmDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(830, 463);
            this.Controls.Add(this.pnlGridview);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlStatus);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlGridview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblBorrowedBooks;
        private System.Windows.Forms.Label lblBorrowedCaption;
        private System.Windows.Forms.Label lblRequestCaption;
        private System.Windows.Forms.Label lblRequestBook;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlGridview;
        private System.Windows.Forms.DataGridView dgDetails;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.Label lblNote;


    }
}