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
    public partial class frmLock : Form
    {
        CustomWindow.frmInfoMsgBox oFrmMsgBox;
        string sKey = string.Empty;
        public frmLock()
        {
            InitializeComponent();
        }

        public frmLock(string sPass)
        {
            InitializeComponent();
            sKey = sPass;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == sKey.Trim())
            {
                this.Dispose();
            }
            else
            {
                oFrmMsgBox = new CustomWindow.frmInfoMsgBox("THE PASSWORD YOU ENTERED IS INCORRECT!");
                oFrmMsgBox.Left = 10;
                oFrmMsgBox.ShowDialog();
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
