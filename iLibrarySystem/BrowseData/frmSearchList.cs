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
    public partial class frmSearchList : Form
    {

        DataAccess.Author oAuthor = new DataAccess.Author();
        DataAccess.Category oCategory = new DataAccess.Category();
        DataAccess.Location oLocation = new DataAccess.Location();

        public Model.Author oMAuthor = new Model.Author();
        public Model.Category oMCategory = new Model.Category();
        public Model.Location oMLocation = new Model.Location();

        public enum FIND_OPTION : int
        { 
            AUTHOR  = 0,
            CATEGORY = 1,
            LOCATION = 2
        }

        public FIND_OPTION oFindOption { get; set; }

        public frmSearchList()
        {
            InitializeComponent();
            eVariable.DisableKeyPress(cboSearch);
            eVariable.DisableTextPanelEnterKey(panel3);
        }

        private void frmSearchList_Load(object sender, EventArgs e)
        {
            SearchByDetails();
            LoadRecords();
        }

        private void LoadRecords()
        {
            dgDetails.Rows.Clear();            
            eVariable.DisableGridColumnSort(dgDetails);
            if (oFindOption == FIND_OPTION.AUTHOR)
            {
                AuthorStructure();
                oAuthor = new DataAccess.Author();
                foreach(DataRow row in oAuthor.GetAuthor(cboSearch.Text,txtSearch.Text).Rows)
                {
                    dgDetails.Rows.Add(row[0].ToString(),row[1].ToString(),row[2].ToString(),row[3].ToString(),row[4].ToString());
                }
            }
            else if (oFindOption == FIND_OPTION.CATEGORY)
            {
                CategoryStructure();
                oCategory = new DataAccess.Category();
                foreach (DataRow row in oCategory.GetCategory(cboSearch.Text, txtSearch.Text).Rows)
                {
                    dgDetails.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }
            else if (oFindOption == FIND_OPTION.LOCATION)
            {
                LocationStructure();
                oLocation = new DataAccess.Location();
                foreach (DataRow row in oLocation.GetLocationRecord(cboSearch.Text,txtSearch.Text).Rows)
                {
                    dgDetails.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }   
        }        

        void AuthorStructure()
        {

            dgDetails.Columns.Clear();
            dgDetails.ColumnHeadersHeight = 25;
            dgDetails.Columns.Add("", "ID");
            dgDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns[0].Visible = false;
            dgDetails.Columns.Add("", "FIRST NAME");
            dgDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgDetails.Columns.Add("", "MIDDLE NAME");
            dgDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "LAST NAME");
            dgDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns.Add("", "STATUS");
            dgDetails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        void CategoryStructure()
        {

            dgDetails.Columns.Clear();
            dgDetails.ColumnHeadersHeight = 25;
            dgDetails.Columns.Add("", "ID");
            dgDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns[0].Visible = false;
            dgDetails.Columns.Add("", "CATEGORY");
            dgDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgDetails.Columns.Add("", "STATUS");
            dgDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;   
        }

        void LocationStructure()
        {
            dgDetails.Columns.Clear();
            dgDetails.ColumnHeadersHeight = 25;
            dgDetails.Columns.Add("", "ID");
            dgDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDetails.Columns[0].Visible = false;
            dgDetails.Columns.Add("", "LOCATION");
            dgDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgDetails.Columns.Add("", "STATUS");
            dgDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        void SearchByDetails()
        {
            if (oFindOption == FIND_OPTION.AUTHOR)
            {
                cboSearch.Items.Clear();
                cboSearch.Text = "FIRST NAME";
                cboSearch.Items.Add("FIRST NAME");
                cboSearch.Items.Add("MIDDLE NAME");
                cboSearch.Items.Add("LAST NAME");                
            }
            else if (oFindOption == FIND_OPTION.CATEGORY)
            {
                cboSearch.Items.Clear();
                cboSearch.Text = "CATEGORY";
                cboSearch.Items.Add("CATEGORY");           
            }
            else if (oFindOption == FIND_OPTION.LOCATION)
            {
                cboSearch.Items.Clear();
                cboSearch.Text = "LOCATION";
                cboSearch.Items.Add("LOCATION");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DatagridSelectedData(sender,e);
                Close();
            }
        }

        void DatagridSelectedData(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgDetails.Rows.Count > 0)
                {
                    if (oFindOption == FIND_OPTION.AUTHOR)
                    {
                        oMAuthor = new Model.Author();
                        oMAuthor.PERSON_ID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMAuthor.FIRST_NAME = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                        oMAuthor.MIDDLE_NAME = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                        oMAuthor.LAST_NAME = dgDetails.Rows[e.RowIndex].Cells[3].Value.ToString();
                        oMAuthor.STATUS = dgDetails.Rows[e.RowIndex].Cells[4].Value.ToString();                       
                    }
                    else if (oFindOption == FIND_OPTION.CATEGORY)
                    {
                        oMCategory = new Model.Category();
                        oMCategory.CATEGORY_ID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMCategory.CATEGORY = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                        oMCategory.STATUS = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }
                    else if (oFindOption == FIND_OPTION.LOCATION)
                    {
                        oMLocation = new Model.Location();
                        oMLocation.LOCATION_ID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                        oMLocation.LOCATION = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                        oMLocation.STATUS = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void dgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DatagridSelectedData(sender, e);
            }
        }

        private void dgDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DatagridSelectedData(sender, e);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
          
           
        }
    }
}
