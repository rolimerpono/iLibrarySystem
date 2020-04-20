using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ePublicVariable;

namespace iControlGrid
{
    public partial class iGridControl : UserControl
    {
        DataAccess.Book oBook = new DataAccess.Book();

        public Delegate GetDataRecordList;
        public Delegate GetDataRecord;

        public enum FIND_OPTION : int
        {
            NONE = 0,
            ADD_BOOK_NO = 1,
            EDIT_BOOK_NO = 2,
            INPUT_BOOK_NO = 3,
            SEARCH_DB_BOOK_ISBN = 4,
            SEARCH_DB_BORROWED_BOOK_ISBN = 5,
            SEARCH_LOCAL_BORROWED_BOOK_ISBN = 6,
            SEARCH_SELECTED_BORROWED_BOOK_ISBN = 7,
        }

        private Model.Transaction oMTransactionData = new Model.Transaction();
        private Model.Transaction oMTransaction = new Model.Transaction();
        private List<Model.Transaction> oMTransactionList = new List<Model.Transaction>();
        private List<Model.Transaction> oMTransactionListData = new List<Model.Transaction>();
        

        public FIND_OPTION FindOption { get; set; }
        frmMsgBoxQuery oFrmMsgBoxQuery;
        frmInfoMsgBox oFrmMsgBox;

    
        private int iRowIndex;
        private Boolean bSetRemaksColumnVisible;
        private Boolean bSetStatusColumnVisible;
        private Boolean bSetCheckBoxColumnVisible;
        private Boolean bSetDeleteColumnVisible;
        private Boolean bSetHeaderVisible;
        private Boolean bSetFooterVisible;
        
        public bool SetCheckBoxColumnVisible
        {
            get { return bSetCheckBoxColumnVisible; }
            set { bSetCheckBoxColumnVisible = value; }
        }

        public bool SetDeleteColumnVisible
        {
            get { return bSetDeleteColumnVisible; }
            set { bSetDeleteColumnVisible = value; }
        }
        public Boolean SetRemaksColumnVisible
        {
            get { return bSetRemaksColumnVisible; }
            set { bSetRemaksColumnVisible = value; }
        }

        public Boolean SetStatusColumnVisible
        {
            get { return bSetStatusColumnVisible; }
            set { bSetStatusColumnVisible = value; }
        }

        public bool SetHeaderVisible
        {
            get { return bSetHeaderVisible; }
            set { bSetHeaderVisible = value; }
        }

        public bool SetFooterVisible
        {
            get { return bSetFooterVisible; }
            set { bSetFooterVisible = value; }
        }
       
        public Model.Transaction BookCommonData
        {
            get { return oMTransactionData; }
            set { oMTransactionData = value; }
        }

      
        public List<Model.Transaction> BookListData
        {
            get { return oMTransactionList; }
            set { oMTransactionList = value; }
        }

        //public List<Model.Transaction> oReturnData
        //{
        //    get { return oMTransactionList; }
        //}

        public iGridControl()
        {
            InitializeComponent();
        }

        public void SetHeaderBackColor(int iRed, int iGreen, int iBlue)
        {
            panelControl.BackColor = Color.FromArgb(iRed, iGreen, iBlue);
        }

        public void SetCloseBackColor(int iRed, int iGreen, int iBlue)
        {
            closeControl.BackColor = Color.FromArgb(iRed, iGreen, iBlue);
        }

        public void SetCloseForeColor(int iRed, int iGreen, int iBlue)
        {
            closeControl.ForeColor = Color.FromArgb(iRed, iGreen, iBlue);
        }

        public void SetGridColor(int iRed, int iGreen, int iBlue)
        {
            GridControl.GridColor = Color.FromArgb(iRed, iGreen, iBlue);
        }
        

        public void EditRecord()
        {
            FindOption = FIND_OPTION.EDIT_BOOK_NO;
        }

        void RefreshControls()
        {            
            GridControl.Columns[3].Visible = bSetRemaksColumnVisible;
            GridControl.Columns[4].Visible = bSetStatusColumnVisible;
            GridControl.Columns[5].Visible = bSetCheckBoxColumnVisible;
            GridControl.Columns[6].Visible = bSetDeleteColumnVisible;
            panelControl.Visible = bSetHeaderVisible;
            pnlFooter.Visible = bSetFooterVisible;

        }

       
        public void PopulateRecord()
        {
            try
            {

                GridControl.Rows.Clear();
                RefreshControls();
                if (FindOption == FIND_OPTION.ADD_BOOK_NO)
                {
                    GridControl.Rows.Clear();
                    foreach (var oItem in oMTransactionList)
                    {
                        GridControl.Rows.Add(oItem.BOOK_ID, oItem.BOOK_NO, oItem.ISBN_NUMBER, oItem.REMARKS, oItem.STATUS, oItem.BFLAG);
                    }
                    WindowHeight();
                    return;
                }
                if (FindOption == FIND_OPTION.EDIT_BOOK_NO)
                {
                    GridControl.Rows.Clear();
                    foreach (var oItem in oMTransactionList)
                    {
                        GridControl.Rows.Add(oItem.BOOK_ID, oItem.BOOK_NO, oItem.ISBN_NUMBER, oItem.REMARKS, oItem.STATUS, oItem.BFLAG);
                    }
                    WindowHeight();
                    return;
                }
                else if (FindOption == FIND_OPTION.INPUT_BOOK_NO)
                {
                    if (BookListData.Count > 0)
                    {
                        foreach (var oData in BookListData)
                        {
                            if (BookCommonData.BOOK_ID == oData.BOOK_ID)
                            {
                                GridControl.Rows.Add(oData.BOOK_ID, oData.BOOK_NO, oData.ISBN_NUMBER, "", false);
                            }
                        }
                        int iInitialCount = GridControl.Rows.Count;
                        for (int i = iInitialCount; i < Convert.ToInt32(BookCommonData.TOTAL_QTY); i++)
                        {
                            GridControl.Rows.Add(BookCommonData.BOOK_ID, "", "", "", false);
                        }

                        int iCount = iInitialCount;

                        while ((iCount) > Convert.ToInt32(BookCommonData.TOTAL_QTY))
                        {
                            oMTransactionList.RemoveAt(iCount - 1);
                            GridControl.Rows.RemoveAt(iCount - 1);
                            iCount--;
                        }

                    }
                    else
                    {
                        for (int i = 0; i < Convert.ToInt32(BookCommonData.TOTAL_QTY); i++)
                        {
                            GridControl.Rows.Add(BookCommonData.BOOK_ID, "", "", "", false);
                        }
                    }
                    WindowHeight();
                    return;
                }
                else if (FindOption == FIND_OPTION.SEARCH_DB_BORROWED_BOOK_ISBN)
                {
                    GridControl.Rows.Clear();
                    if (oMTransactionList.Count == 0)
                    {
                        foreach (DataRow row in oBook.GetBorrowedBookISBNPerBorrower(eVariable.FIND_TYPE.BORROWER_ID, BookCommonData.BOOK_ID, BookCommonData.PERSON_ID).Rows)
                        {
                            GridControl.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), false);
                            oMTransactionList.Add(new Model.Transaction { BOOK_ID = row[0].ToString(), BOOK_NO = row[1].ToString(), ISBN_NUMBER = row[2].ToString(), REMARKS = row[3].ToString(), STATUS = row[4].ToString(), BFLAG = false });
                        }
                    }
                    else
                    {
                        foreach (var oItem in oMTransactionList)
                        {
                            GridControl.Rows.Add(oItem.BOOK_ID, oItem.BOOK_NO, oItem.ISBN_NUMBER, oItem.REMARKS, oItem.STATUS, oItem.BFLAG);
                        }
                    }
                    WindowHeight();
                    return;
                }
                else if (FindOption == FIND_OPTION.SEARCH_DB_BOOK_ISBN)
                {
                    GridControl.Rows.Clear();
                    oBook = new DataAccess.Book();
                    foreach (DataRow row in oBook.GetBookAvailability(BookCommonData).Rows)
                    {
                        GridControl.Rows.Add(row[0], row[1], row[2], row[3], row[4], false);
                    }
                    WindowHeight();
                    return;
                }

                else if (FindOption == FIND_OPTION.SEARCH_LOCAL_BORROWED_BOOK_ISBN)
                {
                    GridControl.Rows.Clear();
                    foreach (var oItem in oMTransactionList)
                    {
                        if (BookCommonData.BOOK_ID == oItem.BOOK_ID)
                        {
                            GridControl.Rows.Add(oItem.BOOK_ID, oItem.BOOK_NO, oItem.ISBN_NUMBER, oItem.REMARKS, oItem.STATUS, oItem.BFLAG);
                        }
                    }
                    WindowHeight();
                    return;
                }

                else if (FindOption == FIND_OPTION.SEARCH_SELECTED_BORROWED_BOOK_ISBN)
                {
                    GridControl.Rows.Clear();
                    foreach (var oItem in oMTransactionList)
                    {
                        if (oItem.BFLAG == true)
                        {
                            if (BookCommonData.BOOK_ID == oItem.BOOK_ID)
                            {
                                GridControl.Rows.Add(oItem.BOOK_ID, oItem.BOOK_NO, oItem.ISBN_NUMBER, oItem.REMARKS, oItem.STATUS, oItem.BFLAG);
                            }
                        }

                    }
                    WindowHeight();
                    return;
                }
            }
            catch (Exception ex)
            { }
        }

        void WindowHeight()
        {
            //if (GridControl.Rows.Count <= 5)
            //{
            //    this.Height = 200;
            //}
            //else
            //{
            //    this.Height = GridControl.Rows.Count * 25;
            //}

        }

        public string GetBookStatus(Model.Transaction oData)
        {
            try
            {
                oBook = new DataAccess.Book();
                string sResult = string.Empty;

                sResult = oBook.GetBookISBN(eVariable.FIND_TYPE.BOOK_ID, oData.BOOK_ID).Rows[0][0].ToString();
                if (sResult != string.Empty)
                {
                    return sResult;
                }

                sResult = oBook.GetBookISBN(eVariable.FIND_TYPE.BOOK_ID, oData.BOOK_ID).Rows[0][0].ToString();
                if (sResult != string.Empty)
                {
                    return sResult;
                }

                return sResult;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public void DatagridSelectedData(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                iRowIndex = e.RowIndex;
                #region CELL_SEARCH
                if (FindOption == FIND_OPTION.SEARCH_DB_BORROWED_BOOK_ISBN || FindOption == FIND_OPTION.SEARCH_LOCAL_BORROWED_BOOK_ISBN || FindOption == FIND_OPTION.SEARCH_SELECTED_BORROWED_BOOK_ISBN || FindOption == FIND_OPTION.INPUT_BOOK_NO)
                {
                    if (e.ColumnIndex == 5 && e.RowIndex >= 0)
                    {
                        if (Convert.ToBoolean(GridControl.Rows[e.RowIndex].Cells[5].Value) == false)
                        {
                            GridControl.Rows[e.RowIndex].Cells[5].Value = true;
                            oMTransactionList.Where(fw => fw.BOOK_NO == GridControl.Rows[e.RowIndex].Cells[3].Value.ToString()).ToList().ForEach(i => { i.BFLAG = true; });
                        }
                        else
                        {
                            GridControl.Rows[e.RowIndex].Cells[5].Value = false;
                            oMTransactionList.Where(fw => fw.BOOK_NO == GridControl.Rows[e.RowIndex].Cells[3].Value.ToString()).ToList().ForEach(i => { i.BFLAG = false; });
                        }

                    }
                }
                #endregion

                #region BOOK_NO_INPUT
                if (FindOption == FIND_OPTION.INPUT_BOOK_NO)
                {

                    if (e.ColumnIndex == 6 && e.RowIndex >= 0)
                    {
                        if (GridControl.Rows[e.RowIndex].Cells[1].Value.ToString() != string.Empty || GridControl.Rows[e.RowIndex].Cells[2].Value.ToString() != string.Empty)
                        {
                            oFrmMsgBoxQuery = new frmMsgBoxQuery("ARE YOU SURE YOU WANT TO DELETE THIS RECORD?");
                            oFrmMsgBoxQuery.ShowDialog();

                            if (oFrmMsgBoxQuery.sAnswer == "YES")
                            {

                                if (oMTransactionList.Count > 0)
                                {
                                    oMTransactionList.RemoveAt(e.RowIndex);
                                }

                                GridControl.Rows[e.RowIndex].Cells[1].Value = "";
                                GridControl.Rows[e.RowIndex].Cells[2].Value = "";

                            }
                        }
                    }
                }
                #endregion
               
            }
            catch (Exception ex)
            { }
        }

        public void CloseGrid()
        {
            try
            {
                if (GridControl.Rows[iRowIndex].Cells[1].Value != null)
                {
                    if (FindOption == FIND_OPTION.SEARCH_DB_BORROWED_BOOK_ISBN)
                    {
                        oMTransactionList = new List<Model.Transaction>();
                        foreach (DataGridViewRow row in GridControl.Rows)
                        {

                            oMTransaction = new Model.Transaction();
                            oMTransaction.BOOK_ID = row.Cells[0].Value.ToString();
                            oMTransaction.BOOK_NO = row.Cells[1].Value.ToString();
                            oMTransaction.ISBN_NUMBER = row.Cells[2].Value.ToString();
                            oMTransaction.REMARKS = row.Cells[3].Value.ToString();
                            oMTransaction.STATUS = row.Cells[4].Value.ToString();
                            if (Convert.ToBoolean(row.Cells[5].Value) == true)
                            {
                                oMTransaction.BFLAG = true;
                            }
                            else
                            {
                                oMTransaction.BFLAG = false;
                            }

                            oMTransaction.TITLE = BookCommonData.TITLE;
                            oMTransaction.SUBJECT = BookCommonData.SUBJECT;
                            oMTransaction.AUTHOR = BookCommonData.AUTHOR;
                            oMTransaction.PUBLISH_DATE = BookCommonData.PUBLISH_DATE;
                            oMTransaction.CATEGORY = BookCommonData.CATEGORY;
                            oMTransaction.LOCATION = BookCommonData.LOCATION;
                            oMTransaction.BOOK_PRICE = BookCommonData.BOOK_PRICE;
                            oMTransaction.RENT_PRICE = BookCommonData.RENT_PRICE;
                            oMTransaction.LD_INTEREST = BookCommonData.LD_INTEREST;
                            oMTransaction.DUE_INTEREST = BookCommonData.DUE_INTEREST;
                            oMTransaction.TOTAL_QTY = BookCommonData.TOTAL_QTY;
                            oMTransaction.TOTAL_DAYS = BookCommonData.TOTAL_DAYS;
                            oMTransaction.ADDED_DATE = BookCommonData.ADDED_DATE;

                            oMTransaction.PERSON_ID = BookCommonData.PERSON_ID;
                            oMTransaction.FIRST_NAME = BookCommonData.FIRST_NAME;
                            oMTransaction.MIDDLE_NAME = BookCommonData.MIDDLE_NAME;
                            oMTransaction.LAST_NAME = BookCommonData.LAST_NAME;

                            oMTransactionList.Add(oMTransaction);

                        }

                        if (oMTransactionList.Count > 0)
                        {
                            GetDataRecordList.DynamicInvoke(oMTransactionList);
                        }
                    }

                    if (FindOption == FIND_OPTION.INPUT_BOOK_NO)
                    {
                        oMTransactionListData = new List<Model.Transaction>();
                        foreach (var oItem in oMTransactionList)
                        {
                            oMTransaction = new Model.Transaction();
                            oMTransaction.BOOK_ID = oItem.BOOK_ID;
                            oMTransaction.BOOK_NO = oItem.BOOK_NO;
                            oMTransaction.ISBN_NUMBER = oItem.ISBN_NUMBER;
                            oMTransaction.REMARKS = oItem.REMARKS;
                            oMTransaction.STATUS = oItem.STATUS;


                            oMTransaction.TITLE = oItem.TITLE;
                            oMTransaction.SUBJECT = oItem.SUBJECT;
                            oMTransaction.AUTHOR = oItem.AUTHOR;
                            oMTransaction.PUBLISH_DATE = oItem.PUBLISH_DATE;
                            oMTransaction.CATEGORY = oItem.CATEGORY;
                            oMTransaction.LOCATION = oItem.LOCATION;
                            oMTransaction.BOOK_PRICE = oItem.BOOK_PRICE;
                            oMTransaction.RENT_PRICE = oItem.RENT_PRICE;
                            oMTransaction.LD_INTEREST = oItem.LD_INTEREST;
                            oMTransaction.DUE_INTEREST = oItem.DUE_INTEREST;
                            oMTransaction.TOTAL_QTY = oItem.TOTAL_QTY;
                            oMTransaction.TOTAL_DAYS = oItem.TOTAL_DAYS;
                            oMTransaction.ADDED_DATE = oItem.ADDED_DATE;

                            oMTransaction.PERSON_ID = oItem.PERSON_ID;
                            oMTransaction.FIRST_NAME = oItem.FIRST_NAME;
                            oMTransaction.MIDDLE_NAME = oItem.MIDDLE_NAME;
                            oMTransaction.LAST_NAME = oItem.LAST_NAME;

                            oMTransactionListData.Add(oMTransaction);

                        }

                        if (oMTransactionList.Count > 0)
                        {
                            GetDataRecordList.DynamicInvoke(oMTransactionListData);
                        }
                    }
                }

                this.Visible = false;
            }
            catch (Exception ex)
            {
                //
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridControl.Rows[iRowIndex].Cells[1].Value != null)
                {
                    if (FindOption == FIND_OPTION.SEARCH_DB_BORROWED_BOOK_ISBN)
                    {
                        oMTransactionList = new List<Model.Transaction>();
                        foreach (DataGridViewRow row in GridControl.Rows)
                        {

                            oMTransaction = new Model.Transaction();
                            oMTransaction.BOOK_ID = row.Cells[0].Value.ToString();
                            oMTransaction.BOOK_NO = row.Cells[1].Value.ToString();
                            oMTransaction.ISBN_NUMBER = row.Cells[2].Value.ToString();
                            oMTransaction.REMARKS = row.Cells[3].Value.ToString();
                            oMTransaction.STATUS = row.Cells[4].Value.ToString();
                            if (Convert.ToBoolean(row.Cells[5].Value) == true)
                            {
                                oMTransaction.BFLAG = true;
                            }
                            else
                            {
                                oMTransaction.BFLAG = false;
                            }

                            oMTransaction.TITLE = BookCommonData.TITLE;
                            oMTransaction.SUBJECT = BookCommonData.SUBJECT;
                            oMTransaction.AUTHOR = BookCommonData.AUTHOR;
                            oMTransaction.PUBLISH_DATE = BookCommonData.PUBLISH_DATE;
                            oMTransaction.CATEGORY = BookCommonData.CATEGORY;
                            oMTransaction.LOCATION = BookCommonData.LOCATION;
                            oMTransaction.BOOK_PRICE = BookCommonData.BOOK_PRICE;
                            oMTransaction.RENT_PRICE = BookCommonData.RENT_PRICE;
                            oMTransaction.LD_INTEREST = BookCommonData.LD_INTEREST;
                            oMTransaction.DUE_INTEREST = BookCommonData.DUE_INTEREST;
                            oMTransaction.TOTAL_QTY = BookCommonData.TOTAL_QTY;
                            oMTransaction.TOTAL_DAYS = BookCommonData.TOTAL_DAYS;
                            oMTransaction.ADDED_DATE = BookCommonData.ADDED_DATE;

                            oMTransaction.PERSON_ID = BookCommonData.PERSON_ID;
                            oMTransaction.FIRST_NAME = BookCommonData.FIRST_NAME;
                            oMTransaction.MIDDLE_NAME = BookCommonData.MIDDLE_NAME;
                            oMTransaction.LAST_NAME = BookCommonData.LAST_NAME;  
                         
                            oMTransactionList.Add(oMTransaction);

                        }

                        if (oMTransactionList.Count > 0)
                        {
                            GetDataRecordList.DynamicInvoke(oMTransactionList);
                        }
                    }

                    if (FindOption == FIND_OPTION.INPUT_BOOK_NO)
                    {
                        oMTransactionListData = new List<Model.Transaction>();
                        foreach (var oItem in oMTransactionList)
                        {
                            oMTransaction = new Model.Transaction();
                            oMTransaction.BOOK_ID = oItem.BOOK_ID;
                            oMTransaction.BOOK_NO = oItem.BOOK_NO;
                            oMTransaction.ISBN_NUMBER = oItem.ISBN_NUMBER;
                            oMTransaction.REMARKS = oItem.REMARKS;
                            oMTransaction.STATUS = oItem.STATUS;

                            
                            oMTransaction.TITLE = oItem.TITLE;
                            oMTransaction.SUBJECT = oItem.SUBJECT;
                            oMTransaction.AUTHOR = oItem.AUTHOR;
                            oMTransaction.PUBLISH_DATE = oItem.PUBLISH_DATE;
                            oMTransaction.CATEGORY = oItem.CATEGORY;
                            oMTransaction.LOCATION = oItem.LOCATION;
                            oMTransaction.BOOK_PRICE = oItem.BOOK_PRICE;
                            oMTransaction.RENT_PRICE = oItem.RENT_PRICE;
                            oMTransaction.LD_INTEREST = oItem.LD_INTEREST;
                            oMTransaction.DUE_INTEREST = oItem.DUE_INTEREST;
                            oMTransaction.TOTAL_QTY = oItem.TOTAL_QTY;
                            oMTransaction.TOTAL_DAYS = oItem.TOTAL_DAYS;
                            oMTransaction.ADDED_DATE = oItem.ADDED_DATE;

                            oMTransaction.PERSON_ID = oItem.PERSON_ID;
                            oMTransaction.FIRST_NAME = oItem.FIRST_NAME;
                            oMTransaction.MIDDLE_NAME = oItem.MIDDLE_NAME;
                            oMTransaction.LAST_NAME = oItem.LAST_NAME;                            

                            oMTransactionListData.Add(oMTransaction);

                        }

                        if (oMTransactionList.Count > 0)
                        {
                            GetDataRecordList.DynamicInvoke(oMTransactionListData);
                        }
                    }
                }

                this.Visible = false;
            }
            catch (Exception ex)
            {
                //
            }
        }



        void GetBookNoISBN(int iRow)
        {
            try
            {
                oBook = new DataAccess.Book();
                foreach (DataRow row in oBook.IsBookAvailable(eVariable.FIND_TYPE.BOOK_NO,"ACTIVE", eVariable.sBookID, eVariable.sBookNumber).Rows)
                {
                    eVariable.sBookNumber = row[1].ToString();
                    eVariable.sISBN_Number = row[2].ToString();
                }
               if (eVariable.sISBN_Number == string.Empty)
                {
                    oFrmMsgBox = new frmInfoMsgBox("THIS BOOK IS NOT AVAILABLE.");
                    oFrmMsgBox.ShowDialog();                    
                    GridControl.Rows[iRow].Cells[1].Value = string.Empty;
                    oMTransactionList.RemoveAt(iRow);
                    
                    return;
                }
                else
                {
                    int iCount = (from DataGridViewRow r in GridControl.Rows
                                   where Convert.ToString(r.Cells["BOOK_NO"].Value) == eVariable.sBookNumber
                                   select r.Cells["BOOK_NO"].Value.ToString()).Count();          
                   
                    if (iCount == 2)
                    {
                        oFrmMsgBox = new frmInfoMsgBox("RECORD ALREADY EXISTS.");
                        oFrmMsgBox.ShowDialog();                                                
                        GridControl.Rows[iRow].Cells[1].Value = string.Empty;
                        GridControl.Rows[iRow].Cells[2].Value = string.Empty;
                        oMTransactionList.RemoveAt(iRow);
                        return;                    
                    }

                    GridControl.Rows[iRow].Cells[2].Value = eVariable.sISBN_Number;                    
                    for (int i = 0; i < GridControl.Rows.Count; i++)
                    {
                        oMTransaction = new Model.Transaction();
                        oMTransaction.BOOK_ID = GridControl.Rows[i].Cells[0].Value.ToString();
                        oMTransaction.BOOK_NO = GridControl.Rows[i].Cells[1].Value.ToString();
                        oMTransaction.ISBN_NUMBER = GridControl.Rows[i].Cells[2].Value.ToString();

                        
                        #region Fixed Data
                        oMTransaction.TITLE = BookCommonData.TITLE;
                        oMTransaction.SUBJECT = BookCommonData.SUBJECT;
                        oMTransaction.AUTHOR = BookCommonData.AUTHOR;
                        oMTransaction.PUBLISH_DATE = BookCommonData.PUBLISH_DATE;
                        oMTransaction.CATEGORY = BookCommonData.CATEGORY;
                        oMTransaction.LOCATION = BookCommonData.LOCATION;
                        oMTransaction.BOOK_PRICE = BookCommonData.BOOK_PRICE;
                        oMTransaction.RENT_PRICE = BookCommonData.RENT_PRICE;
                        oMTransaction.LD_INTEREST = BookCommonData.LD_INTEREST;
                        oMTransaction.DUE_INTEREST = BookCommonData.DUE_INTEREST;
                        oMTransaction.TOTAL_QTY = BookCommonData.TOTAL_QTY;
                        oMTransaction.TOTAL_DAYS = BookCommonData.TOTAL_DAYS;
                        oMTransaction.ADDED_DATE = BookCommonData.ADDED_DATE;

                        oMTransaction.PERSON_ID = BookCommonData.PERSON_ID;
                        oMTransaction.FIRST_NAME = BookCommonData.FIRST_NAME;
                        oMTransaction.MIDDLE_NAME = BookCommonData.MIDDLE_NAME;
                        oMTransaction.LAST_NAME = BookCommonData.LAST_NAME;                        

                        #endregion

                        if (oMTransaction.ISBN_NUMBER != string.Empty)
                        {
                            bool bFound = oMTransactionList.Any(fw => fw.ISBN_NUMBER == oMTransaction.ISBN_NUMBER);
                            if (!bFound)
                            {
                                oMTransactionList.Add(oMTransaction);
                            }
                        }

                    }

                    eVariable.sBookNumber = string.Empty;
                    eVariable.sISBN_Number = string.Empty;
                }
            }
            catch (Exception ex)
            { }

        }



        private void iGridControl_Load(object sender, EventArgs e)
        {
            
        }

        private void GridControl_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (e.Control is TextBox)
                {
                    ((TextBox)(e.Control)).CharacterCasing = CharacterCasing.Upper;

                    if (GridControl.Columns[1].HeaderText.Equals("BOOK NO"))
                    {
                        TextBox _autoText = e.Control as TextBox;
                        if (_autoText != null)
                        {
                            _autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                            _autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection _DataCollection = new AutoCompleteStringCollection();
                            AddRecords(_DataCollection);
                            _autoText.AutoCompleteCustomSource = _DataCollection;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void AddRecords(AutoCompleteStringCollection col)
        {
            try
            {
                col.Clear();
                oBook = new DataAccess.Book();
                foreach (DataRow row in oBook.GetBookAvailability(BookCommonData).Rows)
                {
                    col.Add(row[1].ToString());
                }
            }
            catch (Exception ex)
            { }
        }

        private void GridControl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (GridControl.Rows.Count > 0)
                {
                    iRowIndex = e.RowIndex;
                    eVariable.sBookID = GridControl.Rows[e.RowIndex].Cells[0].Value.ToString();
                    eVariable.sBookNumber = GridControl.Rows[e.RowIndex].Cells[1].Value.ToString();
                    eVariable.sISBN_Number = GridControl.Rows[e.RowIndex].Cells[2].Value.ToString();

                    if (eVariable.sBookNumber != string.Empty)
                    {
                        DatagridSelectedData(sender, e);

                        #region ADD_BOOK_NO
                        if (FindOption == FIND_OPTION.ADD_BOOK_NO)
                        {

                            if (e.ColumnIndex == 6 && e.RowIndex >= 0)
                            {
                                oFrmMsgBoxQuery = new frmMsgBoxQuery("ARE YOU SURE YOU WANT TO DELETE THIS RECORD?");
                                oFrmMsgBoxQuery.ShowDialog();

                                if (oFrmMsgBoxQuery.sAnswer == "YES")
                                {
                                    //var oData = oMTransactionList.Where(fw => fw.BOOK_NO == eVariable.sBookNumber).ToList();
                                    //foreach (var oItem in oData)
                                    //{
                                    //    oData.Remove(oItem);
                                    //}

                                    if (oMTransactionList.Count > 0)
                                    {
                                        oMTransactionList.RemoveAt(e.RowIndex);
                                    }

                                    GridControl.Rows.RemoveAt(e.RowIndex);
                                    
                                }
                            }
                        }
                        #endregion
                    }
                   
                }
            }
            catch (Exception ex)
            {
                
            }
        }



        private void GridControl_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (FindOption)
                {

                    case FIND_OPTION.INPUT_BOOK_NO:
                        if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                        {
                            eVariable.sBookID = GridControl.Rows[e.RowIndex].Cells[0].Value.ToString();
                            eVariable.sBookNumber = GridControl.Rows[e.RowIndex].Cells[1].Value.ToString();
                            if (eVariable.sBookNumber != string.Empty)
                            {
                                if (FindOption == FIND_OPTION.INPUT_BOOK_NO)
                                {
                                    GetBookNoISBN(e.RowIndex);
                                }
                            }
                           
                        }
                        break;

                    default:

                        break;
                }
            }
            catch (Exception ex)
            {
                //if (GridControl.Rows[e.RowIndex].Cells[1].Value == null)
                //{
                //    if (GridControl.Rows[e.RowIndex].Cells[2].Value != null)
                //    {

                //        GridControl.Rows[e.RowIndex].Cells[2].Value = string.Empty;
                //        oMTransactionList.RemoveAll(fw => fw.ISBN_NUMBER == eVariable.sISBN_Number);
                //    }
                //}
            }
        }

        private void GridControl_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (GridControl.Rows.Count > 0)
                {
                    iRowIndex = e.RowIndex;
                    eVariable.sBookID = GridControl.Rows[e.RowIndex].Cells[0].Value.ToString();
                    eVariable.sBookNumber = GridControl.Rows[e.RowIndex].Cells[1].Value.ToString();
                    eVariable.sISBN_Number = GridControl.Rows[e.RowIndex].Cells[2].Value.ToString();

                    if (eVariable.sBookNumber != string.Empty)
                    {
                        DatagridSelectedData(sender, e);
                    }                   
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void GridControl_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (GridControl.Rows.Count > 0)
                {
                    iRowIndex = e.RowIndex;
                    if (FindOption == FIND_OPTION.INPUT_BOOK_NO)
                    {
                        if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                        {

                            GridControl.ReadOnly = false;
                            DataGridViewCell cell = GridControl.Rows[e.RowIndex].Cells[e.ColumnIndex];
                            GridControl.CurrentCell = cell;
                            GridControl.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                            GridControl.BeginEdit(true);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        
        }      

        private void GridControl_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (FindOption == FIND_OPTION.EDIT_BOOK_NO)
                {
                    oMTransaction = new Model.Transaction();
                    oMTransaction.BOOK_ID = GridControl.Rows[iRowIndex].Cells[0].Value.ToString();
                    oMTransaction.BOOK_NO = GridControl.Rows[iRowIndex].Cells[1].Value.ToString();
                    oMTransaction.ISBN_NUMBER = GridControl.Rows[iRowIndex].Cells[2].Value.ToString();
                    GetDataRecord.DynamicInvoke(oMTransaction);
                }
            }
            catch (Exception ex)
            { }
        }

        public void ClearRecords()
        {
            if (GridControl.Rows.Count > 0)
            {
                GridControl.Rows.Clear();
            }
        }

        public void ClearRecordList()
        {
            oMTransactionList = new List<Model.Transaction>();
        }
    
    }
}
