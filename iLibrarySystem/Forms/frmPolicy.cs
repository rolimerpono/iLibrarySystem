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

        CustomWindow.frmInfoMsgBox oFrmMsgBox;
        DataAccess.Policy oPolicy;
        Model.Policy oMPolicy;
        public frmPolicy()
        {
            InitializeComponent();                        
            eVariable.DisableTextEnterKey(pnlInfo);
            eVariable.DisableValidNumberPanel(pnlInfo);
        }    

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
  
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ePublicVariable.eVariable.IsFieldEmpty(pnlBody))
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("ALL FIELDS ARE REQUIRED.");
                oFrmMsgBox.ShowDialog();
                return;
            }
            else
            {
                oMPolicy = new Model.Policy();
                oPolicy = new DataAccess.Policy();
                oMPolicy.DUE_INTEREST = txtDueRate.Text;
                oMPolicy.LOST_DAMAGE_INTEREST = txtLDRate.Text;
                oMPolicy.MAX_DAYS_BORROW = txtMaxDays.Text;
                oMPolicy.MAX_BOOK_BORROW = txtMaxBooks.Text;

                if (!oPolicy.IsPolicyExist())
                {
                    oPolicy.InsertPolicy(oMPolicy);
                }
                else
                {
                    oPolicy.UpdatePolicy(oMPolicy);
                }

                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("RECORD HAS BEEN SUCCESSFULLY SAVED.");
                oFrmMsgBox.ShowDialog();
            
            }
        }

        void LoadRecords()
        {
            oPolicy = new DataAccess.Policy();
            foreach (DataRow row in oPolicy.GetPolicy("", "").Rows)
            {
                txtDueRate.Text = row[0].ToString();
                txtLDRate.Text = row[1].ToString();
                txtMaxDays.Text = row[2].ToString();
                txtMaxBooks.Text = row[3].ToString();
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
