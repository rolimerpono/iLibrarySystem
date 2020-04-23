using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using ePublicVariable;

namespace iLibrarySystem.Forms
{
    public partial class frmBorrowerEntry : Form
    {

        public DataAccess.Borrower oBorrower = new DataAccess.Borrower();
        public Model.Borrower oMBorrower = new Model.Borrower();

        

        OpenFileDialog oDiagLog;

        CommonFunction.CommonFunction oCommonFunction;
        CommonFunction.CommonFunction oImageFunction;            

        #region Forms
        frmBorrowerList oFrmBorrowerLst;
        CustomWindow.frmInfoMsgBox oFrmMsg;
        #endregion

        public frmBorrowerEntry()
        {
            InitializeComponent();           
        }

        public frmBorrowerEntry(Forms.frmBorrowerList oFrmList)
        {
            InitializeComponent();
            oFrmBorrowerLst = oFrmList;
            eVariable.m_ActionType = eVariable.ACTION_TYPE.ADD;
            eVariable.DisableKeyPress(txtBorrowerID);
            eVariable.DisableKeyPress(txtAge);
            eVariable.DisableTextEnterKey(pnlMain);
            eVariable.ValidNumber(txtContactNo);
        }

        public frmBorrowerEntry(frmBorrowerList oFrmList, Model.Borrower oData)
        {
            InitializeComponent();
            eVariable.m_ActionType = eVariable.ACTION_TYPE.EDIT;
            oMBorrower = oData;
            oFrmBorrowerLst = oFrmList;
            eVariable.DisableKeyPress(txtBorrowerID);
            eVariable.DisableKeyPress(txtAge);
            eVariable.DisableTextEnterKey(pnlMain);
            eVariable.ValidNumber(txtContactNo);      

        }



        private void GenerateBorrowerNo()
        {
            int iBorrowerNo = 0;
            oBorrower = new DataAccess.Borrower();
            iBorrowerNo = oBorrower.GetBorrowerNo() + 1;

            if (eVariable.m_ActionType == eVariable.ACTION_TYPE.ADD)
            {
                txtBorrowerID.Text = "BWR-" + (iBorrowerNo).ToString("0000#");
            }
        }

        void LoadRecords()
        {
            if (eVariable.m_ActionType == eVariable.ACTION_TYPE.EDIT)
            {
                txtBorrowerID.Enabled = false;
                txtBorrowerID.Text = oMBorrower.PERSON_ID;
                txtFname.Text = oMBorrower.FIRST_NAME;
                txtMname.Text = oMBorrower.MIDDLE_NAME;
                txtLname.Text = oMBorrower.LAST_NAME;
                dtDOB.Value = Convert.ToDateTime(oMBorrower.DOB);
                txtAge.Text = oMBorrower.AGE;
                txtContactNo.Text = oMBorrower.CONTACT_NO;
                txtAddress.Text = oMBorrower.ADDRESS;

                oCommonFunction = new CommonFunction.CommonFunction();
                oImageFunction = new CommonFunction.CommonFunction();

                if (oMBorrower.PROFILE_PIC != string.Empty)
                {
                    pImage.Image = oCommonFunction.BaseStringToImage(oImageFunction.DecompressString(oMBorrower.PROFILE_PIC));
                }
            }
            else
            {                
                txtBorrowerID.Focus();
            }
        }

   


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        
        }

        private void dtDOB_ValueChanged(object sender, EventArgs e)
        {
            txtAge.Text = eVariable.GetAge(dtDOB.Value.Date,DateTime.Now.Date).ToString();
        }       

        private void btnSave_Click(object sender, EventArgs e)
        {
            oMBorrower = new Model.Borrower();
            oBorrower = new DataAccess.Borrower();
            oCommonFunction = new CommonFunction.CommonFunction();
            
            oMBorrower.PERSON_ID = txtBorrowerID.Text;
            oMBorrower.FIRST_NAME = txtFname.Text;
            oMBorrower.MIDDLE_NAME = txtMname.Text;
            oMBorrower.LAST_NAME = txtLname.Text;
            oMBorrower.DOB = dtDOB.Value.ToString("yyyy-MM-dd");
            oMBorrower.AGE = txtAge.Text;
            oMBorrower.CONTACT_NO = txtContactNo.Text;
            oMBorrower.ADDRESS = txtAddress.Text;

            if (pImage.Image != null)
            {
                oMBorrower.PROFILE_PIC = oCommonFunction.CompressString(oCommonFunction.ImageToBaseString(pImage.Image, ImageFormat.Png));
            }

            if (eVariable.m_ActionType == eVariable.ACTION_TYPE.EDIT)
            {
                oMBorrower.MODIFIED_BY = eVariable.sUsername;
                oMBorrower.MODIFIED_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                oBorrower.UpdateBorrower(oMBorrower);                
            }
            else
            {
                oMBorrower.ADDED_BY = eVariable.sUsername;
                oMBorrower.ADDED_DATE = DateTime.Now.ToString("yyyy-MM-dd");
                oBorrower.InsertBorrower(oMBorrower);
            }

            oFrmMsg = new CustomWindow.frmInfoMsgBox(eVariable.TransactionMessage.RECORD_HAS_BEEN_SUCESSFULLY_SAVED.ToString().Replace("_", " "));            
            oFrmMsg.ShowDialog();
            oFrmBorrowerLst.LoadBorrower();
            eVariable.ClearText(pnlMain);
            ResetFields();            

        }

        private void ResetFields()
        {
            dtDOB.Value = DateTime.Now;
            txtBorrowerID.Focus();
            pImage.Image = null;
            eVariable.m_ActionType = eVariable.ACTION_TYPE.ADD;
            GenerateBorrowerNo();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblUpload_Click(object sender, EventArgs e)
        {
            oDiagLog = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Image Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".jpg",
                Filter = "Image Files (*.png)|*.png",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (oDiagLog.ShowDialog() == DialogResult.OK)
            {
                pImage.Image = Image.FromFile(oDiagLog.FileName);
            } 
        }      

        private void frmBorrowerEntry_Load(object sender, EventArgs e)
        {
            LoadRecords();
            GenerateBorrowerNo();
        }

    }
}
