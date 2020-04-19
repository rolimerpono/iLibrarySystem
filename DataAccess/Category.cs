using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using ePublicVariable;

namespace DataAccess
{
    public class Category
    {

        public string sConnectionString = eVariable.sGlobalConnectionString;
        public OleDbConnectionStringBuilder osb = new OleDbConnectionStringBuilder();


        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        Model.Category oMPosition;
        public DataTable GetCategory(string sType, string sValue)
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                string sQuery = String.Empty;

                switch (sType)
                {
                    case "INACTIVE":
                        sQuery = "SELECT * FROM TBL_CATEGORY WHERE [STATUS] = 'INACTIVE'";
                        break;
                    default:
                        sQuery = "SELECT * FROM TBL_CATEGORY";
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

        public void InsertCategory(Model.Category oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "INSERT INTO TBL_CATEGORY (CATEGORY,STATUS ) VALUES ('" + oData.CATEGORY + "','" + oData.STATUS + "')";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateCategory(Model.Category oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "UPDATE TBL_CATEGORY SET CATEGORY = '" + oData.CATEGORY + "', STATUS = '" + oData.STATUS + "' WHERE [ID] = '" + oData.CATEGORY_ID + "'";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
