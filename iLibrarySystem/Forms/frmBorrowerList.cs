﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ePublicVariable;

namespace iLibrarySystem.Forms
{
    public partial class frmBorrowerList : Form
    {
        DataAccess.Borrower oBorrower;
        Model.Borrower oMBorrower;

        ePublicVariable.eVariable.FILTER_BOOK oFilterBook;
        ePublicVariable.eVariable.FIND_BORROWER oFilterBorrower;


        #region Forms
        CustomWindow.frmInfoMsgBox oFrmMsgBox;
        #endregion

        public frmBorrowerList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Load_Form(false);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
     
        }

        private void cboSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public void LoadBorrower()
        {
            try
            {
                oBorrower = new DataAccess.Borrower();
                dgDetails.Rows.Clear();

                foreach (DataRow row in oBorrower.GetRecords(oFilterBorrower, tbxSearch.Text).Rows)
                {
                    dgDetails.Rows.Add(row["BORROWER_ID"], row["FIRST_NAME"], row["MIDDLE_NAME"], row["LAST_NAME"], row["DOB"], row["AGE"], row["CONTACT_NO"], row["ADDRESS"],row["STATUS"],row["PROFILE_PIC"]);
                }

                lblTotalRecords.Text = dgDetails.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                
            }

        }

   
        void Load_Form(Boolean bEdit)
        {
            frmBorrowerEntry oForm = new frmBorrowerEntry(this, oMBorrower, bEdit);
            oForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                if (dgDetails.SelectedCells[0].Selected == true)
                {
                    Load_Form(true);
                }
                else
                {
                    oFrmMsgBox = new CustomWindow.frmInfoMsgBox("PLEASE SELECT A RECORD FIRST.");
                    oFrmMsgBox.ShowDialog();
                }
            }
        }

        void DatagridSelect(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgDetails.Rows.Count > 0)
                {
                    oMBorrower = new Model.Borrower();
                    oMBorrower.PERSON_ID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                    oMBorrower.FIRST_NAME = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                    oMBorrower.MIDDLE_NAME = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                    oMBorrower.LAST_NAME = dgDetails.Rows[e.RowIndex].Cells[3].Value.ToString();
                    oMBorrower.DOB = dgDetails.Rows[e.RowIndex].Cells[4].Value.ToString();
                    oMBorrower.AGE = dgDetails.Rows[e.RowIndex].Cells[5].Value.ToString();
                    oMBorrower.CONTACT_NO = dgDetails.Rows[e.RowIndex].Cells[6].Value.ToString();
                    oMBorrower.ADDRESS = dgDetails.Rows[e.RowIndex].Cells[7].Value.ToString();
                    oMBorrower.STATUS = dgDetails.Rows[e.RowIndex].Cells[8].Value.ToString();
                    oMBorrower.PROFILE_PIC = dgDetails.Rows[e.RowIndex].Cells[9].Value.ToString();
                }
            }
            catch (Exception ex)
            {
    
            }
        }

        private void dgStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DatagridSelect(sender, e);
        }

        private void dgStudents_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DatagridSelect(sender, e);
        }

        private void frmBorrowerList_Load(object sender, EventArgs e)
        {
            LoadBorrower();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBorrower();
        }

        private void dgDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                Forms.frmBorrowerEntry oForm = new frmBorrowerEntry(this,oMBorrower, true);
                oForm.ShowDialog();
            }
        }

        private void cboSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboSearchBy.Text)
            {
                case "BORROWE ID":
                    oFilterBorrower = eVariable.FIND_BORROWER.BORROWER_ID;
                    break;
                case "FIRST NAME":
                    oFilterBorrower = eVariable.FIND_BORROWER.FIRST_NAME;
                    break;
                case "MIDDLE NAME":
                    oFilterBorrower = eVariable.FIND_BORROWER.MIDDLE_NAME;
                    break;
                case "LAST NAME":
                    oFilterBorrower = eVariable.FIND_BORROWER.LAST_NAME;
                    break;
                default:
                    oFilterBorrower = eVariable.FIND_BORROWER.FIRST_NAME;
                    break;
            }
        }            
       
    }
}
