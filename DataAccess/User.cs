using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using ePublicVariable;

namespace DataAccess
{
    public class User
    {

        public string sConnectionString = eVariable.sGlobalConnectionString;
        public OleDbConnectionStringBuilder osb = new OleDbConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetUser(String sType, string sValue)
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                string sQuery;

                switch (sType.ToLower())
                {
                    case "first name":
                        sQuery = "Select * from tbl_User";
                        break;
                    case "username":
                        sQuery = "Select * from tbl_User where username = '" + sValue + "'";
                        break;
                    case "inactive":
                        sQuery = "Select * from tbl_User";
                        break;
                    default:
                        sQuery = "Select * from tbl_User";
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

        public DataTable GetUserAccess(string sRole)
        {
            try
            {
                string sQuery = string.Empty;
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;
              
                sQuery = "Select * from tbl_UserAccess where Role = '" + sRole + "'";                                  

                ddq.CommandText = sQuery;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables.Count > 0 ? ds.Tables[0] : null;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public Boolean IsRecordExists(String sUsername)
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "Select * from tbl_User where username = '" + sUsername + "'";
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }



        public void ArchiveUser(string sUsername)
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "Update tbl_User set Status = 'INACTIVE' where Username = '" + sUsername + "'";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void InsertUser(Model.User oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "Insert Into tbl_user (Username,Fullname,Password,Role,Contact_No,Address,Added_By,Date_Added) Values ('" + oData.USERNAME + "','" + oData.FULLNAME + "','" + oData.PASSWORD + "','" + oData.ROLE + "','" + oData.CONTACT_NO + "','" + oData.ADDRESS + "','" + "Rolly" + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertUserAccess(Model.UserConfig oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "SP_INSERT_USERACCESS";
                ddq.AddParamer("@BOOK_DETAILS", SqlDbType.Bit, Convert.ToBoolean(oData.BookDetail));
                ddq.AddParamer("@BOOK_ENTRY", SqlDbType.Bit, Convert.ToBoolean(oData.BookEntry));
                ddq.AddParamer("@BOOK_AUTHOR", SqlDbType.Bit, Convert.ToBoolean(oData.BookAuthor));
                ddq.AddParamer("@BOOK_CATEGORY", SqlDbType.Bit, Convert.ToBoolean(oData.BookCategory));
                ddq.AddParamer("@BOOK_LOCATION", SqlDbType.Bit, Convert.ToBoolean(oData.BookLocation));
                ddq.AddParamer("@BOOK_POLICY", SqlDbType.Bit, Convert.ToBoolean(oData.BookPolicy));
                ddq.AddParamer("@BORROWER_DETAILS", SqlDbType.Bit, Convert.ToBoolean(oData.BorrowerDetails));
                ddq.AddParamer("@BORROWER_ENTRY", SqlDbType.Bit, Convert.ToBoolean(oData.BorrowerEntry));
                ddq.AddParamer("@BORROW_BOOK", SqlDbType.Bit, Convert.ToBoolean(oData.BorrowBook));
                ddq.AddParamer("@RETURN_BOOK", SqlDbType.Bit, Convert.ToBoolean(oData.ReturnBook));
                ddq.AddParamer("@PAY_BOOK", SqlDbType.Bit, Convert.ToBoolean(oData.PayBook));
                ddq.AddParamer("@BORROWER_REQUEST", SqlDbType.Bit, Convert.ToBoolean(oData.BorrowerRequest));
                ddq.AddParamer("@USER_ACCOUNT", SqlDbType.Bit, Convert.ToBoolean(oData.UserAccount));
                ddq.AddParamer("@USER_ACCESS", SqlDbType.Bit, Convert.ToBoolean(oData.UserAccess));
                ddq.AddParamer("@USER_ROLE", SqlDbType.Bit, Convert.ToBoolean(oData.UserRole));
                ddq.AddParamer("@IMPORT_EXPORT", SqlDbType.Bit, Convert.ToBoolean(oData.ImportExport));
                ddq.AddParamer("@RBOOK_LIST", SqlDbType.Bit, Convert.ToBoolean(oData.RBookList));
                ddq.AddParamer("@RBORROWER_LIST", SqlDbType.Bit, Convert.ToBoolean(oData.RBorrowerList));
                ddq.AddParamer("@ROLE", SqlDbType.NVarChar, oData.ROLE);
                ddq.ExecuteNonQuery(CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateUserAccess(Model.UserConfig oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "SP_UPDATE_USERACCESS";
                ddq.AddParamer("@BOOK_DETAILS", SqlDbType.Bit, Convert.ToBoolean(oData.BookDetail));
                ddq.AddParamer("@BOOK_ENTRY", SqlDbType.Bit, Convert.ToBoolean(oData.BookEntry));
                ddq.AddParamer("@BOOK_AUTHOR", SqlDbType.Bit, Convert.ToBoolean(oData.BookAuthor));
                ddq.AddParamer("@BOOK_CATEGORY", SqlDbType.Bit, Convert.ToBoolean(oData.BookCategory));
                ddq.AddParamer("@BOOK_LOCATION", SqlDbType.Bit, Convert.ToBoolean(oData.BookLocation));
                ddq.AddParamer("@BOOK_POLICY", SqlDbType.Bit, Convert.ToBoolean(oData.BookPolicy));
                ddq.AddParamer("@BORROWER_DETAILS", SqlDbType.Bit, Convert.ToBoolean(oData.BorrowerDetails));
                ddq.AddParamer("@BORROWER_ENTRY", SqlDbType.Bit, Convert.ToBoolean(oData.BorrowerEntry));
                ddq.AddParamer("@BORROW_BOOK", SqlDbType.Bit, Convert.ToBoolean(oData.BorrowBook));
                ddq.AddParamer("@RETURN_BOOK", SqlDbType.Bit, Convert.ToBoolean(oData.ReturnBook));
                ddq.AddParamer("@PAY_BOOK", SqlDbType.Bit, Convert.ToBoolean(oData.PayBook));
                ddq.AddParamer("@BORROWER_REQUEST", SqlDbType.Bit, Convert.ToBoolean(oData.BorrowerRequest));
                ddq.AddParamer("@USER_ACCOUNT", SqlDbType.Bit, Convert.ToBoolean(oData.UserAccount));
                ddq.AddParamer("@USER_ACCESS", SqlDbType.Bit, Convert.ToBoolean(oData.UserAccess));
                ddq.AddParamer("@USER_ROLE", SqlDbType.Bit, Convert.ToBoolean(oData.UserRole));
                ddq.AddParamer("@IMPORT_EXPORT", SqlDbType.Bit, Convert.ToBoolean(oData.ImportExport));
                ddq.AddParamer("@RBOOK_LIST", SqlDbType.Bit, Convert.ToBoolean(oData.RBookList));
                ddq.AddParamer("@RBORROWER_LIST", SqlDbType.Bit, Convert.ToBoolean(oData.RBorrowerList));
                ddq.AddParamer("@ROLE", SqlDbType.NVarChar, oData.ROLE);
                ddq.ExecuteNonQuery(CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Boolean IsUserRoleExists(String sRole)
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "Select * from tbl_UserAccess where Role = '" + sRole + "'";
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public void UpdateUser(Model.User oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "Update tbl_user set Fullname = '" + oData.FULLNAME + "',Password = '" + oData.PASSWORD + "',Role = '" + oData.ROLE + "',Contact_No = '" + oData.CONTACT_NO + "',Address = '" + oData.ADDRESS + "',Added_By = '" + "Rolly" + "', [STATUS] = '" + oData.STATUS + "' where Username = '" + oData.USERNAME + "'";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean IsLogin(String sUsername, string sPassword)
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "Select * from tbl_user where Username = '" + sUsername + "' and Password = '" + sPassword + "'";
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public Boolean IsAccountEmpty()
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "Select * from tbl_user";
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count <= 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        

    }
}
