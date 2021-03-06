﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ePublicVariable;


namespace iLibrarySystem.Maintenance
{
    
    public partial class frmImportExport : Form
    {
        
        DataAccess.Borrower oBorrower;             
        List<Model.Borrower> lstBorrower;

        ePublicVariable.eVariable.FIND_BORROWER oFilterBorrower;

        SaveFileDialog oSaveFileDialog;
        private string[] oOutputCSV;

        Forms.frmMessageBox oFrmMsgBox;        

        public frmImportExport()
        {
            InitializeComponent();
            eVariable.DisableKeyPress(cboExport);
            eVariable.DisableKeyPress(cboImport);
            
        }

        private void cboImport_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboExport_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;   
        }

        private void tbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbControl.SelectedIndex == 0)
            {
                btnButton.Text = "IMPORT";
                btnPopulate.Visible = false;
            }
            else
            {
                btnButton.Text = "EXPORT";
                btnPopulate.Visible = true;
            }
        }

        private void btnButton_Click(object sender, EventArgs e)
        {

            if (btnButton.Text.Trim() == "IMPORT")
            {

                if (txtImportPath.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please select file to import");
                    return;
                }

                #region Import
                try
                {
                    if (cboImport.SelectedText == "BORROWER" || cboImport.Text == "BORROWER")
                    {
                        if (dgImport.Rows.Count > 0)
                        {
                            foreach (var iData in lstBorrower)
                            {
                                oBorrower = new DataAccess.Borrower();
                                if (!oBorrower.IsRecordExists(iData))
                                {
                                    oBorrower.InsertBorrower(iData);
                                }
                            }

                            oFrmMsgBox = new Forms.frmMessageBox(eVariable.TransactionMessage.RECORD_HAS_BEEN_SUCESSFULLY_SAVED.ToString().Replace("_"," "));
                            oFrmMsgBox.m_MessageType = Forms.frmMessageBox.MESSAGE_TYPE.INFO;
                            oFrmMsgBox.ShowDialog();
                        }
                    }                   
                }
                catch (Exception ex)
                {
                    
                }
                #endregion
            }
            else
            {
                if (txtExportPath.Text.Trim() == string.Empty)
                {
                    MessageBox.Show(eVariable.TransactionMessage.PLEASE_SELECT_DISTINATION_PATH_TO_SAVE_THE_FILE.ToString().Replace("_"," "));
                    return;
                }

                if (dgExport.Rows.Count == 0)
                {
                    MessageBox.Show(eVariable.TransactionMessage.PLEASE_POPULATE_A_RECORD_FIRST.ToString().Replace("_"," "));
                    return;                
                }

                #region Export
                ExtractData();
                #endregion

            }
        }
            

        private void btnBrowseI_Click(object sender, EventArgs e)
        {

            try
            {

                if (cboImport.SelectedText == "BORROWER" || cboImport.Text == "BORROWER")
                {
                    OpenFileDialog oDiaglog = new OpenFileDialog
                    {
                        InitialDirectory = @"D:\",
                        Title = "Browse CSV Files",

                        CheckFileExists = true,
                        CheckPathExists = true,

                        DefaultExt = "csv",
                        Filter = "CSV files (*.CSV)|*.CSV",
                        FilterIndex = 2,
                        RestoreDirectory = true,

                        ReadOnlyChecked = true,
                        ShowReadOnly = true
                    };

                    if (oDiaglog.ShowDialog() == DialogResult.OK)
                    {
                        txtImportPath.Text = oDiaglog.FileName;

                        oBorrower = new DataAccess.Borrower();
                        lstBorrower = oBorrower.GetCSVData(txtImportPath.Text);
                        dgImport.DataSource = lstBorrower;
                    }
                }

                if (txtImportPath.Text.Trim() != String.Empty)
                {
                    foreach (DataGridViewColumn col in dgImport.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    for (int i = 0; i < dgImport.RowCount; i++)
                    {
                        for (int j = 0; j < dgImport.ColumnCount; j++)
                        {
                            if (dgImport.Rows[i].Cells[j].Value != null)
                            {
                                if (dgImport.Rows[i].Cells[j].Value.ToString().Trim() == string.Empty)
                                {
                                    dgImport.Columns[j].Visible = false;
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            if (cboExport.Text == "BORROWER")
            {
                LoadBorrower();
            }
        }

        public void LoadBorrower()
        {
            try
            {
                oBorrower = new DataAccess.Borrower();
                dgExport.Rows.Clear();
                oFilterBorrower = ePublicVariable.eVariable.FIND_BORROWER.FIRST_NAME;
                BorrowerStructure();
                foreach (DataRow row in oBorrower.GetRecords(oFilterBorrower, "").Rows)
                {
                    dgExport.Rows.Add(row["BORROWER_ID"], row["FIRST_NAME"], row["MIDDLE_NAME"], row["LAST_NAME"], row["DOB"], row["AGE"], row["CONTACT_NO"], row["ADDRESS"], row["STATUS"], row["PROFILE_PIC"]);
                }                
            }
            catch (Exception ex)
            {

            }

        }

        void BorrowerStructure()
        {
            dgExport.Columns.Clear();
            dgExport.Columns.Add("", "BORROWER ID");
            dgExport.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgExport.Columns.Add("", "FIRST NAME");
            dgExport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgExport.Columns.Add("", "MIDDLE NAME");
            dgExport.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgExport.Columns.Add("", "LAST NAME");
            dgExport.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgExport.Columns.Add("", "DOB");
            dgExport.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgExport.Columns.Add("", "AGE");
            dgExport.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgExport.Columns.Add("", "CONTACT NO");
            dgExport.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgExport.Columns.Add("", "ADDRESS");
            dgExport.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void ExtractData()
        {

            try
            {
                int iColumnCount = dgExport.Columns.Count;
                string sColumnNames = "";

                oOutputCSV = new string[dgExport.Rows.Count + 1];
                for (int i = 0; i < iColumnCount; i++)
                {
                    sColumnNames += dgExport.Columns[i].HeaderText.ToString() + ",";
                }
                oOutputCSV[0] += sColumnNames;
                for (int i = 1; (i - 1) < dgExport.Rows.Count; i++)
                {
                    for (int j = 0; j < iColumnCount; j++)
                    {
                        oOutputCSV[i] += dgExport.Rows[i - 1].Cells[j].Value.ToString() + ",";
                    }
                }

                File.WriteAllLines(oSaveFileDialog.FileName, oOutputCSV, Encoding.UTF8);
                oFrmMsgBox = new Forms.frmMessageBox(eVariable.TransactionMessage.RECORD_HAS_BEEN_SUCESSFULLY_EXTRACTED_AND_SAVE_TO_PATH.ToString().Replace("_"," ") + " :" + oSaveFileDialog.FileName);
                oFrmMsgBox.m_MessageType = Forms.frmMessageBox.MESSAGE_TYPE.INFO;
                oFrmMsgBox.ShowDialog();
            }
            catch (Exception ex)
            { }
        }

        private void btnBrowseE_Click(object sender, EventArgs e)
        {
            try
            {
                oSaveFileDialog = new SaveFileDialog();
                oSaveFileDialog.Filter = "CSV (*.csv) | *.csv";
                oSaveFileDialog.FileName = "DataResult.csv";

                if (oSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtExportPath.Text = oSaveFileDialog.FileName;
                }
            }
            catch (Exception ex)
            { }
        }

        private void clearText()
        {
            txtExportPath.Text = "";
            dgExport.Rows.Clear();            
        }
    }
}
