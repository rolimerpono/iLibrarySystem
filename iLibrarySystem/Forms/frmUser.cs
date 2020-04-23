using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ePublicVariable;

namespace iLibrarySystem.Forms
{
    public partial class frmUser : Form
    {
        CustomWindow.frmInfoMsgBox oFrmMsgBox;

        Model.Role oMRole;
        DataAccess.Role oRole;

        DataAccess.User oUser;
        Model.User oMUser;
        
        public frmUser()
        {
            InitializeComponent();
            eVariable.DisableTextEnterKey(pnlBody);
        }

     
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        void LoadRole()
        {
            oRole = new DataAccess.Role();
            cboRole.Items.Clear();
            cboRole.DataSource = oRole.GetRole("", "");

            cboRole.DisplayMember = "ROLE";
            cboRole.ValueMember = "ROLE";
            cboRole.Text = string.Empty;
        }

        void LoadRecords()
        {
            oUser = new DataAccess.User();
            dgDetails.Rows.Clear();
            eVariable.DisableGridColumnSort(dgDetails);
            foreach (DataRow row in oUser.GetUser("", "").Rows)
            {
                dgDetails.Rows.Add(row["USERNAME"], row["FULLNAME"], row["PASSWORD"], row["ROLE"], row["CONTACT_NO"], row["ADDRESS"],row["STATUS"]);
            }
        
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            LoadRecords();
            LoadRole();

            foreach (DataGridViewColumn col in dgDetails.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            oUser = new DataAccess.User();
            oMUser = new Model.User();

            if (eVariable.IsFieldEmpty(pnlBody))
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.ALL_FIELDS_ARE_REQUIRED.ToString().Replace("_", " "));
                oFrmMsgBox.ShowDialog();
                return;
            }

            oMUser.FULLNAME = txtFullname.Text;
            oMUser.USERNAME = txtUsername.Text;
            oMUser.PASSWORD = txtPassword.Text;
            oMUser.ROLE = cboRole.Text;
            oMUser.CONTACT_NO = txtContactNo.Text;
            oMUser.ADDRESS = txtAddress.Text;
            oMUser.STATUS = chkStats.Checked == true ? "ACTIVE" : "INACTIVE";

            if (eVariable.m_ActionType == ePublicVariable.eVariable.ACTION_TYPE.EDIT)
            {
                oUser.UpdateUser(oMUser);
                eVariable.ClearText(pnlBody);
                LoadRecords();
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.RECORD_HAS_BEEN_SUCESSFULLY_SAVED.ToString().Replace("_", " "));
                oFrmMsgBox.ShowDialog();
                
            }
            else
            {
                if (oUser.IsRecordExists(txtUsername.Text.Trim()))
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.RECORD_IS_ALREADY_EXISTS.ToString().Replace("_", " "));
                    oFrmMsgBox.ShowDialog();
                    return;
                }
                oUser.InsertUser(oMUser);
                eVariable.ClearText(pnlBody);
                LoadRecords();
                eVariable.m_ActionType = eVariable.ACTION_TYPE.ADD;
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.RECORD_HAS_BEEN_SUCESSFULLY_SAVED.ToString().Replace("_", " "));
                oFrmMsgBox.ShowDialog();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            eVariable.m_ActionType = eVariable.ACTION_TYPE.EDIT;
            if (oMUser.USERNAME.Trim() != String.Empty)
            {
                txtUsername.Text = oMUser.USERNAME;
                txtFullname.Text = oMUser.FULLNAME;
                txtPassword.Text = oMUser.PASSWORD;
                txtRePassword.Text = oMUser.PASSWORD;
                cboRole.Text = oMUser.ROLE;
                txtContactNo.Text = oMUser.CONTACT_NO;
                txtAddress.Text = oMUser.ADDRESS;
                chkStats.Checked = oMUser.STATUS == "ACTIVE" ? true : false;
            }
            txtUsername.Enabled = false;
        }

        private void dgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DatagridSelect(sender, e);
        }

        private void dgDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DatagridSelect(sender, e);
        }

        void DatagridSelect(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgDetails.Rows.Count > 0)
                    {
                        oMUser = new Model.User();
                        oMUser.USERNAME = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMUser.FULLNAME = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                        oMUser.PASSWORD = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                        oMUser.ROLE = dgDetails.Rows[e.RowIndex].Cells[3].Value.ToString();
                        oMUser.CONTACT_NO = dgDetails.Rows[e.RowIndex].Cells[4].Value.ToString();
                        oMUser.ADDRESS = dgDetails.Rows[e.RowIndex].Cells[5].Value.ToString();
                        oMUser.STATUS = dgDetails.Rows[e.RowIndex].Cells[6].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cboRole_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            eVariable.ClearText(pnlBody);
        }

     

       
        
    }
}
