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
    public partial class frmProcessReturnBook : Form
    {

        CommonFunction.CommonFunction oCommonFunction;

        public delegate void GetDataRecordFunction(List<Model.Transaction> oMTransactionList);
        public event GetDataRecordFunction GetDataRecordFunctionPointer;

        Model.Borrower oMBorrower = new Model.Borrower();
        Model.Transaction oMTransaction = new Model.Transaction();
        DataAccess.Book oBook  = new DataAccess.Book();
        DataAccess.Borrower oBorrower = new DataAccess.Borrower();

        List<Model.Transaction> oMTransactionList = new List<Model.Transaction>();
        List<Model.Transaction> oRecordList = new List<Model.Transaction>();

        frmMessageBox oFrmMsgBox;
        private double? iTotalAmount = 0;
        private double? iReceiveAmount = 0;
        
        public frmProcessReturnBook()
        {
            InitializeComponent();

            GetDataRecordFunctionPointer += new GetDataRecordFunction(GetRecord);
            iGridControl.GetDataRecordList = GetDataRecordFunctionPointer;

            eVariable.DisableKeyPress(pnlMain);
        }

        public frmProcessReturnBook(Model.Borrower oData)
        {
            InitializeComponent();

            GetDataRecordFunctionPointer += new GetDataRecordFunction(GetRecord);
            iGridControl.GetDataRecordList = GetDataRecordFunctionPointer;

            oMBorrower = oData;

            eVariable.sBorrowerID = oMBorrower.PERSON_ID;
            eVariable.FirstName = oMBorrower.FIRST_NAME;
            eVariable.MiddleName = oMBorrower.MIDDLE_NAME;
            eVariable.LastName = oMBorrower.LAST_NAME;

            eVariable.DisableKeyPress(pnlMain);
            
            AutoFillBook();
        }     

        private void AutoFillBook()
        {
            dgBooks.Rows.Clear();
            oBook = new DataAccess.Book();
            Model.Transaction oRetain = new Model.Transaction();
            foreach (DataRow row in oBook.GetTransactionBookRecordPerBorrowerNotSort(eVariable.FIND_BOOK.BOOK_BORROWED, eVariable.sBorrowerID).Rows)
            {                
                oMTransaction = new Model.Transaction();
                oMTransaction.PERSON_ID = eVariable.sBorrowerID;
                oMTransaction.FIRST_NAME = eVariable.FirstName;
                oMTransaction.MIDDLE_NAME = eVariable.MiddleName;
                oMTransaction.LAST_NAME = eVariable.LastName;
                oMTransaction.BOOK_ID = row[0].ToString();
                oMTransaction.TITLE  = row[1].ToString();
                oMTransaction.SUBJECT = row[2].ToString();
                oMTransaction.CATEGORY = row[3].ToString();
                oMTransaction.AUTHOR  = row[4].ToString();
                oMTransaction.PUBLISH_DATE = row[5].ToString();
                oMTransaction.LOCATION = row[6].ToString();
                oMTransaction.BOOK_PRICE = row[7].ToString();
                oMTransaction.RENT_PRICE = row[8].ToString();
                oMTransaction.DUE_INTEREST = Convert.ToDouble(row[9].ToString());
                oMTransaction.LD_INTEREST = Convert.ToDouble(row[10].ToString());
                oMTransaction.TOTAL_QTY = row[11].ToString();
                oMTransaction.TOTAL_DAYS = row[12].ToString();
                oMTransaction.ADDED_DATE = row[13].ToString();
                oMTransaction.BOOK_NO = row[14].ToString();
                oMTransaction.ISBN_NUMBER = row[15].ToString();
                oMTransaction.BFLAG = true;
                oMTransactionList.Add(oMTransaction);
            }

            LoadRecords();
     
        }

        public void GetRecord(List<Model.Transaction> oTransList)
        {
            oRecordList = oTransList;
            UpdatePaymentWindow();
        }


        void LoadRecords()
        {
            iTotalAmount = 0;
            dgBooks.Rows.Clear();
            foreach (Model.Transaction oData in oMTransactionList)
            {
                var oResult = (from DataGridViewRow r in dgBooks.Rows
                               where Convert.ToString(r.Cells["ID"].Value) == oData.BOOK_ID
                               select r.Cells["ID"].Value.ToString());                

                if (oResult.Count() == 0)
                {
                    if (oData.BFLAG == true)
                    {
                        eVariable.DisableGridColumnSort(dgBooks);
                        dgBooks.Rows.Add(oData.BOOK_ID, oData.TITLE, oData.SUBJECT, oData.CATEGORY, oData.AUTHOR, oData.PUBLISH_DATE, oData.ADDED_DATE, oData.RENT_PRICE, oData.DUE_INTEREST, oData.TOTAL_DAYS);

                        txtBorrowerID.Text = oData.PERSON_ID;
                        txtFulllname.Text = oData.GetFullName;
                    }
                }                                  
            }

            UpdatePaymentWindow();
        }

        private void UpdatePaymentWindow()
        {

            iPaymentWindow.TransactionList = oMTransactionList;
            iPaymentWindow.TranType = global::iPaymentWindow.iPaymentWindow.TransactionType.Return;
            iPaymentWindow.DisplayDetails();
            iTotalAmount = iPaymentWindow.TotalDue;
            iReceiveAmount = iPaymentWindow.ReceiveAmount;
        
        }

        
        public frmProcessReturnBook(List<Model.Transaction> oTransList)
        {
            InitializeComponent();
            oMTransactionList = oTransList;
            eVariable.DisableKeyPress(pnlMain);            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgBooks.Rows.Count > 0)
            {

                if (iTotalAmount > iPaymentWindow.ReceiveAmount)
                {
                    oFrmMsgBox = new frmMessageBox(eVariable.TransactionMessage.PLEASE_ENTER_EXACT_PAYMENT_AMOUNT.ToString().Replace("_"," "));
                    oFrmMsgBox.m_MessageType = frmMessageBox.MESSAGE_TYPE.INFO;
                    oFrmMsgBox.ShowDialog();
                    return;
                }

                foreach (Model.Transaction oData in oMTransactionList)
                {
                  
                    oMTransaction = new Model.Transaction();
                    oBook = new DataAccess.Book();

                    if (oData.BFLAG == true)
                    {                    
                        oMTransaction.PERSON_ID = oData.PERSON_ID;
                        oMTransaction.BOOK_ID = oData.BOOK_ID;
                        oMTransaction.BOOK_NO = oData.BOOK_NO;
                        oMTransaction.MODIFIED_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                        oMTransaction.MODIFIED_BY = eVariable.sUsername;
                        oMTransaction.TOTAL_AMOUNT = iTotalAmount;
                        oMTransaction.STATUS = "RETURNED";
                        oBook.ReturnBook(oMTransaction);
                        
                    }                    
                }

                oFrmMsgBox = new frmMessageBox(eVariable.TransactionMessage.TRANSACTION_HAS_BEEN_SUCESSFULLY_SAVE.ToString().Replace("_", " "));
                oFrmMsgBox.m_MessageType = frmMessageBox.MESSAGE_TYPE.INFO;
                oFrmMsgBox.ShowDialog();
                iPaymentWindow.clearText();                          
                eVariable.ClearText(pnlMain);
                dgBooks.Rows.Clear();
            }
        }

        private void frmProcessReturnBook_Load(object sender, EventArgs e)
        {
            LoadRecords();
            foreach (DataGridViewColumn col in dgBooks.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void lblMClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
     

        private void dgBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 && e.RowIndex >= 0)
            {
                oMTransaction = new Model.Transaction();

                oMTransaction.BOOK_ID = dgBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
                oMTransaction.TITLE = dgBooks.Rows[e.RowIndex].Cells[1].Value.ToString();
                oMTransaction.SUBJECT = dgBooks.Rows[e.RowIndex].Cells[2].Value.ToString();
                oMTransaction.CATEGORY = dgBooks.Rows[e.RowIndex].Cells[3].Value.ToString();
                oMTransaction.AUTHOR = dgBooks.Rows[e.RowIndex].Cells[4].Value.ToString();
                oMTransaction.PUBLISH_DATE = dgBooks.Rows[e.RowIndex].Cells[5].Value.ToString();
                oMTransaction.ADDED_DATE = dgBooks.Rows[e.RowIndex].Cells[6].Value.ToString();
                oMTransaction.BOOK_PRICE = dgBooks.Rows[e.RowIndex].Cells[7].Value.ToString();
                oMTransaction.RENT_PRICE = dgBooks.Rows[e.RowIndex].Cells[8].Value.ToString();


                oMTransaction.PERSON_ID = txtBorrowerID.Text;        

                iGridControl.BookCommonData = oMTransaction;
                iGridControl.BookListData = oMTransactionList;
                iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.SEARCH_SELECTED_BORROWED_BOOK_ISBN;
                
                iGridControl.SetHeaderVisible = true;
                iGridControl.PopulateRecord();
                iGridControl.Visible = true;
            }
        }

        private void frmProcessReturnBook_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == 27)
            {
                iGridControl.Visible = false;
            }
        }               
     

       

       
      
    }
}
