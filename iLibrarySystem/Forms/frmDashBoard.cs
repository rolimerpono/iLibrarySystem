using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ePublicVariable;

namespace iLibrarySystem.Forms
{
    public partial class frmDashBoard : Form
    {

        Model.Borrower oMBorrower = new Model.Borrower();
        DataAccess.Book oBook;
        DataAccess.Borrower oBorrower;

        Forms.frmDisplayBorrowedBook oFrmDisp;


        private eVariable.FIND_BOOK TranType;

        public frmDashBoard()
        {
            InitializeComponent();                        
        }					      

        public void GetDashBoardCounter()
        {                        

            lblRequestBook.Text = oBorrower.GetDashBoardCount(eVariable.FIND_BOOK.BOOK_REQUESTED).Rows.Count == 0 ? "0" : oBorrower.GetDashBoardCount(eVariable.FIND_BOOK.BOOK_REQUESTED).Rows[0][0].ToString();
            lblBorrowedBooks.Text = oBorrower.GetDashBoardCount(eVariable.FIND_BOOK.BOOK_BORROWED).Rows.Count == 0 ? "0" : oBorrower.GetDashBoardCount(eVariable.FIND_BOOK.BOOK_BORROWED).Rows[0][0].ToString();

        }

        public void GetBorrowerRequest()
        {
            oBorrower = new DataAccess.Borrower();

            dgDetails.DataSource = oBorrower.GetBorrowerTransaction(ePublicVariable.eVariable.FIND_BOOK.BOOK_REQUESTED, "");

            foreach (DataGridViewColumn col in dgDetails.Columns)
            {
                
                col.Width = 115;
                //col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (col.Name == "ADDRESS")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                    
                }
            }
            ChangeCellGridColor();
            lblTotalRecord.Text = dgDetails.Rows.Count.ToString();
            TranType = eVariable.FIND_BOOK.BOOK_REQUESTED;
        }

        public void GetCurrentBorrower()
        {
            oBorrower = new DataAccess.Borrower();

            dgDetails.DataSource = oBorrower.GetBorrowerTransaction(eVariable.FIND_BOOK.BOOK_BORROWED, "");

            foreach (DataGridViewColumn col in dgDetails.Columns)
            {
                
                col.Width = 115;
                //col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (col.Name == "ADDRESS")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                    
                }
            }
            ChangeCellGridColor();
            lblTotalRecord.Text = dgDetails.Rows.Count.ToString();

            TranType = eVariable.FIND_BOOK.BOOK_BORROWED;
        }


        public void ChangeCellGridColor()
        {

            foreach (DataGridViewRow row in dgDetails.Rows)
            {
                row.DefaultCellStyle.SelectionForeColor = Color.White;
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 73, 94);
            }
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            GetBorrowerRequest();
            GetDashBoardCounter();            

            foreach (DataGridViewColumn col in dgDetails.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void lblBorrowedBooks_Click(object sender, EventArgs e)
        {
            GetCurrentBorrower();
            UnderLineText(lblBorrowedCaption);
        }

        private void lblRequestBook_Click(object sender, EventArgs e)
        {
            GetBorrowerRequest();
            UnderLineText(lblRequestCaption);
        }

        private void lblReserveBooks_Click(object sender, EventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                dgDetails.DataSource = null;
            }
            
            lblTotalRecord.Text = dgDetails.Rows.Count.ToString();
        }

      

        void UnderLineText(Control iObject)
        {
            foreach (Control o in pnlStatus.Controls.OfType<Label>().ToList().Where(fw => fw.Text.Length > 5))
            {

                if (o.Name == iObject.Name)
                {
                    o.Font = new Font(o.Font.Name, 8, FontStyle.Underline | FontStyle.Bold);
                    
                }
                else
                {
                    o.Font = new Font(o.Font.Name, 8, FontStyle.Regular | FontStyle.Bold);
                }
            }
                
        }

        private void dgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DataGridviewSelectedData(sender, e);
            }
        }

        private void DataGridviewSelectedData(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                oMBorrower = new Model.Borrower();
                if (dgDetails.Rows.Count > 0)
                {                    
                    oMBorrower.PERSON_ID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                    oMBorrower.FIRST_NAME = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                    oMBorrower.MIDDLE_NAME = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                    oMBorrower.LAST_NAME = dgDetails.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
            }
        }

        private void dgDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0 && e.RowIndex >= 0)
            {
                Close();
                switch (TranType)
                {
                    case eVariable.FIND_BOOK.BOOK_BORROWED:
                        oFrmDisp = new frmDisplayBorrowedBook(oMBorrower, TranType);
                        oFrmDisp.ShowDialog();
                        break;
                    case eVariable.FIND_BOOK.BOOK_REQUESTED:
                        oFrmDisp = new frmDisplayBorrowedBook(oMBorrower, TranType);
                        oFrmDisp.ShowDialog();
                        break;               
                }
            }
        }

        private void dgDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DataGridviewSelectedData(sender, e);
            }
        }

        private void lblRequestCaption_Click(object sender, EventArgs e)
        {
            GetBorrowerRequest();
            UnderLineText(lblRequestCaption);
        }

        private void lblBorrowedCaption_Click(object sender, EventArgs e)
        {
            GetCurrentBorrower();
            UnderLineText(lblBorrowedCaption);
        }

        
    }
}
