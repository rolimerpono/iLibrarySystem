using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ePublicVariable;

namespace DataAccess
{
    public class Role
    {
        public string sConnectionString = eVariable.sGlobalConnectionString;
        public SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetRole(String sType, string sFindText)
        {
            try
            {
                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                string sQuery = "";

                switch (sType)
                {
                    case "ROLE":
                        sQuery = "SELECT * FROM TBL_ROLE WHERE ROLE LIKE '%" + sFindText + "%'";
                        break;
                    default:
                        sQuery = "SELECT * FROM TBL_ROLE WHERE ROLE LIKE '%" + sFindText + "%'";
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


        public void InsertRole(Model.Role oData)
        {
            try
            {

                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                ddq.CommandText = "INSERT INTO TBL_ROLE (ROLE,STATUS) VALUES ('" + oData.ROLE + "','" + oData.STATUS + "')";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateRole(Model.Role oData)
        {
            try
            {

                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                ddq.CommandText = "UPDATE TBL_ROLE SET ROLE = '" + oData.ROLE + "', STATUS = '" + oData.STATUS + "' WHERE [ID] = '" + oData.ID + "'";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
