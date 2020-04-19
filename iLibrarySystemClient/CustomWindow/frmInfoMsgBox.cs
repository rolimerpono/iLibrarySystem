using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iLibrarySystemClient.CustomWindow
{
    public partial class frmInfoMsgBox : Form
    {
        string sMessageBox = string.Empty;
        public frmInfoMsgBox()
        {
            InitializeComponent();
        }

        public frmInfoMsgBox(string sMessage)
        {
            InitializeComponent();
            sMessageBox = sMessage.ToUpper();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmInfoMsgBox_Load(object sender, EventArgs e)
        {
            txtMessage.Text = sMessageBox;
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


    }
}
