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
    public partial class frmReturnBook : Form
    {

        public delegate void GetDataRecordFunction(List<Model.Transaction> oMTransactionList);
        public event GetDataRecordFunction GetDataRecordFunctionPointer;


        DataAccess.Borrower oBorrower = new DataAccess.Borrower();
        Model.Borrower oMBorrower  = new Model.Borrower();

        List<Model.Transaction> oMTransactionList = new List<Model.Transaction>();
        List<Model.Transaction> oMRecordList = new List<Model.Transaction>();

        DataAccess.Book oBook;
        Model.Transaction oMTransaction = new Model.Transaction();
        
        

        CustomWindow.frmInfoMsgBox oFrmMsgBox;

        public frmReturnBook()
        {
            InitializeComponent();

            GetDataRecordFunctionPointer += new GetDataRecordFunction(GetRecord);
            iGridControl.GetDataRecordList = GetDataRecordFunctionPointer;
        }

        public void GetRecord(List<Model.Transaction> oTransList)
        {
            oMRecordList = oTransList;
        }


        void LoadBorrowerRequest()
        {
            oBorrower = new DataAccess.Borrower();

            dgBorrower.DataSource = oBorrower.GetBorrowerTransaction(ePublicVariable.eVariable.FIND_BOOK.BOOK_BORROWED, "");


            foreach (DataGridViewColumn col in dgBorrower.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (col.Name == "ADDRESS")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (col.Name == "ADDED_DATE")
                {
                    col.Visible = false;
                }
            }
            ChangeCellGridColor();
        
        }

        public void ChangeCellGridColor()
        {

            foreach (DataGridViewRow row in dgBorrower.Rows)
            {
                row.DefaultCellStyle.SelectionForeColor = Color.White;
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 73, 94);
            }
        }

        private void frmReturnBook_Load(object sender, EventArgs e)
        {
            LoadBorrowerRequest();

            foreach (DataGridViewColumn col in dgBorrower.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewColumn col in dgBooks.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgBorrower_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DatagridSelect(sender, e);
        }

        void DatagridSelect(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgBorrower.Rows.Count > 0)
                {
                    oMBorrower = new Model.Borrower();
                    oMBorrower.PERSON_ID = dgBorrower.Rows[e.RowIndex].Cells[0].Value.ToString();
                    eVariable.sBorrowerID = dgBorrower.Rows[e.RowIndex].Cells[0].Value.ToString();
                    oMBorrower.FIRST_NAME = dgBorrower.Rows[e.RowIndex].Cells[1].Value.ToString();
                    oMBorrower.MIDDLE_NAME = dgBorrower.Rows[e.RowIndex].Cells[2].Value.ToString();
                    oMBorrower.LAST_NAME = dgBorrower.Rows[e.RowIndex].Cells[3].Value.ToString();
                    oMBorrower.DOB = dgBorrower.Rows[e.RowIndex].Cells[4].Value.ToString();
                    oMBorrower.AGE = dgBorrower.Rows[e.RowIndex].Cells[5].Value.ToString();
                    oMBorrower.CONTACT_NO = dgBorrower.Rows[e.RowIndex].Cells[6].Value.ToString();
                    oMBorrower.ADDRESS = dgBorrower.Rows[e.RowIndex].Cells[7].Value.ToString();
                    oMBorrower.ADDED_DATE = dgBorrower.Rows[e.RowIndex].Cells[8].Value.ToString();

                    FillBooks();
                }
            }
            catch (Exception ex)
            {

            }
        }

        void DatagridSelectedBooks(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgBooks.Rows.Count > 0)
                {
                    oMTransaction = new Model.Transaction();
                    oMTransaction.PERSON_ID = oMBorrower.PERSON_ID;
                    oMTransaction.BOOK_ID = dgBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
                    oMTransaction.TITLE = dgBooks.Rows[e.RowIndex].Cells[1].Value.ToString();
                    oMTransaction.SUBJECT = dgBooks.Rows[e.RowIndex].Cells[2].Value.ToString();
                    oMTransaction.CATEGORY = dgBooks.Rows[e.RowIndex].Cells[3].Value.ToString();
                    oMTransaction.AUTHOR = dgBooks.Rows[e.RowIndex].Cells[4].Value.ToString();
                    oMTransaction.PUBLISH_DATE = dgBooks.Rows[e.RowIndex].Cells[5].Value.ToString();
                    oMTransaction.LOCATION = dgBooks.Rows[e.RowIndex].Cells[6].Value.ToString();
                    oMTransaction.BOOK_PRICE = dgBooks.Rows[e.RowIndex].Cells[7].Value.ToString();
                    oMTransaction.RENT_PRICE = dgBooks.Rows[e.RowIndex].Cells[8].Value.ToString();
                    oMTransaction.DUE_INTEREST = Convert.ToDouble(dgBooks.Rows[e.RowIndex].Cells[9].Value);
                    oMTransaction.LD_INTEREST = Convert.ToDouble(dgBooks.Rows[e.RowIndex].Cells[10].Value);
                    oMTransaction.TOTAL_QTY = dgBooks.Rows[e.RowIndex].Cells[11].Value.ToString();
                    oMTransaction.TOTAL_DAYS = dgBooks.Rows[e.RowIndex].Cells[12].Value.ToString();
                    oMTransaction.ADDED_DATE = dgBooks.Rows[e.RowIndex].Cells[13].Value.ToString();

                    oMTransaction.PERSON_ID = eVariable.sBorrowerID;
                    oMTransaction.FIRST_NAME = oMBorrower.FIRST_NAME;
                    oMTransaction.MIDDLE_NAME = oMBorrower.MIDDLE_NAME;
                    oMTransaction.LAST_NAME = oMBorrower.LAST_NAME;

                    Boolean bFound = oMRecordList.Any(fw => fw.PERSON_ID == eVariable.sBorrowerID);
                    if (!bFound)
                    {
                        oMRecordList.Clear();
                    }

                    if (e.ColumnIndex == 14 && e.RowIndex >= 0)
                    {
                       
                        if (oMRecordList.Count > 0 && bFound)
                        {
                            iGridControl.BookCommonData = oMTransaction;
                            iGridControl.BookListData = oMRecordList;
                            iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.SEARCH_LOCAL_BORROWED_BOOK_ISBN;
                            iGridControl.SetCheckBoxColumnVisible = true;   
                            iGridControl.SetHeaderVisible = true;
                            iGridControl.PopulateRecord();
                            iGridControl.Visible = true;                            

                        }
                        else
                        {
                            iGridControl.BookCommonData = oMTransaction;
                            iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.SEARCH_DB_BORROWED_BOOK_ISBN;
                            iGridControl.SetCheckBoxColumnVisible = true;   
                            iGridControl.SetHeaderVisible = true;
                            iGridControl.PopulateRecord();
                            iGridControl.Visible = true;

                        }

                    }
                  
                }
            }
            catch (Exception ex)
            {

            }
        }
        

        void FillBooks()
        {
            oBook = new DataAccess.Book();
            dgBooks.Rows.Clear();

            foreach (DataRow row in oBook.GetTransactionBookRecordPerBorrower(eVariable.FIND_BOOK.BOOK_BORROWED,eVariable.sBorrowerID).Rows)
            {
                dgBooks.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12],row[13]);
            }
        
        }        

        private void dgBorrower_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DatagridSelect(sender, e);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Boolean bSelected = false;

            foreach (var oData in oMRecordList)
            {
                if (Convert.ToBoolean(oData.BFLAG) == true)
                {
                    bSelected = true;
                }
            }

            if (iGridControl.Visible)
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE CLOSE FIRST ISBN PANEL.");
                oFrmMsgBox.ShowDialog();
                return;
            }

            if (bSelected == false)
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE SELECT A BOOK TO RETURN");
                oFrmMsgBox.ShowDialog();
                return;
            }           

            oMTransactionList = new List<Model.Transaction>();
            foreach (var oData in oMRecordList)
            {
                oMTransaction = new Model.Transaction();
                oMTransaction.BOOK_ID = oData.BOOK_ID;
                oMTransaction.TITLE = oData.TITLE;
                oMTransaction.SUBJECT = oData.SUBJECT;
                oMTransaction.CATEGORY = oData.CATEGORY;
                oMTransaction.AUTHOR = oData.AUTHOR;
                oMTransaction.PUBLISH_DATE = oData.PUBLISH_DATE;
                oMTransaction.LOCATION = oData.LOCATION;
                oMTransaction.BOOK_PRICE = oData.BOOK_PRICE;
                oMTransaction.RENT_PRICE = oData.RENT_PRICE;
                oMTransaction.DUE_INTEREST = Convert.ToDouble(oData.DUE_INTEREST);
                oMTransaction.LD_INTEREST = Convert.ToDouble(oData.LD_INTEREST);
                oMTransaction.TOTAL_QTY = oData.TOTAL_QTY;
                oMTransaction.TOTAL_DAYS = oData.TOTAL_DAYS;
                oMTransaction.ADDED_DATE = oData.ADDED_DATE;
                oMTransaction.BOOK_NO = oData.BOOK_NO;
                oMTransaction.ISBN_NUMBER = oData.ISBN_NUMBER;
                oMTransaction.BFLAG = oData.BFLAG;

                //CHECK BOOK 
                oBook = new DataAccess.Book();
                if (oBook.IsBookLost(oMTransaction))
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("BOOK NUMBER : [" + oMTransaction.BOOK_NO +  " ] WAS TAG AS LOST OR DAMAGE. THIS ITEM CANNOT BE RETURN. ");
                    oFrmMsgBox.ShowDialog();
                    return;
                }

                #region Borrower
                oMTransaction.PERSON_ID = oData.PERSON_ID;
                oMTransaction.FIRST_NAME = oData.FIRST_NAME;
                oMTransaction.MIDDLE_NAME = oData.MIDDLE_NAME;
                oMTransaction.LAST_NAME = oData.LAST_NAME;
                #endregion
              


                oMTransactionList.Add(oMTransaction);

            }


            this.Dispose();
            Forms.frmProcessReturnBook oFrm = new frmProcessReturnBook(oMTransactionList);
            oFrm.ShowDialog();


        }
        

        private void dgBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgBooks.Rows.Count > 0)
            {
                DatagridSelectedBooks(sender, e);
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
