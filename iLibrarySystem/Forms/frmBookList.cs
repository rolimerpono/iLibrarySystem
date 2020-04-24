using System;
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
    public partial class frmBookList : Form
    {

        DataAccess.Book oBook = new DataAccess.Book();
        Model.Transaction oMTransaction = new Model.Transaction();
        Model.Borrower oMBorrower = new Model.Borrower();

        
        ePublicVariable.eVariable.FILTER_BOOK oFilterBook;

        public frmBookList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Forms.frmBookEntry oFrm = new frmBookEntry(this);
            oFrm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                Forms.frmBookEntry oForm = new frmBookEntry(this, oMTransaction);
                oForm.ShowDialog();
            }
        }

        public void LoadRecords()
        {
            try
            {
                oBook = new DataAccess.Book();
                dgDetails.Rows.Clear();
                eVariable.DisableGridColumnSort(dgDetails);
                foreach (DataRow row in oBook.GetBookRecords(oFilterBook,"ACTIVE", txtSearch.Text).Rows)
                {
                    dgDetails.Rows.Add(row["BOOK_ID"], row["TITLE"], row["SUBJECT"], row["CATEGORY"], row["AUTHOR"], row["PUBLISH_DATE"], row["BOOK_PRICE"], row["RENT_PRICE"], row["LOCATION"], row["COPIES_AVAILABLE"], row["TOTAL_COPIES"]);
                }

                lblTotalRecords.Text = dgDetails.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
               
            }

        }

        void DatagridSelect(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgDetails.Rows.Count > 0)
                    {
                        oMTransaction = new Model.Transaction();
                        oMTransaction.BOOK_ID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMTransaction.TITLE = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                        oMTransaction.SUBJECT = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                        oMTransaction.CATEGORY = dgDetails.Rows[e.RowIndex].Cells[3].Value.ToString();
                        oMTransaction.AUTHOR = dgDetails.Rows[e.RowIndex].Cells[4].Value.ToString();
                        oMTransaction.PUBLISH_DATE = dgDetails.Rows[e.RowIndex].Cells[5].Value.ToString();
                        oMTransaction.BOOK_PRICE = dgDetails.Rows[e.RowIndex].Cells[6].Value.ToString();
                        oMTransaction.RENT_PRICE = dgDetails.Rows[e.RowIndex].Cells[7].Value.ToString();
                        oMTransaction.LOCATION = dgDetails.Rows[e.RowIndex].Cells[8].Value.ToString();

                        if (e.ColumnIndex == 11 && e.RowIndex >= 0)
                        {
                            iGridControl.BookCommonData = oMTransaction;
                            iGridControl.FindOption = iControlGrid.iGridControl.FIND_OPTION.SEARCH_DB_BOOK_ISBN;
                            iGridControl.SetRemaksColumnVisible = true;
                            iGridControl.SetStatusColumnVisible = true;
                            iGridControl.SetHeaderVisible = true;
                            iGridControl.PopulateRecord();
                            iGridControl.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

        }


        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Dispose();           
        }

        private void cboSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            ePublicVariable.eVariable.DisableKeyPress(cboSearchBy);
        }

        private void frmBookList_Load(object sender, EventArgs e)
        {
            oFilterBook = ePublicVariable.eVariable.FILTER_BOOK.BOOK_TITLE;
            LoadRecords();

            foreach (DataGridViewColumn col in dgDetails.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            
        }

        private void dgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DatagridSelect(sender, e);
        }

        private void dgDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DatagridSelect(sender, e);
        }

        private void btnAdjustItem_Click(object sender, EventArgs e)
        {
            Forms.frmAdjustItem oFrm = new frmAdjustItem(this, oMTransaction);
            oFrm.ShowDialog();
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void cboSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboSearchBy.Text)
            {
                case "TITLE":
                    oFilterBook = ePublicVariable.eVariable.FILTER_BOOK.BOOK_TITLE;
                    break;
                case "AUTHOR":
                    oFilterBook = ePublicVariable.eVariable.FILTER_BOOK.BOOK_AUTHOR;
                    break;
                case "CATEGORY":
                    oFilterBook = ePublicVariable.eVariable.FILTER_BOOK.BOOK_CATEGORY;
                    break;
                default:
                    oFilterBook = ePublicVariable.eVariable.FILTER_BOOK.BOOK_TITLE;
                    break;
            }
        }

        private void dgDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                Forms.frmBookEntry oForm = new frmBookEntry(this, oMTransaction);
                oForm.ShowDialog();
            }
        }

        private void frmBookList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == 27)
            {
                iGridControl.Visible = false;
            }
        }     

    }
}
