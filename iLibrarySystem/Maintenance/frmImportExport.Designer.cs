namespace iLibrarySystem.Maintenance
{
    partial class frmImportExport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlE = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.tbControl = new System.Windows.Forms.TabControl();
            this.tbPage1 = new System.Windows.Forms.TabPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pDG1 = new System.Windows.Forms.Panel();
            this.dgImport = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboImport = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnBrowseI = new System.Windows.Forms.Button();
            this.txtImportPath = new System.Windows.Forms.TextBox();
            this.tbPage2 = new System.Windows.Forms.TabPage();
            this.pnlMain2 = new System.Windows.Forms.Panel();
            this.pDg2 = new System.Windows.Forms.Panel();
            this.dgExport = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBrowseE = new System.Windows.Forms.Button();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboExport = new System.Windows.Forms.ComboBox();
            this.rdCSV = new System.Windows.Forms.RadioButton();
            this.rdPDF = new System.Windows.Forms.RadioButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.pnlE.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.tbControl.SuspendLayout();
            this.tbPage1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pDG1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgImport)).BeginInit();
            this.panel3.SuspendLayout();
            this.tbPage2.SuspendLayout();
            this.pnlMain2.SuspendLayout();
            this.pDg2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExport)).BeginInit();
            this.panel4.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlE
            // 
            this.pnlE.Controls.Add(this.pnlBody);
            this.pnlE.Location = new System.Drawing.Point(2, 2);
            this.pnlE.Name = "pnlE";
            this.pnlE.Size = new System.Drawing.Size(618, 347);
            this.pnlE.TabIndex = 0;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.tbControl);
            this.pnlBody.Controls.Add(this.pnlBottom);
            this.pnlBody.Controls.Add(this.panel1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(618, 347);
            this.pnlBody.TabIndex = 0;
            // 
            // tbControl
            // 
            this.tbControl.Controls.Add(this.tbPage1);
            this.tbControl.Controls.Add(this.tbPage2);
            this.tbControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControl.Location = new System.Drawing.Point(0, 26);
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 0;
            this.tbControl.Size = new System.Drawing.Size(618, 285);
            this.tbControl.TabIndex = 75;
            this.tbControl.SelectedIndexChanged += new System.EventHandler(this.tbControl_SelectedIndexChanged);
            // 
            // tbPage1
            // 
            this.tbPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPage1.Controls.Add(this.pnlMain);
            this.tbPage1.Location = new System.Drawing.Point(4, 22);
            this.tbPage1.Name = "tbPage1";
            this.tbPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tbPage1.Size = new System.Drawing.Size(610, 259);
            this.tbPage1.TabIndex = 0;
            this.tbPage1.Text = "IMPORT DATA";
            this.tbPage1.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pDG1);
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(602, 251);
            this.pnlMain.TabIndex = 1;
            // 
            // pDG1
            // 
            this.pDG1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDG1.Controls.Add(this.dgImport);
            this.pDG1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDG1.Location = new System.Drawing.Point(0, 71);
            this.pDG1.Name = "pDG1";
            this.pDG1.Size = new System.Drawing.Size(602, 180);
            this.pDG1.TabIndex = 74;
            // 
            // dgImport
            // 
            this.dgImport.AllowUserToAddRows = false;
            this.dgImport.AllowUserToDeleteRows = false;
            this.dgImport.AllowUserToResizeColumns = false;
            this.dgImport.AllowUserToResizeRows = false;
            this.dgImport.BackgroundColor = System.Drawing.Color.White;
            this.dgImport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgImport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgImport.ColumnHeadersHeight = 30;
            this.dgImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgImport.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgImport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgImport.EnableHeadersVisualStyles = false;
            this.dgImport.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgImport.Location = new System.Drawing.Point(0, 0);
            this.dgImport.Name = "dgImport";
            this.dgImport.ReadOnly = true;
            this.dgImport.RowHeadersVisible = false;
            this.dgImport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgImport.Size = new System.Drawing.Size(600, 178);
            this.dgImport.TabIndex = 75;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.cboImport);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.Label1);
            this.panel3.Controls.Add(this.btnBrowseI);
            this.panel3.Controls.Add(this.txtImportPath);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(602, 71);
            this.panel3.TabIndex = 71;
            // 
            // cboImport
            // 
            this.cboImport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboImport.ForeColor = System.Drawing.Color.DimGray;
            this.cboImport.FormattingEnabled = true;
            this.cboImport.Items.AddRange(new object[] {
            "BORROWER",
            "AUTHOR",
            "CATEGORY"});
            this.cboImport.Location = new System.Drawing.Point(94, 42);
            this.cboImport.Name = "cboImport";
            this.cboImport.Size = new System.Drawing.Size(431, 22);
            this.cboImport.TabIndex = 61;
            this.cboImport.Text = "BORROWER";
            this.cboImport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboImport_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "DIRECTORY";
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.AutoSize = true;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(6, 44);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(78, 13);
            this.Label1.TabIndex = 59;
            this.Label1.Text = "TABLE NAME";
            // 
            // btnBrowseI
            // 
            this.btnBrowseI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnBrowseI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseI.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrowseI.Location = new System.Drawing.Point(528, 4);
            this.btnBrowseI.Name = "btnBrowseI";
            this.btnBrowseI.Size = new System.Drawing.Size(71, 34);
            this.btnBrowseI.TabIndex = 57;
            this.btnBrowseI.Text = "BROWSE";
            this.btnBrowseI.UseVisualStyleBackColor = false;
            this.btnBrowseI.Click += new System.EventHandler(this.btnBrowseI_Click);
            // 
            // txtImportPath
            // 
            this.txtImportPath.BackColor = System.Drawing.Color.White;
            this.txtImportPath.Enabled = false;
            this.txtImportPath.Location = new System.Drawing.Point(94, 5);
            this.txtImportPath.Multiline = true;
            this.txtImportPath.Name = "txtImportPath";
            this.txtImportPath.Size = new System.Drawing.Size(431, 33);
            this.txtImportPath.TabIndex = 56;
            // 
            // tbPage2
            // 
            this.tbPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPage2.Controls.Add(this.pnlMain2);
            this.tbPage2.Location = new System.Drawing.Point(4, 22);
            this.tbPage2.Name = "tbPage2";
            this.tbPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tbPage2.Size = new System.Drawing.Size(610, 259);
            this.tbPage2.TabIndex = 1;
            this.tbPage2.Text = "EXPORT DATA";
            this.tbPage2.UseVisualStyleBackColor = true;
            // 
            // pnlMain2
            // 
            this.pnlMain2.Controls.Add(this.pDg2);
            this.pnlMain2.Controls.Add(this.panel4);
            this.pnlMain2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain2.Location = new System.Drawing.Point(3, 3);
            this.pnlMain2.Name = "pnlMain2";
            this.pnlMain2.Size = new System.Drawing.Size(602, 251);
            this.pnlMain2.TabIndex = 1;
            // 
            // pDg2
            // 
            this.pDg2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDg2.Controls.Add(this.dgExport);
            this.pDg2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDg2.Location = new System.Drawing.Point(0, 71);
            this.pDg2.Name = "pDg2";
            this.pDg2.Size = new System.Drawing.Size(602, 180);
            this.pDg2.TabIndex = 74;
            // 
            // dgExport
            // 
            this.dgExport.AllowUserToAddRows = false;
            this.dgExport.AllowUserToDeleteRows = false;
            this.dgExport.AllowUserToResizeColumns = false;
            this.dgExport.AllowUserToResizeRows = false;
            this.dgExport.BackgroundColor = System.Drawing.Color.White;
            this.dgExport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgExport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgExport.ColumnHeadersHeight = 30;
            this.dgExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgExport.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgExport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgExport.EnableHeadersVisualStyles = false;
            this.dgExport.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgExport.Location = new System.Drawing.Point(0, 0);
            this.dgExport.Name = "dgExport";
            this.dgExport.ReadOnly = true;
            this.dgExport.RowHeadersVisible = false;
            this.dgExport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgExport.Size = new System.Drawing.Size(600, 178);
            this.dgExport.TabIndex = 73;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.btnBrowseE);
            this.panel4.Controls.Add(this.txtExportPath);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cboExport);
            this.panel4.Controls.Add(this.rdCSV);
            this.panel4.Controls.Add(this.rdPDF);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(602, 71);
            this.panel4.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "DIRECTORY";
            // 
            // btnBrowseE
            // 
            this.btnBrowseE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnBrowseE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseE.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrowseE.Location = new System.Drawing.Point(526, 38);
            this.btnBrowseE.Name = "btnBrowseE";
            this.btnBrowseE.Size = new System.Drawing.Size(71, 26);
            this.btnBrowseE.TabIndex = 64;
            this.btnBrowseE.Text = "BROWSE";
            this.btnBrowseE.UseVisualStyleBackColor = false;
            this.btnBrowseE.Click += new System.EventHandler(this.btnBrowseE_Click);
            // 
            // txtExportPath
            // 
            this.txtExportPath.BackColor = System.Drawing.Color.White;
            this.txtExportPath.Enabled = false;
            this.txtExportPath.Location = new System.Drawing.Point(91, 39);
            this.txtExportPath.Multiline = true;
            this.txtExportPath.Name = "txtExportPath";
            this.txtExportPath.Size = new System.Drawing.Size(432, 24);
            this.txtExportPath.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(375, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "FILE TYPE";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "TABLE NAME";
            // 
            // cboExport
            // 
            this.cboExport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboExport.ForeColor = System.Drawing.Color.DimGray;
            this.cboExport.FormattingEnabled = true;
            this.cboExport.Items.AddRange(new object[] {
            "BORROWER",
            "AUTHOR",
            "CATEGORY"});
            this.cboExport.Location = new System.Drawing.Point(91, 11);
            this.cboExport.Name = "cboExport";
            this.cboExport.Size = new System.Drawing.Size(224, 22);
            this.cboExport.TabIndex = 60;
            this.cboExport.Text = "BORROWER";
            this.cboExport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboExport_KeyPress);
            // 
            // rdCSV
            // 
            this.rdCSV.AutoSize = true;
            this.rdCSV.Checked = true;
            this.rdCSV.Location = new System.Drawing.Point(463, 11);
            this.rdCSV.Name = "rdCSV";
            this.rdCSV.Size = new System.Drawing.Size(50, 17);
            this.rdCSV.TabIndex = 3;
            this.rdCSV.TabStop = true;
            this.rdCSV.Text = "CSV";
            this.rdCSV.UseVisualStyleBackColor = true;
            // 
            // rdPDF
            // 
            this.rdPDF.AutoSize = true;
            this.rdPDF.Enabled = false;
            this.rdPDF.Location = new System.Drawing.Point(519, 12);
            this.rdPDF.Name = "rdPDF";
            this.rdPDF.Size = new System.Drawing.Size(47, 17);
            this.rdPDF.TabIndex = 2;
            this.rdPDF.Text = "PDF";
            this.rdPDF.UseVisualStyleBackColor = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlBottom.Controls.Add(this.btnPopulate);
            this.pnlBottom.Controls.Add(this.btnClear);
            this.pnlBottom.Controls.Add(this.btnButton);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 311);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(618, 36);
            this.pnlBottom.TabIndex = 74;
            // 
            // btnPopulate
            // 
            this.btnPopulate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPopulate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnPopulate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPopulate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPopulate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPopulate.Location = new System.Drawing.Point(3, 5);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(84, 24);
            this.btnPopulate.TabIndex = 4;
            this.btnPopulate.Text = "POPULATE";
            this.btnPopulate.UseVisualStyleBackColor = false;
            this.btnPopulate.Visible = false;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClear.Location = new System.Drawing.Point(527, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 24);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnButton
            // 
            this.btnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnButton.Location = new System.Drawing.Point(440, 6);
            this.btnButton.Name = "btnButton";
            this.btnButton.Size = new System.Drawing.Size(84, 24);
            this.btnButton.TabIndex = 2;
            this.btnButton.Text = "IMPORT";
            this.btnButton.UseVisualStyleBackColor = false;
            this.btnButton.Click += new System.EventHandler(this.btnButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.panel1.Controls.Add(this.lblClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 26);
            this.panel1.TabIndex = 71;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(556, 6);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(59, 13);
            this.lblClose.TabIndex = 10;
            this.lblClose.Text = "[CLOSE]";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // frmImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(622, 351);
            this.ControlBox = false;
            this.Controls.Add(this.pnlE);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnlE.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.tbControl.ResumeLayout(false);
            this.tbPage1.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pDG1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgImport)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tbPage2.ResumeLayout(false);
            this.pnlMain2.ResumeLayout(false);
            this.pDg2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgExport)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlE;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.TabControl tbControl;
        private System.Windows.Forms.TabPage tbPage1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pDG1;
        private System.Windows.Forms.DataGridView dgImport;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btnBrowseI;
        private System.Windows.Forms.TextBox txtImportPath;
        private System.Windows.Forms.TabPage tbPage2;
        private System.Windows.Forms.Panel pnlMain2;
        private System.Windows.Forms.Panel pDg2;
        private System.Windows.Forms.DataGridView dgExport;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboExport;
        private System.Windows.Forms.RadioButton rdCSV;
        private System.Windows.Forms.RadioButton rdPDF;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBrowseE;
        private System.Windows.Forms.TextBox txtExportPath;
        private System.Windows.Forms.ComboBox cboImport;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Button btnPopulate;




    }
}