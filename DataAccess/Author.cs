﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ePublicVariable;

namespace DataAccess
{
    public class Author
    {

        public string sConnectionString = eVariable.sGlobalConnectionString;
        public SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();


        public DataTable GetAuthor(string sType, string sValue)
        {
            try
            {
                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                string sQuery = string.Empty;

                switch (sType)
                {
                    case "INACTIVE":
                        sQuery = "SELECT * FROM TBL_AUTHOR WHERE STATUS = 'INACTIVE'";
                        break;
                    case "FIRST NAME":
                        sQuery = "SELECT * FROM TBL_AUTHOR WHERE STATUS = 'ACTIVE' AND FIRST_NAME LIKE '%" + sValue + "%'";
                        break;
                    case "MIDDLE NAME":
                        sQuery = "SELECT * FROM TBL_AUTHOR WHERE STATUS = 'ACTIVE' AND MIDDLE_NAME LIKE '%" + sValue + "%'";
                        break;
                    case "LAST NAME":
                        sQuery = "SELECT * FROM TBL_AUTHOR WHERE STATUS = 'ACTIVE' AND LAST_NAME LIKE '%" + sValue + "%'";
                        break;                   
                    default:
                        sQuery = "SELECT * FROM TBL_AUTHOR";
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

        public Boolean isRecordExists(Model.Author oData)
        {

            try
            {
                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                string sQuery = "";


                sQuery = "SELECT * FROM TBL_AUTHOR WHERE FIRST_NAME = '" + oData.FIRST_NAME + " AND MIDDLE_NAME = '" + oData.MIDDLE_NAME + "' AND LAST_NAME = '" + oData.LAST_NAME + "'";

                ddq.CommandText = sQuery;
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return true;
            }

        }

        public void InsertAuthor(Model.Author oData)
        {
            try
            {

                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                ddq.CommandText = "INSERT INTO TBL_AUTHOR (FIRST_NAME,MIDDLE_NAME,LAST_NAME) VALUES ('" + oData.FIRST_NAME + "','" + oData.MIDDLE_NAME + "','" + oData.LAST_NAME + "')";               
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateAuthor(Model.Author oData)
        {
            try
            {

                scb.ConnectionString = sConnectionString;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = scb.ConnectionString;

                ddq.CommandText = "UPDATE TBL_AUTHOR SET FIRST_NAME = '" + oData.FIRST_NAME + "', MIDDLE_NAME = '" + oData.MIDDLE_NAME + "', LAST_NAME = '" + oData.LAST_NAME + "',STATUS = '" + oData.STATUS + "' WHERE ID  = '" + oData.PERSON_ID + "'";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
