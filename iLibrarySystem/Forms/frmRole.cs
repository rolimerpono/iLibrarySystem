﻿using System;
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
        public Boolean bEdit = false;

        public frmRole()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            oMRole = new Model.Role();
            oRole = new DataAccess.Role();

            if (IsRecordEmpty())
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("ALL FIELDS ARE REQUIRED");
                oFrmMsgBox.ShowDialog();
                return;
            }

            if (bEdit)
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
                oRole.InsertRole(oMRole);
            }

            oFrmMsgBox = new CustomWindow.frmInfoMsgBox("RECORD HAS BEEN SUCCESSFULLY SAVED.");
            oFrmMsgBox.ShowDialog();
            ClearFields();
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

        void ClearFields()
        {
            bEdit = false;
            chkActive.Checked = false;
            txtRole.Text = string.Empty;
        }

        public void LoadRole()
        {
            try
            {
                oRole = new DataAccess.Role();
                dgDetails.Rows.Clear();

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
                    bEdit = true;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
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
