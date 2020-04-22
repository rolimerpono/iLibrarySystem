using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ePublicVariable;

namespace DataAccess
{
    public class Location
    {
        public string sConnectionString = eVariable.sGlobalConnectionString;
        public SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetLocationRecord(String sType, string sFindText)
        {
            try
            {
                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                string sQuery = "";

                switch (sType)
                {
                    case "LOCATION":
                        sQuery = "SELECT * FROM TBL_LOCATION WHERE LOCATION LIKE '%" + sFindText + "%'";
                        break;
                    default:
                        sQuery = "SELECT * FROM TBL_LOCATION WHERE LOCATION LIKE '%" + sFindText + "%'";
                        break;

                }

                ddq.CommandText = sQuery;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables.Count > 0 ? ds.Tables[0] : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        
        }

        public Boolean isRecordExists(Model.Location oData)
        {

            try
            {
                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                string sQuery = "";


                sQuery = "SELECT * FROM TBL_LOCATION WHERE LOCATION = '" + oData.LOCATION + "'";

                ddq.CommandText = sQuery;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return true;
            }
        
        }


        public void InsertLocation(Model.Location oData)
        {
            try
            {

                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                ddq.CommandText = "INSERT INTO TBL_LOCATION (LOCATION,STATUS) VALUES ('" + oData.LOCATION + "','" + oData.STATUS + "')";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                
            }

        }

        public void UpdateCategory(Model.Location oData)
        {
            try
            {

                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                ddq.CommandText = "UPDATE TBL_LOCATION SET LOCATION = '" + oData.LOCATION + "', STATUS = '" + oData.STATUS + "' WHERE [ID] = '" + oData.LOCATION_ID + "'";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                
            }

        }
    }
}
