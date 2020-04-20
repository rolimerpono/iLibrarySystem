namespace iControlGrid
{
    partial class iGridControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelControl = new System.Windows.Forms.Panel();
            this.lblISBNList = new System.Windows.Forms.Label();
            this.closeControl = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.GridControl = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BOOK_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BOOK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISBN_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelControl.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.panelControl.Controls.Add(this.lblISBNList);
            this.panelControl.Controls.Add(this.closeControl);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(404, 20);
            this.panelControl.TabIndex = 3;
            this.panelControl.Visible = false;
            // 
            // lblISBNList
            // 
            this.lblISBNList.AutoSize = true;
            this.lblISBNList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblISBNList.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblISBNList.ForeColor = System.Drawing.Color.White;
            this.lblISBNList.Location = new System.Drawing.Point(3, 4);
            this.lblISBNList.Name = "lblISBNList";
            this.lblISBNList.Size = new System.Drawing.Size(71, 13);
            this.lblISBNList.TabIndex = 8;
            this.lblISBNList.Text = "ISBN LIST";
            // 
            // closeControl
            // 
            this.closeControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeControl.AutoSize = true;
            this.closeControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeControl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeControl.ForeColor = System.Drawing.Color.White;
            this.closeControl.Location = new System.Drawing.Point(343, 3);
            this.closeControl.Name = "closeControl";
            this.closeControl.Size = new System.Drawing.Size(59, 13);
            this.closeControl.TabIndex = 7;
            this.closeControl.Text = "[CLOSE]";
            this.closeControl.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.GridControl);
            this.pnlGrid.Controls.Add(this.pnlFooter);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 20);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(404, 168);
            this.pnlGrid.TabIndex = 4;
            // 
            // GridControl
            // 
            this.GridControl.AllowUserToAddRows = false;
            this.GridControl.AllowUserToDeleteRows = false;
            this.GridControl.AllowUserToResizeColumns = false;
            this.GridControl.AllowUserToResizeRows = false;
            this.GridControl.BackgroundColor = System.Drawing.Color.White;
            this.GridControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridControl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridControl.ColumnHeadersHeight = 25;
            this.GridControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridControl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BOOK_ID,
            this.BOOK_NO,
            this.ISBN_NUMBER,
            this.Column4,
            this.Column5,
            this.Column3,
            this.colDel});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridControl.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GridControl.EnableHeadersVisualStyles = false;
            this.GridControl.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.GridControl.Location = new System.Drawing.Point(0, 0);
            this.GridControl.Name = "GridControl";
            this.GridControl.ReadOnly = true;
            this.GridControl.RowHeadersVisible = false;
            this.GridControl.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridControl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridControl.Size = new System.Drawing.Size(402, 146);
            this.GridControl.TabIndex = 28;
            this.GridControl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridControl_CellClick);
            this.GridControl.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridControl_CellDoubleClick);
            this.GridControl.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridControl_CellEndEdit);
            this.GridControl.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridControl_CellEnter);
            this.GridControl.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.GridControl_EditingControlShowing);
            this.GridControl.MouseLeave += new System.EventHandler(this.GridControl_MouseLeave);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlFooter.Controls.Add(this.label1);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 146);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(402, 20);
            this.pnlFooter.TabIndex = 27;
            this.pnlFooter.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "DOUBLE CLICK ON BOOK NO COLUMN TO ENTER THE BOOK NO.";
            // 
            // BOOK_ID
            // 
            this.BOOK_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BOOK_ID.HeaderText = "BOOK ID";
            this.BOOK_ID.Name = "BOOK_ID";
            this.BOOK_ID.ReadOnly = true;
            this.BOOK_ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BOOK_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BOOK_ID.Visible = false;
            this.BOOK_ID.Width = 65;
            // 
            // BOOK_NO
            // 
            this.BOOK_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BOOK_NO.HeaderText = "BOOK NO";
            this.BOOK_NO.MinimumWidth = 150;
            this.BOOK_NO.Name = "BOOK_NO";
            this.BOOK_NO.ReadOnly = true;
            this.BOOK_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BOOK_NO.ToolTipText = "DOUBLE CLICK ON BOOK NO COLUMN TO ENTER THE BOOK NO.";
            this.BOOK_NO.Width = 150;
            // 
            // ISBN_NUMBER
            // 
            this.ISBN_NUMBER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ISBN_NUMBER.HeaderText = "ISBN NUMBER";
            this.ISBN_NUMBER.Name = "ISBN_NUMBER";
            this.ISBN_NUMBER.ReadOnly = true;
            this.ISBN_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "REMARKS";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Visible = false;
            this.Column4.Width = 69;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "STATUS";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Visible = false;
            this.Column5.Width = 57;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Visible = false;
            this.Column3.Width = 5;
            // 
            // colDel
            // 
            this.colDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDel.HeaderText = "";
            this.colDel.Image = global::iControlGrid.Resource._delete;
            this.colDel.Name = "colDel";
            this.colDel.ReadOnly = true;
            this.colDel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDel.Visible = false;
            this.colDel.Width = 5;
            // 
            // iGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.panelControl);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "iGridControl";
            this.Size = new System.Drawing.Size(404, 188);
            this.Load += new System.EventHandler(this.iGridControl_Load);
            this.MouseLeave += new System.EventHandler(this.GridControl_MouseLeave);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label closeControl;
        private System.Windows.Forms.Label lblISBNList;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.DataGridView GridControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BOOK_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BOOK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn colDel;

    }
}
