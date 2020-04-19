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
    public partial class frmPolicy : Form
    {

        CustomWindow.frmInfoMsgBox oFrmMsgBox;
        DataAccess.Policy oPolicy;
        Model.Policy oMPolicy;
        public frmPolicy()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsFieldEmpty())
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

        public bool IsFieldEmpty()
        {
            foreach (var o in pnlInfo.Controls.OfType<TextBox>().ToList())
            {
                if (o.Text.Trim() == String.Empty)
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("ALL FIELDS ARE REQUIRED.");
                    oFrmMsgBox.ShowDialog();
                    o.Focus();
                    return true;
                }
            }
            return false;
        }

        private void frmPolicy_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
