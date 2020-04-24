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
    public partial class frmResetData : Form
    {
        DataAccess.Book oBook = new DataAccess.Book();
        frmMessageBox oFrmMsgBox;

        public frmResetData()
        {
            InitializeComponent();
        }

        private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                oBook = new DataAccess.Book();
                if (optRequest.Checked)
                {
                    oBook.DeleteUnsettledRequestTransaction(dtFrom.Value, dtTo.Value);
                    oFrmMsgBox = new frmMessageBox(ePublicVariable.eVariable.TransactionMessage.RECORD_HAS_BEEN_SUCESSFULLY_DELETED.ToString().Replace("_"," "));
                    oFrmMsgBox.m_MessageType = frmMessageBox.MESSAGE_TYPE.INFO;
                    oFrmMsgBox.ShowDialog();
                }
            }
            catch (Exception ex)
            { }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
