using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Intersoft_ProjectOnline_QC_2017
{
    public partial class frmQCReporting : Form
    {
        DateTime AppStartTime = new DateTime();
        bool isRunning = false;
        HelperLog imsLOG = new HelperLog();
        MainQualityChecker mainQC = new MainQualityChecker();
        string runningSite = "";

        private bool grdClear()
        {
            bool bStatus = false;
            try
            {

                grdRunStatus.Rows.Clear();

                grdRunStatus.Columns[0].Width = 150;
                grdRunStatus.Columns[1].Width = 80;
                grdRunStatus.Columns[2].Width = 40;
                grdRunStatus.Columns[3].Width = 250;
                grdRunStatus.Columns[4].Width = 400;
                grdRunStatus.Columns[5].Width = 10;

                

                bStatus = true;
            }
            catch(Exception ex)
            {
                lblRunningSiteError.Text = ex.Message;
                lblRunningSiteError.Visible = true;
            }

            return bStatus;
        }
        private bool grdEdit(bool edit)
        {
            try
            {
                grdRunStatus.AllowUserToAddRows = edit;
                grdRunStatus.AllowUserToDeleteRows = edit;
                grdRunStatus.AllowUserToOrderColumns = edit;
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool grdRunStatus_StartStopp(bool start)
        {
            bool bStatus = false;
            DateTime Time = DateTime.Now;
            //DateTime sinceTime = Time.Ticks - AppStartTime.Ticks; 

            int minutes = Time.Minute;
            int hours = Time.Hour;
            int second = Time.Second;
            string sAction = "";

            if (start)
            {
               
                sAction = "---------- START UPDATE SITE -----------";
            }
            else
            { sAction = "---------- FINISH WITH UPDATE SITE -----------"; }

            try
            {
                grdEdit(true);

                DataGridViewRow rowA = (DataGridViewRow)grdRunStatus.Rows[0].Clone();
                

                rowA.Cells[0].Value = runningSite;
                rowA.Cells[1].Value = Time.ToShortDateString();
                rowA.Cells[2].Value = Time.ToShortTimeString();

                rowA.Cells[3].Value = sAction;
                rowA.Cells[4].Value = "";
                //rowA.Cells[2].Style = stylebold;
                rowA.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9F, FontStyle.Bold);
                rowA.DefaultCellStyle.BackColor = Color.Navy;
                rowA.DefaultCellStyle.ForeColor = Color.White;

                if (start)
                {
                    grdRunStatus.Rows.Add();
                }

                grdRunStatus.Rows.Add(rowA);

                if (!start)
                {
                    grdRunStatus.Rows.Add();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                grdEdit(false);
            }

            return bStatus;
        }

        public bool grdRunStatus_Add(string sTopic, string sAction)
        {
            bool bStatus = false;
            DateTime Time = DateTime.Now;
            //DateTime sinceTime = Time.Ticks - AppStartTime.Ticks; 

            int minutes = Time.Minute;
            int hours = Time.Hour;
            int second = Time.Second;

            try
            {
                grdEdit(true);

                DataGridViewRow rowA = (DataGridViewRow)grdRunStatus.Rows[0].Clone();
                rowA.Cells[0].Value = runningSite;
                rowA.Cells[1].Value = Time.ToShortDateString();
                rowA.Cells[2].Value = "KL:" + Time.ToShortTimeString();
                rowA.Cells[3].Value = sTopic;
                rowA.Cells[4].Value = sAction;
                //rowA.Cells[2].Style = stylebold;
                rowA.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 7F, FontStyle.Regular);
                rowA.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                rowA.DefaultCellStyle.ForeColor = Color.Black;

                grdRunStatus.Rows.Add(rowA);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                grdEdit(false);
            }

            return bStatus;
        }
        public bool grdRunStatus_Error(string sSource, string sError)
        {
            bool bStatus = false;
            DateTime Time = DateTime.Now;
            //DateTime sinceTime = Time.Ticks - AppStartTime.Ticks; 

            int minutes = Time.Minute;
            int hours = Time.Hour;
            int second = Time.Second;

            try
            {
                grdEdit(true);

                DataGridViewRow rowA = (DataGridViewRow)grdRunStatus.Rows[0].Clone();
                rowA.Cells[0].Value = runningSite;
                rowA.Cells[1].Value = Time.ToShortDateString();
                rowA.Cells[2].Value = "KL:" + Time.ToShortTimeString();
                rowA.Cells[3].Value = sSource;
                rowA.Cells[4].Value = sError;
                //rowA.Cells[2].Style = stylebold;
                rowA.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 7F, FontStyle.Bold);
                rowA.DefaultCellStyle.BackColor = Color.OrangeRed;
                rowA.DefaultCellStyle.ForeColor = Color.Black;

                grdRunStatus.Rows.Add(rowA);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                grdEdit(false);
            }

            return bStatus;
        }
        /// <summary>
        /// Turn timer on or off
        /// </summary>
        /// <param name="onoff"></param>
        public void Timer (bool onoff)
        {
            // Check if we have connecting to database

            foreach (var t in mainQC.oCurrent.Settings.Sites)
            {
                // add a new row to the cell
                if (t.Value.Status_Database.Status)
                {
                    tmTimer.Enabled = onoff;

                    if (onoff)
                    {
                        lblRunStatus.Text = "Running";
                        lblRunStatus.ForeColor = Color.DarkGreen;
                        btnStartTimer.Visible = false;
                    }
                    else
                    {
                        lblRunStatus.Text = "Stopped";
                        lblRunStatus.ForeColor = Color.DarkRed;
                        btnStartTimer.Visible = true;
                    }
                }
            }
        }

        private string Status_Text(int iStatus, int iGridNr )
        {
            string tmpStatus = "";

            switch(iStatus)
            {
                case 2:
                    tmpStatus = "Venter...";

                    grdSiteStatus.Rows[iGridNr].Cells[2].Style.BackColor = Color.White;
                    break;
                case 5000:
                    tmpStatus = "Oppdaterer...";
                    grdSiteStatus.Rows[iGridNr].Cells[2].Style.BackColor = Color.Green;
                    break;
                case 5500:
                    tmpStatus = "Ferdig...";
                    grdSiteStatus.Rows[iGridNr].Cells[2].Style.BackColor = Color.DarkGreen;
                    break;
            }

            grdSiteStatus.Rows[iGridNr].Cells[1].Value = iStatus;
            grdSiteStatus.Rows[iGridNr].Cells[2].Value = tmpStatus;

            return tmpStatus;
        }
        private bool Sites_addGrid()
        {
            bool bStatus = false;
            grdSiteStatus.AllowUserToAddRows = true;
            try
            {
                int i =0;
                foreach (var t in mainQC.oCurrent.Settings.Sites)
                {
                    // add a new row to the cell

                    DataGridViewRow row = (DataGridViewRow)grdSiteStatus.Rows[0].Clone();
                    row.Cells[0].Value = t.Value.QC_SITE;//t.Value.POSite.Enviromentname;
                    if (!t.Value.Status_Database.Status)
                    {
                        row.Cells[1].Value = "-100";
                        row.Cells[2].Value = "Database not connected";
                        row.Cells[2].Style.BackColor = Color.Red;
                    }
                    
                    grdSiteStatus.Rows.Add(row);
                    t.Value.GridNbr = i;
                    i++;
                }

                bStatus = true;
            }
            catch(Exception ex)
            {
                // TODO: Add error handler
                grdRunStatus_Error("Error:" + ex.Message, ex.StackTrace);
            }

            grdSiteStatus.AllowUserToAddRows = false;
            return bStatus;
        }
        public frmQCReporting()
        {
            InitializeComponent();
        }
        
        public int LastRunStatus { get; set; } = -1;

        private void ChangeStatus(bool withClock)
        {
            if (isRunning)
            {
                picRunning.Visible = false;
                picStop.Visible = true;
                lblRunStatus.Text = "Stopped";
                lblRunStatus.ForeColor = Color.Red;
                isRunning = false;
                tmTimer.Stop();
                btnStart.Text = "Start";
                //btnForceRun.Enabled = true;

            }
            else
            {
                picRunning.Visible = true;
                picStop.Visible = false;
                lblRunStatus.Text = "Running";
                lblRunStatus.ForeColor = Color.Green;

                isRunning = true;
                tmTimer.Start();
                //btnForceRun.Enabled = false;
                btnStart.Text = "Stop";
                //mainTimesaldo.DBReadyToRun();
                //InfoUpdate();
            }
        }
        private void btnQuitApplication_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Quit, application?", "QualityChecker 2018", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // TODO Force run this need to be change to select site to refresh
            MainQualityChecker oMain = new MainQualityChecker();

            if (oMain.runExcelQualityReport())
            {
                DialogResult result = MessageBox.Show(this, "Refresh is done", "QualityChecker 2018", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            oMain = null;
        }

        private void btnRefreshFile_Click(object sender, EventArgs e)
        {
            MainQualityChecker oMain = new MainQualityChecker();

            if (oMain.Main_Report_Checker_2017())
            {

                DialogResult result = MessageBox.Show(this, "Read is done", "QualityChecker 2018", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            oMain = null;
        }

        private void btnCheckExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnFullProcess_Click(object sender, EventArgs e)
        {
            MainQualityChecker oMain = new MainQualityChecker();

            try
            {

                grdRunStatus_Add("Run full process", "Start quality check");
                if (oMain.runExcelQualityReport())
                {
                    grdRunStatus_Add("Run full process", "Start copy result");
                    if (oMain.Main_Report_Checker_2017())
                    {
                        grdRunStatus_Add("Run full process", "Finish ok");
                        DialogResult result = MessageBox.Show(this, "All is done", "QualityChecker 2018", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        grdRunStatus_Add("Run full process", "Finish fail");
                    }
                }
            }
            catch (Exception ex)
            {
                grdRunStatus_Error("Error:" + ex.Message, ex.StackTrace);
            }
            finally
            {
                oMain = null;
            }
        }

        private void tmTimer_Tick(object sender, EventArgs e)
        {
            DateTime Time = DateTime.Now;
            //DateTime sinceTime = Time.Ticks - AppStartTime.Ticks; 

            int minutes = Time.Minute;
            int hours = Time.Hour;
            int second = Time.Second;

            System.TimeSpan diff = Time - AppStartTime;

            lblClock.Text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + second.ToString("00");
            lblRunningSince.Text = diff.Hours.ToString("00") + ":" + diff.Minutes.ToString("00") + ":" + diff.Seconds.ToString("00");

            if (mainQC.IsRefreshing)
            {
                if (lblWorking.Text == "Updateing")
                {
                    lblWorking.Text = "Updateing...";
                }
                else
                {
                    lblWorking.Text = "Updating";
                }

                return;
            }
            else
            {
                lblWorking.Text = "Waiting for job";
            }

            // Check status on all enviroments
            foreach (var t in mainQC.oCurrent.Settings.Sites)
            {
                // Check status from database
                if (t.Value.DBReadyToRun())
                {

                    // 1. Status kolonne
                    // 2. status kommentar
                    
                    Status_Text(t.Value.runStatus.ReadyToRun, t.Value.GridNbr);
                    lblSelectedDatabase.Text = "Selected database:" + t.Value.GridNbr.ToString();
                    
                    // 3. Download last run date
                    // 4. Last download OpExId
                    grdSiteStatus.Rows[t.Value.GridNbr].Cells[3].Value = t.Value.runStatus.Download_LastRefresh.ToShortDateString();
                    grdSiteStatus.Rows[t.Value.GridNbr].Cells[4].Value = t.Value.runStatus.Download_OpExId.ToString();

                    // 5. History last run date
                    // 6. History OpExId
                    grdSiteStatus.Rows[t.Value.GridNbr].Cells[5].Value = t.Value.runStatus.History_LastRefresh.ToShortDateString();
                    grdSiteStatus.Rows[t.Value.GridNbr].Cells[6].Value = t.Value.runStatus.History_OpExId.ToString();


                    //7. Reporting last run date
                    //8. Reporting OpExId
                    grdSiteStatus.Rows[t.Value.GridNbr].Cells[7].Value = t.Value.runStatus.LastRefresh.ToShortDateString();
                    grdSiteStatus.Rows[t.Value.GridNbr].Cells[8].Value = t.Value.runStatus.OpExId.ToString();

                    // Update screen and gridview
                    grdSiteStatus.Refresh();
                    

                    
                    /* ReadyToRun:
                     * 5000 - Klar for kjøring i databasen
                     */

                    if (t.Value.runStatus.ReadyToRun == 5000 && t.Value.UpdateSettings==false)
                    {
                        // Updatew database status // we start the run

                        DateTime updateTimeStart = DateTime.Now;
                        DateTime updateTimeFinish;

                        

                        // Set site running and what site to update 
                        mainQC.IsRefreshing = true;
                        mainQC.RunningSite = t.Value;
                        
                        // Update status
                        mainQC.RunningSite.DBStartQualityCheckerRunning();
                        string envName = mainQC.RunningSite.POSite.Enviromentname;
                        runningSite = envName;

                        lblWorking.Text = "Updating site : " + envName;

                        

                        grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "[RUN] - PO Table count";

                        


                        // Documenting what is happning along the way
                        lblRunningSite.Text = envName;
                        grdRunStatus_StartStopp(true);

                        // Update status in grid
                        // Get count from project online
                        // New function
                        if (mainQC.PO_getTableCount())
                        {
                            grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "[RUN - OK] - PO Table count";

                            if (mainQC.PO_runResultCheck())
                            {
                                // All good, go to next site

                                //grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Style.BackColor = Color.DarkGreen;
                                // Set running site to null

                                grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "[SITE- Updated] - Quality";
                                mainQC.RunningSite.UpdateSettings = false;
                                mainQC.RunningSite = null;
                            }
                        }

                        /*
                        grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "[RUN] - Quality report run" ;
                        //grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Style.BackColor = Color.Green;

                        
                        //Run quality check
                        if (mainQC.runExcelQualityReport())
                        {
                            grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "[RUN - OK] - Quality report run";
                            // Read Excel Sheet and add to database
                            if (mainQC.Main_Report_Checker_2017())
                            {
                                grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "[DB - ADD] - Quality report run";
                                // Run resultcheck 
                                if (mainQC.runResultCheck())
                                {
                                    // All good, go to next site
                                    
                                    //grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Style.BackColor = Color.DarkGreen;
                                    // Set running site to null



                                    grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "[SITE- Updated] - Quality";
                                    mainQC.RunningSite.UpdateSettings = false;
                                    mainQC.RunningSite = null;
                                }
                            }
                            else
                            {
                               
                                grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "[DB - ADD] - ERROR";
                                grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Style.BackColor = Color.Red;
                                mainQC.RunningSite.UpdateSettings = true;
                            }
                        }
                        else
                        {
                            // TMP
                            if (mainQC.RunningSite is null)
                            { mainQC.RunningSite = t.Value; }

                            grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "[RUN] - ERROR";
                            //grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Style.BackColor = Color.Red;
                            mainQC.RunningSite.UpdateSettings = true;
                        }
                        */

                        // finish time on the run
                        updateTimeFinish = DateTime.Now;

                        grdRunStatus_StartStopp(false);
                        

                        // Set back is refreshing
                        mainQC.IsRefreshing = false;

                    }
                    if (t.Value.runStatus.ReadyToRun == 2500 && t.Value.UpdateSettings == false)
                    {
                        // NEW 13.12.2018
                        /* Update database with Count table now
                         * 
                         */

                        DateTime updateTimeStart = DateTime.Now;
                        DateTime updateTimeFinish;



                        // Set site running and what site to update 
                        mainQC.IsRefreshing = true;
                        mainQC.RunningSite = t.Value;

                        // Update status
                        string envName = mainQC.RunningSite.POSite.Enviromentname;
                        runningSite = envName;

                        lblWorking.Text = "Updating site : " + envName;
                        grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "[RUN] - BEFORE PO Table count";

                        // Documenting what is happning along the way
                        lblRunningSite.Text = envName;
                        grdRunStatus_StartStopp(true);

                        if (mainQC.PO_getTableCount_Before())
                        {
                            grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "[RUN - OK] - BEFORE PO Table count";
                        }

                        grdRunStatus_StartStopp(false);
                        // Set back is refreshing
                        mainQC.IsRefreshing = false;

                    }
                    else
                    {

                        // TMP
                        if (mainQC.RunningSite is null)
                        { mainQC.RunningSite = t.Value;}

                        //grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = Status_Text(t.Value.runStatus.ReadyToRun, t.Value.GridNbr);

                        if (t.Value.runStatus.ReadyToRun == 2 && t.Value.UpdateSettings == false)
                        {
                            //grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "Venter...";
                            //grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Style.BackColor = Color.White;
                        }
                        else
                        {
                            if (t.Value.runStatus.ReadyToRun == 5500 && t.Value.UpdateSettings == false)
                            {
                              //  grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "[SITE - RUN] - Finish";
                              //  grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Style.BackColor = Color.Green;
                                mainQC.RunningSite.UpdateSettings = false;
                            }
                            else
                            {
                                //grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Value = "[SITE - RUN] - Need update";
                                //grdSiteStatus.Rows[mainQC.RunningSite.GridNbr].Cells[2].Style.BackColor = Color.Red;
                                mainQC.RunningSite.UpdateSettings = false;
                            }
                        }
                    }
                }
            }



            /*
            if (minutes == 00)  //FIRE ON THE HOUR
                //lstLogg.Items.Add("Start:" + minutes.ToString());

            if (minutes == 15)  //FIRE ON 1/4 HOUR
                //lstLogg.Items.Add("Start:" + minutes.ToString());

            if (minutes == 30)  //FIRE ON 1/2 HOUR
                //lstLogg.Items.Add("Start:" + minutes.ToString());

            if (minutes == 45)  //FIRE ON 3/4 HOUR
                //lstLogg.Items.Add("Start:" + minutes.ToString());
                */


            

        }

        private void frmQCReporting_Load(object sender, EventArgs e)
        {

            AppStartTime = DateTime.Now;
            if (grdClear())
            {
                DateTime Time = DateTime.Now;
                DataGridViewRow rowA = (DataGridViewRow)grdRunStatus.Rows[0].Clone();
                rowA.Cells[0].Value = "APPLICATION START";
                rowA.Cells[1].Value = Time.ToShortDateString();
                rowA.Cells[2].Value = "KL:" + Time.ToShortTimeString();
                rowA.Cells[3].Value = "";
                rowA.Cells[4].Value = "";
                rowA.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 8F, FontStyle.Bold);
                rowA.DefaultCellStyle.BackColor = Color.Black;
                rowA.DefaultCellStyle.ForeColor = Color.White;

                grdRunStatus.Rows.Add(rowA);

                grdEdit(false);
            }
        }
        
        private void stbStatus_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmQCReporting_Shown(object sender, EventArgs e)
        {
            //MainQualityChecker oMain = new MainQualityChecker();
            lblWorking.Text = "Checking database connection...";
            lblWorking.Visible = true;

            this.Refresh();

            mainQC.IsRefreshing = true;

            

            if (mainQC.oCurrent.LoadSiteValues())
            {
                lblWorking.Text = "Checking database connection...";
                // settings are loaded correct, start checking 
                if (mainQC.oCurrent.IsSettings_Loaded_DB.Status && mainQC.oCurrent.IsSettings_Loaded_PO.Status)
                {
                    Sites_addGrid();
                    
                    // Start timer
                    tmTimer.Enabled = true;
                    ChangeStatus(true);

                    lblWorking.Text = "Database connection ok...";
                    lblWorking.ForeColor = Color.Green;

                    mainQC.IsRefreshing = false;
                    return;
                }
                else
                {
                    // show error message
                    Sites_addGrid();
                    
                    // TODO: Resource need to be notify to change og check the database settings or other settings that is not right.

                    lblWorking.Text = "Settings is not loaded... not connected";
                    lblWorking.ForeColor = Color.Red;
                    lblWorking.Visible = true;

                    mainQC.IsRefreshing = false;
                    return;
                }
            }
            else
            {
                lblWorking.Text = "Error loading Settings...";
                lblWorking.ForeColor = Color.Red;

                mainQC.IsRefreshing = false;
                return;
            }            
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                Timer(false);

                frmSettings oFormSet = new frmSettings();
                oFormSet.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error show settings:" + ex.Message, "Settingsdialog");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void pnlS1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grdSiteStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                // TODO
                // åpne settinger samt, status på valgt database
                // MessageBox.Show("Valgt database er:" + e.RowIndex.ToString());

                //MOVE TO NEW BUTTON,  Open settings send current site:
                foreach (var t in mainQC.oCurrent.Settings.Sites)
                {
                    // Open form to show result
                    if(t.Value.GridNbr==e.RowIndex)
                    {
                        if (senderGrid.Rows[t.Value.GridNbr].Cells[1].Value.ToString() == "-100")
                        {
                            MessageBox.Show("No connectiong to database","Open database");
                            return;
                        }
                        else
                        {
                            Timer(false);

                            frmQC_Result oForm = new frmQC_Result();
                            oForm.DatabaseNbr = t.Value.GridNbr;
                            oForm.EnviromentName = t.Value.POSite.Enviromentname;
                            oForm.Show(this);

                            // No we showing for and can exit 
                        }

                        return;
                    }
                }

            }
        }

        private void grdSiteStatus_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is Button)

            {

                Button btn = e.Control as Button;

                btn.Click -= new EventHandler(btn_Click);

                btn.Click += new EventHandler(btn_Click);

            }

        }

        void btn_Click(object sender, EventArgs e)

        {

            int col = this.grdSiteStatus.CurrentCell.ColumnIndex;

            int row = this.grdSiteStatus.CurrentCell.RowIndex;

            MessageBox.Show("Button in Cell[" +

                col.ToString() + "," +

                row.ToString() + "] has been clicked");

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnStartTimer_Click(object sender, EventArgs e)
        {
            Timer(true);
        }

        private void btnAddStatus_Click(object sender, EventArgs e)
        {
            grdRunStatus_StartStopp(true);
            grdRunStatus_Add("sTopic", "sAction");
            grdRunStatus_Error("TEST", "Feil");
            grdRunStatus_StartStopp(false);
        }
    }
}
