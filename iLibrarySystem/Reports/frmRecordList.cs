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
    public partial class frmRecordList : Form
    {
        string sBookList = @"C:\Users\ROLLY\Documents\Visual Studio 2010\Projects\iLibrarySystem\iLibrarySystem\Reports\rptBookList.rdlc";
        string sBorrowerList = @"C:\Users\ROLLY\Documents\Visual Studio 2010\Projects\iLibrarySystem\iLibrarySystem\Reports\rptBorrowerList.rdlc";

        DataAccess.Reports oReports;

        DatabaseQuery.DBQuery ddq;
        public string sReportType = string.Empty;
        public frmRecordList()
        {
            InitializeComponent();
        }

        public frmRecordList(String sRecordType)
        {
            InitializeComponent();

            sReportType= sRecordType;
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            dtDateFrom.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dtDateTo.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            switch (sReportType)
            { 
                case "BookList":
                    BooList();
                    break;
                case "BorrowerList":
                    BorrowerList();
                    break;
            }      
        }
 
        void BooList()
        {
            oReports = new DataAccess.Reports();            

            ReportViewer.LocalReport.ReportPath = sBookList;
            ReportViewer.LocalReport.DataSources.Clear();
            ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReportDataSet", oReports.GetBookList(dtDateFrom.Value,dtDateTo.Value)));
            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.ZoomMode = ZoomMode.Percent;
            ReportViewer.ZoomPercent = 100;
            ReportViewer.RefreshReport();

        }

        void BorrowerList()
        {
            oReports = new DataAccess.Reports();

            ReportViewer.LocalReport.ReportPath = sBorrowerList;
            ReportViewer.LocalReport.DataSources.Clear();
            ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReportDataSet", oReports.getBorrowerList(dtDateFrom.Value, dtDateTo.Value)));
            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.ZoomMode = ZoomMode.Percent;
            ReportViewer.ZoomPercent = 100;
            ReportViewer.RefreshReport();

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
