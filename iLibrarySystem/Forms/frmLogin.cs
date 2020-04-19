﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace iLibrarySystem.Forms
{
    public partial class frmLogin : Form
    {
        XMLSerializer.Serializerset oXMLSerializerSet;
        CommonFunction.CommonFunction oCommonFunction;
        DefaultLogin.User oDefUser;

        CustomWindow.frmInfoMsgBox oFrmMsgBox;

        MAIN oMainForm;

        DataAccess.BackupRestoreDB oDatabase;
        DataAccess.User oUser;
        Model.User oMUser;

        public frmLogin()
        {
            InitializeComponent();          
        }

        public void DefaultLogin()
        {
            oXMLSerializerSet = new XMLSerializer.Serializerset(Application.StartupPath + @"\Settings.xml");
            oDefUser = oXMLSerializerSet.ReadXmlSerialize(Application.StartupPath + @"\Settings.xml");
        } 

       

        private void btnLogin_Click(object sender, EventArgs e)
        {            
            oUser = new DataAccess.User();
            oCommonFunction = new CommonFunction.CommonFunction();

            if (oCommonFunction.Decrypt(oDefUser.USERNAME.Trim()) == txtUsername.Text && oCommonFunction.Decrypt(oDefUser.PASSWORD.Trim()) == txtPassword.Text) //Default Login
            {
                this.ShowInTaskbar = false;
                this.Hide();
                oMainForm = new MAIN(txtUsername.Text, txtPassword.Text, oCommonFunction.Decrypt(oDefUser.FULLNAME),oCommonFunction.Decrypt(oDefUser.ROLE));
                oMainForm.ShowDialog();
                
            }

            else
            {
                #region CheckDatabase

                oDatabase = new DataAccess.BackupRestoreDB();

                if (!oDatabase.IsDatabaseExits())
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("DATABASE DOES NOT EXISTS. PLEASE RESTORE FIRST THE DATABASE. THANK YOU");
                    oFrmMsgBox.ShowDialog();

                    Maintenance.frmBackupRestoreDB oFrm = new Maintenance.frmBackupRestoreDB();
                    oFrm.ShowDialog();
                }

                #endregion


                #region DBLogin
              
                if (oUser.IsLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim()))
                {
                    foreach (DataRow row in oUser.GetUser("username", txtUsername.Text).Rows)
                    {
                        oMUser = new Model.User();
                        oMUser.USERNAME = row[0].ToString();
                        oMUser.FULLNAME = row[1].ToString();
                        oMUser.PASSWORD = row[2].ToString();
                        oMUser.ROLE = row[3].ToString();
                        oMUser.CONTACT_NO = row[4].ToString();
                        oMUser.ADDRESS = row[5].ToString();
                    }

                    this.ShowInTaskbar = false;
                    this.Hide();
                    oMainForm = new MAIN(oMUser);
                    oMainForm.ShowDialog();

                }
                else
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE ENTER CORRECT USERNAME AND PASSWORD.");
                    oFrmMsgBox.ShowDialog();
                    txtUsername.Focus();
                }
                #endregion
            }            

        }

        void GetCurrentDate()
        {
            for (int i = 0; i <= 2000; i++)
            {
                Thread.Sleep(1000);
                this.Invoke((MethodInvoker)delegate
                {
                    lblCurrentDate.Text = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                });
                if (i == 1001)
                {
                    i = 0;
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            DefaultLogin();
            Thread T = new Thread(new ThreadStart(GetCurrentDate));
            T.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            oCommonFunction = new CommonFunction.CommonFunction();
            oCommonFunction.TextBox_KeyEnterDisable(sender, e);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            oCommonFunction = new CommonFunction.CommonFunction();
            oCommonFunction.TextBox_KeyEnterDisable(sender, e);
        }
    
    }
}
