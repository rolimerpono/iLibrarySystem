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
    public partial class frmBorrowBook : Form
    {


        public delegate void GetDataRecordFunction(List<Model.Transaction> oMTransactionList);
        public event GetDataRecordFunction GetDataRecordFunctionPointer;


        Model.Transaction oMTransaction = new Model.Transaction();
        List<Model.Transaction> oMTransactionList = new List<Model.Transaction>();
        List<Model.Transaction> oMTransactionNoList = new List<Model.Transaction>();
        Model.Borrower oMBorrower = new Model.Borrower();

        DataAccess.Borrower oBorrower = new DataAccess.Borrower();
        DataAccess.Book oBook = new DataAccess.Book();

        CustomWindow.frmInfoMsgBox oFrmMsgBox;
        CustomWindow.frmMsgBoxQuery oFrmMsgBoxQuery;

        CommonFunction.CommonFunction oCommonFunction;

        private ePublicVariable.eVariable.FIND_BOOK oTranType;

        public frmBorrowBook()
        {
            InitializeComponent();

            GetDataRecordFunctionPointer += new GetDataRecordFunction(GetRecord);
            iGridControl.GetDataRecordList = GetDataRecordFunctionPointer;

            foreach (var o in pnlMain.Controls.OfType<TextBox>().ToList())
            {
                o.KeyPress += TextKeyPress;

                if (!o.Name.Contains("Address"))
                {
                    o.KeyDown += TextKeyDown;
                }
            }
        }

        public frmBorrowBook(Model.Borrower oData, ePublicVariable.eVariable.FIND_BOOK oType)
        {
            InitializeComponent();

            GetDataRecordFunctionPointer += new GetDataRecordFunction(GetRecord);
            iGridControl.GetDataRecordList = GetDataRecordFunctionPointer;

            foreach (var o in pnlMain.Controls.OfType<TextBox>().ToList())
            {
                o.KeyPress += TextKeyPress;

                if (!o.Name.Contains("ADDRESS"))
                {
                    o.KeyDown += TextKeyDown;
                }
                
            }
            oTranType = oType;
            oMBorrower = oData;
            eVariable.sBorrowerID = oMBorrower.PERSON_ID;
            AutoFillBorrower();
            
        }

        void TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                   
                e.SuppressKeyPress = true;
            }
        }

        private void AutoFillBorrower()
        {
            oBorrower = new DataAccess.Borrower();
            foreach (DataRow row in oBorrower.GetBorrowerTransaction(eVariable.FIND_BOOK.BOOK_REQUESTED, eVariable.sBorrowerID).Rows)
            {
                txtBorrowerID.Text = row[0].ToString();
                txtFname.Text = row[1].ToString();
                txtMname.Text = row[2].ToString();
                txtLname.Text = row[3].ToString();
                txtBirthDate.Text = row[4].ToString();
                txtAge.Text = row[5].ToString();
                txtContactNo.Text = row[6].ToString();
                txtAddress.Text = row[7].ToString();

                eVariable.sBorrowerID = txtBorrowerID.Text;
                eVariable.FirstName = txtFname.Text;
                eVariable.MiddleName = txtMname.Text;
                eVariable.LastName = txtLname.Text;
            }
            AutoFillBook();
        }      

        private void AutoFillBook()
        {
            dgBooks.Rows.Clear();
            oBook = new DataAccess.Book();
            Model.Transaction oRetain = new Model.Transaction();
            int iCounter = 0;
            if (oTranType == eVariable.FIND_BOOK.BOOK_REQUESTED)
            {
                foreach (DataRow row in oBook.GetTransactionBookRecordPerBorrowerNotSort(eVariable.FIND_BOOK.BOOK_REQUESTED, eVariable.sBorrowerID).Rows)
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
                    oMTransactionNoList = oMTransactionList;                  
                }
            }

            
            LoadRecords();            
        }

        void LoadRecords()
        {

            dgBooks.Rows.Clear();

            if (oTranType == eVariable.FIND_BOOK.BOOK_REQUESTED)
            {
                dgBooks.Columns[12].Visible = false;
                btnBrowseBorrower.Enabled = false;
                btnBrowse.Enabled = false;
            }
            foreach (Model.Transaction oData in oMTransactionList)
            {
                if (!dgBooks.Rows.Cast<DataGridViewRow>().Any(r => r.Cells[0].Value.Equals(oData.BOOK_ID)))
                {                   
                    dgBooks.Rows.Add(oData.BOOK_ID, oData.TITLE, oData.SUBJECT, oData.CATEGORY, oData.AUTHOR, oData.PUBLISH_DATE,oData.LOCATION, oData.BOOK_PRICE, oData.RENT_PRICE, oData.TOTAL_QTY, oData.TOTAL_DAYS);                    
                }
            }
        }

        public void GetRecord(List<Model.Transaction> oMTransList)
        {
            
            oMTransactionNoList = oMTransList;

        }

        void TextKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            BrowseData.frmSearch oFrm = new BrowseData.frmSearch();
            oFrm.oFilterFindOption = ePublicVariable.eVariable.FIND_OPTION.BOOKS;
            oFrm.oFilterBook = eVariable.FILTER_BOOK.BOOK_TITLE;
            oFrm.StartPosition = FormStartPosition.CenterScreen;
            oFrm.ShowDialog();

            if (dgBooks.Rows.Count > 0)
            {
                if (dgBooks.Rows.Cast<DataGridViewRow>().Any(r => r.Cells[0].Value.Equals(oFrm.oMBook.BOOK_ID)))
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("RECORD ALREADY EXISTS.");
                    oFrmMsgBox.ShowDialog();
                    return;
                }
            }

            dgBooks.Rows.Add(oFrm.oMBook.BOOK_ID, oFrm.oMBook.TITLE, oFrm.oMBook.SUBJECT, oFrm.oMBook.CATEGORY, oFrm.oMBook.AUTHOR, oFrm.oMBook.PUBLISH_DATE, oFrm.oMBook.LOCATION, oFrm.oMBook.BOOK_PRICE, oFrm.oMBook.RENT_PRICE, 1, 1);                            
          
            ChangeCellGridColor();
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        public void ChangeCellGridColor()
        {
            for (int i = 0; i < dgBooks.Rows.Count; ++i)
            {
                dgBooks.Rows[i].Cells[9].Style.ForeColor = Color.Black;
                dgBooks.Rows[i].Cells[9].Style.BackColor = Color.White;
                dgBooks.Rows[i].Cells[9].Style.SelectionForeColor = Color.Black;
                dgBooks.Rows[i].Cells[9].Style.SelectionBackColor = Color.White;

                dgBooks.Rows[i].Cells[10].Style.ForeColor = Color.Black;
                dgBooks.Rows[i].Cells[10].Style.BackColor = Color.White;
                dgBooks.Rows[i].Cells[10].Style.SelectionForeColor = Color.Black;
                dgBooks.Rows[i].Cells[10].Style.SelectionBackColor = Color.White;

                dgBooks.Rows[i].Cells[11].Style.ForeColor = Color.Black;
                dgBooks.Rows[i].Cells[11].Style.BackColor = Color.White;
                dgBooks.Rows[i].Cells[11].Style.SelectionForeColor = Color.Black;
                dgBooks.Rows[i].Cells[11].Style.SelectionBackColor = Color.White;

                dgBooks.Rows[i].Cells[12].Style.ForeColor = Color.Black;
                dgBooks.Rows[i].Cells[12].Style.BackColor = Color.White;
                dgBooks.Rows[i].Cells[12].Style.SelectionForeColor = Color.Black;
                dgBooks.Rows[i].Cells[12].Style.SelectionBackColor = Color.White;


            }
        }

        private void btnBrowseBorrower_Click(object sender, EventArgs e)
        {
            BrowseData.frmSearch oFrm = new BrowseData.frmSearch();
            oFrm.oFilterFindOption = ePublicVariable.eVariable.FIND_OPTION.BORROWER;
            oFrm.StartPosition = FormStartPosition.CenterScreen;
            oFrm.ShowDialog();

            oBorrower = new DataAccess.Borrower();
            oMBorrower = new Model.Borrower();
            oMBorrower.PERSON_ID = oFrm.oMBorrower.PERSON_ID;
            if (!oBorrower.HasUnsettledBook(oMBorrower))
            {
                txtBorrowerID.Text = oFrm.oMBorrower.PERSON_ID;
                txtFname.Text = oFrm.oMBorrower.FIRST_NAME;
                txtMname.Text = oFrm.oMBorrower.MIDDLE_NAME;
                txtLname.Text = oFrm.oMBorrower.LAST_NAME;
                txtBirthDate.Text = oFrm.oMBorrower.DOB;
                txtAge.Text = oFrm.oMBorrower.AGE;
                txtContactNo.Text = oFrm.oMBorrower.CONTACT_NO;
                txtAddress.Text = oFrm.oMBorrower.ADDRESS;
            }
            else
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("THIS BORROWER HAS PENDING UNSETTLED TRANSACTION. PLEASE RETURN FIRST THE BOOK.");
                oFrmMsgBox.ShowDialog();              
            }
        }

        

        private void btnContinue_Click(object sender, EventArgs e)
        {
            int iDaysCount = 0;
            int iBookCount = 0;
            if (txtBorrowerID.Text.Trim() == string.Empty || dgBooks.Rows.Count == 0)
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("ALL FIELDS ARE REQUIRED AND PLEASE BROWSE FIRST BOOK TO BORROW.");
                oFrmMsgBox.ShowDialog();
                return;
            }

            if (iGridControl.Visible)
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE CLOSE FIRST ISBN PANEL.");
                oFrmMsgBox.ShowDialog();
                return;
            }

            foreach (DataGridViewRow row in dgBooks.Rows)
            {
                if (Convert.ToInt32(row.Cells[9].Value) == 0)
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE ENTER NUMBER OF COPIE(S) OF BOOK. THANK YOU.");
                    oFrmMsgBox.ShowDialog();
                    return;
                }

                if (Convert.ToInt32(row.Cells[10].Value) == 0)
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE ENTER NUMBER OF DAY(S) TO RENT. THANK YOU.");
                    oFrmMsgBox.ShowDialog();
                    return;
                }
            }

            foreach (DataGridViewRow row in dgBooks.Rows)
            {
                iBookCount += Convert.ToInt32(row.Cells[9].Value);
            }

            if (oMTransactionNoList.Count != iBookCount || oMTransactionNoList.Count == 0)
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE ENTER BOOK NUMBER.");
                oFrmMsgBox.ShowDialog();
                return;
            } 

            foreach (var oData in oMTransactionNoList)
            {
                iDaysCount = Convert.ToInt32(oData.TOTAL_DAYS);


                if (iBookCount > Convert.ToInt32(5))
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("TOTAL BOOK COUNT TO BORROW EXECEEDED!");
                    oFrmMsgBox.ShowDialog();
                    return;
                }
                if (iDaysCount > Convert.ToInt32(7))
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("TOTAL DAYS COUNT TO BORROW EXECEEDED!");
                    oFrmMsgBox.ShowDialog();
                    return;
                }
            }

            oMTransactionList = new List<Model.Transaction>();
            foreach (Model.Transaction oData in oMTransactionNoList)
            {
                oMTransaction = new Model.Transaction();

                oMTransaction.PERSON_ID = txtBorrowerID.Text;
                oMTransaction.FIRST_NAME = txtFname.Text;
                oMTransaction.MIDDLE_NAME = txtMname.Text;
                oMTransaction.LAST_NAME = txtLname.Text;


                oMTransaction.BOOK_ID = oData.BOOK_ID;
                oMTransaction.BOOK_NO = oData.BOOK_NO;
                oMTransaction.TITLE = oData.TITLE;
                oMTransaction.SUBJECT = oData.SUBJECT;
                oMTransaction.CATEGORY = oData.CATEGORY;
                oMTransaction.AUTHOR = oData.AUTHOR;
                oMTransaction.PUBLISH_DATE = oData.PUBLISH_DATE;
                oMTransaction.ISBN_NUMBER = oData.ISBN_NUMBER;
                oMTransaction.LOCATION = oData.LOCATION;
                oMTransaction.ADDED_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                oMTransaction.LD_INTEREST = oData.LD_INTEREST;
                oMTransaction.DUE_INTEREST = oData.DUE_INTEREST;
                oMTransaction.BOOK_PRICE = oData.BOOK_PRICE;
                oMTransaction.RENT_PRICE = oData.RENT_PRICE;
                oMTransaction.TOTAL_QTY = oData.TOTAL_QTY;
                oMTransaction.TOTAL_DAYS = oData.TOTAL_DAYS;

                oMTransactionList.Add(oMTransaction);
            }


            Forms.frmCheckOutBook oFrm = new frmCheckOutBook(this, oMTransactionList);
            oFrm.ShowDialog();
            Close();

            
        }

        private void dgBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgBooks.Rows.Count > 0)
                {
                    ChangeCellGridColor();
                    DatagridSelect(sender, e);

                    if (e.ColumnIndex == 11 && e.RowIndex >= 0)
                    {
                        if (oTranType == eVariable.FIND_BOOK.BOOK_REQUESTED)
                        {
                            iGridControl.BookCommonData = oMTransaction;
                            iGridControl.BookListData = oMTransactionNoList;
                            iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.SEARCH_LOCAL_BORROWED_BOOK_ISBN;                                                      
                            iGridControl.SetHeaderVisible = true;
                            iGridControl.Visible = true;
                            iGridControl.PopulateRecord();
                        }
                        else
                        {
                            iGridControl.BookCommonData = oMTransaction;
                            iGridControl.BookListData = oMTransactionNoList;
                            iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.INPUT_BOOK_NO;
                            iGridControl.SetDeleteColumnVisible = true;
                            iGridControl.SetFooterVisible = true;
                            iGridControl.SetHeaderVisible = true;
                            iGridControl.Visible = true;
                            iGridControl.PopulateRecord();
                        }
                    }


                    if (e.ColumnIndex == 12 && e.RowIndex >= 0)
                    {

                        oFrmMsgBoxQuery = new CustomWindow.frmMsgBoxQuery("ARE YOU SURE YOU WANT TO DELETE THIS RECORD?");
                        oFrmMsgBoxQuery.ShowDialog();

                        if (oFrmMsgBoxQuery.sAnswer == "YES")
                        {
                            //var iRemove = oMTransactionNoList.Where(fw => fw.BOOK_ID == eVariable.sBookID); foreach (var iData in iRemove) oMTransactionNoList.Remove(iData);

                            if (oMTransactionNoList.Count > 0)
                            {
                                oMTransactionList.RemoveAt(e.RowIndex);
                            }                  
                            
                            dgBooks.Rows.RemoveAt(e.RowIndex);
                            return;
                        }
                        else
                        {
                            return;
                        }

                    }

                }
            }
            catch (Exception ex)
            { }
        }

        void DatagridSelect(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgBooks.Rows.Count > 0)
                {

                    oMTransaction = new Model.Transaction();

                    #region Borrower Data
                    oMTransaction.PERSON_ID = txtBorrowerID.Text;
                    oMTransaction.FIRST_NAME = txtFname.Text;
                    oMTransaction.MIDDLE_NAME = txtMname.Text;
                    oMTransaction.LAST_NAME = txtLname.Text;
                    #endregion

                    eVariable.sBookID = dgBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
                    oMTransaction.BOOK_ID = dgBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
                    oMTransaction.TITLE = dgBooks.Rows[e.RowIndex].Cells[1].Value.ToString();
                    oMTransaction.SUBJECT = dgBooks.Rows[e.RowIndex].Cells[2].Value.ToString();
                    oMTransaction.CATEGORY = dgBooks.Rows[e.RowIndex].Cells[3].Value.ToString();
                    oMTransaction.AUTHOR = dgBooks.Rows[e.RowIndex].Cells[4].Value.ToString();
                    oMTransaction.PUBLISH_DATE = dgBooks.Rows[e.RowIndex].Cells[5].Value.ToString();
                    oMTransaction.LOCATION = dgBooks.Rows[e.RowIndex].Cells[6].Value.ToString();
                    oMTransaction.BOOK_PRICE = dgBooks.Rows[e.RowIndex].Cells[7].Value.ToString();
                    oMTransaction.RENT_PRICE = dgBooks.Rows[e.RowIndex].Cells[8].Value.ToString();
                    oMTransaction.TOTAL_QTY = dgBooks.Rows[e.RowIndex].Cells[9].Value.ToString();
                    oMTransaction.TOTAL_DAYS = dgBooks.Rows[e.RowIndex].Cells[10].Value.ToString();

                }
                else
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE SELECT A RECORD FIRST.");
                    oFrmMsgBox.ShowDialog();
                }

            }
            catch (Exception ex)
            {

            }

        }
     
        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9 || e.ColumnIndex == 10 && e.RowIndex >= 0)
                {
                    if (oTranType != eVariable.FIND_BOOK.BOOK_REQUESTED)
                    {
                        dgBooks.ReadOnly = false;
                        DataGridViewCell cell = dgBooks.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dgBooks.CurrentCell = cell;
                        dgBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                        dgBooks.BeginEdit(true);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9 || e.ColumnIndex == 10 && e.RowIndex >= 0)
                {
                    if (dgBooks.Rows[e.RowIndex].Cells[9].Value == null && dgBooks.Rows[e.RowIndex].Cells[9].Value.ToString().Trim() == String.Empty || Convert.ToInt32(dgBooks.Rows[e.RowIndex].Cells[9].Value) == 0)
                    {
                        oFrmMsgBox = new CustomWindow.frmInfoMsgBox("INVALID INPUT.");
                        oFrmMsgBox.ShowDialog();
                        dgBooks.Rows[e.RowIndex].Cells[9].Value = 1;
                        return;
                    }

                    if (dgBooks.Rows[e.RowIndex].Cells[10].Value == null && dgBooks.Rows[e.RowIndex].Cells[10].Value.ToString().Trim() == String.Empty || Convert.ToInt32(dgBooks.Rows[e.RowIndex].Cells[10].Value) == 0)
                    {
                        oFrmMsgBox = new CustomWindow.frmInfoMsgBox("INVALID INPUT.");
                        oFrmMsgBox.ShowDialog();
                        dgBooks.Rows[e.RowIndex].Cells[10].Value = 1;
                        return;
                    }

                    int iBookCount = 0;
                    foreach (DataGridViewRow row in dgBooks.Rows)
                    {
                        iBookCount += Convert.ToInt32(row.Cells[9].Value);
                    }
                    int i = oMTransactionNoList.Count;
                    while (i > iBookCount)
                    {
                        oMTransactionNoList.RemoveAt(i - 1);
                        i--;
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }

    

        private void dgBooks_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 9 || e.ColumnIndex == 10 && e.RowIndex >= 0)
            {

                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                }

            }
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

        private void dgBooks_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(TextKeyPressData);
            if (dgBooks.CurrentCell.ColumnIndex == 9 || dgBooks.CurrentCell.ColumnIndex == 10)
            {
                TextBox T = e.Control as TextBox;
                if (T != null)
                {
                    T.KeyPress += new KeyPressEventHandler(TextKeyPressData);
                }
            }
        }

        private void frmBorrowBook_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgBooks.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }


        private void clearFields()
        { 
            foreach(Control o in pnlBody.Controls.OfType<TextBox>().ToList())
            {
                o.Text = "";            
            }
            dgBooks.Rows.Clear();
        }

    }
}
