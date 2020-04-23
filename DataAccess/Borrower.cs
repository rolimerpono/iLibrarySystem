using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.IO;
using ePublicVariable;
using System.Text.RegularExpressions;

namespace DataAccess
{
    public class Borrower
    {
        public string sConnectionString = eVariable.sGlobalConnectionString;
        public OleDbConnectionStringBuilder osb = new OleDbConnectionStringBuilder();


        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();
        Model.Borrower oMBorrower;

        public DataTable GetRecords(eVariable.FIND_BORROWER oFindType, string sFindText)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                string sQuery;

                switch (oFindType)
                {
                    case eVariable.FIND_BORROWER.BORROWER_ID:
                        sQuery = "SELECT * FROM TBL_BORROWER WHERE STATUS = 'ACTIVE' AND BORROWER_ID LIKE '%" + sFindText + "%'";
                        break;
                    case eVariable.FIND_BORROWER.FIRST_NAME:
                        sQuery = "SELECT * FROM TBL_BORROWER WHERE STATUS = 'ACTIVE' AND FIRST_NAME LIKE '%" + sFindText + "%'";
                        break;
                    case eVariable.FIND_BORROWER.MIDDLE_NAME:
                        sQuery = "SELECT * FROM TBL_BORROWER WHERE STATUS = 'ACTIVE' AND MIDDLE_NAME LIKE '%" + sFindText + "%'";
                        break;
                    case eVariable.FIND_BORROWER.LAST_NAME:
                        sQuery = "SELECT * FROM TBL_BORROWER WHERE STATUS = 'ACTIVE' AND LAST_NAME LIKE '%" + sFindText + "%'";
                        break;
                    default:
                        sQuery = "SELECT * FROM TBL_BORROWER WHERE STATUS = 'ACTIVE' AND FIRST_NAME LIKE '%" + sFindText + "%'";
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


        public DataTable GetBorrowerTransaction(eVariable.FIND_BOOK oFilter, string sFindText)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                string sQuery;

                switch (oFilter)
                {
                    case eVariable.FIND_BOOK.BOOK_REQUESTED:
                        sQuery = "SELECT DISTINCT B.BORROWER_ID [ID],B.FIRST_NAME,B.MIDDLE_NAME,B.LAST_NAME,B.DOB,B.AGE,B.CONTACT_NO,B.[ADDRESS],R.ADDED_DATE FROM TBL_BORROWER B INNER JOIN TBL_BORROWERREQUEST R ON B.BORROWER_ID  = R.BORROWER_ID WHERE R.[STATUS] = 'REQUEST' AND R.BORROWER_ID LIKE + '%" + sFindText + "%' GROUP BY B.BORROWER_ID,B.FIRST_NAME,B.MIDDLE_NAME,B.LAST_NAME,B.DOB,B.AGE,B.CONTACT_NO,B.[ADDRESS],R.ADDED_DATE";
                        break;
                    case eVariable.FIND_BOOK.BOOK_BORROWED:
                        sQuery = "SELECT DISTINCT B.BORROWER_ID [ID],B.FIRST_NAME,B.MIDDLE_NAME,B.LAST_NAME,B.DOB,B.AGE,B.CONTACT_NO,B.[ADDRESS],R.ADDED_DATE FROM TBL_BORROWER B INNER JOIN TBL_BORROWEDBOOKS R ON B.BORROWER_ID  = R.BORROWER_ID WHERE R.[STATUS] = 'BORROWED' AND R.BORROWER_ID LIKE + '%" + sFindText + "%' GROUP BY B.BORROWER_ID,B.FIRST_NAME,B.MIDDLE_NAME,B.LAST_NAME,B.DOB,B.AGE,B.CONTACT_NO,B.[ADDRESS],R.ADDED_DATE";
                        break;
                    case eVariable.FIND_BOOK.BOOK_RETURNED:
                        sQuery = "SELECT DISTINCT B.BORROWER_ID [ID],B.FIRST_NAME,B.MIDDLE_NAME,B.LAST_NAME,B.DOB,B.AGE,B.CONTACT_NO,B.[ADDRESS],R.ADDED_DATE FROM TBL_BORROWER B INNER JOIN TBL_BORROWERREQUEST R ON B.BORROWER_ID  = R.BORROWER_ID WHERE R.[STATUS] = 'RETURNED' AND R.BORROWER_ID LIKE + '%" + sFindText + "%' GROUP BY B.BORROWER_ID,B.FIRST_NAME,B.MIDDLE_NAME,B.LAST_NAME,B.DOB,B.AGE,B.CONTACT_NO,B.[ADDRESS],R.ADDED_DATE";
                        break;
                    case eVariable.FIND_BOOK.BOOK_PENALTY:
                        sQuery = "SELECT DISTINCT B.BORROWER_ID [ID],B.FIRST_NAME,B.MIDDLE_NAME,B.LAST_NAME,B.DOB,B.AGE,B.CONTACT_NO,B.[ADDRESS],R.ADDED_DATE FROM TBL_BORROWER B INNER JOIN TBL_BORROWERREQUEST R ON B.BORROWER_ID  = R.BORROWER_ID WHERE R.[STATUS] = 'DAMAGED' AND R.BORROWER_ID LIKE + '%" + sFindText + "%' GROUP BY B.BORROWER_ID,B.FIRST_NAME,B.MIDDLE_NAME,B.LAST_NAME,B.DOB,B.AGE,B.CONTACT_NO,B.[ADDRESS],R.ADDED_DATE";
                        break;
                    default:
                        sQuery = "SELECT DISTINCT B.BORROWER_ID [ID],B.FIRST_NAME,B.MIDDLE_NAME,B.LAST_NAME,B.DOB,B.AGE,B.CONTACT_NO,B.[ADDRESS],R.ADDED_DATE FROM TBL_BORROWER B INNER JOIN TBL_BORROWERREQUEST R ON B.BORROWER_ID  = R.BORROWER_ID WHERE R.[STATUS] = 'REQUEST' AND R.BORROWER_ID LIKE + '%" + sFindText + "%' GROUP BY B.BORROWER_ID,B.FIRST_NAME,B.MIDDLE_NAME,B.LAST_NAME,B.DOB,B.AGE,B.CONTACT_NO,B.[ADDRESS],R.ADDED_DATE";
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

        public DataTable GetDashBoardCount(eVariable.FIND_BOOK oFilter)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                string sQuery;

                switch (oFilter)
                {
                    case eVariable.FIND_BOOK.BOOK_REQUESTED:
                        sQuery = "SELECT COUNT(*) FROM TBL_BORROWER WHERE BORROWER_ID IN (SELECT BORROWER_ID FROM TBL_BORROWERREQUEST WHERE STATUS  = 'REQUEST')";
                        break;
                    case eVariable.FIND_BOOK.BOOK_BORROWED:
                        sQuery = "SELECT COUNT(*) FROM TBL_BORROWER WHERE BORROWER_ID IN (SELECT BORROWER_ID FROM TBL_BORROWEDBOOKS WHERE STATUS  = 'BORROWED')";
                        break;
                    case eVariable.FIND_BOOK.BOOK_RETURNED:
                        sQuery = "SELECT COUNT(DISTINCT B.BORROWER_ID) [COUNTER] TBL_BORROWER B INNER JOIN TBL_BORROWERREQUEST R ON B.BORROWER_ID  = R.BORROWER_ID WHERE R.[STATUS] = 'RETURNED' GROUP BY B.BORROWER_ID";
                        break;
                    case eVariable.FIND_BOOK.BOOK_PENALTY:
                        sQuery = "SELECT COUNT(DISTINCT B.BORROWER_ID) [COUNTER] FROM TBL_BORROWER B INNER JOIN TBL_BORROWERREQUEST R ON B.BORROWER_ID  = R.BORROWER_ID WHERE R.[STATUS] = 'DAMAGED' GROUP BY B.BORROWER_ID";
                        break;
                    default:
                        sQuery = "SELECT COUNT(DISTINCT B.BORROWER_ID) [COUNTER] FROM TBL_BORROWER B INNER JOIN TBL_BORROWERREQUEST R ON B.BORROWER_ID  = R.BORROWER_ID WHERE R.[STATUS] = 'REQUEST' GROUP BY B.BORROWER_ID";
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

        public void InsertBorrower(Model.Borrower oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "SP_INSERT_BORROWER";
                ddq.AddParamer("@BORROWER_ID", SqlDbType.VarChar, oData.PERSON_ID);
                ddq.AddParamer("@FIRST_NAME", SqlDbType.VarChar, oData.FIRST_NAME);
                ddq.AddParamer("@MIDDLE_NAME", SqlDbType.VarChar, oData.MIDDLE_NAME);
                ddq.AddParamer("@LAST_NAME", SqlDbType.VarChar, oData.LAST_NAME);
                ddq.AddParamer("@DOB", SqlDbType.VarChar, oData.DOB);
                ddq.AddParamer("@AGE", SqlDbType.VarChar, oData.AGE);
                ddq.AddParamer("@CONTACT_NO", SqlDbType.VarChar, oData.CONTACT_NO);
                ddq.AddParamer("@ADDRESS", SqlDbType.VarChar, oData.ADDRESS);
                ddq.AddParamer("@ADDED_DATE", SqlDbType.VarChar, oData.ADDED_DATE);
                ddq.AddParamer("@ADDED_BY", SqlDbType.VarChar, oData.ADDED_BY);
                ddq.AddParamer("@MODIFIED_DATE", SqlDbType.VarChar, oData.MODIFIED_DATE);
                ddq.AddParamer("@MODIFIED_BY", SqlDbType.VarChar, oData.MODIFIED_BY);
                ddq.AddParamer("@PROFILE_PIC", SqlDbType.VarChar, oData.PROFILE_PIC);

                ddq.ExecuteNonQuery(CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateBorrower(Model.Borrower oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "SP_UPDATE_BORROWER";
                ddq.AddParamer("@BORROWER_ID", SqlDbType.VarChar, oData.PERSON_ID);
                ddq.AddParamer("@FIRST_NAME", SqlDbType.VarChar, oData.FIRST_NAME);
                ddq.AddParamer("@MIDDLE_NAME", SqlDbType.VarChar, oData.MIDDLE_NAME);
                ddq.AddParamer("@LAST_NAME", SqlDbType.VarChar, oData.LAST_NAME);
                ddq.AddParamer("@DOB", SqlDbType.VarChar, oData.DOB);
                ddq.AddParamer("@AGE", SqlDbType.VarChar, oData.AGE);
                ddq.AddParamer("@CONTACT_NO", SqlDbType.VarChar, oData.CONTACT_NO);
                ddq.AddParamer("@ADDRESS", SqlDbType.VarChar, oData.ADDRESS);
                ddq.AddParamer("@MODIFIED_DATE", SqlDbType.VarChar, oData.MODIFIED_DATE);
                ddq.AddParamer("@MODIFIED_BY", SqlDbType.VarChar, oData.MODIFIED_BY);
                ddq.AddParamer("@STATUS", SqlDbType.VarChar, oData.STATUS);
                ddq.AddParamer("@PROFILE_PIC", SqlDbType.VarChar, oData.PROFILE_PIC);

                ddq.ExecuteNonQuery(CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Boolean IsRecordExists(Model.Borrower oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "SELECT * FROM TBL_BORROWER WHERE BORROWER_ID = '" + oData.PERSON_ID + "'";
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean HasUnsettledBook(Model.Borrower oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = " SELECT BORROWER_ID FROM TBL_BORROWER WHERE BORROWER_ID = '" + oData.PERSON_ID + "' " +
                                  " AND (BORROWER_ID IN (SELECT BORROWER_ID FROM TBL_BORROWEDBOOKS WHERE [STATUS] = 'BORROWED') " +
                                  " OR BORROWER_ID IN (SELECT BORROWER_ID FROM TBL_BORROWERREQUEST WHERE [STATUS] = 'REQUEST')) ";

                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean HasUnsettledBook(String sBorrowerID)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = " SELECT BORROWER_ID FROM TBL_BORROWER WHERE BORROWER_ID = '" + sBorrowerID + "' " +
                                  " AND (BORROWER_ID IN (SELECT BORROWER_ID FROM TBL_BORROWEDBOOKS WHERE [STATUS] = 'BORROWED') " +
                                  " OR BORROWER_ID IN (SELECT BORROWER_ID FROM TBL_BORROWERREQUEST WHERE [STATUS] = 'REQUEST')) ";

                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean IsCustomerMember(string sBorrowerID)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "SELECT * FROM TBL_BORROWER WHERE BORROWER_ID = '" + sBorrowerID + "' AND STATUS = 'ACTIVE' ";
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetBorrowerNo()
        {
            osb.ConnectionString = sConnectionString;
            ddq = new DatabaseQuery.DBQuery();
            ddq.ConnectionString = osb.ConnectionString;


            ddq.CommandText = "SELECT TOP 1 BORROWER_ID FROM TBL_BORROWER ORDER BY BORROWER_ID DESC";
            ds = ddq.GetDataset(CommandType.Text);

            return ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(Regex.Replace(ds.Tables[0].Rows[0][0].ToString(), "[^0-9]", "")) : 0;
        }

        public List<Model.Borrower> GetCSVData(string sPath)
        {

            try
            {

                List<string> queries = new List<string>(File.ReadAllLines(sPath));
                List<Model.Borrower> lstBorrower = new List<Model.Borrower>();

                foreach (string query in queries)
                {

                    string[] queryArr = query.Split(',');

                    if (!queryArr[0].Contains("_"))
                    {

                        oMBorrower = new Model.Borrower();
                        oMBorrower.PERSON_ID = queryArr[0];
                        oMBorrower.FIRST_NAME = queryArr[1];
                        oMBorrower.MIDDLE_NAME = queryArr[2];
                        oMBorrower.LAST_NAME = queryArr[3];
                        oMBorrower.DOB = Convert.ToDateTime(queryArr[4]).ToString();
                        oMBorrower.AGE = queryArr[5];
                        oMBorrower.CONTACT_NO = queryArr[6];
                        oMBorrower.ADDRESS = queryArr[7];
                        oMBorrower.ADDED_DATE = queryArr[8];
                        oMBorrower.ADDED_BY = queryArr[9];

                        lstBorrower.Add(oMBorrower);
                    }

                }

                return lstBorrower;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
