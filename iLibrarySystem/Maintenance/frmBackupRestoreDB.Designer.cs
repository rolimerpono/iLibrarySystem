namespace iLibrarySystem.Maintenance
{
    partial class frmBackupRestoreDB
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
            this.pnlRes = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.tbControl = new System.Windows.Forms.TabControl();
            this.tbPage1 = new System.Windows.Forms.TabPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnBrowseB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDBBackup = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdSQLDB = new System.Windows.Forms.RadioButton();
            this.rdSQL = new System.Windows.Forms.RadioButton();
            this.rdBAK = new System.Windows.Forms.RadioButton();
            this.tbPage2 = new System.Windows.Forms.TabPage();
            this.btnBrowseR = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDBRestore = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.BackgroudWorkerBK = new System.ComponentModel.BackgroundWorker();
            this.BackgroundWorkerRT = new System.ComponentModel.BackgroundWorker();
            this.pnlRes.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.tbControl.SuspendLayout();
            this.tbPage1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tbPage2.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRes
            // 
            this.pnlRes.Controls.Add(this.pnlBody);
            this.pnlRes.Location = new System.Drawing.Point(2, 2);
            this.pnlRes.Name = "pnlRes";
            this.pnlRes.Size = new System.Drawing.Size(437, 228);
            this.pnlRes.TabIndex = 0;
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
            this.pnlBody.Size = new System.Drawing.Size(437, 228);
            this.pnlBody.TabIndex = 0;
            // 
            // tbControl
            // 
            this.tbControl.Controls.Add(this.tbPage1);
            this.tbControl.Controls.Add(this.tbPage2);
            this.tbControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControl.Location = new System.Drawing.Point(0, 24);
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 0;
            this.tbControl.Size = new System.Drawing.Size(437, 168);
            this.tbControl.TabIndex = 78;
            this.tbControl.SelectedIndexChanged += new System.EventHandler(this.tbControl_SelectedIndexChanged);
            // 
            // tbPage1
            // 
            this.tbPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPage1.Controls.Add(this.pnlMain);
            this.tbPage1.Location = new System.Drawing.Point(4, 22);
            this.tbPage1.Name = "tbPage1";
            this.tbPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tbPage1.Size = new System.Drawing.Size(429, 142);
            this.tbPage1.TabIndex = 0;
            this.tbPage1.Text = "BACKUP DATABASE";
            this.tbPage1.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnBrowseB);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtDBBackup);
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(421, 134);
            this.pnlMain.TabIndex = 1;
            // 
            // btnBrowseB
            // 
            this.btnBrowseB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnBrowseB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrowseB.Location = new System.Drawing.Point(351, 92);
            this.btnBrowseB.Name = "btnBrowseB";
            this.btnBrowseB.Size = new System.Drawing.Size(69, 37);
            this.btnBrowseB.TabIndex = 74;
            this.btnBrowseB.Text = "BROWSE";
            this.btnBrowseB.UseVisualStyleBackColor = false;
            this.btnBrowseB.Click += new System.EventHandler(this.btnBrowseB_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(-2, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "DIRECTORY :";
            // 
            // txtDBBackup
            // 
            this.txtDBBackup.BackColor = System.Drawing.Color.White;
            this.txtDBBackup.Enabled = false;
            this.txtDBBackup.Location = new System.Drawing.Point(4, 93);
            this.txtDBBackup.Multiline = true;
            this.txtDBBackup.Name = "txtDBBackup";
            this.txtDBBackup.Size = new System.Drawing.Size(346, 34);
            this.txtDBBackup.TabIndex = 72;
            this.txtDBBackup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDBBackup_KeyPress);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.rdSQLDB);
            this.panel3.Controls.Add(this.rdSQL);
            this.panel3.Controls.Add(this.rdBAK);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(421, 74);
            this.panel3.TabIndex = 71;
            // 
            // rdSQLDB
            // 
            this.rdSQLDB.AutoSize = true;
            this.rdSQLDB.Enabled = false;
            this.rdSQLDB.Location = new System.Drawing.Point(6, 28);
            this.rdSQLDB.Name = "rdSQLDB";
            this.rdSQLDB.Size = new System.Drawing.Size(210, 17);
            this.rdSQLDB.TabIndex = 4;
            this.rdSQLDB.Text = "BACKUP DB AS SQL WITH DATA";
            this.rdSQLDB.UseVisualStyleBackColor = true;
            // 
            // rdSQL
            // 
            this.rdSQL.AutoSize = true;
            this.rdSQL.Enabled = false;
            this.rdSQL.Location = new System.Drawing.Point(6, 51);
            this.rdSQL.Name = "rdSQL";
            this.rdSQL.Size = new System.Drawing.Size(200, 17);
            this.rdSQL.TabIndex = 5;
            this.rdSQL.Text = "BACKUP DB AS SCHEMA ONLY";
            this.rdSQL.UseVisualStyleBackColor = true;
            // 
            // rdBAK
            // 
            this.rdBAK.AutoSize = true;
            this.rdBAK.Checked = true;
            this.rdBAK.Location = new System.Drawing.Point(6, 4);
            this.rdBAK.Name = "rdBAK";
            this.rdBAK.Size = new System.Drawing.Size(146, 17);
            this.rdBAK.TabIndex = 3;
            this.rdBAK.TabStop = true;
            this.rdBAK.Text = "BACKUP DB AS .BAK";
            this.rdBAK.UseVisualStyleBackColor = true;
            // 
            // tbPage2
            // 
            this.tbPage2.Controls.Add(this.btnBrowseR);
            this.tbPage2.Controls.Add(this.label2);
            this.tbPage2.Controls.Add(this.txtDBRestore);
            this.tbPage2.Location = new System.Drawing.Point(4, 22);
            this.tbPage2.Name = "tbPage2";
            this.tbPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tbPage2.Size = new System.Drawing.Size(429, 142);
            this.tbPage2.TabIndex = 1;
            this.tbPage2.Text = "RESTORE DATABASE";
            this.tbPage2.UseVisualStyleBackColor = true;
            // 
            // btnBrowseR
            // 
            this.btnBrowseR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnBrowseR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseR.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrowseR.Location = new System.Drawing.Point(354, 23);
            this.btnBrowseR.Name = "btnBrowseR";
            this.btnBrowseR.Size = new System.Drawing.Size(73, 40);
            this.btnBrowseR.TabIndex = 77;
            this.btnBrowseR.Text = "BROWSE";
            this.btnBrowseR.UseVisualStyleBackColor = false;
            this.btnBrowseR.Click += new System.EventHandler(this.btnBrowseR_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "DIRECTORY :";
            // 
            // txtDBRestore
            // 
            this.txtDBRestore.BackColor = System.Drawing.Color.White;
            this.txtDBRestore.Enabled = false;
            this.txtDBRestore.Location = new System.Drawing.Point(6, 23);
            this.txtDBRestore.Multiline = true;
            this.txtDBRestore.Name = "txtDBRestore";
            this.txtDBRestore.Size = new System.Drawing.Size(346, 40);
            this.txtDBRestore.TabIndex = 75;
            this.txtDBRestore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDBRestore_KeyPress);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlBottom.Controls.Add(this.btnClear);
            this.pnlBottom.Controls.Add(this.btnButton);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 192);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(437, 36);
            this.pnlBottom.TabIndex = 77;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClear.Location = new System.Drawing.Point(346, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 24);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnButton
            // 
            this.btnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnButton.Location = new System.Drawing.Point(259, 6);
            this.btnButton.Name = "btnButton";
            this.btnButton.Size = new System.Drawing.Size(84, 24);
            this.btnButton.TabIndex = 2;
            this.btnButton.Text = "BACKUP";
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
            this.panel1.Size = new System.Drawing.Size(437, 24);
            this.panel1.TabIndex = 76;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(375, 5);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(59, 13);
            this.lblClose.TabIndex = 10;
            this.lblClose.Text = "[CLOSE]";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // frmBackupRestoreDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(441, 232);
            this.ControlBox = false;
            this.Controls.Add(this.pnlRes);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBackupRestoreDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnlRes.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.tbControl.ResumeLayout(false);
            this.tbPage1.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tbPage2.ResumeLayout(false);
            this.tbPage2.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRes;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.TabControl tbControl;
        private System.Windows.Forms.TabPage tbPage1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnBrowseB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDBBackup;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdSQLDB;
        private System.Windows.Forms.RadioButton rdSQL;
        private System.Windows.Forms.RadioButton rdBAK;
        private System.Windows.Forms.TabPage tbPage2;
        private System.Windows.Forms.Button btnBrowseR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDBRestore;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnButton;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker BackgroudWorkerBK;
        private System.ComponentModel.BackgroundWorker BackgroundWorkerRT;
        private System.Windows.Forms.Label lblClose;


    }
}