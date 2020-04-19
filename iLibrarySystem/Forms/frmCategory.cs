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
    public partial class frmCategory : Form
    {

        CustomWindow.frmInfoMsgBox oFrmMsgBox;

        Model.Category oMCategory = new Model.Category();
        DataAccess.Category oCategory = new DataAccess.Category();
        public Boolean bEdit = false;

        public frmCategory()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
           
        }

        void DatagridSelectedData(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgDetails.Rows.Count > 0)
                    {
                        oMCategory = new Model.Category();
                        eVariable.sUniqueID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMCategory.CATEGORY_ID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMCategory.CATEGORY = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                        oMCategory.STATUS = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void LoadCategory()
        {
            try
            {
                oCategory = new DataAccess.Category();
                dgDetails.Rows.Clear();

                foreach (DataRow row in oCategory.GetCategory("", "").Rows)
                {
                    dgDetails.Rows.Add(row[0], row[1],row[2]);
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
                if (oMCategory.CATEGORY_ID != string.Empty)
                {
                    eVariable.sUniqueID = oMCategory.CATEGORY_ID;
                    txtCategory.Text = oMCategory.CATEGORY;
                    chkActive.Checked = oMCategory.STATUS.Trim() == "ACTIVE" ? true : false;
                    bEdit = true;
                }
            }
        }

        Boolean IsRecordEmpty()
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            oMCategory = new Model.Category();
            oCategory = new DataAccess.Category();

            if (IsRecordEmpty())
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("ALL FIELDS ARE REQUIRED");
                oFrmMsgBox.ShowDialog();
                return;
            }
          
            if (bEdit)
            {
                oMCategory.CATEGORY_ID = eVariable.sUniqueID;
                oMCategory.CATEGORY = txtCategory.Text;
                oMCategory.STATUS = chkActive.Checked == true ? "ACTIVE" : "INACTIVE";
                oCategory.UpdateCategory(oMCategory);            
            }
            else
            {                
                oMCategory.CATEGORY = txtCategory.Text;
                oMCategory.STATUS = chkActive.Checked == true ? "ACTIVE" : "INACTIVE";
                oCategory.InsertCategory(oMCategory);
            }

            oFrmMsgBox = new CustomWindow.frmInfoMsgBox("RECORD HAS BEEN SUCCESSFULLY SAVED.");
            oFrmMsgBox.ShowDialog();            
            ClearFields();
            LoadCategory();
        }

        void ClearFields()
        {
            bEdit = false;
            chkActive.Checked = false;
            txtCategory.Text = string.Empty;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
