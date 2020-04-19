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
    public class BackupRestoreDB
    {

        public string sConnectionString = eVariable.sGlobalConnectionString;
        public string sMasterDBConnection = eVariable.sGlobalMasterConnectionString;
        public OleDbConnectionStringBuilder osb = new OleDbConnectionStringBuilder();
        DatabaseQuery.DBQuery ddq = new DatabaseQuery.DBQuery();
        DataSet ds = new DataSet();

        public Boolean BackupDatabase(String sPath)
        {
            try
            {
                osb.ConnectionString = sMasterDBConnection;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "BACKUP DATABASE [iLibrarySystem] to disk ='" + sPath + @"\\" + "iLibrarySystem_" + DateTime.Now.ToString("yyyy-MM-dd") + ".BAK" + "' WITH INIT";                                
                ddq.ExecuteNonQuery(CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RestoreDatabase(String sPath)
        {
            try
            {
                osb.ConnectionString = sMasterDBConnection;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "USE MASTER RESTORE Database iLibrarySystem FROM DISK ='" + sPath + "' WITH REPLACE;";
                ddq.ExecuteNonQuery(CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean IsDatabaseExits()
        {
            try
            {
                osb.ConnectionString = sMasterDBConnection;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "SELECT name FROM master.sys.databases WHERE name = 'iLibrarySystem'";
                ds = ddq.GetDataset(CommandType.Text);

                return ds.Tables[0].Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void DropDatabase()
        {
            try
            {
                osb.ConnectionString = sMasterDBConnection;
                ddq = new DatabaseQuery.DBQuery();
                ddq.ConnectionString = osb.ConnectionString;


                ddq.CommandText = "DROP DATABASE iLibrarySystem";
                ddq.ExecuteNonQuery(CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
