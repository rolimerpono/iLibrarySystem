using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iLibrarySystem.Reports
{
    public partial class frmBookReport : Form
    {
        public frmBookReport()
        {
            InitializeComponent();
        }

        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;   
        }
    }
}
