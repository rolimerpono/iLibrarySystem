using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using ePublicVariable;

namespace DataAccess
{

    
    public class Reports
    {

        public string sConnectionString = eVariable.sGlobalConnectionString;
        public OleDbConnectionStringBuilder osb = new OleDbConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();        

        public DataTable Get_BookReport(ePublicVariable.eVariable.BOOK_STATUS e_ReportStatus, DateTime dDateFrom, DateTime dDateTo)
        {
            try
            {
                string sQuery = "";
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                switch (e_ReportStatus)
                {
                    case eVariable.BOOK_STATUS.BOOK_RECORDLIST:
                        sQuery = " SELECT B.ID AS [BOOK_ID], B.TITLE,B.[SUBJECT],B.CATEGORY,B.AUTHOR,B.PUBLISH_DATE,B.BOOK_PRICE,B.RENT_PRICE,B.LOCATION,    " +
                                 " COUNT(*) - " +
                                 " ((SELECT COUNT(*) FROM TBL_BORROWERREQUEST WHERE BOOK_ID = B.ID AND [STATUS] = 'REQUEST') + (SELECT COUNT(*) FROM TBL_BORROWEDBOOKS WHERE BOOK_ID = B.ID AND [STATUS] = 'BORROWED')) AS [COPIES_AVAILABLE],  " +
                                 " (SELECT COUNT(*) FROM TBL_BOOKS TB WHERE TB.ID = B.ID AND TB.STATUS = 'ACTIVE')[TOTAL_COPIES]  " +
                                 " FROM TBL_BOOKS AS B WHERE B.ADDED_DATE BETWEEN '" + dDateFrom.ToString("yyyy-MM-dd") + "' AND '" + dDateTo.ToString("yyyy-MM-dd") + "' AND B.[STATUS] = 'ACTIVE'  " +
                                 " GROUP BY ID, TITLE,[SUBJECT],CATEGORY,AUTHOR,PUBLISH_DATE,BOOK_PRICE,RENT_PRICE,LOCATION ";
                        break;
          
                    case eVariable.BOOK_STATUS.BORROWED_BOOKS:
                        sQuery = " SELECT BOOK_ID, B.TITLE,B.[SUBJECT],B.CATEGORY,B.AUTHOR,B.PUBLISH_DATE,B.BOOK_PRICE,B.RENT_PRICE,B.LOCATION,  " +
                                 " (SELECT COUNT(*) FROM TBL_BOOKS WHERE ID = B.BOOK_ID) - " +
                                 " (CASE WHEN (SELECT COUNT(*) FROM TBL_BOOKS WHERE STATUS = 'INACTIVE' AND ID = B.BOOK_ID GROUP BY ID) IS NULL THEN '0' ELSE  (SELECT COUNT(*) FROM TBL_BOOKS WHERE STATUS = 'INACTIVE' AND ID = B.BOOK_ID GROUP BY ID) END + (SELECT COUNT(*) FROM TBL_BORROWERREQUEST WHERE BOOK_ID = B.BOOK_ID AND [STATUS] = 'REQUEST' AND BOOK_NO NOT IN(SELECT BOOK_NO FROM TBL_BOOKS WHERE [STATUS] = 'INACTIVE')) + (SELECT COUNT(*) FROM TBL_BORROWEDBOOKS WHERE BOOK_ID = B.BOOK_ID AND [STATUS] = 'BORROWED' AND BOOK_NO NOT IN(SELECT BOOK_NO FROM TBL_BOOKS WHERE [STATUS] = 'INACTIVE'))) AS [COPIES_AVAILABLE], " +
                                 " COUNT(*) TOTAL_COPIES " +                   
                                 " FROM TBL_BORROWEDBOOKS AS B " +
                                 " WHERE B.[STATUS] = 'BORROWED' AND B.ADDED_DATE BETWEEN  '" + dDateFrom.ToString("yyyy-MM-dd") + "' AND '" + dDateTo.ToString("yyyy-MM-dd") + "' GROUP BY B.BOOK_ID, B.TITLE,B.[SUBJECT],B.CATEGORY,B.AUTHOR,B.PUBLISH_DATE,B.BOOK_PRICE,B.RENT_PRICE,B.LOCATION";

                        break;
                    case eVariable.BOOK_STATUS.RETUNRNED_BOOKS:
                        sQuery = " SELECT BOOK_ID, B.TITLE,B.[SUBJECT],B.CATEGORY,B.AUTHOR,B.PUBLISH_DATE,B.BOOK_PRICE,B.RENT_PRICE,B.LOCATION,  " +
                                 " (SELECT COUNT(*) FROM TBL_BOOKS WHERE ID = B.BOOK_ID) - " +
                                 " (CASE WHEN (SELECT COUNT(*) FROM TBL_BOOKS WHERE STATUS = 'INACTIVE' AND ID = B.BOOK_ID GROUP BY ID) IS NULL THEN '0' ELSE  (SELECT COUNT(*) FROM TBL_BOOKS WHERE STATUS = 'INACTIVE' AND ID = B.BOOK_ID GROUP BY ID) END + (SELECT COUNT(*) FROM TBL_BORROWERREQUEST WHERE BOOK_ID = B.BOOK_ID AND [STATUS] = 'REQUEST' AND BOOK_NO NOT IN(SELECT BOOK_NO FROM TBL_BOOKS WHERE [STATUS] = 'INACTIVE')) + (SELECT COUNT(*) FROM TBL_BORROWEDBOOKS WHERE BOOK_ID = B.BOOK_ID AND [STATUS] = 'BORROWED' AND BOOK_NO NOT IN(SELECT BOOK_NO FROM TBL_BOOKS WHERE [STATUS] = 'INACTIVE'))) AS [COPIES_AVAILABLE], " +
                                 " COUNT(*) TOTAL_COPIES " +
                                 " FROM TBL_BORROWEDBOOKS AS B " +
                                 " WHERE B.[STATUS] = 'RETURNED' AND B.ADDED_DATE BETWEEN  '" + dDateFrom.ToString("yyyy-MM-dd") + "' AND '" + dDateTo.ToString("yyyy-MM-dd") + "' GROUP BY B.BOOK_ID, B.TITLE,B.[SUBJECT],B.CATEGORY,B.AUTHOR,B.PUBLISH_DATE,B.BOOK_PRICE,B.RENT_PRICE,B.LOCATION";

                        break;

                    case eVariable.BOOK_STATUS.REQUEST_BOOKS:
                        sQuery = " SELECT BOOK_ID, B.TITLE,B.[SUBJECT],B.CATEGORY,B.AUTHOR,B.PUBLISH_DATE,B.BOOK_PRICE,B.RENT_PRICE,B.LOCATION,  " +
                                 " (SELECT COUNT(*) FROM TBL_BOOKS WHERE ID = B.BOOK_ID) - " +
                                 " (CASE WHEN (SELECT COUNT(*) FROM TBL_BOOKS WHERE STATUS = 'INACTIVE' AND ID = B.BOOK_ID GROUP BY ID) IS NULL THEN '0' ELSE  (SELECT COUNT(*) FROM TBL_BOOKS WHERE STATUS = 'INACTIVE' AND ID = B.BOOK_ID GROUP BY ID) END + (SELECT COUNT(*) FROM TBL_BORROWERREQUEST WHERE BOOK_ID = B.BOOK_ID AND [STATUS] = 'REQUEST' AND BOOK_NO NOT IN(SELECT BOOK_NO FROM TBL_BOOKS WHERE [STATUS] = 'INACTIVE')) + (SELECT COUNT(*) FROM TBL_BORROWEDBOOKS WHERE BOOK_ID = B.BOOK_ID AND [STATUS] = 'BORROWED' AND BOOK_NO NOT IN(SELECT BOOK_NO FROM TBL_BOOKS WHERE [STATUS] = 'INACTIVE'))) AS [COPIES_AVAILABLE], " +
                                 " COUNT(*) TOTAL_COPIES " +
                                 " FROM TBL_BORROWERREQUEST AS B " +
                                 " WHERE B.[STATUS] = 'REQUEST' AND B.ADDED_DATE BETWEEN  '" + dDateFrom.ToString("yyyy-MM-dd") + "' AND '" + dDateTo.ToString("yyyy-MM-dd") + "' GROUP BY B.BOOK_ID, B.TITLE,B.[SUBJECT],B.CATEGORY,B.AUTHOR,B.PUBLISH_DATE,B.BOOK_PRICE,B.RENT_PRICE,B.LOCATION";

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


        public DataTable Get_BorrowerReport(ePublicVariable.eVariable.BORROWER_STATUS e_ReportStatus, DateTime dDateFrom, DateTime dDateTo)
        {
            try
            {
                string sQuery = "";
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                switch (e_ReportStatus)
                { 
                    case eVariable.BORROWER_STATUS.BORROWER_RECORDLIST:
                        sQuery = "SELECT * FROM TBL_BORROWER WHERE STATUS = 'ACTIVE' AND ADDED_DATE BETWEEN '" + dDateFrom.ToString("yyyy-MM-dd") + "' AND '" + dDateTo.ToString("yyyy-MM-dd") + "'";
                        break;              
                    case eVariable.BORROWER_STATUS.REQUESTED_BOOKS:
                        sQuery = " SELECT  A.BORROWER_ID, B.FIRST_NAME, B.MIDDLE_NAME, B.LAST_NAME, A.ADDED_DATE FROM TBL_BORROWERREQUEST A INNER JOIN TBL_BORROWER B ON A.BORROWER_ID = B.BORROWER_ID " +
                                  " WHERE A.[STATUS]= 'REQUEST' AND A.ADDED_DATE BETWEEN '" + dDateFrom.ToString("yyyy-MM-dd") + "' AND '" + dDateTo.ToString("yyyy-MM-dd") + "' GROUP BY  A.BORROWER_ID, B.FIRST_NAME, B.MIDDLE_NAME, B.LAST_NAME,A.ADDED_DATE";

                        break;
                    case eVariable.BORROWER_STATUS.UNRETURNED_BOOKS:
                        sQuery = " SELECT  A.BORROWER_ID, B.FIRST_NAME, B.MIDDLE_NAME, B.LAST_NAME, A.ADDED_DATE FROM TBL_BORROWEDBOOKS A INNER JOIN TBL_BORROWER B ON A.BORROWER_ID = B.BORROWER_ID " +
                                  " WHERE A.[STATUS]= 'BORROWED' AND A.ADDED_DATE BETWEEN '" + dDateFrom.ToString("yyyy-MM-dd") + "' AND '" + dDateTo.ToString("yyyy-MM-dd") + "' GROUP BY  A.BORROWER_ID, B.FIRST_NAME, B.MIDDLE_NAME, B.LAST_NAME,A.ADDED_DATE";

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


        public DataTable Get_BorrowerSubReport(ePublicVariable.eVariable.BORROWER_STATUS e_ReportStatus, string sBorrower_ID, DateTime dDateFrom, DateTime dDateTo)
        {
            try
            {
                string sQuery = "";
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                switch (e_ReportStatus)
                {
                    case eVariable.BORROWER_STATUS.BORROWER_RECORDLIST:
                        sQuery = "SELECT * FROM TBL_BORROWER WHERE STATUS = 'ACTIVE' AND ADDED_DATE BETWEEN '" + dDateFrom.ToString("yyyy-MM-dd") + "' AND '" + dDateTo.ToString("yyyy-MM-dd") + "'";
                        break;
  
                    case eVariable.BORROWER_STATUS.REQUESTED_BOOKS:
                        sQuery = " SELECT BORROWER_ID, BOOK_NO, TITLE, AUTHOR, ISBN_NUMBER, BOOK_PRICE, RENT_PRICE, DAYS_BORROWED " +
                                 " FROM TBL_BORROWERREQUEST WHERE [STATUS] = 'REQUEST' AND ADDED_DATE BETWEEN '" + dDateFrom.ToString("yyyy-MM-dd") + "' AND '" + dDateTo.ToString("yyyy-MM-dd") + "' AND BORROWER_ID = '" + sBorrower_ID + "'";

                        break;
                    case eVariable.BORROWER_STATUS.UNRETURNED_BOOKS:
                        sQuery = " SELECT BORROWER_ID, BOOK_NO, TITLE, AUTHOR, ISBN_NUMBER, BOOK_PRICE, RENT_PRICE, DAYS_BORROWED " +
                                 " FROM TBL_BORROWEDBOOKS WHERE [STATUS] = 'BORROWED' AND ADDED_DATE BETWEEN '" + dDateFrom.ToString("yyyy-MM-dd") + "' AND '" + dDateTo.ToString("yyyy-MM-dd") + "' AND BORROWER_ID = '" + sBorrower_ID + "'";

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

        
        


    }
}
