using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Transaction : Book
    {
        public Transaction()
        {
            PERSON_ID = string.Empty;
            FIRST_NAME = string.Empty;
            MIDDLE_NAME = string.Empty;
            LAST_NAME = string.Empty;

            BOOK_ID = string.Empty;
            TITLE = string.Empty;
            SUBJECT = string.Empty;
            CATEGORY = string.Empty;
            AUTHOR = string.Empty;
            PUBLISH_DATE = string.Empty;
            LOCATION = string.Empty;
            BOOK_PRICE = string.Empty;
            RENT_PRICE = string.Empty;
            ADDED_DATE = string.Empty;
            ADDED_BY = string.Empty;
            MODIFIED_DATE = string.Empty;
            MODIFIED_BY = string.Empty;
            STATUS = string.Empty;
            

            TRANSACTION_NO = string.Empty;
            DUE_INTEREST = 0;
            LD_INTEREST = 0;
            TOTAL_QTY = "";
            TOTAL_DAYS = "";
            TOTAL_AMOUNT = 0;
            BFLAG = false;
        }

        public string TRANSACTION_NO { get; set; }
        public double? DUE_INTEREST { get; set; }
        public double? LD_INTEREST { get; set; }
        public string TOTAL_QTY { get; set; }
        public string TOTAL_DAYS { get; set; }
        public double? TOTAL_AMOUNT { get; set; }
        public bool BFLAG { get; set; }


        public double GetTotalDue(double iRentPrice, double iCopiesBorrowed, double iDaysBorrowed)
        {
            return (iRentPrice * iCopiesBorrowed) * iDaysBorrowed;
        }

        public double GetTotalDueIntrest(double iRentPrice, double iInterestRate, int iDaysDue)
        {
            return (iRentPrice * (iInterestRate / 100)) * iDaysDue;
        }

        public double GetLostDamagePrice(Double iBookPrice, double iLostDamageInterest)
        {
            return iBookPrice * iLostDamageInterest;
        }

        public int GetTotalDaysBorrowed(DateTime dStart, DateTime dEnd)
        {
            return (DateTime.Now - dEnd).Days;
        }      

    }
}
