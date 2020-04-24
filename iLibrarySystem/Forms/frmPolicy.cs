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
    public partial class frmPolicy : Form
    {

        frmMessageBox oFrmMsgBox;
        DataAccess.Policy oPolicy;
        Model.Policy oMPolicy;
        public frmPolicy()
        {
            InitializeComponent();                        
            eVariable.DisableTextEnterKey(pnlInfo);
            eVariable.ValidNumberPanel(pnlInfo);
        }    

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
  
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ePublicVariable.eVariable.IsFieldEmpty(pnlBody))
            {
                oFrmMsgBox = new frmMessageBox(eVariable.TransactionMessage.ALL_FIELDS_ARE_REQUIRED.ToString().Replace("_", " "));
                oFrmMsgBox.m_MessageType = frmMessageBox.MESSAGE_TYPE.INFO;
                oFrmMsgBox.ShowDialog();
                return;
            }
            else
            {
                oMPolicy = new Model.Policy();
                oPolicy = new DataAccess.Policy();
                oMPolicy.DUE_INTEREST = txtDueRate.Text;
                oMPolicy.LOST_DAMAGE_INTEREST = txtLDRate.Text;
                oMPolicy.DAYS_LIMIT = txtMaxDays.Text;
                oMPolicy.BOOK_LIMIT = txtMaxBooks.Text;

                if (!oPolicy.IsPolicyExist())
                {
                    oPolicy.InsertPolicy(oMPolicy);
                }
                else
                {
                    oPolicy.UpdatePolicy(oMPolicy);
                }

                oFrmMsgBox = new frmMessageBox(eVariable.TransactionMessage.RECORD_HAS_BEEN_SUCESSFULLY_SAVED.ToString().Replace("_", " "));
                oFrmMsgBox.m_MessageType = frmMessageBox.MESSAGE_TYPE.INFO;
                oFrmMsgBox.ShowDialog();
            
            }
        }

        void LoadRecords()
        {
            oPolicy = new DataAccess.Policy();
            foreach (DataRow row in oPolicy.GetPolicy("", "").Rows)
            {
                txtDueRate.Text = row[0] == null ? "0" : row[0].ToString();
                txtLDRate.Text = row[1] == null ? "0" : row[0].ToString();
                txtMaxDays.Text = row[2] == null ? "0" : row[0].ToString();
                txtMaxBooks.Text = row[3] == null ? "0" : row[0].ToString();
            }
        }

        

        private void frmPolicy_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
       
    }
}
