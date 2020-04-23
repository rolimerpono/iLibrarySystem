using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using ePublicVariable;

namespace iLibrarySystem.Forms
{
    public partial class frmCheckOutBook : Form
    {

        public delegate void GetDataRecordFunction(List<Model.Transaction> oMTransactionList);
        public event GetDataRecordFunction GetDataRecordFunctionPointer;

        CustomWindow.frmInfoMsgBox oFrmMsgBox;
        Model.Transaction oMTransaction = new Model.Transaction();
        List<Model.Transaction> oMTransactionList = new List<Model.Transaction>();
        List<Model.Transaction> oMRecordList = new List<Model.Transaction>();

        DataAccess.Book oBook = new DataAccess.Book();
        DataAccess.Policy oPolicy = new DataAccess.Policy();

        int iMaxBook = 0;
        int iMaxDays = 0;
        int iTransactionNo = 0;
        
        double iDueInterest = 0;
        double iLDInterest = 0;

        private double? iTotalAmount = 0;
        private double? iReceiveAmount = 0;

        public frmCheckOutBook()
        {
            InitializeComponent();

            GetDataRecordFunctionPointer += new GetDataRecordFunction(GetRecord);
            iGridControl.GetDataRecordList = GetDataRecordFunctionPointer;
        }

        public frmCheckOutBook(frmBorrowBook oFrmBrwBk, List<Model.Transaction> oRecordList)
        {
            InitializeComponent();         
            oMRecordList = oRecordList;
            eVariable.DisablePanelTextKeyPress(pnlMain);            

            GetDataRecordFunctionPointer += new GetDataRecordFunction(GetRecord);
            iGridControl.GetDataRecordList = GetDataRecordFunctionPointer;
        }

        public void GetRecord(List<Model.Transaction> oMTransList)
        {
            oMTransactionList = oMTransList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
                       
        }

        public void LoadRecords()
        {
            #region First Solution
            oMTransactionList = new List<Model.Transaction>();
            foreach (Model.Transaction oData in oMRecordList)
            {
                if (oMTransactionList.Count == 0)
                {

                    txtBorrowerID.Text = oData.PERSON_ID;
                    txtFulllname.Text = oData.GetFullName;


                    oMTransactionList.Add(new Model.Transaction { BOOK_ID = oData.BOOK_ID });
                    dgBooks.Rows.Add(oData.BOOK_ID, oData.TITLE, oData.SUBJECT, oData.CATEGORY, oData.AUTHOR, oData.PUBLISH_DATE, oData.RENT_PRICE,oData.DUE_INTEREST,oData.TOTAL_QTY,oData.TOTAL_DAYS);
                }
                bool bBFound = oMTransactionList.Any(fw => fw.BOOK_ID == oData.BOOK_ID);
                if (!bBFound)
                {
                    oMTransactionList.Add(new Model.Transaction { BOOK_ID = oData.BOOK_ID });
                    dgBooks.Rows.Add(oData.BOOK_ID, oData.TITLE, oData.SUBJECT, oData.CATEGORY, oData.AUTHOR, oData.PUBLISH_DATE, oData.RENT_PRICE,oData.DUE_INTEREST, oData.TOTAL_QTY,oData.TOTAL_DAYS);
                }
            }
            #endregion  
            
            iPaymentWindow.TransactionList = oMRecordList;
            iPaymentWindow.TranType = global::iPaymentWindow.iPaymentWindow.TransactionType.Checkout;
            iPaymentWindow.DisplayDetails();            
            iTotalAmount = iPaymentWindow.TotalDue;
            

            ChangeCellGridColor();
            
            GetPolicy();
        }

        void GetPolicy()
        {
            oPolicy = new DataAccess.Policy();
            foreach (DataRow row in oPolicy.GetPolicy("", "").Rows)
            {
                iDueInterest = Convert.ToDouble(row[0]);
                iLDInterest = Convert.ToDouble(row[1]);
                iMaxDays = Convert.ToInt32(row[2]);
                iMaxBook = Convert.ToInt32(row[3]);
            }
        }



        private void frmCheckOutBook_Load(object sender, EventArgs e)
        {
            LoadRecords();
            GetTransactionNo();
            foreach (DataGridViewColumn col in dgBooks.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void ChangeCellGridColor()
        {
            for (int i = 0; i < dgBooks.Rows.Count; ++i)
            {
                dgBooks.Rows[i].Cells[10].Style.ForeColor = Color.Black;
                dgBooks.Rows[i].Cells[10].Style.BackColor = Color.White;
                dgBooks.Rows[i].Cells[10].Style.SelectionForeColor = Color.Black;
                dgBooks.Rows[i].Cells[10].Style.SelectionBackColor = Color.White;

            }
        }

        void GetTransactionNo()
        {
            try
            {
                oBook = new DataAccess.Book();
                iTransactionNo = oBook.GetTransactionNo();


                iTransactionNo = iTransactionNo + 1;
                eVariable.sTransactionNo = "TRX-" + (iTransactionNo).ToString("00000#");
                lblTransNo.Text = eVariable.sTransactionNo;
            }
            catch (Exception ex)
            { }
        }
       
        void DatagridSelect(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 10 && e.RowIndex >= 0)
                {
                    iGridControl.BookCommonData = oMTransaction;
                    iGridControl.BookListData = oMRecordList;
                    iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.SEARCH_LOCAL_BORROWED_BOOK_ISBN;
                    iGridControl.SetHeaderVisible = true;  
                    iGridControl.PopulateRecord();                    
                    iGridControl.Visible = true;
                }
            }
            catch (Exception ex)
            { }
        }       

        private void dgBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 10 && e.RowIndex >= 0)
                {

                    oMTransaction = new Model.Transaction();
                    oMTransaction.BOOK_ID = dgBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
                    DatagridSelect(sender, e);                    
                }
            }
            catch (Exception ex)
            { }
            
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
       

        private void btnSave_Click(object sender, EventArgs e)
        {                             
            if (dgBooks.Rows.Count > 0)
            {
                if (iTotalAmount >  iPaymentWindow.ReceiveAmount)
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.PLEASE_ENTER_EXACT_PAYMENT_AMOUNT.ToString().Replace("_", " "));
                    oFrmMsgBox.ShowDialog();
                    
                    return;
                }

                foreach (Model.Transaction oData in oMRecordList)
                {                   
                    oMTransaction = new Model.Transaction();
                    oBook = new DataAccess.Book();
                    oMTransaction.PERSON_ID = oData.PERSON_ID;
                    oMTransaction.BOOK_ID = oData.BOOK_ID;
                    oMTransaction.BOOK_NO = oData.BOOK_NO;
                    oMTransaction.TITLE = oData.TITLE;
                    oMTransaction.SUBJECT = oData.SUBJECT;
                    oMTransaction.CATEGORY = oData.CATEGORY;
                    oMTransaction.AUTHOR = oData.AUTHOR;
                    oMTransaction.PUBLISH_DATE = oData.PUBLISH_DATE;
                    oMTransaction.ISBN_NUMBER = oData.ISBN_NUMBER;
                    oMTransaction.LOCATION = oData.LOCATION;
                    oMTransaction.BOOK_PRICE = oData.BOOK_PRICE;
                    oMTransaction.RENT_PRICE = oData.RENT_PRICE;
                    oMTransaction.DUE_INTEREST = oData.DUE_INTEREST;
                    oMTransaction.LD_INTEREST = oData.LD_INTEREST;
                    oMTransaction.TOTAL_QTY = oData.TOTAL_QTY;
                    oMTransaction.TOTAL_DAYS = oData.TOTAL_DAYS;
                    oMTransaction.ADDED_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                    oMTransaction.ADDED_BY = eVariable.sUsername;
                    oMTransaction.TRANSACTION_NO = eVariable.sTransactionNo;
                    

                    oBook.CheckOutBook(oMTransaction);                    
                    
                }

                oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.TRANSACTION_HAS_BEEN_SUCESSFULLY_SAVE.ToString().Replace("_", " "));
                iPaymentWindow.clearText();
                oFrmMsgBox.ShowDialog();
                eVariable.ClearText(pnlMain);
                dgBooks.Rows.Clear();
            }
        }

     
        private void dgBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgBooks_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void frmCheckOutBook_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == 27)
            {
                iGridControl.Visible = false;
            }
        }                        
    }


}
