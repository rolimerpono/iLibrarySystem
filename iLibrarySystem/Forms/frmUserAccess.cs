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
    public partial class frmUserAccess : Form
    {
        Forms.frmMessageBox oFrmMsgBox;
        DataAccess.User oUser;
        Model.UserConfig oMUserConfig;
        CommonFunction.CommonFunction oCommonFunction;
        DataAccess.Role oRole;
        Model.Role oMRole;

        public frmUserAccess()
        {
            InitializeComponent();
        }

        void LoadRecords()
        {
            dgDetails.Rows.Clear();
            oRole = new DataAccess.Role();
            foreach (DataRow row in oRole.GetRole("", "").Rows)
            {
                dgDetails.Rows.Add(row[0], row[1],row[2]);
            }        
        }

        private void frmUserRole_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void LoadAccess(string sRole)
        {
            oUser = new DataAccess.User();
            oMUserConfig = new Model.UserConfig();
            oCommonFunction = new CommonFunction.CommonFunction();           
           
            foreach (DataRow row in oUser.GetUserAccess(sRole).Rows)
            {

                oMUserConfig.BookDetail = Convert.ToBoolean(row["BookDetails"]);
                oMUserConfig.BookEntry = Convert.ToBoolean(row["BookEntry"]);
                oMUserConfig.BookAuthor = Convert.ToBoolean(row["BookAuthor"]);
                oMUserConfig.BookCategory = Convert.ToBoolean(row["BookCategory"]);
                oMUserConfig.BookLocation = Convert.ToBoolean(row["BookLocation"]);
                oMUserConfig.BookPolicy = Convert.ToBoolean(row["BookPolicy"]);
                oMUserConfig.BorrowerDetails = Convert.ToBoolean(row["BorrowerDetails"]);
                oMUserConfig.BorrowerEntry = Convert.ToBoolean(row["BorrowerEntry"]);
                oMUserConfig.BorrowBook = Convert.ToBoolean(row["BorrowBook"]);
                oMUserConfig.ReturnBook = Convert.ToBoolean(row["ReturnBook"]);
                oMUserConfig.PayBook = Convert.ToBoolean(row["PayBook"]);
                oMUserConfig.BorrowerRequest = Convert.ToBoolean(row["BorrowerRequest"]);
                oMUserConfig.UserAccount = Convert.ToBoolean(row["UserAccount"]);
                oMUserConfig.UserAccess = Convert.ToBoolean(row["UserAccess"]);
                oMUserConfig.UserRole = Convert.ToBoolean(row["UserRole"]);
                oMUserConfig.ImportExport = Convert.ToBoolean(row["ImportExport"]);
                oMUserConfig.RBookList = Convert.ToBoolean(row["RBookList"]);
                oMUserConfig.RBorrowerList = Convert.ToBoolean(row["RBorrowerList"]);                  
            
            }


            chkBookDetail.Checked = oMUserConfig.BookDetail;
            chkBookEntry.Checked = oMUserConfig.BookEntry;
            chkAuthor.Checked = oMUserConfig.BookAuthor;
            chkCategory.Checked = oMUserConfig.BookCategory;
            chkLocation.Checked = oMUserConfig.BookLocation;
            chkPolicy.Checked = oMUserConfig.BookPolicy;
            chkBorrowerDetails.Checked = oMUserConfig.BorrowerDetails;
            chkBorrowerEntry.Checked = oMUserConfig.BorrowerEntry;
            chkBorrowBook.Checked = oMUserConfig.BorrowBook;
            chkReturnBook.Checked = oMUserConfig.ReturnBook;
            chkPayBook.Checked = oMUserConfig.PayBook;
            chkBorrowerRequest.Checked = oMUserConfig.BorrowerRequest;
            chkUserAccount.Checked = oMUserConfig.UserAccount;
            chkUserAccess.Checked = oMUserConfig.UserAccess;
            chkUserRole.Checked = oMUserConfig.UserRole;
            chkImportExport.Checked = oMUserConfig.ImportExport;
            chkRBookList.Checked = oMUserConfig.RBookList;
            chkRBorrowerList.Checked = oMUserConfig.RBorrowerList;
            oMUserConfig.ROLE = oMUserConfig.ROLE;
        
        }      

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            oUser = new DataAccess.User();

            if (oMRole.ROLE != string.Empty)
            {                
                oMUserConfig.BookDetail = chkBookDetail.Checked;
                oMUserConfig.BookEntry =  chkBookEntry.Checked;
                oMUserConfig.BookAuthor = chkAuthor.Checked;
                oMUserConfig.BookCategory = chkCategory.Checked;
                oMUserConfig.BookLocation = chkLocation.Checked;
                oMUserConfig.BookPolicy = chkPolicy.Checked;
                oMUserConfig.BorrowerDetails = chkBorrowerDetails.Checked;
                oMUserConfig.BorrowerEntry = chkBorrowerEntry.Checked;
                oMUserConfig.BorrowBook = chkBorrowBook.Checked;
                oMUserConfig.ReturnBook = chkReturnBook.Checked;
                oMUserConfig.PayBook =  chkPayBook.Checked;
                oMUserConfig.BorrowerRequest = chkBorrowerRequest.Checked;
                oMUserConfig.UserAccount = chkUserAccount.Checked;
                oMUserConfig.UserAccess = chkUserAccess.Checked;
                oMUserConfig.UserRole = chkUserRole.Checked;
                oMUserConfig.ImportExport = chkImportExport.Checked;
                oMUserConfig.RBookList = chkRBookList.Checked;
                oMUserConfig.RBorrowerList = chkRBorrowerList.Checked;
                oMUserConfig.ROLE = oMRole.ROLE;

                if (!oUser.IsUserRoleExists(oMRole.ROLE))
                {
                    oUser.InsertUserAccess(oMUserConfig);
                }
                else
                {
                    oUser.UpdateUserAccess(oMUserConfig);
                }

                oFrmMsgBox = new frmMessageBox(eVariable.TransactionMessage.RECORD_HAS_BEEN_SUCESSFULLY_SAVED.ToString().Replace("_", " "));
                oFrmMsgBox.m_MessageType = frmMessageBox.MESSAGE_TYPE.INFO;
                oFrmMsgBox.ShowDialog();
                chkSelectAll.Checked = false;
            }

        }

        private void dgDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DatagridSelectedview(sender, e);
                LoadAccess(oMRole.ROLE);
            }
        }

        private void DatagridSelectedview(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0 && e.RowIndex >= 0)
            {
                oMRole = new Model.Role();
                oMRole.ID = dgDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                oMRole.ROLE = dgDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                oMRole.STATUS = dgDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void dgDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetails.Rows.Count > 0)
            {
                DatagridSelectedview(sender, e);
                LoadAccess(oMRole.ROLE);
            }
        }

        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                foreach (var o in pnlAccess.Controls.OfType<CheckBox>().ToList())
                {
                    o.Checked = true;
                }
            }
            else
            {
                foreach (var o in pnlAccess.Controls.OfType<CheckBox>().ToList())
                {
                    o.Checked = false;
                }
            }
        }
    }
}
