using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iControlGrid
{
    public partial class frmMsgBoxQuery : Form
    {
        string sMessageBox = string.Empty;
        public frmMsgBoxQuery()
        {
            InitializeComponent();
        }

        public string sAnswer = string.Empty;
        public frmMsgBoxQuery(string sMessage)
        {
            InitializeComponent();
            sMessageBox = sMessage;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            sAnswer = "YES";
            this.Dispose();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            sAnswer = "NO";
            this.Dispose();
        }

        private void frmMsgBoxQuery_Load(object sender, EventArgs e)
        {
            txtMessage.Text = sMessageBox;
        }
    }
}
