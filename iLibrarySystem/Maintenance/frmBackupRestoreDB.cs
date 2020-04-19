using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iLibrarySystem.Maintenance
{
    public partial class frmBackupRestoreDB : Form
    {
        DataAccess.BackupRestoreDB oBackup;
        DataAccess.BackupRestoreDB oRestore;

        CustomWindow.frmInfoMsgBox oFrmMsgBox;
        public frmBackupRestoreDB()
        {
            InitializeComponent();
        }

       
        private void btnBackup_Click(object sender, EventArgs e)
        {
            
        }

        void ClearFields()
        {
            txtDBBackup.Text = string.Empty;
            txtDBRestore.Text = string.Empty;
        }


        private void btnBrowseB_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog oFolderDialog = new FolderBrowserDialog();
          
            if (oFolderDialog.ShowDialog() == DialogResult.OK)
            {                
                txtDBBackup.Text = oFolderDialog.SelectedPath;
            }
        }

    
        private void btnCloseR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnButton.Text.Trim() == "BACKUP")
                {
                    #region Backup
                    oBackup = new DataAccess.BackupRestoreDB();

                    if (txtDBBackup.Text.Trim() != string.Empty)
                    {
                        if (oBackup.IsDatabaseExits())
                        {
                            if (oBackup.BackupDatabase(txtDBBackup.Text))
                            {

                                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("DATABASE SUCCESSFULL BACKUP IN PATH :" + " " + txtDBBackup.Text);
                                oFrmMsgBox.ShowDialog();
                            }
                            else
                            {
                                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("DATABASE BACKUP FAIL.");
                                oFrmMsgBox.ShowDialog(); 
                            }
                        }
                        else
                        {
                            oFrmMsgBox = new CustomWindow.frmInfoMsgBox("DATABASE DOES NOT EXISTS");
                            oFrmMsgBox.ShowDialog();
                        }

                    }
                    else
                    {
                        oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE SELECT DISTINATION FOLDER TO SAVE THE FILE.");
                        oFrmMsgBox.ShowDialog();
                    }
                    txtDBBackup.Text = string.Empty;
                    return;
                    #endregion
                }
                else
                {
                    #region Restore

                    if (txtDBRestore.Text.Trim() != String.Empty)
                    {
                        oRestore = new DataAccess.BackupRestoreDB();

                        if (oRestore.RestoreDatabase(txtDBRestore.Text))
                        {
                            oFrmMsgBox = new CustomWindow.frmInfoMsgBox("DATABASE SUCCESSFULLY RESTORED");
                            oFrmMsgBox.ShowDialog();
                        }
                        else
                        {
                            oFrmMsgBox = new CustomWindow.frmInfoMsgBox("DATABASE RESTORATION FAIL.");
                            oFrmMsgBox.ShowDialog();
                        }
                    }
                    txtDBRestore.Text = string.Empty;
                    return;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void tbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbControl.SelectedIndex == 0)
            {
                btnButton.Text = "BACKUP";
            }
            else
            {
                btnButton.Text = "RESTORE";
            }
        }

        private void btnBrowseR_Click(object sender, EventArgs e)
        {

            OpenFileDialog oDiaglog = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse .BAK Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "bak",
                Filter = "BAK files (*.BAK)|*.BAK",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (oDiaglog.ShowDialog() == DialogResult.OK)
            {
                txtDBRestore.Text = oDiaglog.FileName;
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void txtDBRestore_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtDBBackup_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

      
         
    }
}
