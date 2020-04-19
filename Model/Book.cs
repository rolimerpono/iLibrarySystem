using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Book : Borrower
    {

        public Book()
        {
            BOOK_ID = string.Empty;
            BOOK_NO = string.Empty;
            TITLE = string.Empty;
            SUBJECT = string.Empty;
            CATEGORY = string.Empty;
            AUTHOR = string.Empty;
            ISBN_NUMBER = string.Empty;
            PUBLISH_DATE = string.Empty;
            LOCATION = string.Empty;
            BOOK_PRICE = string.Empty;
            RENT_PRICE = string.Empty;
            ADDED_DATE = string.Empty;
            ADDED_BY = string.Empty;
            MODIFIED_DATE = string.Empty;
            MODIFIED_BY = string.Empty;
            REMARKS = string.Empty;
        }

        public string BOOK_ID { get; set; }
        public string BOOK_NO { get; set; }
        public string TITLE { get; set; }
        public string SUBJECT { get; set; }
        public string CATEGORY { get; set; }
        public string AUTHOR { get; set; }
        public string ISBN_NUMBER { get; set; }
        public string PUBLISH_DATE { get; set; }
        public string LOCATION { get; set; }
        public string BOOK_PRICE { get; set; }
        public string RENT_PRICE { get; set; }
        public string REMARKS { get; set; }
 
    }
}
