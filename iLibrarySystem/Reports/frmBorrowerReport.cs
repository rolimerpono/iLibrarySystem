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
    public partial class frmBorrowerReport : Form
    {
        
        string sReportPath = @"C:\Users\ROLLY\Documents\Visual Studio 2010\Projects\iLibrarySystem\iLibrarySystem\Reports\";

        DataAccess.Reports oReports = new DataAccess.Reports();
        private ePublicVariable.eVariable.BORROWER_STATUS e_ReportStatus;

              
        public frmBorrowerReport()
        {
            InitializeComponent();
        }

        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmBorrowerReport_Load(object sender, EventArgs e)
        {
            dtDateFrom.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dtDateTo.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            e_ReportStatus = ePublicVariable.eVariable.BORROWER_STATUS.BORROWER_RECORDLIST;
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string sReportName = string.Empty;
            try
            {

                ReportParameter[] oParameters = new ReportParameter[1];
                oParameters[0] = new ReportParameter("Description", cboStatus.Text);


                switch (e_ReportStatus)
                {
                    case ePublicVariable.eVariable.BORROWER_STATUS.BORROWER_RECORDLIST:
                        sReportName = "rptBorrowerList.rdlc";
                        break;
                    case ePublicVariable.eVariable.BORROWER_STATUS.UNRETURNED_BOOKS:
                        sReportName = "rptBorrowerTransaction.rdlc";
                        break;
                    case ePublicVariable.eVariable.BORROWER_STATUS.REQUESTED_BOOKS:
                        sReportName = "rptBorrowerTransaction.rdlc";
                        break;
                }

                oReports = new DataAccess.Reports();

                ReportViewer.LocalReport.ReportPath = sReportPath + sReportName;
                ReportViewer.LocalReport.DataSources.Clear();
                ReportViewer.LocalReport.SetParameters(oParameters);
                ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReportDataSet", oReports.Get_BorrowerReport(e_ReportStatus, dtDateFrom.Value, dtDateTo.Value)));
                if (e_ReportStatus != ePublicVariable.eVariable.BORROWER_STATUS.BORROWER_RECORDLIST)
                {
                    ReportViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                }
                ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                ReportViewer.ZoomMode = ZoomMode.Percent;
                ReportViewer.ZoomPercent = 100;
                ReportViewer.RefreshReport();
            }
            catch (Exception ex)
            { }
            
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            ePublicVariable.eVariable.sBorrowerID = e.Parameters["BORROWER_ID"].Values.ToList().SingleOrDefault();
            oReports = new DataAccess.Reports();            
            e.DataSources.Add(new ReportDataSource("ReportDataSet", oReports.Get_BorrowerSubReport(e_ReportStatus, ePublicVariable.eVariable.sBorrowerID, dtDateFrom.Value, dtDateTo.Value)));        
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboStatus.Text)
            { 
                case "BORROWER RECORD LIST":
                    e_ReportStatus = ePublicVariable.eVariable.BORROWER_STATUS.BORROWER_RECORDLIST;
                    break;
                case "UNRETURNED BOOKS":
                    e_ReportStatus = ePublicVariable.eVariable.BORROWER_STATUS.UNRETURNED_BOOKS;
                    break;
                case "REQUESTED BOOKS":
                    e_ReportStatus = ePublicVariable.eVariable.BORROWER_STATUS.REQUESTED_BOOKS;
                    break;            
                default:
                    e_ReportStatus= ePublicVariable.eVariable.BORROWER_STATUS.BORROWER_RECORDLIST;
                    break;

            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
