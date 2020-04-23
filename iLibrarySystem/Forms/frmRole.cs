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
    public partial class frmRole : Form
    {
        CustomWindow.frmInfoMsgBox oFrmMsgBox;

        Model.Role oMRole = new Model.Role();
        DataAccess.Role oRole = new DataAccess.Role();
        

        public frmRole()
        {
            InitializeComponent();
            eVariable.m_ActionType = eVariable.ACTION_TYPE.ADD;
            eVariable.DisableTextEnterKey(pnlBody);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            oMRole = new Model.Role();
            oRole = new DataAccess.Role();

            if (IsRecordEmpty())
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.ALL_FIELDS_ARE_REQUIRED.ToString().Replace("_"," "));
                oFrmMsgBox.ShowDialog();
                return;
            }

            if (eVariable.m_ActionType == eVariable.ACTION_TYPE.EDIT)
            {
                oMRole.ID = eVariable.sUniqueID;
                oMRole.ROLE = txtRole.Text;
                oMRole.STATUS = chkActive.Checked == true ? "ACTIVE" : "INACTIVE";
                oRole.UpdateRole(oMRole);
            }
            else
            {
              
                oMRole.ROLE = txtRole.Text;
                oMRole.STATUS = chkActive.Checked == true ? "ACTIVE" : "INACTIVE";

                if (oRole.isRecordExists(oMRole))
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.RECORD_IS_ALREADY_EXISTS.ToString().Replace("_", " "));
                    oFrmMsgBox.ShowDialog();
                    return;
                }

                oRole.InsertRole(oMRole);
            }

            oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.RECORD_HAS_BEEN_SUCESSFULLY_SAVED.ToString().Replace("_", " "));
            oFrmMsgBox.ShowDialog();
            eVariable.ClearText(pnlBody);
            eVariable.m_ActionType = eVariable.ACTION_TYPE.ADD;
            LoadRole();
        }

        void DatagridSelectedData(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgDetails.Rows.Count > 0)
                    {
                        oMRole = new Model.Role();
                        eVariable.sUniqueID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMRole.ID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMRole.ROLE = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                        oMRole.STATUS = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private Boolean IsRecordEmpty()
        {
            foreach (Control o in pnlBody.Controls.OfType<TextBox>().ToList())
            {

                if (o.Text.Trim() == String.Empty)
                {
                    o.Focus();
                    return true;
                }

            }
            return false;
        }

        public void LoadRole()
        {
            try
            {
                oRole = new DataAccess.Role();
                dgDetails.Rows.Clear();
                eVariable.DisableGridColumnSort(dgDetails);
                foreach (DataRow row in oRole.GetRole("", "").Rows)
                {
                    dgDetails.Rows.Add(row[0], row[1], row[2]);
                }
            }
            catch (Exception ex)
            {
                
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                if (oMRole.ID != string.Empty)
                {
                    eVariable.sUniqueID = oMRole.ID;
                    txtRole.Text = oMRole.ROLE;
                    chkActive.Checked = oMRole.STATUS.Trim() == "ACTIVE" ? true : false;
                    eVariable.m_ActionType = eVariable.ACTION_TYPE.EDIT;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            eVariable.ClearText(pnlBody);
            
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DatagridSelectedData(sender, e);
            }
        }

        private void dgDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DatagridSelectedData(sender, e);
            }
        }

        private void dgDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DatagridSelectedData(sender, e);
            }
        }

        private void frmRole_Load(object sender, EventArgs e)
        {
            LoadRole();
        }

        private void txtRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
