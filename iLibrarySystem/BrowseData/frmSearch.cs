using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ePublicVariable;

namespace iLibrarySystem.BrowseData
{
    

    public partial class frmSearch : Form
    {

        public eVariable.FILTER_BOOK oFilterBook;
        public eVariable.FIND_BORROWER oFilterBorrower;
        public eVariable.FIND_OPTION oFilterFindOption;
        public eVariable.FORM_NAME oFormName;
     

        public Model.Book oMBook = new Model.Book();
        public Model.Borrower oMBorrower = new Model.Borrower();
        public DataAccess.Book oBook = new DataAccess.Book();
        public DataAccess.Borrower oBorrower = new DataAccess.Borrower();     
        
        public frmSearch()
        {
            InitializeComponent();
            eVariable.DisableKeyPress(cboSearch);
            eVariable.DisableTextPanelEnterKey(panel3);
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            SearchByDetails();
            LoadRecords();          
        }

        void LoadRecords()
        {            
            dgDetails.Rows.Clear();
            eVariable.DisableGridColumnSort(dgDetails);
            if (oFilterFindOption == eVariable.FIND_OPTION.BOOKS)
            {
                BookStructure();
                foreach (DataRow oRow in oBook.GetBookRecords(oFilterBook,"ACTIVE", txtSearch.Text).Rows)
                {
                    dgDetails.Rows.Add(oRow["BOOK_ID"], oRow["TITLE"], oRow["SUBJECT"], oRow["CATEGORY"], oRow["AUTHOR"], oRow["PUBLISH_DATE"], oRow["BOOK_PRICE"], oRow["RENT_PRICE"], oRow["LOCATION"], oRow["COPIES_AVAILABLE"], oRow["TOTAL_COPIES"]);
                }
            }
            else if (oFilterFindOption == eVariable.FIND_OPTION.BORROWER)
            {
                BorrowerStructure();
                if (oFormName == eVariable.FORM_NAME.PAY_BOOK)
                {
                    foreach (DataRow oRow in oBorrower.GetBorrowerTransaction(eVariable.FIND_BOOK.BOOK_BORROWED, txtSearch.Text).Rows)
                    {
                        dgDetails.Rows.Add(oRow["ID"], oRow["FIRST_NAME"], oRow["MIDDLE_NAME"], oRow["LAST_NAME"], oRow["DOB"], oRow["AGE"], oRow["CONTACT_NO"], oRow["ADDRESS"]);
                    }
                }
                else if (oFormName == eVariable.FORM_NAME.BORROW_BOOK)
                {
                    BorrowerStructure();
                    foreach (DataRow oRow in oBorrower.GetRecords(oFilterBorrower, txtSearch.Text).Rows)
                    {
                        dgDetails.Rows.Add(oRow["BORROWER_ID"], oRow["FIRST_NAME"], oRow["MIDDLE_NAME"], oRow["LAST_NAME"], oRow["DOB"], oRow["AGE"], oRow["CONTACT_NO"], oRow["ADDRESS"]);
                    }
                }
            }
        }

        void BorrowerStructure()
        {
            dgDetails.Columns.Clear();
            dgDetails.Columns.Add("", "BORROWER ID");
            dgDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "FIRST NAME");
            dgDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "MIDDLE NAME");
            dgDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "LAST NAME");
            dgDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "DOB");
            dgDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "AGE");
            dgDetails.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "CONTACT NO");
            dgDetails.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "ADDRESS");
            dgDetails.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;        
        }

        void BookStructure()
        {
            
            dgDetails.Columns.Clear();
            dgDetails.Columns.Add("", "BOOK ID");
            dgDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns[0].Visible = false;
            dgDetails.Columns.Add("", "TITLE");
            dgDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "SUBJECT");
            dgDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "CATEGORY");
            dgDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "AUTHOR");
            dgDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "PUBLISH DATE");
            dgDetails.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "BOOK PRICE");
            dgDetails.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "RENT PRICE");
            dgDetails.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgDetails.Columns.Add("", "LOCATION");
            dgDetails.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgDetails.Columns.Add("", "COPIES AVAILABLE");
            dgDetails.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "TOTAL COPIES");
            dgDetails.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


         

        }

        void SearchByDetails()
        {
            if (oFilterFindOption == eVariable.FIND_OPTION.BOOKS)
            {
                cboSearch.Items.Clear();
                cboSearch.Text = "TITLE";
                cboSearch.Items.Add("TITLE");
                cboSearch.Items.Add("AUTHOR");
                cboSearch.Items.Add("CATEGORY");  
            }
            else
            {
                cboSearch.Items.Clear();
                cboSearch.Text = "BORROWER ID";
                cboSearch.Items.Add("BORROWER ID");
                cboSearch.Items.Add("FIRST NAME");
                cboSearch.Items.Add("MIDDLE NAME");
                cboSearch.Items.Add("LAST NAME");
            }
        }

        void DatagridSelect(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgDetails.Rows.Count > 0)
                {
                    if (oFilterFindOption == eVariable.FIND_OPTION.BOOKS)
                    {
                        oMBook = new Model.Book();
                        oMBook.BOOK_ID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMBook.TITLE = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                        oMBook.SUBJECT = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                        oMBook.CATEGORY = dgDetails.Rows[e.RowIndex].Cells[3].Value.ToString();
                        oMBook.AUTHOR = dgDetails.Rows[e.RowIndex].Cells[4].Value.ToString();
                        oMBook.PUBLISH_DATE = dgDetails.Rows[e.RowIndex].Cells[5].Value.ToString();
                        oMBook.BOOK_PRICE = dgDetails.Rows[e.RowIndex].Cells[6].Value.ToString();
                        oMBook.RENT_PRICE = dgDetails.Rows[e.RowIndex].Cells[7].Value.ToString();
                        oMBook.LOCATION = dgDetails.Rows[e.RowIndex].Cells[8].Value.ToString();
                    }
                    else if (oFilterFindOption == eVariable.FIND_OPTION.BORROWER)
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
                    }
                }
            }
            catch (Exception ex)
            {
               
            }

        }

        private void dgDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DatagridSelect(sender, e);
                Close();
            }
        }

        private void dgDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DatagridSelect(sender, e);
            }
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (oFilterFindOption == eVariable.FIND_OPTION.BOOKS)
            {
                switch (cboSearch.Text)
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
            else
            {
                switch (cboSearch.Text)
                {
                    case "BORROWER ID":
                        oFilterBorrower = ePublicVariable.eVariable.FIND_BORROWER.BORROWER_ID;
                        break;
                    case "FIRST NAME":
                        oFilterBorrower = ePublicVariable.eVariable.FIND_BORROWER.FIRST_NAME;
                        break;
                    case "MIDDLE NAME":
                        oFilterBorrower = ePublicVariable.eVariable.FIND_BORROWER.MIDDLE_NAME;
                        break;
                    case "LAST NAME":
                        oFilterBorrower = ePublicVariable.eVariable.FIND_BORROWER.LAST_NAME;
                        break;
                    default:
                        oFilterBorrower = ePublicVariable.eVariable.FIND_BORROWER.FIRST_NAME;
                        break;
                }
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void cboSearch_TextChanged(object sender, EventArgs e)
        {
            if (oFilterFindOption == eVariable.FIND_OPTION.BOOKS)
            {
                switch (cboSearch.Text)
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
            else
            {
                switch (cboSearch.Text)
                {
                    case "BORROWER ID":
                        oFilterBorrower = ePublicVariable.eVariable.FIND_BORROWER.BORROWER_ID;
                        break;
                    case "FIRST NAME":
                        oFilterBorrower = ePublicVariable.eVariable.FIND_BORROWER.FIRST_NAME;
                        break;
                    case "MIDDLE NAME":
                        oFilterBorrower = ePublicVariable.eVariable.FIND_BORROWER.MIDDLE_NAME;
                        break;
                    case "LAST NAME":
                        oFilterBorrower = ePublicVariable.eVariable.FIND_BORROWER.LAST_NAME;
                        break;
                    default:
                        oFilterBorrower = ePublicVariable.eVariable.FIND_BORROWER.FIRST_NAME;
                        break;
                }
            }
        }
    }
}
