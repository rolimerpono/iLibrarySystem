using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using ePublicVariable;

namespace iLibrarySystem.Forms
{
    public partial class frmBookEntry : Form
    {

        DataAccess.Book oBook = new DataAccess.Book();
        CommonFunction.CommonFunction oCommonFunction;

        public Model.Borrower oMBorrower = new Model.Borrower();
        public Model.Transaction oMTransaction = new Model.Transaction();
        public List<Model.Transaction> oMTransactionList = new List<Model.Transaction>();
        public Model.Category oMCategory = new Model.Category();
        public Model.Author oMAuthor = new Model.Author();


        
        #region Forms
        frmBookList oFrmBookList;
        CustomWindow.frmInfoMsgBox oFrmMsgBox;
        CustomWindow.frmMsgBoxQuery oFrmMsgBoxQuery;
        #endregion

        public frmBookEntry()
        {
            InitializeComponent();    
        }


        public frmBookEntry(Forms.frmBookList oFrmList)
        {
            InitializeComponent();
            oFrmBookList = oFrmList;
            GetBookID();
            
            eVariable.m_ActionType = eVariable.ACTION_TYPE.ADD;

            eVariable.DisableTextEnterKey(pnlMain);
            eVariable.DisableTextEnterKey(pnlOther);
            eVariable.DisableKeyPress(txtAuthor);
            eVariable.DisableKeyPress(txtLocation);
            eVariable.DisableKeyPress(txtCategory);

            eVariable.ValidAmount(txtBookPrice);
            eVariable.ValidAmount(txtRentPrice);
            
        } 

        public frmBookEntry(frmBookList oFrmList, Model.Transaction oTrans)
        {
            InitializeComponent();
            oMTransaction = oTrans;                        
            oFrmBookList = oFrmList;

            eVariable.DisableTextEnterKey(pnlMain);
            eVariable.DisableTextEnterKey(pnlOther);
            eVariable.m_ActionType = eVariable.ACTION_TYPE.EDIT;
            eVariable.DisableKeyPress(txtAuthor);
            eVariable.DisableKeyPress(txtLocation);
            eVariable.DisableKeyPress(txtCategory);

            eVariable.ValidAmount(txtBookPrice);
            eVariable.ValidAmount(txtRentPrice);
        }     


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowseAuthor_Click(object sender, EventArgs e)
        {
            BrowseData.frmSearchList oFrm = new BrowseData.frmSearchList();
            oFrm.oFindOption = BrowseData.frmSearchList.FIND_OPTION.AUTHOR;
            oFrm.StartPosition = FormStartPosition.CenterScreen;
            oFrm.ShowDialog();

            if (oFrm.oMAuthor.PERSON_ID != string.Empty && oFrm.oMAuthor.STATUS.Trim() == "ACTIVE")
            {
                txtAuthor.Text = oFrm.oMAuthor.FIRST_NAME + " " + oFrm.oMAuthor.MIDDLE_NAME + " " + oFrm.oMAuthor.LAST_NAME;
            }
        }

        void EnableDisableControl(Boolean bFlag)
        {
            chkAutoNumber.Enabled = bFlag;
            lblISBN.Enabled = bFlag;
            txtBookNo.Enabled = bFlag;
            txtISBN.Enabled = bFlag;
            btnAdd.Enabled = bFlag; 
        }

        private void frmBookEntry_Load(object sender, EventArgs e)
        {
            
            if (eVariable.m_ActionType == eVariable.ACTION_TYPE.EDIT)
            {                              
                eVariable.sBookID = oMTransaction.BOOK_ID;
                txtTitle.Text = oMTransaction.TITLE;
                txtSubject.Text = oMTransaction.SUBJECT;
                txtCategory.Text = oMTransaction.CATEGORY;
                txtAuthor.Text = oMTransaction.AUTHOR;
                dtDatePublish.Value = Convert.ToDateTime(oMTransaction.PUBLISH_DATE);
                txtLocation.Text = oMTransaction.LOCATION;
                txtBookPrice.Text = oMTransaction.BOOK_PRICE;
                txtRentPrice.Text = oMTransaction.RENT_PRICE;

                FillRecordList();
                FillRecords();
                EnableDisableControl(false);                
                chkAutoNumber.Enabled = false;                

            }
            else
            {                
                EnableDisableControl(true);
                GetBookID();              
                
            }

        }
       
        void FillRecordList()
        {
            oMTransactionList = new List<Model.Transaction>();
            oBook = new DataAccess.Book();
            foreach (DataRow row in oBook.GetBookRecords(eVariable.FILTER_BOOK.BOOK_DEFAULT,"ACTIVE", eVariable.sBookID).Rows)
            {
                oMTransaction = new Model.Transaction();
                oMTransaction.BOOK_ID = row[0].ToString();
                oMTransaction.BOOK_NO = row[1].ToString();
                oMTransaction.TITLE = row[2].ToString();
                oMTransaction.SUBJECT = row[3].ToString();
                oMTransaction.CATEGORY = row[4].ToString();
                oMTransaction.AUTHOR = row[5].ToString();
                oMTransaction.PUBLISH_DATE = row[6].ToString();
                oMTransaction.ISBN_NUMBER = row[7].ToString();
                oMTransaction.LOCATION = row[8].ToString();

                oMTransaction.BOOK_PRICE = row[9].ToString();
                oMTransaction.RENT_PRICE = row[10].ToString();
                oMTransaction.ADDED_DATE = row[11].ToString();
                oMTransaction.ADDED_BY = row[12].ToString();
                oMTransaction.MODIFIED_DATE = row[13].ToString();
                oMTransaction.MODIFIED_BY = row[14].ToString();
                oMTransaction.REMARKS = row[15].ToString();
                oMTransaction.STATUS = row[16].ToString();

                oMTransactionList.Add(oMTransaction);

            }
        }

        void FillRecords()        
        {
            iGridControl.BookCommonData = oMTransaction;
            iGridControl.BookListData = oMTransactionList;
            iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.SEARCH_LOCAL_BORROWED_BOOK_ISBN;
            iGridControl.SetHeaderVisible = false;
            iGridControl.SetRemaksColumnVisible = true;
            iGridControl.SetStatusColumnVisible = true;            
            iGridControl.PopulateRecord();
            iGridControl.Visible = true;
        }

        void GetBookID()
        {
            oBook = new DataAccess.Book();
            eVariable.sBookID = (oBook.GetBookID() + 1).ToString();
        }     

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (eVariable.IsFieldEmpty(pnlMain))
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.ALL_FIELDS_ARE_REQUIRED.ToString().Replace("_", " "));
                oFrmMsgBox.ShowDialog();
                return;
            }        

            if (eVariable.m_ActionType == eVariable.ACTION_TYPE.ADD)
            {

                foreach (var oData in oMTransactionList)
                {
                    oMTransaction = new Model.Transaction();
                    oBook = new DataAccess.Book();

                    oMTransaction.BOOK_ID = eVariable.sBookID;
                    oMTransaction.BOOK_NO = oData.BOOK_NO;
                    oMTransaction.TITLE = txtTitle.Text;
                    oMTransaction.SUBJECT = txtSubject.Text;
                    oMTransaction.CATEGORY = txtCategory.Text;
                    oMTransaction.AUTHOR = txtAuthor.Text;
                    oMTransaction.PUBLISH_DATE = dtDatePublish.Value.ToString("yyyy-MM-dd");
                    oMTransaction.ISBN_NUMBER = oData.ISBN_NUMBER;
                    oMTransaction.LOCATION = txtLocation.Text;
                    oMTransaction.BOOK_PRICE = txtBookPrice.Text;
                    oMTransaction.RENT_PRICE = txtRentPrice.Text;
                    oMTransaction.ADDED_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                    oMTransaction.ADDED_BY = eVariable.sUsername;
                    oMTransaction.STATUS = "ACTIVE";
                    oBook.InsertBook(oMTransaction);
                    
                }
            }
            else
            {
              
                oMTransaction = new Model.Transaction();
                oBook = new DataAccess.Book();

                oMTransaction.BOOK_ID = eVariable.sBookID;
                oMTransaction.TITLE = txtTitle.Text;
                oMTransaction.SUBJECT = txtSubject.Text;
                oMTransaction.CATEGORY = txtCategory.Text;
                oMTransaction.AUTHOR = txtAuthor.Text;
                oMTransaction.PUBLISH_DATE = dtDatePublish.Value.ToString("yyyy-MM-dd");
                oMTransaction.LOCATION = txtLocation.Text;
                oMTransaction.BOOK_PRICE = txtBookPrice.Text;
                oMTransaction.RENT_PRICE = txtRentPrice.Text;
                oMTransaction.MODIFIED_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                oMTransaction.MODIFIED_BY = eVariable.sUsername;
                oMTransaction.STATUS = "ACTIVE";
                oBook.UpdateBookDetails(oMTransaction);

            }

            oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.RECORD_HAS_BEEN_SUCESSFULLY_SAVED.ToString().Replace("_", " "));
            oFrmMsgBox.ShowDialog();
            oFrmBookList.LoadRecords();
            EDControls(true);            
            
            ResetFields();
        }

        private void ResetFields()
        {
            chkAutoNumber.Enabled = false;
            txtBookNo.Text = string.Empty;
            txtISBN.Text = string.Empty;
            eVariable.m_ActionType = eVariable.ACTION_TYPE.ADD;
            eVariable.iAutoBookNo = 0;            
        }     


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Boolean bFound = false;


            if (!chkAutoNumber.Checked)
            {
                if (txtBookNo.Text.Trim() == string.Empty)
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.PLEASE_ENTER_BOOK_NUMBER.ToString().Replace("_", " "));
                    oFrmMsgBox.ShowDialog();
                    return;
                }
            }

            if (txtISBN.Text.Trim() == string.Empty)
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.PLEASE_ENTER_ISBN_NUMBER.ToString().Replace("_", " "));
                oFrmMsgBox.ShowDialog();
                return;
            }


            oBook = new DataAccess.Book();
            eVariable.sISBN_Number = txtISBN.Text;
            if (oBook.IsBookRecordDataExists(ePublicVariable.eVariable.FIND_TYPE.ISBN_NUMBER, eVariable.sISBN_Number))
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.ISBN_NUMBER_ALREADY_EXISTS.ToString().Replace("_", " "));
                oFrmMsgBox.ShowDialog();
                txtISBN.Focus();
                return;
            }

            if (!chkAutoNumber.Checked)
            {
                eVariable.sBookNumber = txtBookNo.Text;
                if (oBook.IsBookRecordDataExists(eVariable.FIND_TYPE.BOOK_NO, eVariable.sBookNumber.Trim()))
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.BOOK_NUMBER_ALREADY_EXISTS.ToString().Replace("_", " "));
                    oFrmMsgBox.ShowDialog();
                    txtBookNo.Focus();
                    return;
                }
            }
            else
            {           
                eVariable.sBookNumber = GetBookNo(oMTransactionList);                
            }

            bFound = oMTransactionList.Any(fw => fw.BOOK_NO == eVariable.sBookNumber || fw.ISBN_NUMBER == eVariable.sISBN_Number);            

            if (!bFound)
            {
                oMTransactionList.Add(new Model.Transaction { BOOK_ID = eVariable.sBookID, TITLE = txtTitle.Text, SUBJECT = txtSubject.Text, CATEGORY = txtCategory.Text, AUTHOR = txtAuthor.Text, PUBLISH_DATE = dtDatePublish.Value.ToString("yyyy-MM-dd"), LOCATION = txtLocation.Text, BOOK_PRICE = txtBookPrice.Text, RENT_PRICE = txtRentPrice.Text, BOOK_NO = eVariable.sBookNumber, ISBN_NUMBER = eVariable.sISBN_Number, REMARKS = "", STATUS = "ACTIVE" });

                iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.ADD_BOOK_NO;
                iGridControl.BookCommonData = oMTransaction;
                iGridControl.BookListData = oMTransactionList;
                iGridControl.SetDeleteColumnVisible = true;
                iGridControl.SetHeaderVisible = false;              
                iGridControl.PopulateRecord();
                iGridControl.Visible = true;


                txtBookNo.Text = string.Empty;
                txtISBN.Text = string.Empty;
            }
            else
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.RECORD_IS_ALREADY_EXISTS.ToString().Replace("_", " "));
                oFrmMsgBox.ShowDialog();
            }

        }

        private string GetBookNo(List<Model.Transaction> oDataList)
        {
            Boolean bFound = false;

            int iCounter = 0;
            oBook = new DataAccess.Book();
            eVariable.iAutoBookNo = oBook.GetBookNo();
        RETURN_HERE:
            eVariable.iAutoBookNo = eVariable.iAutoBookNo + 1;
        eVariable.sBookNumber = "BKR-" + (eVariable.iAutoBookNo).ToString("0000#");

            if (oBook.IsBookRecordDataExists(ePublicVariable.eVariable.FIND_TYPE.BOOK_NO, eVariable.sBookNumber))
            {
                iCounter++;
                eVariable.iAutoBookNo = eVariable.iAutoBookNo + 1;
                goto RETURN_HERE;
            }

            if (bFound = oMTransactionList.Any(fw => fw.BOOK_NO == eVariable.sBookNumber))
            {
                goto RETURN_HERE;
            }

            return eVariable.sBookNumber;

        }

  

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkAutoNumber_Click(object sender, EventArgs e)
        {
            if (chkAutoNumber.Checked)
            {
                EDControls(false);
                ResetFields();  
            }  
        }
     

        void EDControls(Boolean bFlag)
        {
            txtBookNo.Enabled = bFlag;         
            chkAutoNumber.Enabled = bFlag;
        }

        private void btnBrowseCategory_Click(object sender, EventArgs e)
        {
            BrowseData.frmSearchList oFrm = new BrowseData.frmSearchList();
            oFrm.oFindOption = BrowseData.frmSearchList.FIND_OPTION.CATEGORY;
            oFrm.StartPosition = FormStartPosition.CenterScreen;
            oFrm.ShowDialog();
            if (oFrm.oMCategory.CATEGORY_ID != string.Empty && oFrm.oMCategory.STATUS.Trim() == "ACTIVE")
            {
                txtCategory.Text = oFrm.oMCategory.CATEGORY;
            }
        }

        private void btnBrowseLocation_Click(object sender, EventArgs e)
        {
            BrowseData.frmSearchList oFrm = new BrowseData.frmSearchList();
            oFrm.oFindOption = BrowseData.frmSearchList.FIND_OPTION.LOCATION;
            oFrm.StartPosition = FormStartPosition.CenterScreen;
            oFrm.ShowDialog();

            if (oFrm.oMLocation.LOCATION_ID != string.Empty && oFrm.oMLocation.STATUS.Trim() == "ACTIVE")
            {
                txtLocation.Text = oFrm.oMLocation.LOCATION;
            }
        }       

        private void btnClear_Click(object sender, EventArgs e)
        {
            eVariable.ClearText(pnlMain);
        }      

    }
}
