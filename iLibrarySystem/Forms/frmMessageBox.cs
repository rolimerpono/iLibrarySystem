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
    public partial class frmMessageBox : Form
    {
        public string sAnswer = string.Empty;
        private string sMessage = string.Empty;
        public frmMessageBox()
        {
            InitializeComponent();
        }

        public frmMessageBox(string sMsg)
        {
            InitializeComponent();
            sMessage = sMsg;
        }

        public enum MESSAGE_TYPE : int
        {
            NONE = 0,
            INFO = 1,
            QUERY = 2
        }

        public MESSAGE_TYPE m_MessageType;
        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            if (m_MessageType == MESSAGE_TYPE.INFO)
            {
                lblMessage.Text = sMessage.ToUpper();
                ShowInfo();
            }
            else if (m_MessageType == MESSAGE_TYPE.QUERY)
            {
                lblMessage.Text = sMessage.ToUpper();
                ShowQuery();
            }
        }      

        private void ShowInfo()
        {
            btnLeft.Visible = true;
            btnLeft.Text = "OK";
            btnRight.Visible = false;
        }

        private void ShowQuery()
        {
            btnLeft.Visible = true;
            btnLeft.Text = "NO";
            btnRight.Visible = true;
            btnRight.Text = "YES";
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            switch (m_MessageType)
            { 
                case MESSAGE_TYPE.INFO:                    
                    break;
                case MESSAGE_TYPE.QUERY:
                    sAnswer = "NO";                    
                    break;            
            }
            Close();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (m_MessageType == MESSAGE_TYPE.QUERY)
            {
                sAnswer = "YES";                
            }
            Close();
        }               
    }
}
