using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.IO;
using ePublicVariable;

namespace DataAccess
{
    public class Policy
    {

        public string sConnectionString = eVariable.sGlobalConnectionString;
        public OleDbConnectionStringBuilder osb = new OleDbConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public DataTable GetPolicy(String sType, string sValue)
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;



                ddq.CommandText = "SELECT * FROM TBL_POLICY" ;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables.Count > 0 ? ds.Tables[0] : null;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public Boolean IsPolicyExist()
        {
            try
            {
                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;



                ddq.CommandText = "SELECT * FROM TBL_POLICY";
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public void InsertPolicy(Model.Policy oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "INSERT INTO TBL_POLICY (DUE_PENALTY,LOST_DAMAGE_INTERST,MAX_DAYS_BORROW,MAX_BOOK_BORROW) VALUES ('" + oData.DUE_INTEREST + "','" + oData.LOST_DAMAGE_INTEREST + "','" + oData.MAX_DAYS_BORROW + "','" + oData.MAX_BOOK_BORROW + "'";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePolicy(Model.Policy oData)
        {
            try
            {

                osb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;

                ddq.CommandText = "UPDATE TBL_POLICY SET    DUE_PENALTY = '" + oData.DUE_INTEREST + "',LOST_DAMAGE_INTEREST = '" + oData.LOST_DAMAGE_INTEREST + "',MAX_DAYS_BORROW = '" + oData.MAX_DAYS_BORROW + "',MAX_BOOK_BORROW = '" + oData.MAX_BOOK_BORROW + "'";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
