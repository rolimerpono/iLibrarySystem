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
    public partial class frmAdjustItem : Form
    {

        public delegate void GetDataRecordFunction(Model.Transaction oMTransaction);
        public event GetDataRecordFunction GetDataRecordFunctionPointer;

        public delegate void GetDataRecordFunctionList(Model.Transaction oMTransaction);
        public event GetDataRecordFunctionList GetDataRecordFunctionPointerList;
        
        CustomWindow.frmInfoMsgBox oFrmMsgBox;
        frmBookList oFrmBookLst;
        
        DataAccess.Book oBook = new DataAccess.Book();
        
        Model.Transaction oMTransaction = new Model.Transaction();
        Model.Transaction oMTransactionRecord = new Model.Transaction();
        

        List<Model.Transaction> oMTransactionList = new List<Model.Transaction>();
        List<Model.Transaction> oRecordList = new List<Model.Transaction>();               
           
        
         
        public frmAdjustItem()
        {
            InitializeComponent();

            GetDataRecordFunctionPointerList += new GetDataRecordFunctionList(GetRecord);
            iGridControl.GetDataRecordList = GetDataRecordFunctionPointerList;

            eVariable.DisableTextEnterKey(pnlMain);
            eVariable.DisableTextEnterKey(pnlOther);
        }

        public frmAdjustItem(frmBookList oFrmBook, Model.Transaction oTrans)
        {
            InitializeComponent();

            oFrmBookLst = oFrmBook;
            oMTransaction = oTrans;

            eVariable.DisableTextEnterKey(pnlMain);
            eVariable.DisableTextEnterKey(pnlOther);
            GetDataRecordFunctionPointer += new GetDataRecordFunction(GetRecord);
            iGridControl.GetDataRecord = GetDataRecordFunctionPointer;
        }

        public void GetRecordList(List<Model.Transaction> oTransList)
        {
            oRecordList = oTransList;
        }

        public void GetRecord(Model.Transaction oTrans)
        {
            oMTransactionRecord = oTrans;
        }        
      

        private void btnAdjust_Click(object sender, EventArgs e)
        {

        }

        private void frmAdjustItem_Load(object sender, EventArgs e)
        {
            eVariable.m_ActionType = eVariable.ACTION_TYPE.EDIT;
            LoadRecord();                
        }

        
        private void EDControls(Boolean bFlag)
        {
            txtBookNo.Enabled = bFlag;
            cboStatus.Enabled = bFlag;
            txtRemarks.Enabled = bFlag;
            chkAutoNumber.Enabled = bFlag;            
        }
             

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();   
        }

        void LoadRecord()
        {
            eVariable.sBookID = oMTransaction.BOOK_ID;
            txtTitle.Text = oMTransaction.TITLE;
            txtSubject.Text = oMTransaction.SUBJECT;
            txtCategory.Text = oMTransaction.CATEGORY;
            txtAuthor.Text = oMTransaction.AUTHOR;
            txtDatePublish.Text = oMTransaction.PUBLISH_DATE;
            txtLocation.Text = oMTransaction.LOCATION;
            txtPrice.Text = oMTransaction.BOOK_PRICE;
            txtLDPrice.Text = oMTransaction.RENT_PRICE;

            FillRecordList();
            FillRecords();
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

            iGridControl.BookListData = oMTransactionList;
            iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.EDIT_BOOK_NO;
            iGridControl.SetRemaksColumnVisible = true;
            iGridControl.SetStatusColumnVisible = true;
            iGridControl.SetHeaderVisible = false;  
            iGridControl.PopulateRecord();
            iGridControl.Visible = true;    
                    
        }      

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Boolean bFound = false;
            eVariable.m_ActionType = eVariable.ACTION_TYPE.ADD;
            oBook = new DataAccess.Book();

            if (!chkAutoNumber.Checked)
            {
                if (txtBookNo.Text.Trim() == string.Empty)
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.PLEASE_ENTER_BOOK_NUMBER.ToString().Replace("_"," "));
                    oFrmMsgBox.ShowDialog();
                    return;
                }
            }

            if (txtISBN.Text.Trim() == string.Empty)
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.PLEASE_ENTER_ISBN_NUMBER.ToString().Replace("_"," "));
                oFrmMsgBox.ShowDialog();
                return;
            }

            oBook = new DataAccess.Book();
            eVariable.sISBN_Number = txtISBN.Text;
            if (oBook.IsBookRecordDataExists(ePublicVariable.eVariable.FIND_TYPE.ISBN_NUMBER, eVariable.sISBN_Number))
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.ISBN_NUMBER_ALREADY_EXISTS.ToString().Replace("_"," "));
                oFrmMsgBox.ShowDialog();
                txtISBN.Focus();
                return;
            }

            if (!chkAutoNumber.Checked)
            {
                eVariable.sBookNumber = txtBookNo.Text;
                if (oBook.IsBookRecordDataExists(eVariable.FIND_TYPE.BOOK_NO, eVariable.sBookNumber.Trim()))
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.BOOK_NUMBER_ALREADY_EXISTS.ToString().Replace("_"," "));
                    oFrmMsgBox.ShowDialog();
                    txtBookNo.Focus();
                    return;
                }
            }
            else
            {
                eVariable.sBookNumber = GetBookNo(oMTransactionList);
            }

            bFound = oMTransactionList.Any(fw => fw.BOOK_NO == eVariable.sBookNumber || fw.ISBN_NUMBER == txtISBN.Text);

            if (!bFound)
            {
                EDControls(false);
                oMTransactionList.Add(new Model.Transaction { BOOK_ID = eVariable.sBookID, TITLE = txtTitle.Text, SUBJECT = txtSubject.Text, CATEGORY = txtCategory.Text, AUTHOR = txtAuthor.Text, PUBLISH_DATE = txtDatePublish.Text, LOCATION = txtLocation.Text, BOOK_PRICE = txtPrice.Text, RENT_PRICE = txtLDPrice.Text, BOOK_NO = eVariable.sBookNumber, ISBN_NUMBER = txtISBN.Text, REMARKS = "", STATUS = "ACTIVE" });
                txtRemarks.Text = "";
                cboStatus.Text = "ACTIVE";
                iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.ADD_BOOK_NO;
                iGridControl.BookListData = oMTransactionList;
                iGridControl.SetRemaksColumnVisible = true;
                iGridControl.SetStatusColumnVisible = true;
                iGridControl.SetHeaderVisible = false;
                iGridControl.PopulateRecord();
                iGridControl.Visible = true;               
                txtBookNo.Text = string.Empty;
                txtISBN.Text = string.Empty;
            }
            else
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.RECORD_IS_ALREADY_EXISTS.ToString().Replace("_"," "));
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (oMTransactionList.Count <= 0)
            {
                return;
            }           

            #region ADD
            if (eVariable.m_ActionType == eVariable.ACTION_TYPE.ADD)
            {
                
                foreach (var oItem in oMTransactionList)
                {
                    oMTransaction = new Model.Transaction();
                    oBook = new DataAccess.Book();
                    oMTransaction.BOOK_ID = oItem.BOOK_ID;
                    oMTransaction.BOOK_NO = oItem.BOOK_NO;
                    oMTransaction.TITLE = oItem.TITLE;
                    oMTransaction.SUBJECT = oItem.SUBJECT;
                    oMTransaction.CATEGORY = oItem.CATEGORY;
                    oMTransaction.AUTHOR = oItem.AUTHOR;
                    oMTransaction.ISBN_NUMBER = oItem.ISBN_NUMBER;
                    oMTransaction.PUBLISH_DATE = oItem.PUBLISH_DATE;
                    oMTransaction.LOCATION = oItem.LOCATION;
                    oMTransaction.BOOK_PRICE = oItem.BOOK_PRICE;
                    oMTransaction.RENT_PRICE = oItem.RENT_PRICE;
                    oMTransaction.REMARKS = txtRemarks.Text;
                    oMTransaction.STATUS = "ACTIVE";
                    oMTransaction.ADDED_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                    oMTransaction.ADDED_BY = eVariable.sUsername;
                    oBook.InsertBook(oMTransaction);                               
                }
            }
            #endregion

            if (eVariable.m_ActionType == eVariable.ACTION_TYPE.EDIT)
            {
                    oMTransaction = new Model.Transaction();
                    oBook = new DataAccess.Book();

                    oMTransaction.TITLE = txtTitle.Text;
                    oMTransaction.SUBJECT = txtSubject.Text;
                    oMTransaction.CATEGORY = txtCategory.Text;
                    oMTransaction.AUTHOR = txtAuthor.Text;
                    oMTransaction.PUBLISH_DATE = txtDatePublish.Text;
                    oMTransaction.LOCATION = txtLocation.Text;
                    oMTransaction.BOOK_PRICE = txtPrice.Text;
                    oMTransaction.RENT_PRICE = txtLDPrice.Text;

                    oMTransaction.BOOK_ID = oMTransactionRecord.BOOK_ID;
                    oMTransaction.BOOK_NO = oMTransactionRecord.BOOK_NO;
                    oMTransaction.ISBN_NUMBER = oMTransactionRecord.ISBN_NUMBER;
                    oMTransaction.REMARKS = txtRemarks.Text;
                    oMTransaction.STATUS = cboStatus.Text;

                    if (oMTransaction.STATUS == "INACTIVE")
                    {
                        if (oBook.IsBookCheckout(oMTransaction))
                        { 
                            oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.THE_RECORD_YOU_HAVE_SELECTED_HAVE_ACTIVE_TRANSACTION.ToString().Replace("_"," "));
                            oFrmMsgBox.ShowDialog();
                            return;                        
                        }
                    }

                    oMTransaction.ADDED_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                    oMTransaction.ADDED_BY = eVariable.sUsername;
                    oBook.UpdateBook(oMTransaction);
                
            }

            oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.RECORD_HAS_BEEN_SUCESSFULLY_SAVED.ToString().Replace("_"," "));
            oFrmMsgBox.ShowDialog();
            oFrmBookLst.LoadRecords();            
            LoadRecord();            
            clearText();
        }

        void ResetFields()
        {
            txtBookNo.Text = "";
            txtRemarks.Text = "";
            cboStatus.Text = "ACTIVE";
            txtISBN.Text = "";                        
        }

        private void clearText()
        {
            txtBookNo.Text = "";
            txtRemarks.Text = "";
            cboStatus.Text = "ACTIVE";
            txtISBN.Text = "";
            EDControls(true);
            eVariable.m_ActionType = eVariable.ACTION_TYPE.EDIT;
            chkAutoNumber.Checked = false;
            LoadRecord();
        }        

        private void chkAutoNumber_Click(object sender, EventArgs e)
        {            
            if (chkAutoNumber.Checked)
            {                
                EDControls(false);
                ResetFields();
            }          
        }
       
        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }              

        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearText();
        }


    }
}
