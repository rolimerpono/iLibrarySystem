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
    public partial class frmPayBook : Form
    {
        CustomWindow.frmInfoMsgBox oFrmMsgBox;

        Model.Borrower oMBorrower = new Model.Borrower();
        DataAccess.Borrower oBorrower = new DataAccess.Borrower();
        DataAccess.Book oBook = new DataAccess.Book();


        public delegate void GetDataRecordFunction(List<Model.Transaction> oMTransactionList);
        public event GetDataRecordFunction GetDataRecordFunctionPointer;

        Model.Transaction oMTransaction = new Model.Transaction();
        List<Model.Transaction> oMTransactionList = new List<Model.Transaction>();

        private double? dTotalAmount = 0;
        private double? dReceiveAmount = 0;

        ePublicVariable.eVariable.FIND_BOOK oTranType;
        private int iBookCount = 0;

        public frmPayBook()
        {
            InitializeComponent();

            GetDataRecordFunctionPointer += new GetDataRecordFunction(GetRecord);
            iGridControl.GetDataRecordList = GetDataRecordFunctionPointer;

            eVariable.DisableKeyPress(pnlMain);

        }

        public frmPayBook(Model.Borrower oData, ePublicVariable.eVariable.FIND_BOOK oType)
        {
            InitializeComponent();

            GetDataRecordFunctionPointer += new GetDataRecordFunction(GetRecord);
            iGridControl.GetDataRecordList = GetDataRecordFunctionPointer;

            eVariable.DisableKeyPress(pnlMain);
        

            oMBorrower = oData;
            oTranType = oType;
            eVariable.sBorrowerID = oData.PERSON_ID;
            AutoFillBorrower();
        }

        private void AutoFillBorrower()
        {
            oBorrower = new DataAccess.Borrower();
            foreach (DataRow row in oBorrower.GetRecords(eVariable.FIND_BORROWER.BORROWER_ID, oMBorrower.PERSON_ID).Rows)
            {
                txtBorrowerID.Text = row[0].ToString();
                txtFulllname.Text = row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString();
            }
            AutoFillBook();
        }

        private void AutoFillBook()
        {
            dgBooks.Rows.Clear();
            oBook = new DataAccess.Book();
            Model.Transaction oRetain = new Model.Transaction();
            int iCounter = 0;
            //if (oTranType == eVariable.FIND_BOOK.BOOK_BORROWED)
            //{
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
                //oMTransaction.TOTAL_QTY = row[11].ToString();
                oMTransaction.TOTAL_DAYS = row[12].ToString();
                oMTransaction.ADDED_DATE = row[13].ToString();
                oMTransaction.BOOK_NO = row[14].ToString();
                oMTransaction.ISBN_NUMBER = row[15].ToString();
                oMTransaction.BFLAG = true;



                oMTransactionList.Add(oMTransaction);
                iCounter = oMTransactionList.Where(fw => fw.BOOK_ID == row[0].ToString()).Count();
                oMTransactionList.Where(w => w.BOOK_ID == row[0].ToString()).ToList().ForEach(i => i.TOTAL_QTY = iCounter.ToString());
            }
            //}


            LoadRecords();
        }

        void LoadRecords()
        {
          
            dgBooks.Rows.Clear();
            if (oTranType == eVariable.FIND_BOOK.BOOK_BORROWED)
            {
                btnBrowse.Enabled = false;
            }
            foreach (Model.Transaction oData in oMTransactionList)
            {
                if (!dgBooks.Rows.Cast<DataGridViewRow>().Any(r => r.Cells[0].Value.Equals(oData.BOOK_ID)))
                {
                    dgBooks.Rows.Add(oData.BOOK_ID, oData.TITLE, oData.SUBJECT, oData.ADDED_DATE, oData.BOOK_PRICE, oData.RENT_PRICE, oData.DUE_INTEREST, oData.LD_INTEREST, oData.TOTAL_QTY, oData.TOTAL_DAYS);
                    
                }
            }
            updatePaymentWindow();

        }

        public void GetRecord(List<Model.Transaction> oMTransList)
        {
            oMTransactionList = oMTransList;
            updatePaymentWindow();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (oMTransactionList.Count > 0)
            {
                if (dTotalAmount > iPaymentWindow.ReceiveAmount)
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE PAY EXACT AMOUNT.");
                    oFrmMsgBox.ShowDialog();
                    return;
                }
                
                if (oMTransactionList.Where(fw => fw.BFLAG == true).Count()==0)
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE SELECT A BOOK NUMBER TO PAY.");
                    oFrmMsgBox.ShowDialog();
                    return; 
                }

                foreach (var oItem in oMTransactionList)
                {

                    oBook = new DataAccess.Book();
                    oMTransaction = new Model.Transaction();
                    oMTransaction.PERSON_ID = txtBorrowerID.Text;
                    oMTransaction.BOOK_ID = oItem.BOOK_ID;
                    oMTransaction.BOOK_NO = oItem.BOOK_NO;
                    oMTransaction.TOTAL_AMOUNT = dTotalAmount;
                    oMTransaction.REMARKS = rdDamage.Checked == true ? "DAMAGE" : "LOST";
                    oMTransaction.STATUS = "INACTIVE";
                    oBook.ReturnBook(oMTransaction);
                }

                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("TRANSACTION HAS BEEN SUCESSFULLY SAVED");
                iPaymentWindow.clearText();
                oFrmMsgBox.ShowDialog();
            }
            else
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE SELECT A RECORD TO RETURN.");
                oFrmMsgBox.ShowDialog();
            }
        }

        private void lblMClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            BrowseData.frmSearch oFrm = new BrowseData.frmSearch();
            oFrm.oFilterFindOption = ePublicVariable.eVariable.FIND_OPTION.BORROWER;
            oFrm.oFormName = ePublicVariable.eVariable.FORM_NAME.PAY_BOOK;
            oFrm.StartPosition = FormStartPosition.CenterScreen;
            oFrm.ShowDialog();
            if (oFrm.oMBorrower.PERSON_ID != null)
            {
                txtBorrowerID.Text = oFrm.oMBorrower.PERSON_ID;
                txtFulllname.Text = oFrm.oMBorrower.GetFullName;
                iGridControl.ClearRecordList();
            }
        }

        private void txtBorrowerID_TextChanged(object sender, EventArgs e)
        {
            eVariable.sBorrowerID = txtBorrowerID.Text;
            AutoFillBook();
      
        }

        private void txtBorrowerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtFulllname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgBooks.Rows.Count > 0)
            {
                if (e.ColumnIndex == 10 && e.RowIndex >= 0)
                {
                    oMTransaction = new Model.Transaction();
                    oMTransaction.PERSON_ID = txtBorrowerID.Text;
                    oMTransaction.BOOK_ID = dgBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
                    oMTransaction.TITLE = dgBooks.Rows[e.RowIndex].Cells[1].Value.ToString();
                    oMTransaction.SUBJECT = dgBooks.Rows[e.RowIndex].Cells[2].Value.ToString();
                    oMTransaction.ADDED_DATE = dgBooks.Rows[e.RowIndex].Cells[3].Value.ToString();
                    oMTransaction.BOOK_PRICE = dgBooks.Rows[e.RowIndex].Cells[4].Value.ToString();
                    oMTransaction.RENT_PRICE = dgBooks.Rows[e.RowIndex].Cells[5].Value.ToString();
                    oMTransaction.DUE_INTEREST = Convert.ToDouble(dgBooks.Rows[e.RowIndex].Cells[6].Value);
                    oMTransaction.LD_INTEREST = Convert.ToDouble(dgBooks.Rows[e.RowIndex].Cells[7].Value);
                    oMTransaction.TOTAL_QTY = dgBooks.Rows[e.RowIndex].Cells[8].Value.ToString();
                    oMTransaction.TOTAL_DAYS = dgBooks.Rows[e.RowIndex].Cells[9].Value.ToString();



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

        private void updatePaymentWindow()
        {
            iPaymentWindow.clearText();
            iPaymentWindow.TransactionList = oMTransactionList;
            iPaymentWindow.TranType = global::iPaymentWindow.iPaymentWindow.TransactionType.Pay;
            iPaymentWindow.DisplayDetails();
            dTotalAmount = iPaymentWindow.TotalDue;
            dReceiveAmount = iPaymentWindow.ReceiveAmount;
        }

        private void dgBooks_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgBooks.Rows.Count > 0)
            {
                oMTransaction = new Model.Transaction();
                oMTransaction.PERSON_ID = txtBorrowerID.Text;
                oMTransaction.BOOK_ID = dgBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


    }
}
