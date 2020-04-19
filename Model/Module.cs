using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Module
    {
        public Module()
        {
            ManageBook = true;
            BookDetails = true;
            BookAuthor = true;
            BookCategory = true;
            BookRemarks = true;
            BookPolicy = true;

            ManageBorrower = true;
            BorrowerDetails = true;
            BorrowBook = true;
            ReserveBook = true;
            ReturnBook = true;
            BorrowerRequest = true;

            SecuritySettings = true;

            UserAccount = true;
            UserRole = true;    
        
        }


        public bool ManageBook { get; set; }

        public bool BookDetails { get; set; }
        public bool BookAuthor { get; set; }
        public bool BookCategory { get; set; }
        public bool BookRemarks { get; set; }
        public bool BookPolicy { get; set; }

        public bool ManageBorrower { get; set; }

        public bool BorrowerDetails { get; set; }
        public bool BorrowBook { get; set; }
        public bool ReserveBook { get; set; }
        public bool ReturnBook { get; set; }
        public bool BorrowerRequest { get; set; }

        public bool SecuritySettings { get; set; }

        public bool UserAccount { get; set; }
        public bool UserRole { get; set; }

    }
}
