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
        
        

        frmMessageBox oFrmMsgBox;

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

        private void AutoFillBook()
        {
            dgBooks.Rows.Clear();
            oBook = new DataAccess.Book();
            Model.Transaction oRetain = new Model.Transaction();
            int iCounter = 0;
         
            oMTransactionList = new List<Model.Transaction>();
            foreach (DataRow row in oBook.GetTransactionBookRecordPerBorrowerNotSort(eVariable.FIND_BOOK.BOOK_BORROWED, eVariable.sBorrowerID).Rows)
            {
                oMTransaction = new Model.Transaction();



                oMTransaction.PERSON_ID = eVariable.sBorrowerID;
                oMTransaction.FIRST_NAME = eVariable.FirstName;
                oMTransaction.MIDDLE_NAME = eVariable.MiddleName;
                oMTransaction.LAST_NAME = eVariable.LastName;
                oMTransaction.BOOK_ID = row[0].ToString();
                oMTransaction.TITLE = row[1].ToString();
                oMTransaction.SUBJECT = row[2].ToString();
                oMTransaction.CATEGORY = row[3].ToString();
                oMTransaction.AUTHOR = row[4].ToString();
                oMTransaction.PUBLISH_DATE = row[5].ToString();
                oMTransaction.LOCATION = row[6].ToString();
                oMTransaction.BOOK_PRICE = row[7].ToString();
                oMTransaction.RENT_PRICE = row[8].ToString();
                oMTransaction.DUE_INTEREST = Convert.ToDouble(row[9].ToString());
                oMTransaction.LD_INTEREST = Convert.ToDouble(row[10].ToString());
                
                oMTransaction.TOTAL_DAYS = row[12].ToString();
                oMTransaction.ADDED_DATE = row[13].ToString();
                oMTransaction.BOOK_NO = row[14].ToString();
                oMTransaction.ISBN_NUMBER = row[15].ToString();
                oMTransaction.BFLAG = true;



                oMTransactionList.Add(oMTransaction);
                iCounter = oMTransactionList.Where(fw => fw.BOOK_ID == row[0].ToString()).Count();
                oMTransactionList.Where(w => w.BOOK_ID == row[0].ToString()).ToList().ForEach(i => i.TOTAL_QTY = iCounter.ToString());
            }            

            LoadRecords();
        }

        void LoadRecords()
        {

            foreach (Model.Transaction oData in oMTransactionList)
            {
                if (!dgBooks.Rows.Cast<DataGridViewRow>().Any(r => r.Cells[0].Value.Equals(oData.BOOK_ID)))
                {
                    eVariable.DisableGridColumnSort(dgBooks);
                    dgBooks.Rows.Add(oData.BOOK_ID, oData.TITLE, oData.SUBJECT,oData.CATEGORY,oData.AUTHOR,oData.PUBLISH_DATE,oData.LOCATION,oData.BOOK_PRICE,oData.RENT_PRICE,oData.DUE_INTEREST,oData.LD_INTEREST, oData.TOTAL_QTY, oData.TOTAL_DAYS,oData.ADDED_DATE,oData.BOOK_NO,oData.ISBN_NUMBER,oData.BFLAG);

                }
            }            

        }


        void LoadBorrowerRequest()
        {
            oBorrower = new DataAccess.Borrower();
            eVariable.DisableGridColumnSort(dgBorrower);
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

                    eVariable.sBorrowerID = oMBorrower.PERSON_ID;
                    AutoFillBook();
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
                    oMTransaction.BOOK_NO = dgBooks.Rows[e.RowIndex].Cells[14].Value.ToString();
                    oMTransaction.ISBN_NUMBER = dgBooks.Rows[e.RowIndex].Cells[15].Value.ToString();
                    oMTransaction.BFLAG = Convert.ToBoolean(dgBooks.Rows[e.RowIndex].Cells[16].Value);

                    oMTransaction.PERSON_ID = eVariable.sBorrowerID;
                    oMTransaction.FIRST_NAME = oMBorrower.FIRST_NAME;
                    oMTransaction.MIDDLE_NAME = oMBorrower.MIDDLE_NAME;
                    oMTransaction.LAST_NAME = oMBorrower.LAST_NAME;

                    if (e.ColumnIndex == 17)
                    {
                        iGridControl.BookCommonData = oMTransaction;
                        iGridControl.BookListData = oMTransactionList;
                        iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.SEARCH_LOCAL_BORROWED_BOOK_ISBN;
                        iGridControl.SetCheckBoxColumnVisible = true;
                        iGridControl.SetHeaderVisible = true;
                        iGridControl.PopulateRecord();
                        iGridControl.Visible = true;
                    }
                    
                  
                }
            }
            catch (Exception ex)
            {

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
                oFrmMsgBox = new frmMessageBox(eVariable.TransactionMessage.PLEASE_CLOSE_THE_ISBN_PANEL.ToString().Replace("_", " "));
                oFrmMsgBox.m_MessageType = frmMessageBox.MESSAGE_TYPE.INFO;
                oFrmMsgBox.ShowDialog();
                return;
            }

            if (bSelected == false)
            {
                oFrmMsgBox = new frmMessageBox(eVariable.TransactionMessage.PLEASE_SELECT_A_RECORD.ToString().Replace("_", " "));
                oFrmMsgBox.m_MessageType = frmMessageBox.MESSAGE_TYPE.INFO;
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

        private void frmReturnBook_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == 27)
            {
                iGridControl.Visible = false;
            }
        }
    }
}
