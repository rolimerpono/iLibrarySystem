﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ePublicVariable
{
    public static class eVariable
    {

        public static void DisableGridColumnSort(DataGridView oGrid)
        {
            foreach (DataGridViewColumn col in oGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.Frozen = false;
            }
        }

        public static void ClearText(Control oControl)
        {
            foreach (Control o in oControl.Controls.OfType<TextBox>().ToList())
            {
                o.Text = string.Empty;
            }

            foreach (CheckBox o in oControl.Controls.OfType<CheckBox>().ToList())
            {
                o.Checked = false;
            }
        }

        public static void DisablePanelTextKeyPress(Control oControl)
        {
            foreach (Control o in oControl.Controls.OfType<TextBox>().ToList())
            {                
                o.KeyPress += TextKeyPress;                
            }
        }    

        private static void TextKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        public static void DisableTextEnterKey(Control oControl)
        {
            oControl.KeyDown += TextKeyDown;
        }
       

        public static void DisableTextPanelEnterKey(Control oControl)
        {
            foreach (Control o in oControl.Controls.OfType<TextBox>().ToList())
            {
                if (!o.Name.ToLower().Contains("address"))
                {
                    o.KeyDown += TextKeyDown;
                }
            }
        }

      

        private static void TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        public static bool IsFieldEmpty(Control oControl)
        {
            foreach (var oText in oControl.Controls.OfType<TextBox>().ToList())
            {
                if (oText.Text.Trim() == String.Empty)
                {
                    return true;
                }
            }
            return false;
        }

        public static void DisableKeyPress(Control oControl)
        { 
            oControl.KeyPress += NoKeyPress;
        }

        private static void NoKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public static void ValidAmount(Control oControl)
        {
            oControl.KeyPress += ValidAmountKeyPress;
        }

        public static void ValidNumber(Control oControl)
        {
            oControl.KeyPress += ValidNumberKeyPress;
        }

        public static void ValidAmountPanel(Control oControl)
        {
            foreach (Control o in oControl.Controls.OfType<TextBox>().ToList())
            {
                o.KeyPress += ValidAmountKeyPress;
            }

        }

        public static void ValidNumberPanel(Control oControl)
        {
            foreach (Control o in oControl.Controls.OfType<TextBox>().ToList())
            {
                o.KeyPress += ValidNumberKeyPress;
            }

        }

        private static void ValidAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf('.') != -1)
                {
                    e.Handled = true;
                    return;
                }

                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 46)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private static void ValidNumberKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (((Control)sender).Text == "" && e.KeyChar == '0')
                {
                    e.Handled = true;
                    return;
                }
                if (e.KeyChar < '0' || e.KeyChar > '9')
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        public static int GetAge(DateTime dStart, DateTime dEnd)
        {
            return (dEnd.Year - dStart.Year - 1) + (((dEnd.Month > dStart.Month) || ((dEnd.Month == dStart.Month) && (dEnd.Day >= dStart.Day))) ? 1 : 0);
        }

        public enum FILTER_BOOK : int
        {
            NONE = 0,
            BOOK_TITLE = 1,
            BOOK_AUTHOR = 2,
            BOOK_CATEGORY = 3,
            BOOK_ACTIVE = 4,
            BOOK_INACTIVE = 5,
            BOOK_DEFAULT = 6
        }
       
        public enum MESSAGEBOX_TYPE
        { 
            DEFAULT = 0,
            INFORMATION = 1,
            QUERY = 2,
            ERROR = 3
        }

        public enum ACTION_TYPE : int
        { 
            NONE = 0,
            ADD = 1,
            EDIT = 2,
            DELETE = 3
        }

        public enum FIND_TYPE : int
        { 
            NONE = 0,
            BOOK_ID = 1,
            BOOK_NO = 2,
            ISBN_NUMBER = 3, 
            BORROWER_ID= 4
        }

        public enum FIND_BOOK : int
        {
            NONE = 0,
            BOOK_RECORDS = 1,
            BOOK_BORROWED = 2,
            BOOK_RETURNED = 3,
            BOOK_REQUESTED = 4,
            BOOK_PENALTY = 5,
            BOOK_PAY = 6
                 
        }

        public enum FIND_OPTION : int
        {
            BOOKS = 1,
            BORROWER = 2
        }

        public enum FORM_NAME : int
        {
            BORROW_BOOK = 0,
            RETURN_BOOK = 1,
            REQUEST_BOOK = 2,
            PAY_BOOK = 3         
        }

        public enum FIND_BORROWER : int
        { 
            NONE = 0,
            BORROWER_ID = 1,
            FIRST_NAME = 2,
            MIDDLE_NAME = 3,
            LAST_NAME = 4,
            INACTIVE= 5
        }          


        #region Reports
        public enum BOOK_STATUS : int
        { 
            NONE = 0,
            BOOK_RECORDLIST = 1,
            BORROWED_BOOKS = 2,
            RETUNRNED_BOOKS = 3,  
            REQUEST_BOOKS= 4,
            INACTIVE_BOOKS= 5
        }

        public enum BORROWER_STATUS : int
        { 
            NONE = 0,
            BORROWER_RECORDLIST = 1,
            UNRETURNED_BOOKS = 2,
            REQUESTED_BOOKS = 3     
        }
        #endregion

        public static BOOK_STATUS r_BookStatus { get; set; }
        public static BORROWER_STATUS r_BorrowerStatus { get; set; }

        #region Message
        public enum TransactionMessage : int
        { 

            ALL_FIELDS_ARE_REQUIRED = 0,            
            ARE_YOU_SURE_YOU_WANT_TO_DELETE_THIS_RECORD = 1,
            ARE_YOU_SURE_YOU_WANT_TO_PROCEED_TO_THE_TRANSACTION = 2,

            BOOK_NUMBER_ALREADY_EXISTS = 3,
            BORROWER_HAS_CURRENTLY_HAVE_ACTIVE_TRANSACTION = 4,
            
            DATABASE_BACKUP_FAILED = 5,
            DATABASE_DOES_NOT_EXISTS = 6,
            DATABASE_RESTORATION_FAILED = 7,
            DATABASE_HAS_BEEN_SUCESSFULLY_RESTORED = 8,
            DATABASE_HAS_BEEN_SUCESSFULLY_BACKUP_IN_PATH = 9,                                   

            ISBN_NUMBER_ALREADY_EXISTS = 10,            
                       
            PLEASE_ENTER_BOOK_NUMBER = 11,
            PLEASE_ENTER_NUMBER_OF_DAYS = 12,                         
            PLEASE_ENTER_ISBN_NUMBER = 13,
            PLEASE_ENTER_NUMBER_OF_BOOK = 14, 
            PLEASE_ENTER_EXACT_PAYMENT_AMOUNT = 15,
            PLEASE_ENTER_MEMBERSHIP_ID_FOR_VERIFICATION = 16,
            PLEASE_CLOSE_THE_ISBN_PANEL= 17,
            PLEASE_SELECT_A_RECORD = 18, 
            PLEASE_POPULATE_A_RECORD_FIRST = 19,
            PLEASE_SELECT_DISTINATION_PATH_TO_SAVE_THE_FILE = 20,            
            PLEASE_ENTER_BORROWER_ID_TO_CONTINUE_WITH_THE_TRANSACTION= 21,                                 
           
            RECORD_IS_ALREADY_EXISTS = 22,
            RECORD_HAS_BEEN_SUCESSFULLY_SAVED = 23,
            RECORD_HAS_BEEN_SUCESSFULLY_DELETED = 24,
            RECORD_HAS_BEEN_SUCESSFULLY_EXTRACTED_AND_SAVE_TO_PATH = 25,         
            
            THE_DATABASE_DOES_NOT_EXITS = 26, 
            THE_MEMBERSHIP_STATUS_IS_INVALID = 27, 
            THE_DATA_YOU_HAVE_ENTERED_IS_INVALID = 28,
            THE_PASSWORD_YOU_HAVE_ENTERED_IS_INCORRECT = 29,                            
            TRANSACTION_HAS_BEEN_SUCESSFULLY_SAVE = 30,
            TOTAL_BOOK_COUNT_ALREADY_EXCEED_LIMIT = 31,
            TOTAL_DAY_COUNT_ALREADY_EXCEED_LIMIT = 32, 
            THE_RECORD_YOU_HAVE_SELECTED_HAVE_ACTIVE_TRANSACTION = 33,           
            THE_BOOK_YOU_HAVE_SELECTED_IS_CURRENTLY_NOT_AVAILABLE = 34                                                                                                  

        }
        #endregion
        
        public static FORM_NAME m_FormName { get; set; }
        public static FIND_OPTION m_FindOption { get; set; }
        public static FILTER_BOOK m_FilterBook { get; set; }        
        public static MESSAGEBOX_TYPE m_MessageType { get; set; }
        public static ACTION_TYPE m_ActionType { get; set; }
        public static FIND_TYPE m_FindType { get; set; }

        public static int iAutoBookNo = 0;
        public static string sBookID = string.Empty;
        public static string sBookNumber = string.Empty;
        public static string sISBN_Number = string.Empty;
        public static string sBorrowerID = string.Empty;
        public static string sTransactionNo = string.Empty;
        public static string sUniqueID = string.Empty;
        public static int iDaysLimit = 0;
        public static int iBookLimit = 0;

        public static string FirstName = string.Empty;
        public static string MiddleName = string.Empty;
        public static string LastName = string.Empty;

        public static string sUsername = string.Empty;
        public static string sPassword = string.Empty;
        public static string sRole = string.Empty;
        public static string sFullName = string.Empty;

        public static string sGlobalConnectionString = @"Data Source=.\SQLSERVERR2;Initial Catalog=iLibrarySystem;Integrated Security=True";
        public static string sGlobalMasterConnectionString = @"Data Source=.\SQLSERVERR2;Initial Catalog=master;Integrated Security=True";

               
    }
}
