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
    public partial class frmAuthor : Form
    {

        CustomWindow.frmInfoMsgBox oFrmMsgBox;
        
        Model.Author oMAuthor = new Model.Author();
        DataAccess.Author oAuthor = new DataAccess.Author();        

        public frmAuthor()
        {
            InitializeComponent();          
            eVariable.DisableTextEnterKey(pnlBody);
            eVariable.m_ActionType = eVariable.ACTION_TYPE.ADD;
        }     

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
          
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            oMAuthor = new Model.Author();
            oAuthor = new DataAccess.Author();

            if (eVariable.IsFieldEmpty(pnlBody))
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.ALL_FIELDS_ARE_REQUIRED.ToString().Replace("_", " "));
                oFrmMsgBox.ShowDialog();
                return;
            }          

            if (eVariable.m_ActionType == eVariable.ACTION_TYPE.EDIT)
            {                            
                oMAuthor.PERSON_ID = eVariable.sUniqueID;
                oMAuthor.FIRST_NAME = txtFname.Text;
                oMAuthor.MIDDLE_NAME = txtMname.Text;
                oMAuthor.LAST_NAME = txtLname.Text;
                oMAuthor.STATUS = chkActive.Checked == true ? "ACTIVE" : "INACTIVE";
                oAuthor.UpdateAuthor(oMAuthor);                         
            }
            else
            {                
                oMAuthor.FIRST_NAME = txtFname.Text;
                oMAuthor.MIDDLE_NAME = txtMname.Text;
                oMAuthor.LAST_NAME = txtLname.Text;

                if (oAuthor.isRecordExists(oMAuthor))
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.RECORD_IS_ALREADY_EXISTS.ToString().Replace("_", " "));
                    oFrmMsgBox.ShowDialog();
                    return;
                }

                oMAuthor.STATUS = chkActive.Checked == true ? "ACTIVE" : "INACTIVE";
                oAuthor.InsertAuthor(oMAuthor);            
            }

            oFrmMsgBox = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.RECORD_HAS_BEEN_SUCESSFULLY_SAVED.ToString().Replace("_", " "));
            oFrmMsgBox.ShowDialog();
            eVariable.ClearText(pnlBody);
            eVariable.m_ActionType = eVariable.ACTION_TYPE.ADD;
            LoadAuthor();

        }       

        void DatagridSelect(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgDetails.Rows.Count > 0)
                    {
                        oMAuthor = new Model.Author();
                        eVariable.sUniqueID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMAuthor.PERSON_ID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMAuthor.FIRST_NAME = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                        oMAuthor.MIDDLE_NAME = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                        oMAuthor.LAST_NAME = dgDetails.Rows[e.RowIndex].Cells[3].Value.ToString();
                        oMAuthor.STATUS = dgDetails.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void LoadAuthor()
        {
            try
            {
                oAuthor = new DataAccess.Author();
                dgDetails.Rows.Clear();
                eVariable.DisableGridColumnSort(dgDetails);
                foreach (DataRow row in oAuthor.GetAuthor("", "").Rows)
                {                    
                    dgDetails.Rows.Add(row[0].ToString(), row[1].ToString(),row[2].ToString(),row[3].ToString(),row[4].ToString().Trim());
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
                if (oMAuthor.PERSON_ID != string.Empty)
                {                    
                    txtFname.Text = oMAuthor.FIRST_NAME;
                    txtMname.Text = oMAuthor.MIDDLE_NAME;
                    txtLname.Text = oMAuthor.LAST_NAME;
                    chkActive.Checked = oMAuthor.STATUS.Trim() == "ACTIVE" ? true : false;
                    eVariable.m_ActionType = eVariable.ACTION_TYPE.EDIT;
                }
            }
        }

        private void dgDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DatagridSelect(sender, e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmAuthor_Load(object sender, EventArgs e)
        {
            LoadAuthor();
        }

        private void dgDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DatagridSelect(sender, e);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            eVariable.ClearText(pnlBody);
            eVariable.m_ActionType = eVariable.ACTION_TYPE.ADD;
        }      

    }
}
