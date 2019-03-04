namespace Intersoft_ProjectOnline_QC_2017
{
    partial class frmSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlDatabaseSetting = new System.Windows.Forms.Panel();
            this.grpSetFileAndMail = new System.Windows.Forms.GroupBox();
            this.btnTestMail = new System.Windows.Forms.Button();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQC_Mail = new System.Windows.Forms.TextBox();
            this.txtQC_File = new System.Windows.Forms.TextBox();
            this.grpSetProjectOnline = new System.Windows.Forms.GroupBox();
            this.txtPO_Password = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPO_Username = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPO_Site_PWA = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnValidate_Prod = new System.Windows.Forms.Button();
            this.txtQC_SITE_DBC = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstSites = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDatabaseStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQC_SITE_SEQ = new System.Windows.Forms.TextBox();
            this.txtQC_SITE_Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboEnviroments = new System.Windows.Forms.ComboBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.fldFileReport = new System.Windows.Forms.OpenFileDialog();
            this.pnlDatabaseSetting.SuspendLayout();
            this.grpSetFileAndMail.SuspendLayout();
            this.grpSetProjectOnline.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "QualityCheck file:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Database connection:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(626, 50);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlDatabaseSetting
            // 
            this.pnlDatabaseSetting.Controls.Add(this.grpSetFileAndMail);
            this.pnlDatabaseSetting.Controls.Add(this.grpSetProjectOnline);
            this.pnlDatabaseSetting.Location = new System.Drawing.Point(12, 255);
            this.pnlDatabaseSetting.Name = "pnlDatabaseSetting";
            this.pnlDatabaseSetting.Size = new System.Drawing.Size(706, 265);
            this.pnlDatabaseSetting.TabIndex = 9;
            this.pnlDatabaseSetting.Visible = false;
            // 
            // grpSetFileAndMail
            // 
            this.grpSetFileAndMail.Controls.Add(this.btnTestMail);
            this.grpSetFileAndMail.Controls.Add(this.btnChooseFile);
            this.grpSetFileAndMail.Controls.Add(this.label6);
            this.grpSetFileAndMail.Controls.Add(this.txtQC_Mail);
            this.grpSetFileAndMail.Controls.Add(this.txtQC_File);
            this.grpSetFileAndMail.Controls.Add(this.label1);
            this.grpSetFileAndMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grpSetFileAndMail.Location = new System.Drawing.Point(9, 123);
            this.grpSetFileAndMail.Name = "grpSetFileAndMail";
            this.grpSetFileAndMail.Size = new System.Drawing.Size(557, 117);
            this.grpSetFileAndMail.TabIndex = 18;
            this.grpSetFileAndMail.TabStop = false;
            this.grpSetFileAndMail.Text = "Settings file and mail:";
            // 
            // btnTestMail
            // 
            this.btnTestMail.Location = new System.Drawing.Point(519, 87);
            this.btnTestMail.Name = "btnTestMail";
            this.btnTestMail.Size = new System.Drawing.Size(26, 23);
            this.btnTestMail.TabIndex = 7;
            this.btnTestMail.Text = "...";
            this.btnTestMail.UseVisualStyleBackColor = true;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(519, 36);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(26, 23);
            this.btnChooseFile.TabIndex = 6;
            this.btnChooseFile.Text = "...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(9, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Send result mail to:";
            // 
            // txtQC_Mail
            // 
            this.txtQC_Mail.Location = new System.Drawing.Point(11, 89);
            this.txtQC_Mail.Name = "txtQC_Mail";
            this.txtQC_Mail.Size = new System.Drawing.Size(502, 20);
            this.txtQC_Mail.TabIndex = 5;
            this.txtQC_Mail.TextChanged += new System.EventHandler(this.txtQC_Mail_TextChanged);
            // 
            // txtQC_File
            // 
            this.txtQC_File.Location = new System.Drawing.Point(11, 38);
            this.txtQC_File.Name = "txtQC_File";
            this.txtQC_File.Size = new System.Drawing.Size(502, 20);
            this.txtQC_File.TabIndex = 3;
            // 
            // grpSetProjectOnline
            // 
            this.grpSetProjectOnline.Controls.Add(this.txtPO_Password);
            this.grpSetProjectOnline.Controls.Add(this.label8);
            this.grpSetProjectOnline.Controls.Add(this.txtPO_Username);
            this.grpSetProjectOnline.Controls.Add(this.label7);
            this.grpSetProjectOnline.Controls.Add(this.txtPO_Site_PWA);
            this.grpSetProjectOnline.Controls.Add(this.label9);
            this.grpSetProjectOnline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grpSetProjectOnline.Location = new System.Drawing.Point(9, 3);
            this.grpSetProjectOnline.Name = "grpSetProjectOnline";
            this.grpSetProjectOnline.Size = new System.Drawing.Size(533, 117);
            this.grpSetProjectOnline.TabIndex = 17;
            this.grpSetProjectOnline.TabStop = false;
            this.grpSetProjectOnline.Text = "Settings Project Online";
            // 
            // txtPO_Password
            // 
            this.txtPO_Password.Location = new System.Drawing.Point(70, 78);
            this.txtPO_Password.Name = "txtPO_Password";
            this.txtPO_Password.PasswordChar = '*';
            this.txtPO_Password.Size = new System.Drawing.Size(449, 20);
            this.txtPO_Password.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(8, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Username:";
            // 
            // txtPO_Username
            // 
            this.txtPO_Username.Location = new System.Drawing.Point(71, 52);
            this.txtPO_Username.Name = "txtPO_Username";
            this.txtPO_Username.Size = new System.Drawing.Size(448, 20);
            this.txtPO_Username.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(8, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Site (PWA):";
            // 
            // txtPO_Site_PWA
            // 
            this.txtPO_Site_PWA.Location = new System.Drawing.Point(71, 27);
            this.txtPO_Site_PWA.Name = "txtPO_Site_PWA";
            this.txtPO_Site_PWA.Size = new System.Drawing.Size(448, 20);
            this.txtPO_Site_PWA.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(8, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Password:";
            // 
            // btnValidate_Prod
            // 
            this.btnValidate_Prod.Location = new System.Drawing.Point(614, 19);
            this.btnValidate_Prod.Name = "btnValidate_Prod";
            this.btnValidate_Prod.Size = new System.Drawing.Size(75, 23);
            this.btnValidate_Prod.TabIndex = 5;
            this.btnValidate_Prod.Text = "&Validate";
            this.btnValidate_Prod.UseVisualStyleBackColor = true;
            this.btnValidate_Prod.Visible = false;
            this.btnValidate_Prod.Click += new System.EventHandler(this.btnValidate_Prod_Click);
            // 
            // txtQC_SITE_DBC
            // 
            this.txtQC_SITE_DBC.Location = new System.Drawing.Point(170, 94);
            this.txtQC_SITE_DBC.Name = "txtQC_SITE_DBC";
            this.txtQC_SITE_DBC.Size = new System.Drawing.Size(519, 20);
            this.txtQC_SITE_DBC.TabIndex = 4;
            this.txtQC_SITE_DBC.TextChanged += new System.EventHandler(this.txtPROD_CON_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(640, 555);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstSites);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblDatabaseStatus);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtQC_SITE_SEQ);
            this.groupBox1.Controls.Add(this.txtQC_SITE_Name);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnValidate_Prod);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtQC_SITE_DBC);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 170);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings for database:";
            // 
            // lstSites
            // 
            this.lstSites.FormattingEnabled = true;
            this.lstSites.Location = new System.Drawing.Point(3, 39);
            this.lstSites.Name = "lstSites";
            this.lstSites.Size = new System.Drawing.Size(155, 121);
            this.lstSites.TabIndex = 17;
            this.lstSites.SelectedIndexChanged += new System.EventHandler(this.lstSites_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Enviroments";
            // 
            // lblDatabaseStatus
            // 
            this.lblDatabaseStatus.AutoSize = true;
            this.lblDatabaseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseStatus.ForeColor = System.Drawing.Color.Green;
            this.lblDatabaseStatus.Location = new System.Drawing.Point(235, 129);
            this.lblDatabaseStatus.MinimumSize = new System.Drawing.Size(300, 0);
            this.lblDatabaseStatus.Name = "lblDatabaseStatus";
            this.lblDatabaseStatus.Size = new System.Drawing.Size(300, 29);
            this.lblDatabaseStatus.TabIndex = 10;
            this.lblDatabaseStatus.Text = "Database ok";
            this.lblDatabaseStatus.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Order:";
            // 
            // txtQC_SITE_SEQ
            // 
            this.txtQC_SITE_SEQ.Location = new System.Drawing.Point(170, 138);
            this.txtQC_SITE_SEQ.Name = "txtQC_SITE_SEQ";
            this.txtQC_SITE_SEQ.Size = new System.Drawing.Size(47, 20);
            this.txtQC_SITE_SEQ.TabIndex = 9;
            // 
            // txtQC_SITE_Name
            // 
            this.txtQC_SITE_Name.Location = new System.Drawing.Point(170, 55);
            this.txtQC_SITE_Name.Name = "txtQC_SITE_Name";
            this.txtQC_SITE_Name.Size = new System.Drawing.Size(519, 20);
            this.txtQC_SITE_Name.TabIndex = 7;
            this.txtQC_SITE_Name.TextChanged += new System.EventHandler(this.txtQC_SITE_Name_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name:";
            // 
            // cboEnviroments
            // 
            this.cboEnviroments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEnviroments.FormattingEnabled = true;
            this.cboEnviroments.Location = new System.Drawing.Point(12, 555);
            this.cboEnviroments.Name = "cboEnviroments";
            this.cboEnviroments.Size = new System.Drawing.Size(279, 21);
            this.cboEnviroments.TabIndex = 15;
            this.cboEnviroments.Visible = false;
            this.cboEnviroments.SelectedIndexChanged += new System.EventHandler(this.cboEnviroments_SelectedIndexChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Navy;
            this.pnlTop.Controls.Add(this.label10);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(732, 43);
            this.pnlTop.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(11, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "Site settings";
            // 
            // fldFileReport
            // 
            this.fldFileReport.DefaultExt = "*.xlsx";
            this.fldFileReport.FileName = "openFileDialog1";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 590);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlDatabaseSetting);
            this.Controls.Add(this.cboEnviroments);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.Text = "Settinger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.pnlDatabaseSetting.ResumeLayout(false);
            this.grpSetFileAndMail.ResumeLayout(false);
            this.grpSetFileAndMail.PerformLayout();
            this.grpSetProjectOnline.ResumeLayout(false);
            this.grpSetProjectOnline.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtQC_SITE_DBC;
        private System.Windows.Forms.TextBox txtQC_File;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnValidate_Prod;
        private System.Windows.Forms.Panel pnlDatabaseSetting;
        private System.Windows.Forms.TextBox txtPO_Password;
        private System.Windows.Forms.TextBox txtPO_Username;
        private System.Windows.Forms.TextBox txtPO_Site_PWA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboEnviroments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQC_SITE_Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQC_SITE_SEQ;
        private System.Windows.Forms.GroupBox grpSetFileAndMail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQC_Mail;
        private System.Windows.Forms.GroupBox grpSetProjectOnline;
        private System.Windows.Forms.Label lblDatabaseStatus;
        private System.Windows.Forms.ListBox lstSites;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnTestMail;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.OpenFileDialog fldFileReport;
    }
}