using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ePublicVariable
{
    public static class eVariable
    {

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
            REQUEST_BOOKS = 4,
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


        public static FORM_NAME m_FormName { get; set; }
        public static FIND_OPTION m_FindOption { get; set; }
        public static FILTER_BOOK m_FilterBook { get; set; }        
        public static MESSAGEBOX_TYPE m_MessageType { get; set; }
        public static ACTION_TYPE m_ActionType { get; set; }
        public static FIND_TYPE m_FindType { get; set; }

        public static string sBookID = string.Empty;
        public static string sBookNumber = string.Empty;
        public static string sISBN_Number = string.Empty;
        public static string sBorrowerID = string.Empty;
        public static string sTransactionNo = string.Empty;
        public static string sUniqueID = string.Empty;

        public static string FirstName = string.Empty;
        public static string MiddleName = string.Empty;
        public static string LastName = string.Empty;

        public static string sUsername = string.Empty;
        public static string sPassword = string.Empty;
        public static string sRole = string.Empty;
        public static string sFullName = string.Empty;

        
        public static string sGlobalConnectionString = @"Data Source=DESKTOP-BSCTAT9\SQLSERVERR2;Initial Catalog=iLibrarySystem;Integrated Security=True";
        public static string sGlobalMasterConnectionString = @"Data Source=DESKTOP-BSCTAT9\SQLSERVERR2;Initial Catalog=master;Integrated Security=True";
    }
}
