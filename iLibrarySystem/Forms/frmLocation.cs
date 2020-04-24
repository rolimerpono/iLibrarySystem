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
        Forms.frmMessageBox oFrmMsgBox;

        Model.Location oMLocation = new Model.Location();
        DataAccess.Location oLocation = new DataAccess.Location();
        

        CommonFunction.CommonFunction oCommonFunction;

        public frmLocation()
        {
            InitializeComponent();
            eVariable.DisableTextEnterKey(pnlBody);
            eVariable.m_ActionType = eVariable.ACTION_TYPE.ADD;
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

            if (eVariable.IsFieldEmpty(pnlBody))
            {
                oFrmMsgBox = new frmMessageBox(eVariable.TransactionMessage.ALL_FIELDS_ARE_REQUIRED.ToString().Replace("_", " "));
                oFrmMsgBox.m_MessageType = frmMessageBox.MESSAGE_TYPE.INFO;
                oFrmMsgBox.ShowDialog();
                return;
            }

            if (eVariable.m_ActionType == eVariable.ACTION_TYPE.EDIT)
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

                if (oLocation.isRecordExists(oMLocation))
                {
                    oFrmMsgBox = new frmMessageBox(eVariable.TransactionMessage.RECORD_IS_ALREADY_EXISTS.ToString().Replace("_", " "));
                    oFrmMsgBox.m_MessageType = frmMessageBox.MESSAGE_TYPE.INFO;
                    oFrmMsgBox.ShowDialog();
                    return;
                }

           
                oLocation.InsertLocation(oMLocation);
            }

            oFrmMsgBox = new frmMessageBox(eVariable.TransactionMessage.RECORD_HAS_BEEN_SUCESSFULLY_SAVED.ToString().Replace("_", " "));
            oFrmMsgBox.m_MessageType = frmMessageBox.MESSAGE_TYPE.INFO;
            oFrmMsgBox.ShowDialog();
            eVariable.ClearText(pnlBody);
            LoadLocation();
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
                eVariable.DisableGridColumnSort(dgDetails);
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
                    eVariable.m_ActionType = eVariable.ACTION_TYPE.EDIT;
              
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            eVariable.ClearText(pnlBody);
          
        }
     
    }
}
