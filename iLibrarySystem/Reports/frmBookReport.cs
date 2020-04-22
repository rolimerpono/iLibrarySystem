using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace iLibrarySystem.Reports
{
    public partial class frmBookReport : Form
    {
        

        string sReportPath = Application.StartupPath.Replace("bin", "").Replace("Debug", "").Replace("\\\\", "") + @"\Reports\";

        
        DataAccess.Reports oReports = new DataAccess.Reports();
        private ePublicVariable.eVariable.BOOK_STATUS e_ReportStatus;
        
        public frmBookReport()
        {
            InitializeComponent();
        }

        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;   
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {                
                

                ReportParameter[]  oParameters = new ReportParameter[1];
                oParameters[0] = new ReportParameter("Description", cboStatus.Text);

                string sReportName = "rptBookList.rdlc";

                oReports = new DataAccess.Reports();

                ReportViewer.LocalReport.ReportPath = sReportPath + sReportName;
                ReportViewer.LocalReport.DataSources.Clear();               
                ReportViewer.LocalReport.SetParameters(oParameters);                
                ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReportDataSet", oReports.Get_BookReport(e_ReportStatus, dtDateFrom.Value, dtDateTo.Value)));
                ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                ReportViewer.ZoomMode = ZoomMode.Percent;
               
                ReportViewer.ZoomPercent = 100;
                ReportViewer.RefreshReport();
            }
            catch (Exception ex)
            { }            
        }

  
        private void frmBookReport_Load(object sender, EventArgs e)
        {
            dtDateFrom.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dtDateTo.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            e_ReportStatus = ePublicVariable.eVariable.BOOK_STATUS.BOOK_RECORDLIST;
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cboStatus.Text)
            {
                case "BOOK RECORD LIST":
                    e_ReportStatus = ePublicVariable.eVariable.BOOK_STATUS.BOOK_RECORDLIST;
                    break;
                case "BORROWED BOOKS":
                    e_ReportStatus = ePublicVariable.eVariable.BOOK_STATUS.BORROWED_BOOKS;
                    break;
                case "RETURNED BOOKS":
                    e_ReportStatus = ePublicVariable.eVariable.BOOK_STATUS.RETUNRNED_BOOKS;
                    break;
                case "REQUEST BOOKS":
                    e_ReportStatus = ePublicVariable.eVariable.BOOK_STATUS.REQUEST_BOOKS;
                    break;                  
                default:
                    e_ReportStatus = ePublicVariable.eVariable.BOOK_STATUS.BOOK_RECORDLIST;
                    break;
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
