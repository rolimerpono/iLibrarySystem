using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iLibrarySystem.Forms
{
    public partial class frmUser : Form
    {
        CustomWindow.frmInfoMsgBox oFrmMsgBox;

        Model.Role oMRole;
        DataAccess.Role oRole;

        DataAccess.User oUser;
        Model.User oMUser;
        Boolean bEdit = false;
        public frmUser()
        {
            InitializeComponent();

            foreach (var o in pnlBody.Controls.OfType<TextBox>().ToList())
            {                

                if (!o.Name.Contains("Address"))
                {
                    o.KeyDown += TextKeyDown;
                }

            }
        }

        void TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
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

            foreach (var o in pnlInfo.Controls.OfType<TextBox>().ToList())
            {
                if (o.Text.Trim() == String.Empty)
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("ALL FIELDS ARE REQUIRED!");
                    oFrmMsgBox.ShowDialog();
                    o.Focus();
                    return;
                }
            }

            oMUser.FULLNAME = txtFullname.Text;
            oMUser.USERNAME = txtUsername.Text;
            oMUser.PASSWORD = txtPassword.Text;
            oMUser.ROLE = cboRole.Text;
            oMUser.CONTACT_NO = txtContactNo.Text;
            oMUser.ADDRESS = txtAddress.Text;
            oMUser.STATUS = chkStats.Checked == true ? "ACTIVE" : "INACTIVE";

            if (bEdit)
            {
                oUser.UpdateUser(oMUser);
                ClearFields();
                LoadRecords();
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("RECORD SUCCESSFULL SAVED.");
                oFrmMsgBox.ShowDialog();
                bEdit = false;
            }
            else
            {
                if (oUser.IsRecordExists(txtUsername.Text.Trim()))
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("USERNAME YOU CREATED ALREADY EXISTS.");
                    oFrmMsgBox.ShowDialog();
                    return;
                }
                oUser.InsertUser(oMUser);
                ClearFields();
                LoadRecords();
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("RECORD SUCCESSFULL SAVED.");
                oFrmMsgBox.ShowDialog();

            }
        }

        void ClearFields()
        {
            foreach (var o in pnlInfo.Controls.OfType<TextBox>().ToList())
            {
                o.Text = string.Empty;
            }
            txtUsername.Enabled = true;
            cboRole.Text = string.Empty;
            chkStats.Checked = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bEdit = true;
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
            ClearFields();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {

        }

   

       
        
    }
}
