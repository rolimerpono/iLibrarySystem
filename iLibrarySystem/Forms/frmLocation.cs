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
    public partial class frmLocation : Form
    {
        CustomWindow.frmInfoMsgBox oFrmMsgBox;

        Model.Location oMLocation = new Model.Location();
        DataAccess.Location oLocation = new DataAccess.Location();
        public Boolean bEdit = false;

        CommonFunction.CommonFunction oCommonFunction;

        public frmLocation()
        {
            InitializeComponent();
        }

   
        void DatagridSelectedData(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgDetails.Rows.Count > 0)
                    {
                        oMLocation = new Model.Location();
                        eVariable.sUniqueID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMLocation.LOCATION_ID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMLocation.LOCATION = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                        oMLocation.STATUS = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            oMLocation = new Model.Location();
            oLocation = new DataAccess.Location();

            if (IsRecordEmpty())
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("ALL FIELDS ARE REQUIRED");
                oFrmMsgBox.ShowDialog();
                return;
            }

            if (bEdit)
            {
                oMLocation.LOCATION_ID = eVariable.sUniqueID;
                oMLocation.LOCATION = txtLocation.Text;
                oMLocation.STATUS = chkActive.Checked == true ? "ACTIVE" : "INACTIVE";
                oLocation.UpdateCategory(oMLocation);                
            }
            else
            {                
                oMLocation.LOCATION = txtLocation.Text;
                oMLocation.STATUS = chkActive.Checked == true ? "ACTIVE" : "INACTIVE";
                oLocation.InsertLocation(oMLocation);
            }

            oFrmMsgBox = new CustomWindow.frmInfoMsgBox("RECORD HAS BEEN SUCCESSFULLY SAVED.");
            oFrmMsgBox.ShowDialog();
            ClearFields();
            LoadLocation();
        }

        void ClearFields()
        {
            bEdit = false;
            chkActive.Checked = false;
            txtLocation.Text = string.Empty;
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

        public void LoadLocation()
        {
            try
            {
                oLocation = new DataAccess.Location();
                dgDetails.Rows.Clear();

                foreach (DataRow row in oLocation.GetLocationRecord("", "").Rows)
                {
                    dgDetails.Rows.Add(row[0], row[1], row[2]);
                }
            }
            catch (Exception ex)
            {
                
            }

        }

        private void dgDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DatagridSelectedData(sender, e);
            }
        }

        private void frmLocation_Load(object sender, EventArgs e)
        {
            LoadLocation();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                if (oMLocation.LOCATION_ID != string.Empty)
                {
                    eVariable.sUniqueID = oMLocation.LOCATION_ID;
                    txtLocation.Text = oMLocation.LOCATION;
                    chkActive.Checked = oMLocation.STATUS.Trim() == "ACTIVE" ? true : false;
                    bEdit = true;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            //
        }

        private void txtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
