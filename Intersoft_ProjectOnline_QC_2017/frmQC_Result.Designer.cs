namespace Intersoft_ProjectOnline_QC_2017
{
    partial class frmQC_Result
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
            this.btnClose = new System.Windows.Forms.Button();
            this.grdStatus = new System.Windows.Forms.DataGridView();
            this.lblEnviroment = new System.Windows.Forms.Label();
            this.btnOnlyErrors = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cboViewType = new System.Windows.Forms.ComboBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblViewName = new System.Windows.Forms.Label();
            this.btnSaveRecordset = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnGetTables = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatus)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1374, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdStatus
            // 
            this.grdStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdStatus.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.grdStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdStatus.GridColor = System.Drawing.Color.White;
            this.grdStatus.Location = new System.Drawing.Point(12, 89);
            this.grdStatus.Name = "grdStatus";
            this.grdStatus.Size = new System.Drawing.Size(1437, 482);
            this.grdStatus.TabIndex = 1;
            this.grdStatus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdStatus_CellContentClick);
            // 
            // lblEnviroment
            // 
            this.lblEnviroment.AutoSize = true;
            this.lblEnviroment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnviroment.ForeColor = System.Drawing.Color.White;
            this.lblEnviroment.Location = new System.Drawing.Point(8, 9);
            this.lblEnviroment.Name = "lblEnviroment";
            this.lblEnviroment.Size = new System.Drawing.Size(180, 24);
            this.lblEnviroment.TabIndex = 2;
            this.lblEnviroment.Text = "[Enviromentname]";
            this.lblEnviroment.Click += new System.EventHandler(this.lblEnviroment_Click);
            // 
            // btnOnlyErrors
            // 
            this.btnOnlyErrors.Location = new System.Drawing.Point(1358, 62);
            this.btnOnlyErrors.Name = "btnOnlyErrors";
            this.btnOnlyErrors.Size = new System.Drawing.Size(87, 21);
            this.btnOnlyErrors.TabIndex = 3;
            this.btnOnlyErrors.Text = "Errors";
            this.btnOnlyErrors.UseVisualStyleBackColor = true;
            this.btnOnlyErrors.Click += new System.EventHandler(this.btnOnlyErrors_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1260, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Run check again";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboViewType
            // 
            this.cboViewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViewType.FormattingEnabled = true;
            this.cboViewType.Location = new System.Drawing.Point(1108, 62);
            this.cboViewType.Name = "cboViewType";
            this.cboViewType.Size = new System.Drawing.Size(244, 21);
            this.cboViewType.TabIndex = 5;
            this.cboViewType.SelectedIndexChanged += new System.EventHandler(this.cboViewType_SelectedIndexChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Navy;
            this.pnlTop.Controls.Add(this.lblViewName);
            this.pnlTop.Controls.Add(this.lblEnviroment);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1457, 56);
            this.pnlTop.TabIndex = 6;
            // 
            // lblViewName
            // 
            this.lblViewName.AutoSize = true;
            this.lblViewName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewName.ForeColor = System.Drawing.Color.White;
            this.lblViewName.Location = new System.Drawing.Point(522, 9);
            this.lblViewName.Name = "lblViewName";
            this.lblViewName.Size = new System.Drawing.Size(120, 24);
            this.lblViewName.TabIndex = 3;
            this.lblViewName.Text = "[Viewname]";
            // 
            // btnSaveRecordset
            // 
            this.btnSaveRecordset.Location = new System.Drawing.Point(3, 9);
            this.btnSaveRecordset.Name = "btnSaveRecordset";
            this.btnSaveRecordset.Size = new System.Drawing.Size(114, 23);
            this.btnSaveRecordset.TabIndex = 7;
            this.btnSaveRecordset.Text = "Save recordset";
            this.btnSaveRecordset.UseVisualStyleBackColor = true;
            this.btnSaveRecordset.Click += new System.EventHandler(this.btnSaveRecordset_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnGetTables);
            this.pnlBottom.Controls.Add(this.btnSaveRecordset);
            this.pnlBottom.Controls.Add(this.button1);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 577);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1457, 35);
            this.pnlBottom.TabIndex = 8;
            // 
            // btnGetTables
            // 
            this.btnGetTables.Location = new System.Drawing.Point(132, 9);
            this.btnGetTables.Name = "btnGetTables";
            this.btnGetTables.Size = new System.Drawing.Size(114, 23);
            this.btnGetTables.TabIndex = 8;
            this.btnGetTables.Text = "Get tables";
            this.btnGetTables.UseVisualStyleBackColor = true;
            this.btnGetTables.Click += new System.EventHandler(this.btnGetTables_Click);
            // 
            // frmQC_Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 612);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.cboViewType);
            this.Controls.Add(this.btnOnlyErrors);
            this.Controls.Add(this.grdStatus);
            this.Name = "frmQC_Result";
            this.Text = "Result of Qualitycheck";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQC_Result_FormClosed);
            this.Load += new System.EventHandler(this.frmQC_Result_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdStatus)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView grdStatus;
        private System.Windows.Forms.Label lblEnviroment;
        private System.Windows.Forms.Button btnOnlyErrors;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboViewType;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnSaveRecordset;
        private System.Windows.Forms.Label lblViewName;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnGetTables;
    }
}