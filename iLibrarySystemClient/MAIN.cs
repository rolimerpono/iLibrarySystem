using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ePublicVariable;
using Model;

namespace iLibrarySystemClient
{
    public partial class MAIN : Form
    {
        public delegate void GetDataRecordFunction(List<Model.Transaction> oMTransactionList);
        public event GetDataRecordFunction GetDataRecordFunctionPointer;

        Model.Policy oMPolicy = new Policy();
        DataAccess.Policy oPolicy = new DataAccess.Policy();

        DataAccess.Borrower oBorrower = new DataAccess.Borrower();
        DataAccess.Book oBook = new DataAccess.Book();
        Model.Transaction oMTransaction  =new Model.Transaction();        
        List<Model.Transaction> oMTransactionList = new List<Model.Transaction>();
        

        CustomWindow.frmInfoMsgBox oFrmMsgBox;
        CustomWindow.frmMsgBoxQuery oFrmMsgBoxQuery;
     
        double iTotalAmount = 0;
        eVariable.FILTER_BOOK oFilterBook;
        
        public MAIN()
        {
            InitializeComponent();

            GetDataRecordFunctionPointer += new GetDataRecordFunction(GetRecord);
            iGridControl.GetDataRecordList = GetDataRecordFunctionPointer;

            eVariable.DisableTextEnterKey(txtBorrowerID);
            eVariable.DisableTextEnterKey(txtSearch);
            eVariable.DisableKeyPress(cboSearchBy);
        }

        public void GetRecord(List<Model.Transaction> oMTransList)
        {
            oMTransactionList = oMTransList;
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }


        void GetPolicy()
        {
            oPolicy = new DataAccess.Policy();
            foreach (DataRow row in oPolicy.GetPolicy("", "").Rows)
            {
                lblDueInterest.Text = row[0].ToString() + " %";
                lblLDInterest.Text = row[1].ToString() + " %" ;
                lblMaxDays.Text = row[2].ToString();
                lblMaxBook.Text = row[3].ToString();
            }
        }

        void LoadRecords()
        {
            oBook = new DataAccess.Book();
            dgDetails.Rows.Clear();
            eVariable.DisableGridColumnSort(dgDetails);
            foreach (DataRow row in oBook.GetBookRecords(oFilterBook,"ACTIVE", txtSearch.Text).Rows)
            {
                dgDetails.Rows.Add(row["BOOK_ID"], row["TITLE"], row["SUBJECT"], row["CATEGORY"], row["AUTHOR"], row["PUBLISH_DATE"], row["BOOK_PRICE"], row["RENT_PRICE"], row["LOCATION"], row["COPIES_AVAILABLE"], row["TOTAL_COPIES"]);
            }

            GetPolicy();
        }

        void DatagridSelect(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgDetails.Rows.Count > 0)
                    {
                        oMTransaction = new Model.Transaction();
                        oMTransaction.BOOK_ID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMTransaction.TITLE = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                        oMTransaction.SUBJECT = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                        oMTransaction.CATEGORY = dgDetails.Rows[e.RowIndex].Cells[3].Value.ToString();
                        oMTransaction.AUTHOR = dgDetails.Rows[e.RowIndex].Cells[4].Value.ToString();
                        oMTransaction.PUBLISH_DATE = dgDetails.Rows[e.RowIndex].Cells[5].Value.ToString();
                        oMTransaction.BOOK_PRICE = dgDetails.Rows[e.RowIndex].Cells[6].Value.ToString();
                        oMTransaction.RENT_PRICE = dgDetails.Rows[e.RowIndex].Cells[7].Value.ToString();
                        oMTransaction.LOCATION = dgDetails.Rows[e.RowIndex].Cells[8].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

        }      

        private void dgDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0 && e.RowIndex >= 0)
            {

                if (txtBorrowerID.Text == string.Empty)
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE ENTER FIRST THE MEMBERSHIP ID FOR VERIFICATION");
                    oFrmMsgBox.ShowDialog();
                    txtBorrowerID.Focus();
                    return;                
                }


                if (lblMemberStatus.Text == "INVALID")
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("THE MEMBERSHIP STATUS IS INVALID.");
                    oFrmMsgBox.ShowDialog();
                    txtBorrowerID.Focus();
                    return;
                }

                DatagridSelect(sender, e);

                if (dgBorrowedBooks.Rows.Cast<DataGridViewRow>().Any(r => r.Cells[0].Value.Equals(oMTransaction.BOOK_ID)))
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("RECORD YOU SELECTED ALREADY EXISTS.");
                    oFrmMsgBox.ShowDialog();
                    return;
                }
                eVariable.DisableGridColumnSort(dgBorrowedBooks);
                dgBorrowedBooks.Rows.Add(oMTransaction.BOOK_ID, oMTransaction.TITLE, oMTransaction.SUBJECT, oMTransaction.CATEGORY, oMTransaction.AUTHOR, oMTransaction.PUBLISH_DATE, oMTransaction.BOOK_PRICE, oMTransaction.RENT_PRICE, oMTransaction.LOCATION, 1, 1);                
                UpdateComputation();
                ChangeCellGridColor();
            }
        }

        private void UpdateComputation()
        {
            iTotalAmount = 0;
            foreach (DataGridViewRow row in dgBorrowedBooks.Rows)
            {
                iTotalAmount += Convert.ToDouble(row.Cells[7].Value) * Convert.ToInt32(row.Cells[9].Value) * Convert.ToInt32(row.Cells[10].Value);
            }
            lblTotalPayment.Text = "P " + String.Format("{0:0.00}",iTotalAmount).ToString();
        }
     

        private void btnCheck_Click(object sender, EventArgs e)
        {                        
            oBorrower = new DataAccess.Borrower();

            if (oBorrower.HasUnsettledBook(txtBorrowerID.Text))
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("THIS BORROWER HAS PENDING UNSETTLED TRANSACTION.");
                oFrmMsgBox.ShowDialog();
                txtBorrowerID.Text = string.Empty;
                lblMemberStatus.Text = "";
                return;
            }

            if (oBorrower.IsCustomerMember(txtBorrowerID.Text.Trim()))
            {
                lblMemberStatus.Text = "VALID";
                btnCheck.Enabled = false;
                txtBorrowerID.Enabled = false;
            }
            else
            {
                lblMemberStatus.Text = "INVALID";                
            }            
        }

        private void clearText()
        {
            iTotalAmount = 0;
            lblTotalPayment.Text = "P 0.00";
            dgBorrowedBooks.Rows.Clear();
            oMTransaction = new Transaction();
            oMTransactionList = new List<Transaction>();
            btnCheck.Enabled = true;
            txtBorrowerID.Enabled = true;
            txtBorrowerID.Text = "";
            lblMemberStatus.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgBorrowedBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 11 && e.RowIndex >= 0)
                {
                    DatagridSelectedData(sender, e);

                    iGridControl.BookCommonData = oMTransaction;
                    iGridControl.BookListData = oMTransactionList;
                    iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.INPUT_BOOK_NO;
                    iGridControl.SetDeleteColumnVisible = true;
                    iGridControl.SetFooterVisible = true;
                    iGridControl.SetHeaderVisible = true;
                    iGridControl.Visible = true;
                    iGridControl.PopulateRecord();

                }

                if (e.ColumnIndex == 12 && e.RowIndex >= 0)
                {


                    oFrmMsgBoxQuery = new CustomWindow.frmMsgBoxQuery("ARE YOU SURE YOU WANT TO DELETE THIS RECORD?");
                    oFrmMsgBoxQuery.ShowDialog();

                    if (oFrmMsgBoxQuery.sAnswer == "YES")
                    {

                        if (oMTransactionList.Count > 0)
                        {
                            oMTransactionList.RemoveAt(e.RowIndex);
                        }

                        dgBorrowedBooks.Rows.RemoveAt(e.RowIndex);
                        UpdateComputation();
                    }

                }
                ChangeCellGridColor();
            }
            catch (Exception ex)
            { }
        }

        void DatagridSelectedData(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgBorrowedBooks.Rows.Count > 0)
                    {
                        oMTransaction = new Transaction();

                        #region Borrower Data
                        oMTransaction.PERSON_ID = txtBorrowerID.Text;
                        #endregion

                        eVariable.sBookID = dgBorrowedBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMTransaction.BOOK_ID = dgBorrowedBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMTransaction.TITLE = dgBorrowedBooks.Rows[e.RowIndex].Cells[1].Value.ToString();
                        oMTransaction.SUBJECT = dgBorrowedBooks.Rows[e.RowIndex].Cells[2].Value.ToString();
                        oMTransaction.CATEGORY = dgBorrowedBooks.Rows[e.RowIndex].Cells[3].Value.ToString();
                        oMTransaction.AUTHOR = dgBorrowedBooks.Rows[e.RowIndex].Cells[4].Value.ToString();
                        oMTransaction.PUBLISH_DATE = dgBorrowedBooks.Rows[e.RowIndex].Cells[5].Value.ToString();
                        oMTransaction.BOOK_PRICE = dgBorrowedBooks.Rows[e.RowIndex].Cells[6].Value.ToString();
                        oMTransaction.RENT_PRICE = dgBorrowedBooks.Rows[e.RowIndex].Cells[7].Value.ToString();
                        oMTransaction.LOCATION = dgBorrowedBooks.Rows[e.RowIndex].Cells[8].Value.ToString();
                        oMTransaction.TOTAL_QTY = dgBorrowedBooks.Rows[e.RowIndex].Cells[9].Value.ToString();
                        oMTransaction.TOTAL_DAYS = dgBorrowedBooks.Rows[e.RowIndex].Cells[10].Value.ToString();

                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
                                      
        }

        private void dgBorrowedBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgBorrowedBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9 && e.RowIndex >= 0)
                {
                    dgBorrowedBooks.ReadOnly = false;
                    DataGridViewCell cell = dgBorrowedBooks.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgBorrowedBooks.CurrentCell = cell;
                    dgBorrowedBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    dgBorrowedBooks.BeginEdit(true);
                    UpdateComputation();
                }

                if (e.ColumnIndex == 10 && e.RowIndex >= 0)
                {
                    dgBorrowedBooks.ReadOnly = false;
                    DataGridViewCell cell = dgBorrowedBooks.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgBorrowedBooks.CurrentCell = cell;
                    dgBorrowedBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    dgBorrowedBooks.BeginEdit(true);
                    UpdateComputation();
                }
            }
            catch (Exception ex)
            { }
        }        
       

        private void dgBorrowedBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9 || e.ColumnIndex == 10 && e.RowIndex >= 0)
                {
                    if (dgBorrowedBooks.Rows[e.RowIndex].Cells[9].Value == null || dgBorrowedBooks.Rows[e.RowIndex].Cells[9].Value.ToString().Trim() == String.Empty || Convert.ToInt32(dgBorrowedBooks.Rows[e.RowIndex].Cells[9].Value) == 0)
                    {
                        oFrmMsgBox = new CustomWindow.frmInfoMsgBox("INVALID INPUT.");
                        oFrmMsgBox.ShowDialog();
                        dgBorrowedBooks.Rows[e.RowIndex].Cells[9].Value = 1;
                        return;
                    }

                    if (dgBorrowedBooks.Rows[e.RowIndex].Cells[10].Value == null || dgBorrowedBooks.Rows[e.RowIndex].Cells[10].Value.ToString().Trim() == String.Empty || Convert.ToInt32(dgBorrowedBooks.Rows[e.RowIndex].Cells[10].Value) == 0)
                    {
                        oFrmMsgBox = new CustomWindow.frmInfoMsgBox("INVALID INPUT.");
                        oFrmMsgBox.ShowDialog();
                        dgBorrowedBooks.Rows[e.RowIndex].Cells[10].Value = 1;
                        return;
                    }

                    int iBookCount = 0;
                    foreach (DataGridViewRow row in dgBorrowedBooks.Rows)
                    {
                        iBookCount += Convert.ToInt32(row.Cells[9].Value);
                    }
                    int i = oMTransactionList.Count;
                    while(i > iBookCount)
                    {                     
                        oMTransactionList.RemoveAt(i-1);                        
                        i--;
                    }
                    UpdateComputation();
                }
            }
            catch (Exception ex)
            { }
        }

        private void dgBorrowedBooks_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ChangeCellGridColor();
                DatagridSelectedData(sender, e);
            }
            catch (Exception ex)
            { }
        }        
   
        public void ChangeCellGridColor()
        {
            for (int i = 0; i < dgBorrowedBooks.Rows.Count; ++i)
            {
                dgBorrowedBooks.Rows[i].Cells[9].Style.ForeColor = Color.Black;
                dgBorrowedBooks.Rows[i].Cells[9].Style.BackColor = Color.White;
                dgBorrowedBooks.Rows[i].Cells[9].Style.SelectionForeColor = Color.Black;
                dgBorrowedBooks.Rows[i].Cells[9].Style.SelectionBackColor = Color.White;

                dgBorrowedBooks.Rows[i].Cells[10].Style.ForeColor = Color.Black;
                dgBorrowedBooks.Rows[i].Cells[10].Style.BackColor = Color.White;
                dgBorrowedBooks.Rows[i].Cells[10].Style.SelectionForeColor = Color.Black;
                dgBorrowedBooks.Rows[i].Cells[10].Style.SelectionBackColor = Color.White;

                dgBorrowedBooks.Rows[i].Cells[11].Style.ForeColor = Color.Black;
                dgBorrowedBooks.Rows[i].Cells[11].Style.BackColor = Color.White;
                dgBorrowedBooks.Rows[i].Cells[11].Style.SelectionForeColor = Color.Black;
                dgBorrowedBooks.Rows[i].Cells[11].Style.SelectionBackColor = Color.White;

                dgBorrowedBooks.Rows[i].Cells[12].Style.ForeColor = Color.Black;
                dgBorrowedBooks.Rows[i].Cells[12].Style.BackColor = Color.White;
                dgBorrowedBooks.Rows[i].Cells[12].Style.SelectionForeColor = Color.Black;
                dgBorrowedBooks.Rows[i].Cells[12].Style.SelectionBackColor = Color.White;
            }
        }

        private void dgISBN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int iDaysCount = 0;
            int iBookCount = 0;

            try
            {       
                if (iGridControl.Visible == true)
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE CLOSE THE ISBN LIST.");
                    oFrmMsgBox.ShowDialog();
                    return;                
                }

                
                foreach (DataGridViewRow row in dgBorrowedBooks.Rows)
                {
                    iBookCount += Convert.ToInt32(row.Cells[9].Value);                
                }

                if (oMTransactionList.Count != iBookCount || oMTransactionList.Count == 0)
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE ENTER BOOK NUMBER.");
                    oFrmMsgBox.ShowDialog();
                    return;                
                }                          

                foreach (var oData in oMTransactionList)
                {
                    iDaysCount = Convert.ToInt32(oData.TOTAL_DAYS);
                    

                    if (iBookCount > Convert.ToInt32(lblMaxBook.Text))
                    {
                        oFrmMsgBox = new CustomWindow.frmInfoMsgBox("TOTAL BOOK COUNT TO BORROW EXECEEDED!");
                        oFrmMsgBox.ShowDialog();
                        return;
                    }
                    if (iDaysCount > Convert.ToInt32(lblMaxDays.Text))
                    {
                        oFrmMsgBox = new CustomWindow.frmInfoMsgBox("TOTAL DAYS COUNT TO BORROW EXECEEDED!");
                        oFrmMsgBox.ShowDialog();
                        return;
                    }
                }
                oBorrower = new DataAccess.Borrower();

                if (dgBorrowedBooks.Rows.Count > 0)
                {
                    oFrmMsgBoxQuery = new CustomWindow.frmMsgBoxQuery("ARE YOU SURE YOU WANT TO PROCEED TO THE TRANSACTION?");
                    oFrmMsgBoxQuery.ShowDialog();

                    if (oFrmMsgBoxQuery.sAnswer == "YES")
                    {
                        foreach (Model.Transaction oData in oMTransactionList)
                        {
                            oMTransaction = new Model.Transaction();
                            oBook = new DataAccess.Book();
                            oMTransaction.BOOK_ID = oData.BOOK_ID;
                            oMTransaction.PERSON_ID = txtBorrowerID.Text;
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
                            oMTransaction.ADDED_BY = txtBorrowerID.Text;
                            oMTransaction.STATUS = "REQUEST";
                            oBook.RequestBook(oMTransaction);

                        }


                        oFrmMsgBox = new CustomWindow.frmInfoMsgBox("RECORD HAS BEEN SUCCESSFULLY REQUESTED.");
                        oFrmMsgBox.ShowDialog();
                        LoadRecords();
                        clearText();
                    }

                }
            }
            catch (Exception ex)
            { }
        }

        private void dgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void dgBorrowedBooks_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress += new KeyPressEventHandler(TextKeyPressData);
                if (dgBorrowedBooks.CurrentCell.ColumnIndex == 9 || dgBorrowedBooks.CurrentCell.ColumnIndex == 10)
                {
                    TextBox T = e.Control as TextBox;
                    if (T != null)
                    {
                        T.KeyPress += new KeyPressEventHandler(TextKeyPressData);
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        void TextKeyPressData(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (e.KeyChar < '0' || e.KeyChar > '9')
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void MAIN_Load(object sender, EventArgs e)
        {
            LoadRecords();
            oFilterBook = eVariable.FILTER_BOOK.BOOK_TITLE;
        }

        private void cboSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboSearchBy.Text)
            {
                case "TITLE":
                    oFilterBook = ePublicVariable.eVariable.FILTER_BOOK.BOOK_TITLE;
                    break;
                case "AUTHOR":
                    oFilterBook = ePublicVariable.eVariable.FILTER_BOOK.BOOK_AUTHOR;
                    break;
                case "CATEGORY":
                    oFilterBook = ePublicVariable.eVariable.FILTER_BOOK.BOOK_CATEGORY;
                    break;
                default:
                    oFilterBook = ePublicVariable.eVariable.FILTER_BOOK.BOOK_TITLE;
                    break;
            }
        }        
       
    }
}
