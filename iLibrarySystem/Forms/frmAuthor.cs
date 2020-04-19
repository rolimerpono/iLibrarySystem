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

        Boolean bEdit = false;
        Model.Author oMAuthor = new Model.Author();
        DataAccess.Author oAuthor = new DataAccess.Author();        
        public frmAuthor()
        {
            InitializeComponent();

            foreach (var o in pnlBody.Controls.OfType<TextBox>().ToList())
            {
                o.KeyDown += TextKeyDown;
            }
        }

        void TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
          
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

            oMAuthor = new Model.Author();
            oAuthor = new DataAccess.Author();

            if (IsRecordEmpty())
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("ALL FIELDS REQUIRED.");
                oFrmMsgBox.ShowDialog();
                return;
            }          

            if (bEdit)
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
                oMAuthor.STATUS = chkActive.Checked == true ? "ACTIVE" : "INACTIVE";
                oAuthor.InsertAuthor(oMAuthor);            
            }

            oFrmMsgBox = new CustomWindow.frmInfoMsgBox("RECORD HAS BEEN SUCCESSFULLY SAVED.");
            oFrmMsgBox.ShowDialog();            
            ClearFields();
            LoadAuthor();

        }

        void ClearFields()
        {
            bEdit = false;
            chkActive.Checked = false;
            foreach (Control o in pnlBody.Controls.OfType<TextBox>().ToList())
            {
                o.Text = string.Empty;
            }
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
                    bEdit = true;
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

   

    }
}
