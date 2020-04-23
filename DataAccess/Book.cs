using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using ePublicVariable;


namespace DataAccess
{
    public class Book
    {
        public string sConnectionString = eVariable.sGlobalConnectionString;
        public OleDbConnectionStringBuilder osb = new OleDbConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetBookRecords(eVariable.FILTER_BOOK oFilter, string sStatus, string sFindText)
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                string sQuery;

                switch (oFilter)
                {
                    case eVariable.FILTER_BOOK.BOOK_TITLE:

                        sQuery = " SELECT B.ID AS [BOOK_ID], B.TITLE,B.[SUBJECT],B.CATEGORY,B.AUTHOR,B.PUBLISH_DATE,B.BOOK_PRICE,B.RENT_PRICE,B.LOCATION,    " +
                                 " COUNT(*) - " +
                                 " ((SELECT COUNT(*) FROM TBL_BORROWERREQUEST WHERE BOOK_ID = B.ID AND [STATUS] = 'REQUEST') + (SELECT COUNT(*) FROM TBL_BORROWEDBOOKS WHERE BOOK_ID = B.ID AND [STATUS] = 'BORROWED')) AS [COPIES_AVAILABLE],  " +
                                 " (SELECT COUNT(*) FROM TBL_BOOKS TB WHERE TB.ID = B.ID AND TB.STATUS = 'ACTIVE')[TOTAL_COPIES]  " +
                                 " FROM TBL_BOOKS AS B WHERE B.TITLE LIKE '%" + sFindText + "%' AND B.[STATUS] = '" + sStatus + "'  " +
                                 " GROUP BY ID, TITLE,[SUBJECT],CATEGORY,AUTHOR,PUBLISH_DATE,BOOK_PRICE,RENT_PRICE,LOCATION ";


                        break;
                    case eVariable.FILTER_BOOK.BOOK_CATEGORY:

                        sQuery = " SELECT B.ID AS [BOOK_ID], B.TITLE,B.[SUBJECT],B.CATEGORY,B.AUTHOR,B.PUBLISH_DATE,B.BOOK_PRICE,B.RENT_PRICE,B.LOCATION,    " +
                                 " COUNT(*) - " +
                                 " ((SELECT COUNT(*) FROM TBL_BORROWERREQUEST WHERE BOOK_ID = B.ID AND [STATUS] = 'REQUEST') + (SELECT COUNT(*) FROM TBL_BORROWEDBOOKS WHERE BOOK_ID = B.ID AND [STATUS] = 'BORROWED')) AS [COPIES_AVAILABLE],  " +
                                 " (SELECT COUNT(*) FROM TBL_BOOKS TB WHERE TB.ID = B.ID AND TB.STATUS = 'ACTIVE')[TOTAL_COPIES]  " +
                                 " FROM TBL_BOOKS AS B WHERE B.CATEGORY LIKE '%" + sFindText + "%' AND B.[STATUS] = '" + sStatus + "'  " +
                                 " GROUP BY ID, TITLE,[SUBJECT],CATEGORY,AUTHOR,PUBLISH_DATE,BOOK_PRICE,RENT_PRICE,LOCATION ";

                        break;
                    case eVariable.FILTER_BOOK.BOOK_AUTHOR:

                        sQuery = " SELECT B.ID AS [BOOK_ID], B.TITLE,B.[SUBJECT],B.CATEGORY,B.AUTHOR,B.PUBLISH_DATE,B.BOOK_PRICE,B.RENT_PRICE,B.LOCATION,    " +
                                 " COUNT(*) - " +
                                 " ((SELECT COUNT(*) FROM TBL_BORROWERREQUEST WHERE BOOK_ID = B.ID AND [STATUS] = 'REQUEST') + (SELECT COUNT(*) FROM TBL_BORROWEDBOOKS WHERE BOOK_ID = B.ID AND [STATUS] = 'BORROWED')) AS [COPIES_AVAILABLE],  " +
                                 " (SELECT COUNT(*) FROM TBL_BOOKS TB WHERE TB.ID = B.ID AND TB.STATUS = 'ACTIVE')[TOTAL_COPIES]  " +
                                 " FROM TBL_BOOKS AS B WHERE B.AUTHOR LIKE '%" + sFindText + "%' AND B.[STATUS] = '" + sStatus + "'  " +
                                 " GROUP BY ID, TITLE,[SUBJECT],CATEGORY,AUTHOR,PUBLISH_DATE,BOOK_PRICE,RENT_PRICE,LOCATION ";

                        break;
                    case eVariable.FILTER_BOOK.BOOK_INACTIVE:

                        sQuery = " SELECT B.ID AS [BOOK_ID], B.TITLE,B.[SUBJECT],B.CATEGORY,B.AUTHOR,B.PUBLISH_DATE,B.BOOK_PRICE,B.RENT_PRICE,B.LOCATION,    " +
                                 " COUNT(*) - " +
                                 " ((SELECT COUNT(*) FROM TBL_BORROWERREQUEST WHERE BOOK_ID = B.ID AND [STATUS] = 'REQUEST') + (SELECT COUNT(*) FROM TBL_BORROWEDBOOKS WHERE BOOK_ID = B.ID AND [STATUS] = 'BORROWED')) AS [COPIES_AVAILABLE],  " +
                                 " (SELECT COUNT(*) FROM TBL_BOOKS TB WHERE TB.ID = B.ID AND TB.STATUS = 'ACTIVE')[TOTAL_COPIES]  " +
                                 " FROM TBL_BOOKS AS B WHERE B.[STATUS] = 'INACTIVE'  " +
                                 " GROUP BY ID, TITLE,[SUBJECT],CATEGORY,AUTHOR,PUBLISH_DATE,BOOK_PRICE,RENT_PRICE,LOCATION ";

                        break;
                    case eVariable.FILTER_BOOK.NONE:

                        sQuery = " SELECT B.ID AS [BOOK_ID], B.TITLE,B.[SUBJECT],B.CATEGORY,B.AUTHOR,B.PUBLISH_DATE,B.BOOK_PRICE,B.RENT_PRICE,B.LOCATION,    " +
                                 " COUNT(*) - " +
                                 " ((SELECT COUNT(*) FROM TBL_BORROWERREQUEST WHERE BOOK_ID = B.ID AND [STATUS] = 'REQUEST') + (SELECT COUNT(*) FROM TBL_BORROWEDBOOKS WHERE BOOK_ID = B.ID AND [STATUS] = 'BORROWED')) AS [COPIES_AVAILABLE],  " +
                                 " (SELECT COUNT(*) FROM TBL_BOOKS TB WHERE TB.ID = B.ID AND TB.STATUS = 'ACTIVE')[TOTAL_COPIES]  " +
                                 " FROM TBL_BOOKS AS B WHERE B.[STATUS] = 'ACTIVE'  " +
                                 " GROUP BY ID, TITLE,[SUBJECT],CATEGORY,AUTHOR,PUBLISH_DATE,BOOK_PRICE,RENT_PRICE,LOCATION ";

                        break;
                    case eVariable.FILTER_BOOK.BOOK_DEFAULT:

                        sQuery = "SELECT * FROM TBL_BOOKS WHERE ID = '" + sFindText + "'";

                        break;
                    default:

                        sQuery = " SELECT B.ID AS [BOOK_ID], B.TITLE,B.[SUBJECT],B.CATEGORY,B.AUTHOR,B.PUBLISH_DATE,B.BOOK_PRICE,B.RENT_PRICE,B.LOCATION,    " +
                                 " COUNT(*) - " +
                                 " ((SELECT COUNT(*) FROM TBL_BORROWERREQUEST WHERE BOOK_ID = B.ID AND [STATUS] = 'REQUEST') + (SELECT COUNT(*) FROM TBL_BORROWEDBOOKS WHERE BOOK_ID = B.ID AND [STATUS] = 'BORROWED')) AS [COPIES_AVAILABLE],  " +
                                 " (SELECT COUNT(*) FROM TBL_BOOKS TB WHERE TB.ID = B.ID AND TB.STATUS = 'ACTIVE')[TOTAL_COPIES]  " +
                                 " FROM TBL_BOOKS AS B WHERE B.[STATUS] = 'ACTIVE'  " +
                                 " GROUP BY ID, TITLE,[SUBJECT],CATEGORY,AUTHOR,PUBLISH_DATE,BOOK_PRICE,RENT_PRICE,LOCATION ";
                        break;

                }

                ddq.CommandText = sQuery;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables.Count > 0 ? ds.Tables[0] : null;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
   
        public Boolean IsBookAvailable(Model.Transaction oData)
        {
            try
            {
                string sQuery = string.Empty;

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = " SELECT BOOK_NO FROM TBL_BOOKS WHERE BOOK_NO = '" + oData.BOOK_NO + "' AND [STATUS] = 'ACTIVE' " +
                                  " AND BOOK_NO IN (SELECT BOOK_NO FROM TBL_BORROWERREQUEST WHERE [STATUS] = 'REQUEST') " +
                                  " OR BOOK_NO IN (SELECT BOOK_NO FROM TBL_BORROWEDBOOKS WHERE [STATUS] = 'BORROWED') ";

                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetBookIDList(Model.Transaction oData)
        {
            try
            {
                string sQuery = string.Empty;

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                sQuery = "SELECT ID AS BOOK_ID, BOOK_NO, ISBN_NUMBER, REMARKS,[STATUS] FROM TBL_BOOKS WHERE ID = '" + oData.BOOK_ID + "'";


                ddq.CommandText = sQuery;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables.Count > 0 ? ds.Tables[0] : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetBookNoISBNNumber(Model.Transaction oData)
        {
            try
            {
                string sQuery = string.Empty;

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                sQuery = " SELECT ID AS BOOK_ID, BOOK_NO, ISBN_NUMBER, REMARKS,[STATUS] FROM TBL_BOOKS WHERE ID = '" + oData.BOOK_ID + "' AND BOOK_NO = '" + oData.BOOK_NO + "' AND [STATUS] = 'ACTIVE'  " +
                         " AND (BOOK_NO NOT IN (SELECT BOOK_NO FROM TBL_BORROWERREQUEST WHERE [STATUS] = 'REQUEST')  " +
                         " AND BOOK_NO NOT IN (SELECT BOOK_NO FROM TBL_BORROWEDBOOKS WHERE [STATUS] = 'BORROWED')) ";

                ddq.CommandText = sQuery;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables.Count > 0 ? ds.Tables[0] : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetBookISBN(eVariable.FIND_TYPE o_FindType, string sFindText)
        {
            try
            {
                string sQuery = string.Empty;

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                switch (o_FindType)
                {
                    case eVariable.FIND_TYPE.BOOK_ID:
                        sQuery = "SELECT ID, BOOK_NO, ISBN_NUMBER,REMARKS,[STATUS] FROM TBL_BOOKS WHERE ID = '" + sFindText + "'";
                        break;
                    case eVariable.FIND_TYPE.BOOK_NO:
                        sQuery = "SELECT ID, BOOK_NO, ISBN_NUMBER,REMARKS,[STATUS] FROM TBL_BOOKS WHERE BOOK_NO = '" + sFindText + "'";
                        break;
                    default:
                        sQuery = "SELECT ID,BOOK_NO, ISBN_NUMBER,REMARKS,[STATUS] FROM TBL_BOOKS";
                        break;
                }

                ddq.CommandText = sQuery;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables.Count > 0 ? ds.Tables[0] : null;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public DataTable GetTransactionBookRecordPerBorrower(eVariable.FIND_BOOK oFilter, string sBorrowerID)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                string sQuery;

                switch (oFilter)
                {
                    case eVariable.FIND_BOOK.BOOK_BORROWED:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED,ADDED_DATE FROM TBL_BORROWEDBOOKS WHERE BORROWER_ID = '" + sBorrowerID + "' AND [STATUS] = 'BORROWED' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED,ADDED_DATE";
                        break;
                    case eVariable.FIND_BOOK.BOOK_RETURNED:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED,ADDED_DATE FROM TBL_BORROWEDBOOKS WHERE BORROWER_ID = '" + sBorrowerID + "' AND [STATUS] = 'RETURNED' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED,ADDED_DATE";
                        break;
                    case eVariable.FIND_BOOK.BOOK_REQUESTED:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED,ADDED_DATE FROM TBL_BORROWERREQUEST WHERE BORROWER_ID = '" + sBorrowerID + "' AND [STATUS] = 'REQUEST' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED,ADDED_DATE";
                        break;
                    case eVariable.FIND_BOOK.BOOK_PENALTY:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED,ADDED_DATE FROM TBL_BORROWEDBOOKS WHERE BORROWER_ID = '" + sBorrowerID + "' AND [STATUS] = 'BORROWED' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED,ADDED_DATE";
                        break;
                    default:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED,ADDED_DATE FROM TBL_BORROWEDBOOKS WHERE BORROWER_ID = '" + sBorrowerID + "' AND [STATUS] = 'BORROWED' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED,ADDED_DATE";
                        break;
                }

                ddq.CommandText = sQuery;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables.Count > 0 ? ds.Tables[0] : null;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public DataTable GetTransactionBookRecordPerBorrowerNotSort(eVariable.FIND_BOOK oFilter, string sBorrowerID)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                string sQuery;

                switch (oFilter)
                {
                    case eVariable.FIND_BOOK.BOOK_BORROWED:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED,ADDED_DATE,BOOK_NO,ISBN_NUMBER FROM TBL_BORROWEDBOOKS WHERE BORROWER_ID = '" + sBorrowerID + "' AND [STATUS] = 'BORROWED' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED,ADDED_DATE,BOOK_NO,ISBN_NUMBER";
                        break;
                    case eVariable.FIND_BOOK.BOOK_RETURNED:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED,ADDED_DATE,BOOK_NO,ISBN_NUMBER FROM TBL_BORROWEDBOOKS WHERE BORROWER_ID = '" + sBorrowerID + "' AND [STATUS] = 'RETURNED' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED,ADDED_DATE,BOOK_NO,ISBN_NUMBER";
                        break;
                    case eVariable.FIND_BOOK.BOOK_REQUESTED:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED,ADDED_DATE,BOOK_NO,ISBN_NUMBER FROM TBL_BORROWERREQUEST WHERE BORROWER_ID = '" + sBorrowerID + "' AND [STATUS] = 'REQUEST' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED,ADDED_DATE,BOOK_NO,ISBN_NUMBER";
                        break;
                    case eVariable.FIND_BOOK.BOOK_PENALTY:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED,ADDED_DATE,BOOK_NO,ISBN_NUMBER FROM TBL_BORROWERREQUEST WHERE BORROWER_ID = '" + sBorrowerID + "' AND [STATUS] = 'PENALTY' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED,ADDED_DATE,BOOK_NO,ISBN_NUMBER";
                        break;
                    default:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED,ADDED_DATE,BOOK_NO,ISBN_NUMBER FROM TBL_BORROWERREQUEST WHERE BORROWER_ID = '" + sBorrowerID + "' AND [STATUS] = 'BORROWED' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED,ADDED_DATE,BOOK_NO,ISBN_NUMBER";
                        break;
                }

                ddq.CommandText = sQuery;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables.Count > 0 ? ds.Tables[0] : null;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public Boolean IsBookCheckout(Model.Transaction oData)
        {
            osb.ConnectionString = sConnectionString;
            ddq = new DatabaseQuery.DBQuery();
            ddq.ConnectionString = osb.ConnectionString;

            ddq.CommandText = " SELECT ID FROM TBL_BOOKS WHERE BOOK_NO = '" + oData.BOOK_NO + "' AND [STATUS] = 'ACTIVE' " +
                             " AND BOOK_NO IN (SELECT BOOK_NO FROM TBL_BORROWEDBOOKS WHERE [STATUS] = 'BORROWED') " +
                             " OR BOOK_NO IN (SELECT BOOK_NO FROM TBL_BORROWERREQUEST WHERE [STATUS] = 'REQUEST') ";

            ds = ddq.GetDataset(CommandType.Text);
            return ds.Tables[0].Rows.Count > 0 ? true : false;
        }

        public DataTable GetTransactionBookRecordPerStatus(eVariable.FIND_BOOK oFilter)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                string sQuery;

                switch (oFilter)
                {
                    case eVariable.FIND_BOOK.BOOK_BORROWED:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED FROM TBL_BORROWEDBOOKS WHERE [STATUS] = 'BORROWED' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED";
                        break;
                    case eVariable.FIND_BOOK.BOOK_RETURNED:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED FROM TBL_BORROWEDBOOKS WHERE [STATUS] = 'RETURNED' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED";
                        break;
                    case eVariable.FIND_BOOK.BOOK_REQUESTED:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED FROM TBL_BORROWEDBOOKS WHERE [STATUS] = 'REQUESTED' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED";
                        break;
                    case eVariable.FIND_BOOK.BOOK_PENALTY:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED FROM TBL_BORROWEDBOOKS WHERE [STATUS] = 'DAMAGED' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED";
                        break;
                    default:
                        sQuery = "SELECT BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,COUNT(*) BOOK_COUNT,DAYS_BORROWED FROM TBL_BORROWEDBOOKS WHERE [STATUS] = 'BORROWED' GROUP BY BOOK_ID, TITLE, [SUBJECT], CATEGORY, AUTHOR, PUBLISH_DATE, LOCATION, BOOK_PRICE, RENT_PRICE, DUE_PENALTY_INTEREST, LOST_DAMAGE_INTEREST,DAYS_BORROWED";
                        break;
                }

                ddq.CommandText = sQuery;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables.Count > 0 ? ds.Tables[0] : null;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public DataTable GetBorrowedBookISBNPerBorrower(eVariable.FIND_TYPE oFilter, string sBookID, string sBorrowerID)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;
                string sQuery = string.Empty;

                switch (oFilter)
                {
                    case eVariable.FIND_TYPE.BOOK_ID:
                        sQuery = "SELECT BOOK_ID, BOOK_NO, ISBN_NUMBER, REMARKS, [STATUS] FROM TBL_BORROWEDBOOKS WHERE BOOK_ID = '" + sBookID + "' AND [STATUS] = 'BORROWED'";
                        break;

                    case eVariable.FIND_TYPE.BORROWER_ID:
                        sQuery = "SELECT BOOK_ID,BOOK_NO, ISBN_NUMBER, REMARKS, [STATUS] FROM TBL_BORROWEDBOOKS WHERE BOOK_ID = '" + sBookID + "' AND BORROWER_ID = '" + sBorrowerID + "' AND [STATUS] = 'BORROWED' ";
                        break;

                    default:
                        sQuery = "SELECT BOOK_ID, BOOK_NO, ISBN_NUMBER, REMARKS, [STATUS] FROM TBL_BORROWEDBOOKS WHERE [STATUS] = 'BORROWED' ";
                        break;
                }

                ddq.CommandText = sQuery;

                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables.Count > 0 ? ds.Tables[0] : null;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public int GetBookID()
        {
            osb.ConnectionString = sConnectionString;
            ddq = new DatabaseQuery.DBQuery();
            ddq.ConnectionString = osb.ConnectionString;
            ddq.CommandText = "SELECT TOP 1 ID FROM TBL_BOOKS ORDER BY ID DESC";
            ds = ddq.GetDataset(CommandType.Text);

            return ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds.Tables[0].Rows[0][0]) : 0;
        }

        public int GetBookNo()
        {
            osb.ConnectionString = sConnectionString;
            ddq = new DatabaseQuery.DBQuery();
            ddq.ConnectionString = osb.ConnectionString;


            ddq.CommandText = "SELECT TOP 1 BOOK_NO FROM TBL_BOOKS ORDER BY BOOK_NO DESC";
            ds = ddq.GetDataset(CommandType.Text);

            return ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(Regex.Replace(ds.Tables[0].Rows[0][0].ToString(), "[^0-9]", "")) : 0;
        }

        public int GetTransactionNo()
        {
            osb.ConnectionString = sConnectionString;
            ddq = new DatabaseQuery.DBQuery();
            ddq.ConnectionString = osb.ConnectionString;


            ddq.CommandText = "SELECT TOP 1 TRANSACTION_NO FROM TBL_BORROWEDBOOKS ORDER BY TRANSACTION_NO DESC";
            ds = ddq.GetDataset(CommandType.Text);

            return ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(Regex.Replace(ds.Tables[0].Rows[0][0].ToString(), "[^0-9]", "")) : 0;
        }

        public Boolean IsBookRecordDataExists(eVariable.FIND_TYPE oFilter, string sFindText)
        {
            try
            {
                string sQuery = string.Empty;
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                switch (oFilter)
                {
                    case eVariable.FIND_TYPE.ISBN_NUMBER:
                        sQuery = "SELECT * FROM TBL_BOOKS WHERE ISBN_NUMBER = '" + sFindText + "'";
                        break;
                    case eVariable.FIND_TYPE.BOOK_NO:
                        sQuery = "SELECT * FROM TBL_BOOKS WHERE BOOK_NO = '" + sFindText + "'";
                        break;
                    default:
                        sQuery = "SELECT * FROM TBL_BOOKS WHERE ISBN_NUMBER = '" + sFindText + "'";
                        break;
                }

                ddq.CommandText = sQuery;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public void InsertBook(Model.Transaction oMTransaction)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "SP_INSERT_BOOK";
                ddq.AddParamer("@ID", SqlDbType.Int, oMTransaction.BOOK_ID);
                ddq.AddParamer("@BOOK_NO", SqlDbType.VarChar, oMTransaction.BOOK_NO);
                ddq.AddParamer("@TITLE", SqlDbType.VarChar, oMTransaction.TITLE);
                ddq.AddParamer("@SUBJECT", SqlDbType.VarChar, oMTransaction.SUBJECT);
                ddq.AddParamer("@CATEGORY", SqlDbType.VarChar, oMTransaction.CATEGORY);
                ddq.AddParamer("@AUTHOR", SqlDbType.VarChar, oMTransaction.AUTHOR);
                ddq.AddParamer("@PUBLISH_DATE", SqlDbType.VarChar, oMTransaction.PUBLISH_DATE);
                ddq.AddParamer("@ISBN_NUMBER", SqlDbType.VarChar, oMTransaction.ISBN_NUMBER);
                ddq.AddParamer("@LOCATION", SqlDbType.VarChar, oMTransaction.LOCATION);
                ddq.AddParamer("@BOOK_PRICE", SqlDbType.VarChar, oMTransaction.BOOK_PRICE);
                ddq.AddParamer("@RENT_PRICE", SqlDbType.VarChar, oMTransaction.RENT_PRICE);
                ddq.AddParamer("@ADDED_DATE", SqlDbType.VarChar, oMTransaction.ADDED_DATE);
                ddq.AddParamer("@ADDED_BY", SqlDbType.VarChar, oMTransaction.ADDED_BY);
                ddq.AddParamer("@MODIFIED_DATE", SqlDbType.VarChar, oMTransaction.MODIFIED_DATE);
                ddq.AddParamer("@MODIFIED_BY", SqlDbType.VarChar, oMTransaction.MODIFIED_BY);
                ddq.ExecuteNonQuery(CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void CheckOutBook(Model.Transaction oMTransaction)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "SP_CHECKOUT_BOOK";
                ddq.AddParamer("@BOOK_ID", SqlDbType.VarChar, oMTransaction.BOOK_ID);
                ddq.AddParamer("@BORROWER_ID", SqlDbType.VarChar, oMTransaction.PERSON_ID);
                ddq.AddParamer("@BOOK_NO", SqlDbType.VarChar, oMTransaction.BOOK_NO);
                ddq.AddParamer("@TITLE", SqlDbType.VarChar, oMTransaction.TITLE);
                ddq.AddParamer("@SUBJECT", SqlDbType.VarChar, oMTransaction.SUBJECT);
                ddq.AddParamer("@CATEGORY", SqlDbType.VarChar, oMTransaction.CATEGORY);
                ddq.AddParamer("@AUTHOR", SqlDbType.VarChar, oMTransaction.AUTHOR);
                ddq.AddParamer("@PUBLISH_DATE", SqlDbType.VarChar, oMTransaction.PUBLISH_DATE);
                ddq.AddParamer("@ISBN_NUMBER", SqlDbType.VarChar, oMTransaction.ISBN_NUMBER);
                ddq.AddParamer("@LOCATION", SqlDbType.VarChar, oMTransaction.LOCATION);
                ddq.AddParamer("@BOOK_PRICE", SqlDbType.VarChar, oMTransaction.BOOK_PRICE);
                ddq.AddParamer("@RENT_PRICE", SqlDbType.VarChar, oMTransaction.RENT_PRICE);
                ddq.AddParamer("@DAYS_BORROWED", SqlDbType.VarChar, oMTransaction.TOTAL_DAYS);
                ddq.AddParamer("@ADDED_DATE", SqlDbType.VarChar, oMTransaction.ADDED_DATE);
                ddq.AddParamer("@ADDED_BY", SqlDbType.VarChar, oMTransaction.ADDED_BY);
                ddq.AddParamer("@TRANSACTION_NO", SqlDbType.VarChar, oMTransaction.TRANSACTION_NO);
                ddq.ExecuteNonQuery(CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }        

        public void RequestBook(Model.Transaction oMTransaction)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "SP_REQUEST_BOOK";
                ddq.AddParamer("@ID", SqlDbType.VarChar, oMTransaction.BOOK_ID);
                ddq.AddParamer("@BORROWER_ID", SqlDbType.VarChar, oMTransaction.PERSON_ID);
                ddq.AddParamer("@BOOK_NO", SqlDbType.VarChar, oMTransaction.BOOK_NO);
                ddq.AddParamer("@TITLE", SqlDbType.VarChar, oMTransaction.TITLE);
                ddq.AddParamer("@SUBJECT", SqlDbType.VarChar, oMTransaction.SUBJECT);
                ddq.AddParamer("@CATEGORY", SqlDbType.VarChar, oMTransaction.CATEGORY);
                ddq.AddParamer("@AUTHOR", SqlDbType.VarChar, oMTransaction.AUTHOR);
                ddq.AddParamer("@PUBLISH_DATE", SqlDbType.VarChar, oMTransaction.PUBLISH_DATE);
                ddq.AddParamer("@ISBN_NUMBER", SqlDbType.VarChar, oMTransaction.ISBN_NUMBER);
                ddq.AddParamer("@LOCATION", SqlDbType.VarChar, oMTransaction.LOCATION);
                ddq.AddParamer("@BOOK_PRICE", SqlDbType.VarChar, oMTransaction.BOOK_PRICE);
                ddq.AddParamer("@RENT_PRICE", SqlDbType.VarChar, oMTransaction.RENT_PRICE);
                ddq.AddParamer("@DAYS_BORROWED", SqlDbType.VarChar, oMTransaction.TOTAL_DAYS);
                ddq.AddParamer("@ADDED_DATE", SqlDbType.VarChar, oMTransaction.ADDED_DATE);
                ddq.AddParamer("@ADDED_BY", SqlDbType.VarChar, oMTransaction.ADDED_BY);
                ddq.AddParamer("@STATUS", SqlDbType.VarChar, oMTransaction.STATUS);

                ddq.ExecuteNonQuery(CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateBook(Model.Transaction oMTransaction)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "SP_UPDATE_BOOK";
                ddq.AddParamer("@ID", SqlDbType.VarChar, oMTransaction.BOOK_ID);
                ddq.AddParamer("@BOOK_NO", SqlDbType.VarChar, oMTransaction.BOOK_NO);
                ddq.AddParamer("@TITLE", SqlDbType.VarChar, oMTransaction.TITLE);
                ddq.AddParamer("@SUBJECT", SqlDbType.VarChar, oMTransaction.SUBJECT);
                ddq.AddParamer("@CATEGORY", SqlDbType.VarChar, oMTransaction.CATEGORY);
                ddq.AddParamer("@AUTHOR", SqlDbType.VarChar, oMTransaction.AUTHOR);
                ddq.AddParamer("@PUBLISH_DATE", SqlDbType.VarChar, oMTransaction.PUBLISH_DATE);
                ddq.AddParamer("@LOCATION", SqlDbType.VarChar, oMTransaction.LOCATION);
                ddq.AddParamer("@BOOK_PRICE", SqlDbType.VarChar, oMTransaction.BOOK_PRICE);
                ddq.AddParamer("@RENT_PRICE", SqlDbType.VarChar, oMTransaction.RENT_PRICE);
                ddq.AddParamer("@ISBN_NUMBER", SqlDbType.VarChar, oMTransaction.ISBN_NUMBER);
                ddq.AddParamer("@MODIFIED_DATE", SqlDbType.VarChar, oMTransaction.MODIFIED_DATE);
                ddq.AddParamer("@MODIFIED_BY", SqlDbType.VarChar, oMTransaction.MODIFIED_BY);
                ddq.AddParamer("@REMARKS", SqlDbType.VarChar, oMTransaction.REMARKS);
                ddq.AddParamer("@STATUS", SqlDbType.VarChar, oMTransaction.STATUS);
                ddq.ExecuteNonQuery(CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateBookDetails(Model.Transaction oMTransaction)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "SP_UPDATE_BOOK_DETAILS";
                ddq.AddParamer("@ID", SqlDbType.VarChar, oMTransaction.BOOK_ID);
                ddq.AddParamer("@BOOK_NO", SqlDbType.VarChar, oMTransaction.BOOK_NO);
                ddq.AddParamer("@TITLE", SqlDbType.VarChar, oMTransaction.TITLE);
                ddq.AddParamer("@SUBJECT", SqlDbType.VarChar, oMTransaction.SUBJECT);
                ddq.AddParamer("@CATEGORY", SqlDbType.VarChar, oMTransaction.CATEGORY);
                ddq.AddParamer("@AUTHOR", SqlDbType.VarChar, oMTransaction.AUTHOR);
                ddq.AddParamer("@PUBLISH_DATE", SqlDbType.VarChar, oMTransaction.PUBLISH_DATE);
                ddq.AddParamer("@LOCATION", SqlDbType.VarChar, oMTransaction.LOCATION);
                ddq.AddParamer("@BOOK_PRICE", SqlDbType.VarChar, oMTransaction.BOOK_PRICE);
                ddq.AddParamer("@RENT_PRICE", SqlDbType.VarChar, oMTransaction.RENT_PRICE);
                ddq.AddParamer("@ISBN_NUMBER", SqlDbType.VarChar, oMTransaction.ISBN_NUMBER);
                ddq.AddParamer("@MODIFIED_DATE", SqlDbType.VarChar, oMTransaction.MODIFIED_DATE);
                ddq.AddParamer("@MODIFIED_BY", SqlDbType.VarChar, oMTransaction.MODIFIED_BY);
                ddq.AddParamer("@REMARKS", SqlDbType.VarChar, oMTransaction.REMARKS);
                ddq.AddParamer("@STATUS", SqlDbType.VarChar, oMTransaction.STATUS);
                ddq.ExecuteNonQuery(CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ReturnBook(Model.Transaction oMTransaction)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "SP_RETURN_BOOK";
                ddq.AddParamer("@BOOK_ID", SqlDbType.VarChar, oMTransaction.BOOK_ID);
                ddq.AddParamer("@BORROWER_ID", SqlDbType.VarChar, oMTransaction.PERSON_ID);
                ddq.AddParamer("@BOOK_NO", SqlDbType.VarChar, oMTransaction.BOOK_NO);
                ddq.AddParamer("@MODIFIED_DATE", SqlDbType.VarChar, oMTransaction.MODIFIED_DATE);
                ddq.AddParamer("@MODIFIED_BY", SqlDbType.VarChar, oMTransaction.MODIFIED_BY);
                ddq.AddParamer("@TOTAL_AMOUNT", SqlDbType.Decimal, oMTransaction.TOTAL_AMOUNT);
                ddq.AddParamer("@REMARKS", SqlDbType.VarChar, oMTransaction.REMARKS);
                ddq.AddParamer("@STATUS", SqlDbType.VarChar, oMTransaction.STATUS);

                ddq.ExecuteNonQuery(CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
     
        public void DeleteUnsettledRequestTransaction(DateTime dTFrom, DateTime dTTo)
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "DELETE FROM TBL_BORROWERREQUEST WHERE [STATUS] = 'REQUEST' AND ADDED_DATE BETWEEN '" + dTFrom.ToString("yyyy-MM-dd") + "' AND '" + dTTo.ToString("yyyy-MM-dd") + "'";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

     
    }
}
