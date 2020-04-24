using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ePublicVariable;
namespace iLibrarySystem
{
    public partial class MAIN : Form
    {
        Form xFrm;

        XMLSerializer.Serializerset oXMLSerializerSet;
        DefaultLogin.User oDefUser;

        Forms.frmMessageBox oFrmMsgBox;  
      
        DataAccess.BackupRestoreDB oDatabase;            
        DataAccess.User oUser = new DataAccess.User();

        Model.UserConfig oMConfig = new Model.UserConfig();
        Model.User oMuser = new Model.User();

        public MAIN()
        {
            InitializeComponent();
            GetUserAccess();
        }


        public MAIN(string sUser, string sPass, string sName, string sRole)
        {
            InitializeComponent();

            eVariable.sUsername = sUser;
            eVariable.sPassword = sPass;
            eVariable.sFullName = sName;
            eVariable.sRole = sRole;
        }

        public MAIN(Model.User oData)
        {
            InitializeComponent();                   

            eVariable.sUsername = oData.USERNAME;
            eVariable.sPassword = oData.PASSWORD;
            eVariable.sRole = oData.ROLE;
            eVariable.sFullName = oData.FULLNAME;
            
            GetUserAccess();
            GetAllowedAccess();
        }

        private void GetAllowedAccess()
        {
            btnBookList.Enabled = oMConfig.BookDetail;            
            btnBookAuthor.Enabled = oMConfig.BookAuthor;
            btnBookCategory.Enabled = oMConfig.BookCategory;
            btnBookLocation.Enabled = oMConfig.BookLocation;
            btnPolicy.Enabled = oMConfig.BookPolicy;
            btnBorrowerList.Enabled = oMConfig.BorrowerDetails;
            btnBorrowBook.Enabled = oMConfig.BorrowBook;
            btnReturnBook.Enabled = oMConfig.ReturnBook;
            btnPayBook.Enabled = oMConfig.PayBook;
            btnUserAccount.Enabled = oMConfig.UserAccount;
            btnUserAccess.Enabled = oMConfig.UserAccess;
            btnUserRole.Enabled = oMConfig.UserRole;
            btnDBBackup.Enabled = oMConfig.DBBackup;
            btnImportExport.Enabled = oMConfig.ImportExport;            
            btnRBookDetails.Enabled = oMConfig.RBookList;
            btnRBorrowerDetails.Enabled = oMConfig.RBorrowerList;
            btnResetData.Enabled = oMConfig.ResetData;

            if (btnPayBook.Enabled == false || btnBorrowBook.Enabled == false || btnReturnBook.Enabled == false)
            {
                btnDashboard.Enabled = false;                
            }
        }    

        private void GetUserAccess()
        {
            oUser = new DataAccess.User();
            oMConfig = new Model.UserConfig();

            foreach (DataRow row in oUser.GetUserAccess(eVariable.sRole).Rows)
            {
                oMConfig.BookDetail = Convert.ToBoolean(row["BookDetails"]);
                oMConfig.BookEntry = Convert.ToBoolean(row["BookEntry"]);
                oMConfig.BookAuthor = Convert.ToBoolean(row["BookAuthor"]);
                oMConfig.BookCategory = Convert.ToBoolean(row["BookCategory"]);
                oMConfig.BookLocation = Convert.ToBoolean(row["BookLocation"]);
                oMConfig.BookPolicy = Convert.ToBoolean(row["BookPolicy"]);
                oMConfig.BorrowerDetails = Convert.ToBoolean(row["BorrowerDetails"]);
                oMConfig.BorrowerEntry = Convert.ToBoolean(row["BorrowerEntry"]);
                oMConfig.BorrowBook = Convert.ToBoolean(row["BorrowBook"]);
                oMConfig.ReturnBook = Convert.ToBoolean(row["ReturnBook"]);
                oMConfig.PayBook = Convert.ToBoolean(row["PayBook"]);
                oMConfig.BorrowerRequest = Convert.ToBoolean(row["BorrowerRequest"]);
                oMConfig.UserAccount = Convert.ToBoolean(row["UserAccount"]);
                oMConfig.UserAccess = Convert.ToBoolean(row["UserAccess"]);
                oMConfig.UserRole = Convert.ToBoolean(row["UserRole"]);
                oMConfig.ImportExport = Convert.ToBoolean(row["ImportExport"]);
                oMConfig.RBookList = Convert.ToBoolean(row["RBookList"]);
                oMConfig.RBorrowerList = Convert.ToBoolean(row["RBorrowerList"]);
                oMConfig.ResetData = Convert.ToBoolean(row["ResetData"]); 
            }
        }       

        void Form_Load(Form xForm)
        {
            xForm.TopLevel = false;

            foreach (Control item in pnlMain.Controls)
            {
                if (!item.Name.Contains("SubMenu"))
                {
                    pnlMain.Controls.Remove(item);
                    break; 
                }
            }

            pnlMain.Controls.Add(xForm);
            xForm.Show();                
        }   



        private void btnImportData_Click(object sender, EventArgs e)
        {
            ClearControls();
            Maintenance.frmImportExport oFrm = new Maintenance.frmImportExport();
            oFrm.ShowDialog();
        }

        void ClearControls()
        {
            foreach (Control item in pnlMain.Controls)
            {
                if (!item.Name.Contains("SubMenu"))
                {
                    
                    pnlMain.Controls.Remove(item);
                }
                else
                {
                    pnlTransactionSubMenu.Visible = false;
                    pnlBorrowerSubMenu.Visible = false;
                    pnlBookSubMenu.Visible = false;
                    pnlSecuritySubMenu.Visible = false;
                    pnlUtilitySubMenu.Visible = false;
                    pnlReportSubMenu.Visible = false;   
                    break;
                }

            }

           
        }


        public Point GetPositionInForm(Control oCtrl)
        {
            Point iP = oCtrl.Location;
            Control oParent = oCtrl.Parent;
            while (!(oParent is Form))
            {
                iP.Offset(oParent.Location.X, oParent.Location.Y);
                oParent = oParent.Parent;
            }
            return iP;
        }

        void MovePanel(Control btn, Control oPanel)
        {                
            oPanel.Top = 0;
            oPanel.Left = GetPositionInForm(btn).X;            
        }          
      
       

        private void btnUserAccount_Click(object sender, EventArgs e)
        {
            ClearControls();            
            Forms.frmUser oFrm = new Forms.frmUser();
            oFrm.ShowDialog();
        }

        public void DefaultLogin()
        { 
            oXMLSerializerSet = new XMLSerializer.Serializerset(@"D:\XML_Data.xml");
            oDefUser = oXMLSerializerSet.ReadXmlSerialize(@"D:\XML_Data.xml");            
        }    
        private void btnBackUpRestore_Click(object sender, EventArgs e)
        {
            ClearControls();
            Maintenance.frmBackupRestoreDB oFrm = new Maintenance.frmBackupRestoreDB();
            oFrm.ShowDialog();
        }


        private void btnLock_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashBoard();
        }

        void IsDBExists()
        {
            oDatabase = new DataAccess.BackupRestoreDB();
            if (!oDatabase.IsDatabaseExits())
            {
                oFrmMsgBox = new Forms.frmMessageBox(eVariable.TransactionMessage.DATABASE_DOES_NOT_EXISTS.ToString().Replace("_", " "));
                oFrmMsgBox.m_MessageType = Forms.frmMessageBox.MESSAGE_TYPE.INFO;
                oFrmMsgBox.ShowDialog();

                Maintenance.frmBackupRestoreDB oFrmDB = new Maintenance.frmBackupRestoreDB();
                oFrmDB.ShowDialog();

                return;
            }
        
        }


        private void btnManageBook_Click(object sender, EventArgs e)
        {            
            
            MovePanel(btnManageBook, pnlBookSubMenu);
            if (pnlBookSubMenu.Visible == true)
            {
                pnlBookSubMenu.Visible = false;
                LoadDashBoard();                
            }
            else
            {
                ClearControls();                
                pnlBookSubMenu.Visible = true;                
            }
        }

        

        private void btnBookList_Click(object sender, EventArgs e)
        {
            ClearControls();
            xFrm = new Forms.frmBookList();
            Form_Load(xFrm);
        }

        private void btnBorrowerList_Click(object sender, EventArgs e)
        {
            ClearControls();
            xFrm = new Forms.frmBorrowerList();
            Form_Load(xFrm);
        }



        private void btnUtility_Click(object sender, EventArgs e)
        {
            MovePanel(btnUtility, pnlUtilitySubMenu);
            if (pnlUtilitySubMenu.Visible == true)
            {
                pnlUtilitySubMenu.Visible = false;
                LoadDashBoard();
            }
            else
            {
                ClearControls();
                pnlUtilitySubMenu.Visible = true;
            }
        }

        private void btnPolicy_Click(object sender, EventArgs e)
        {
            ClearControls();
            Forms.frmPolicy oFrm = new Forms.frmPolicy();
            oFrm.ShowDialog();
        }


        private void btnAdjustBook_Click(object sender, EventArgs e)
        {
            ClearControls();
            Forms.frmAdjustItem oFrm = new Forms.frmAdjustItem();
            oFrm.ShowDialog();
        }

      

        private void btnBookCategory_Click(object sender, EventArgs e)
        {
            ClearControls();
            Forms.frmCategory oFrm = new Forms.frmCategory();
            oFrm.ShowDialog();
        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            ClearControls();
            Forms.frmBorrowBook oFrm = new Forms.frmBorrowBook();
            oFrm.ShowDialog();
        }

        private void btnManageBorrower_Click(object sender, EventArgs e)
        {
            MovePanel(btnManageBorrower, pnlBorrowerSubMenu);
            if (pnlBorrowerSubMenu.Visible == true)
            {
                pnlBorrowerSubMenu.Visible = false;
                LoadDashBoard();
            }
            else
            {
                ClearControls();
                pnlBorrowerSubMenu.Visible = true;
            }
        }

        private void MAIN_Load(object sender, EventArgs e)
        {
            if (btnDashboard.Enabled)
            {
                LoadDashBoard();
            }
            Thread T = new Thread(new ThreadStart(GetCurrentDate));
            T.Start();
        }

        void GetCurrentDate()
        {
            for (int i = 0; i <= 2000; i++)
            {
                Thread.Sleep(1000);
                this.Invoke((MethodInvoker)delegate
                {
                    lblCurrentDate.Text = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                });
                if (i == 1001)
                {
                    i = 0;
                }
            }
        }

        public void LoadDashBoard()
        {
            ClearControls();
            xFrm = new Forms.frmDashBoard();
            Form_Load(xFrm);
        }

        private void btnBookAuthor_Click(object sender, EventArgs e)
        {
            ClearControls();
            Forms.frmAuthor oFrm = new Forms.frmAuthor();
            oFrm.ShowDialog();
        }

        private void btnSecuritySettings_Click(object sender, EventArgs e)
        {
            MovePanel(btnSecuritySettings, pnlSecuritySubMenu);
            if (pnlSecuritySubMenu.Visible == true)
            {
                pnlSecuritySubMenu.Visible = false;
                LoadDashBoard();
            }
            else
            {
                ClearControls();
                pnlSecuritySubMenu.Visible = true;
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            ClearControls();
            Forms.frmReturnBook oFrm = new Forms.frmReturnBook();
            oFrm.ShowDialog();
        }

    

        private void btnPayBook_Click(object sender, EventArgs e)
        {
            ClearControls();
            Forms.frmPayBook oFrm = new Forms.frmPayBook();
            oFrm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            MovePanel(btnReports, pnlReportSubMenu);
            if (pnlReportSubMenu.Visible == true)
            {
                pnlReportSubMenu.Visible = false;
                LoadDashBoard();
            }
            else
            {
                ClearControls();
                pnlReportSubMenu.Visible = true;
            }
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            MovePanel( btnTransactions, pnlTransactionSubMenu);
            if (pnlTransactionSubMenu.Visible == true)
            {
                pnlTransactionSubMenu.Visible = false;
                LoadDashBoard();
            }
            else
            {
                ClearControls();
                pnlTransactionSubMenu.Visible = true;
            }
        }

        
        private void btnImportExport_Click(object sender, EventArgs e)
        {
            ClearControls();
            Maintenance.frmImportExport oFrm = new Maintenance.frmImportExport();
            oFrm.ShowDialog();
        }

        private void btnDBBackup_Click(object sender, EventArgs e)
        {
            ClearControls();
            Maintenance.frmBackupRestoreDB oFrm = new Maintenance.frmBackupRestoreDB();
            oFrm.ShowDialog();
        }

        private void btnBookLocation_Click(object sender, EventArgs e)
        {
            ClearControls();
            Forms.frmLocation oFrm = new Forms.frmLocation();
            oFrm.ShowDialog();
        }

        private void btnRBookList_Click(object sender, EventArgs e)
        {
            ClearControls();            
            xFrm = new Reports.frmBookReport();
            Form_Load(xFrm);
        }

        private void btnRBorrowerList_Click(object sender, EventArgs e)
        {
            ClearControls();
            xFrm = new Reports.frmBorrowerReport();
            Form_Load(xFrm);
        }

        private void btnUserRole_Click(object sender, EventArgs e)
        {
            ClearControls();
            Forms.frmRole oFrm = new Forms.frmRole();
            oFrm.ShowDialog();
        }

        private void btnUserAccess_Click(object sender, EventArgs e)
        {
            ClearControls();
            Forms.frmUserAccess oFrm = new Forms.frmUserAccess();
            oFrm.ShowDialog();
        }

        private void btnResetData_Click(object sender, EventArgs e)
        {
            ClearControls();
            Forms.frmResetData oFrm = new Forms.frmResetData();
            oFrm.ShowDialog();
        }

                   
     
    }
}
