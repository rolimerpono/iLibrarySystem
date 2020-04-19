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
    public partial class frmDisplayBorrowedBook : Form
    {

        DataAccess.Book oBook = new DataAccess.Book();
        Model.Transaction oMTransaction = new Model.Transaction();
        List<Model.Transaction> oMTransactionList = new List<Model.Transaction>();
        Model.Borrower oMBorrower = new Model.Borrower();

      
        private ePublicVariable.eVariable.FIND_BOOK TranType;

        public frmDisplayBorrowedBook()
        {
            InitializeComponent();
        }

        public frmDisplayBorrowedBook(Model.Borrower oData, eVariable.FIND_BOOK oType)
        {
            InitializeComponent();
            oMBorrower = oData;
            TranType = oType;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadRecords()
        {
            dgBooks.Rows.Clear();
            switch (TranType)
            { 
                case eVariable.FIND_BOOK.BOOK_BORROWED:
                    foreach (DataRow row in oBook.GetTransactionBookRecordPerBorrower(ePublicVariable.eVariable.FIND_BOOK.BOOK_BORROWED, oMBorrower.PERSON_ID).Rows)
                    {
                        dgBooks.Rows.Add(row[0], row[1], row[3], row[13], row[8], row[11], row[12]);
                    }
                    break;
                case eVariable.FIND_BOOK.BOOK_REQUESTED:
                
                    foreach (DataRow row in oBook.GetTransactionBookRecordPerBorrower(ePublicVariable.eVariable.FIND_BOOK.BOOK_REQUESTED, oMBorrower.PERSON_ID).Rows)
                    {
                        dgBooks.Rows.Add(row[0], row[1], row[3], row[13], row[8], row[11], row[12]);                        
                    }
                    break;
                
                case eVariable.FIND_BOOK.BOOK_PENALTY:

                    break;                        
            }            
        }

        private void frmDisplayBorrowedBook_Load(object sender, EventArgs e)
        {
            LoadRecords();
            if (TranType == eVariable.FIND_BOOK.BOOK_BORROWED || TranType == eVariable.FIND_BOOK.BOOK_PENALTY)
            {
                btnBorrowBook.Enabled = false;
            }
            if (TranType == eVariable.FIND_BOOK.BOOK_REQUESTED)
            {
                btnPayBook.Enabled = false;
                btnReturnBook.Enabled = false;
            }
        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            Forms.frmBorrowBook oFrm = new frmBorrowBook(oMBorrower,eVariable.FIND_BOOK.BOOK_REQUESTED);
            oFrm.ShowDialog();
            Close();
        }

        private void btnPayBook_Click(object sender, EventArgs e)
        {
            Forms.frmPayBook oFrm = new frmPayBook(oMBorrower,eVariable.FIND_BOOK.BOOK_BORROWED);
            oFrm.ShowDialog();
            Close();
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            Forms.frmProcessReturnBook oFrm = new frmProcessReturnBook(oMBorrower);
            oFrm.ShowDialog();
            Close();
        }

        private void dgBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }
    }
}
