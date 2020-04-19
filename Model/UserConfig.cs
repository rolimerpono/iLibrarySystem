using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class UserConfig
    {
        
        public UserConfig()
        {
            ROLE = string.Empty;

            BookDetail = false;
            BookEntry = false;
            BookAuthor = false;
            BookCategory = false;
            BookLocation = false;
            BookPolicy = false;

            BorrowerDetails = false;
            BorrowerEntry = false;
            BorrowBook = false;
            ReturnBook = false;
            PayBook = false;
            BorrowerRequest = false;

            UserAccount = false;
            UserAccess = false;
            UserRole = false;

            DBBackup = false;
            ImportExport = false;

            RBookList = false;
            RBorrowerList = false;

            ResetData = false; 
        }


        public string ROLE { get; set; }
        public bool BookDetail { get; set; }
        public bool BookEntry { get; set; }
        public bool BookAuthor { get; set; }
        public bool BookCategory { get; set; }
        public bool BookLocation { get; set; }
        public bool BookPolicy { get; set; }

        public bool BorrowerDetails { get; set; }
        public bool BorrowerEntry { get; set; }
        public bool BorrowBook { get; set; }
        public bool ReturnBook { get; set; }
        public bool PayBook { get; set; }
        public bool BorrowerRequest { get; set; }

        public bool UserAccount { get; set; }
        public bool UserAccess { get; set; }
        public bool UserRole { get; set; }

        public bool DBBackup { get; set; }
        public bool ImportExport { get; set; }
        public bool RBookList { get; set; }
        public bool RBorrowerList { get; set; }
        public bool ResetData { get; set; }


    }
}
