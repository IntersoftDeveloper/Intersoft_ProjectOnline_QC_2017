namespace Intersoft_ProjectOnline_QC_2017
{
    partial class frmQCReporting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQCReporting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCheckExcel = new System.Windows.Forms.Button();
            this.btnRefreshFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnQuitApplication = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.stbStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.btnFullProcess = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tmTimer = new System.Windows.Forms.Timer(this.components);
            this.lblRunningSite = new System.Windows.Forms.Label();
            this.lblRunStatus = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblRunningSince = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblWorking = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblSelectedDatabase = new System.Windows.Forms.Label();
            this.grdSiteStatus = new System.Windows.Forms.DataGridView();
            this.colSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastRunTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpExId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistory_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistoryOpExId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReportingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReportingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMTimesaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMReportRefresh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpenSettings = new System.Windows.Forms.DataGridViewButtonColumn();
            this.picRunning = new System.Windows.Forms.PictureBox();
            this.picStop = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStartTimer = new System.Windows.Forms.Button();
            this.grdRunStatus = new System.Windows.Forms.DataGridView();
            this.colSitename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRunDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRuntime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTopic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRuntimeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddStatus = new System.Windows.Forms.Button();
            this.lblRunningSiteError = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblVersionNote = new System.Windows.Forms.Label();
            this.stbStatus.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSiteStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRunning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRunStatus)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheckExcel
            // 
            this.btnCheckExcel.Location = new System.Drawing.Point(179, 364);
            this.btnCheckExcel.Name = "btnCheckExcel";
            this.btnCheckExcel.Size = new System.Drawing.Size(75, 23);
            this.btnCheckExcel.TabIndex = 0;
            this.btnCheckExcel.Text = "Check excel";
            this.btnCheckExcel.UseVisualStyleBackColor = true;
            this.btnCheckExcel.Visible = false;
            this.btnCheckExcel.Click += new System.EventHandler(this.btnCheckExcel_Click);
            // 
            // btnRefreshFile
            // 
            this.btnRefreshFile.Location = new System.Drawing.Point(98, 364);
            this.btnRefreshFile.Name = "btnRefreshFile";
            this.btnRefreshFile.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshFile.TabIndex = 1;
            this.btnRefreshFile.Text = "Read file";
            this.btnRefreshFile.UseVisualStyleBackColor = true;
            this.btnRefreshFile.Visible = false;
            this.btnRefreshFile.Click += new System.EventHandler(this.btnRefreshFile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Copy result to db";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // btnQuitApplication
            // 
            this.btnQuitApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitApplication.Location = new System.Drawing.Point(982, 14);
            this.btnQuitApplication.Name = "btnQuitApplication";
            this.btnQuitApplication.Size = new System.Drawing.Size(75, 23);
            this.btnQuitApplication.TabIndex = 39;
            this.btnQuitApplication.Text = "&Quit";
            this.btnQuitApplication.UseVisualStyleBackColor = true;
            this.btnQuitApplication.Click += new System.EventHandler(this.btnQuitApplication_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(17, 364);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 40;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // stbStatus
            // 
            this.stbStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.stbStatus.Location = new System.Drawing.Point(0, 648);
            this.stbStatus.Name = "stbStatus";
            this.stbStatus.Size = new System.Drawing.Size(1072, 22);
            this.stbStatus.TabIndex = 42;
            this.stbStatus.Text = "statusStrip1";
            this.stbStatus.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.stbStatus_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel1.Text = "Progress:";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // btnFullProcess
            // 
            this.btnFullProcess.Location = new System.Drawing.Point(364, 364);
            this.btnFullProcess.Name = "btnFullProcess";
            this.btnFullProcess.Size = new System.Drawing.Size(75, 23);
            this.btnFullProcess.TabIndex = 43;
            this.btnFullProcess.Text = "Force Run ";
            this.btnFullProcess.UseVisualStyleBackColor = true;
            this.btnFullProcess.Visible = false;
            this.btnFullProcess.Click += new System.EventHandler(this.btnFullProcess_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(70, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(407, 23);
            this.label5.TabIndex = 44;
            this.label5.Text = "Intersoft Reporting Quality Checker 2017";
            // 
            // tmTimer
            // 
            this.tmTimer.Interval = 1000;
            this.tmTimer.Tick += new System.EventHandler(this.tmTimer_Tick);
            // 
            // lblRunningSite
            // 
            this.lblRunningSite.AutoSize = true;
            this.lblRunningSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunningSite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblRunningSite.Location = new System.Drawing.Point(680, 126);
            this.lblRunningSite.Name = "lblRunningSite";
            this.lblRunningSite.Size = new System.Drawing.Size(28, 24);
            this.lblRunningSite.TabIndex = 12;
            this.lblRunningSite.Text = "...";
            this.lblRunningSite.Visible = false;
            // 
            // lblRunStatus
            // 
            this.lblRunStatus.AutoSize = true;
            this.lblRunStatus.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunStatus.ForeColor = System.Drawing.Color.Red;
            this.lblRunStatus.Location = new System.Drawing.Point(109, 66);
            this.lblRunStatus.Name = "lblRunStatus";
            this.lblRunStatus.Size = new System.Drawing.Size(172, 45);
            this.lblRunStatus.TabIndex = 49;
            this.lblRunStatus.Text = "Stopped";
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.Location = new System.Drawing.Point(394, 3);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(79, 20);
            this.lblClock.TabIndex = 50;
            this.lblClock.Text = "24:00:00";
            // 
            // lblRunningSince
            // 
            this.lblRunningSince.AutoSize = true;
            this.lblRunningSince.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunningSince.Location = new System.Drawing.Point(111, 3);
            this.lblRunningSince.Name = "lblRunningSince";
            this.lblRunningSince.Size = new System.Drawing.Size(79, 20);
            this.lblRunningSince.TabIndex = 51;
            this.lblRunningSince.Text = "24:00:00";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // lblWorking
            // 
            this.lblWorking.AutoSize = true;
            this.lblWorking.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblWorking.Location = new System.Drawing.Point(12, 131);
            this.lblWorking.MinimumSize = new System.Drawing.Size(500, 0);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Size = new System.Drawing.Size(500, 19);
            this.lblWorking.TabIndex = 52;
            this.lblWorking.Text = "Oppdaterer....";
            this.lblWorking.Visible = false;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(12, 14);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 55;
            this.btnSettings.Text = "Settings...";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.lblSelectedDatabase);
            this.panel1.Controls.Add(this.lblClock);
            this.panel1.Controls.Add(this.lblRunningSince);
            this.panel1.Location = new System.Drawing.Point(466, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 30);
            this.panel1.TabIndex = 57;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(12, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(81, 20);
            this.label19.TabIndex = 53;
            this.label19.Text = "Running:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(295, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 20);
            this.label18.TabIndex = 52;
            this.label18.Text = "Time:";
            // 
            // lblSelectedDatabase
            // 
            this.lblSelectedDatabase.AutoSize = true;
            this.lblSelectedDatabase.Location = new System.Drawing.Point(544, 7);
            this.lblSelectedDatabase.Name = "lblSelectedDatabase";
            this.lblSelectedDatabase.Size = new System.Drawing.Size(16, 13);
            this.lblSelectedDatabase.TabIndex = 59;
            this.lblSelectedDatabase.Text = "...";
            // 
            // grdSiteStatus
            // 
            this.grdSiteStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSiteStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSiteStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSite,
            this.colStatus,
            this.colStatusMessage,
            this.colLastRunTime,
            this.colOpExId,
            this.colHistory_Date,
            this.colHistoryOpExId,
            this.colReportingDate,
            this.colReportingId,
            this.colStatusDB,
            this.colStatusPO,
            this.colStatusFile,
            this.colMHistory,
            this.colMTimesaldo,
            this.colMReportRefresh,
            this.colOpenSettings});
            this.grdSiteStatus.Location = new System.Drawing.Point(16, 163);
            this.grdSiteStatus.Name = "grdSiteStatus";
            this.grdSiteStatus.Size = new System.Drawing.Size(1041, 185);
            this.grdSiteStatus.TabIndex = 58;
            this.grdSiteStatus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSiteStatus_CellContentClick);
            this.grdSiteStatus.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdSiteStatus_EditingControlShowing);
            // 
            // colSite
            // 
            this.colSite.Frozen = true;
            this.colSite.HeaderText = "Site";
            this.colSite.Name = "colSite";
            this.colSite.Width = 120;
            // 
            // colStatus
            // 
            this.colStatus.Frozen = true;
            this.colStatus.HeaderText = "Nbr";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 40;
            // 
            // colStatusMessage
            // 
            this.colStatusMessage.Frozen = true;
            this.colStatusMessage.HeaderText = "Status";
            this.colStatusMessage.Name = "colStatusMessage";
            this.colStatusMessage.Width = 150;
            // 
            // colLastRunTime
            // 
            this.colLastRunTime.Frozen = true;
            this.colLastRunTime.HeaderText = "Dowl. date";
            this.colLastRunTime.Name = "colLastRunTime";
            this.colLastRunTime.Width = 70;
            // 
            // colOpExId
            // 
            this.colOpExId.Frozen = true;
            this.colOpExId.HeaderText = "Dowl. Id";
            this.colOpExId.Name = "colOpExId";
            this.colOpExId.Width = 50;
            // 
            // colHistory_Date
            // 
            this.colHistory_Date.Frozen = true;
            this.colHistory_Date.HeaderText = "Hist. date";
            this.colHistory_Date.Name = "colHistory_Date";
            this.colHistory_Date.Width = 70;
            // 
            // colHistoryOpExId
            // 
            this.colHistoryOpExId.Frozen = true;
            this.colHistoryOpExId.HeaderText = "Hist. Id";
            this.colHistoryOpExId.Name = "colHistoryOpExId";
            this.colHistoryOpExId.Width = 50;
            // 
            // colReportingDate
            // 
            this.colReportingDate.Frozen = true;
            this.colReportingDate.HeaderText = "Rep. date";
            this.colReportingDate.Name = "colReportingDate";
            this.colReportingDate.Width = 70;
            // 
            // colReportingId
            // 
            this.colReportingId.Frozen = true;
            this.colReportingId.HeaderText = "Rep. Id";
            this.colReportingId.Name = "colReportingId";
            this.colReportingId.Width = 50;
            // 
            // colStatusDB
            // 
            this.colStatusDB.Frozen = true;
            this.colStatusDB.HeaderText = "DB Status";
            this.colStatusDB.Name = "colStatusDB";
            this.colStatusDB.ToolTipText = "Database status";
            this.colStatusDB.Visible = false;
            this.colStatusDB.Width = 50;
            // 
            // colStatusPO
            // 
            this.colStatusPO.Frozen = true;
            this.colStatusPO.HeaderText = "PO Status";
            this.colStatusPO.Name = "colStatusPO";
            this.colStatusPO.ToolTipText = "Project Online status";
            this.colStatusPO.Visible = false;
            this.colStatusPO.Width = 50;
            // 
            // colStatusFile
            // 
            this.colStatusFile.Frozen = true;
            this.colStatusFile.HeaderText = "File status";
            this.colStatusFile.Name = "colStatusFile";
            this.colStatusFile.Visible = false;
            this.colStatusFile.Width = 50;
            // 
            // colMHistory
            // 
            this.colMHistory.Frozen = true;
            this.colMHistory.HeaderText = "M history";
            this.colMHistory.Name = "colMHistory";
            this.colMHistory.Visible = false;
            this.colMHistory.Width = 50;
            // 
            // colMTimesaldo
            // 
            this.colMTimesaldo.Frozen = true;
            this.colMTimesaldo.HeaderText = "M timesaldo";
            this.colMTimesaldo.Name = "colMTimesaldo";
            this.colMTimesaldo.Visible = false;
            this.colMTimesaldo.Width = 50;
            // 
            // colMReportRefresh
            // 
            this.colMReportRefresh.Frozen = true;
            this.colMReportRefresh.HeaderText = "M report refresh";
            this.colMReportRefresh.Name = "colMReportRefresh";
            this.colMReportRefresh.Visible = false;
            this.colMReportRefresh.Width = 50;
            // 
            // colOpenSettings
            // 
            this.colOpenSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colOpenSettings.Frozen = true;
            this.colOpenSettings.HeaderText = "";
            this.colOpenSettings.Name = "colOpenSettings";
            this.colOpenSettings.ToolTipText = "Check settings";
            this.colOpenSettings.Width = 20;
            // 
            // picRunning
            // 
            this.picRunning.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picRunning.ErrorImage")));
            this.picRunning.Image = ((System.Drawing.Image)(resources.GetObject("picRunning.Image")));
            this.picRunning.InitialImage = ((System.Drawing.Image)(resources.GetObject("picRunning.InitialImage")));
            this.picRunning.Location = new System.Drawing.Point(12, 56);
            this.picRunning.Name = "picRunning";
            this.picRunning.Size = new System.Drawing.Size(91, 66);
            this.picRunning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRunning.TabIndex = 48;
            this.picRunning.TabStop = false;
            this.picRunning.Visible = false;
            // 
            // picStop
            // 
            this.picStop.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picStop.ErrorImage")));
            this.picStop.Image = ((System.Drawing.Image)(resources.GetObject("picStop.Image")));
            this.picStop.InitialImage = ((System.Drawing.Image)(resources.GetObject("picStop.InitialImage")));
            this.picStop.Location = new System.Drawing.Point(12, 56);
            this.picStop.Name = "picStop";
            this.picStop.Size = new System.Drawing.Size(91, 66);
            this.picStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStop.TabIndex = 47;
            this.picStop.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Intersoft_ProjectOnline_QC_2017.Properties.Resources.IntersoftDataQualityChecker;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 41);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // btnStartTimer
            // 
            this.btnStartTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnStartTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTimer.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnStartTimer.Location = new System.Drawing.Point(304, 78);
            this.btnStartTimer.Name = "btnStartTimer";
            this.btnStartTimer.Size = new System.Drawing.Size(65, 23);
            this.btnStartTimer.TabIndex = 60;
            this.btnStartTimer.Text = "Start";
            this.btnStartTimer.UseVisualStyleBackColor = false;
            this.btnStartTimer.Visible = false;
            this.btnStartTimer.Click += new System.EventHandler(this.btnStartTimer_Click);
            // 
            // grdRunStatus
            // 
            this.grdRunStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRunStatus.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.grdRunStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRunStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSitename,
            this.colRunDate,
            this.colRuntime,
            this.colTopic,
            this.colAction,
            this.colRuntimeStatus});
            this.grdRunStatus.GridColor = System.Drawing.Color.White;
            this.grdRunStatus.Location = new System.Drawing.Point(17, 393);
            this.grdRunStatus.Name = "grdRunStatus";
            this.grdRunStatus.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRunStatus.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdRunStatus.Size = new System.Drawing.Size(1040, 179);
            this.grdRunStatus.TabIndex = 61;
            // 
            // colSitename
            // 
            this.colSitename.HeaderText = "Sitename";
            this.colSitename.Name = "colSitename";
            // 
            // colRunDate
            // 
            this.colRunDate.HeaderText = "Date";
            this.colRunDate.Name = "colRunDate";
            // 
            // colRuntime
            // 
            this.colRuntime.HeaderText = "Time";
            this.colRuntime.Name = "colRuntime";
            // 
            // colTopic
            // 
            this.colTopic.HeaderText = "Topic";
            this.colTopic.Name = "colTopic";
            // 
            // colAction
            // 
            this.colAction.HeaderText = "Action";
            this.colAction.Name = "colAction";
            // 
            // colRuntimeStatus
            // 
            this.colRuntimeStatus.HeaderText = "Status";
            this.colRuntimeStatus.Name = "colRuntimeStatus";
            // 
            // btnAddStatus
            // 
            this.btnAddStatus.Location = new System.Drawing.Point(98, 14);
            this.btnAddStatus.Name = "btnAddStatus";
            this.btnAddStatus.Size = new System.Drawing.Size(75, 23);
            this.btnAddStatus.TabIndex = 62;
            this.btnAddStatus.Text = "Add status";
            this.btnAddStatus.UseVisualStyleBackColor = true;
            this.btnAddStatus.Visible = false;
            this.btnAddStatus.Click += new System.EventHandler(this.btnAddStatus_Click);
            // 
            // lblRunningSiteError
            // 
            this.lblRunningSiteError.AutoSize = true;
            this.lblRunningSiteError.BackColor = System.Drawing.Color.Red;
            this.lblRunningSiteError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunningSiteError.Location = new System.Drawing.Point(179, 19);
            this.lblRunningSiteError.MinimumSize = new System.Drawing.Size(300, 0);
            this.lblRunningSiteError.Name = "lblRunningSiteError";
            this.lblRunningSiteError.Size = new System.Drawing.Size(300, 18);
            this.lblRunningSiteError.TabIndex = 63;
            this.lblRunningSiteError.Text = "...";
            this.lblRunningSiteError.Visible = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnQuitApplication);
            this.pnlBottom.Controls.Add(this.lblRunningSiteError);
            this.pnlBottom.Controls.Add(this.btnSettings);
            this.pnlBottom.Controls.Add(this.btnAddStatus);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 593);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1072, 55);
            this.pnlBottom.TabIndex = 64;
            // 
            // lblVersionNote
            // 
            this.lblVersionNote.AutoSize = true;
            this.lblVersionNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblVersionNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVersionNote.Location = new System.Drawing.Point(71, 32);
            this.lblVersionNote.Name = "lblVersionNote";
            this.lblVersionNote.Size = new System.Drawing.Size(85, 15);
            this.lblVersionNote.TabIndex = 65;
            this.lblVersionNote.Text = "No Excel - 2019";
            // 
            // frmQCReporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 670);
            this.Controls.Add(this.lblVersionNote);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.grdRunStatus);
            this.Controls.Add(this.btnStartTimer);
            this.Controls.Add(this.lblRunningSite);
            this.Controls.Add(this.grdSiteStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblWorking);
            this.Controls.Add(this.lblRunStatus);
            this.Controls.Add(this.picRunning);
            this.Controls.Add(this.picStop);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFullProcess);
            this.Controls.Add(this.stbStatus);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRefreshFile);
            this.Controls.Add(this.btnCheckExcel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQCReporting";
            this.Text = "Intersoft QualityChecker2017";
            this.Load += new System.EventHandler(this.frmQCReporting_Load);
            this.Shown += new System.EventHandler(this.frmQCReporting_Shown);
            this.stbStatus.ResumeLayout(false);
            this.stbStatus.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSiteStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRunning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRunStatus)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheckExcel;
        private System.Windows.Forms.Button btnRefreshFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnQuitApplication;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.StatusStrip stbStatus;
        private System.Windows.Forms.Button btnFullProcess;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Timer tmTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picRunning;
        private System.Windows.Forms.PictureBox picStop;
        private System.Windows.Forms.Label lblRunStatus;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblRunningSince;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label lblWorking;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView grdSiteStatus;
        private System.Windows.Forms.Label lblRunningSite;
        private System.Windows.Forms.Label lblSelectedDatabase;
        private System.Windows.Forms.Button btnStartTimer;
        private System.Windows.Forms.DataGridView grdRunStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSitename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRunDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuntime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTopic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuntimeStatus;
        private System.Windows.Forms.Button btnAddStatus;
        private System.Windows.Forms.Label lblRunningSiteError;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastRunTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpExId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistory_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistoryOpExId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMTimesaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMReportRefresh;
        private System.Windows.Forms.DataGridViewButtonColumn colOpenSettings;
        private System.Windows.Forms.Label lblVersionNote;
    }
}

