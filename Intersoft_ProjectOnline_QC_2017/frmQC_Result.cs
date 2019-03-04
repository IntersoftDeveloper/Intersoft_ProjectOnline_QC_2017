using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intersoft_ProjectOnline_QC_2017
{
    

    public partial class frmQC_Result : Form
    {
        private bool isLoading = false;
        private bool ShowErrors = false;

        public int DatabaseNbr = -1;
        
        public string EnviromentName { get; set; }
        private MainQualityChecker mainQC = new MainQualityChecker();
        private DBSiteSettings CurrentSite = null;

        public frmQC_Result()
        {
            InitializeComponent();
        }

        private void frmQC_Result_Load(object sender, EventArgs e)
        {
            isLoading = true;
            Dictionary<int, string> colViews = new Dictionary<int, string>();

            colViews.Add(1, "Final Today"); // Default views
            colViews.Add(2, "Daily result");
            colViews.Add(3, "Checksum History");
            colViews.Add(4, "Errorlog");
            colViews.Add(5, "Reporting state log");
            colViews.Add(6, "Rowcount Stage");
            colViews.Add(7, "Rowcount DBO");
            colViews.Add(8, "Rowcount History");
            colViews.Add(9, "History settings");
            colViews.Add(10, "Application settings");


            lblEnviroment.Text = EnviromentName;


            // Add views to 

            cboViewType.DataSource = new BindingSource(colViews, null);
            cboViewType.DisplayMember = "Value";
            cboViewType.ValueMember = "Key";


            if (mainQC.oCurrent.LoadSiteValues())
            {

                foreach (var t in mainQC.oCurrent.Settings.Sites)
                {
                    if (t.Value.POSite.Enviromentname == EnviromentName)
                    {
                        CurrentSite = t.Value;
                        if (!t.Value.Status_Database.Status)
                        {
                            // No connection
                            break;
                        }
                        else
                        {
                            grdStatus.AllowUserToAddRows = true;
                            grdStatus.AllowUserToDeleteRows = true;
                            grdStatus.DataSource = CurrentSite.imsSQL.QCResults(-1);
                            grdStatus.AllowUserToAddRows = false;
                            grdStatus.AllowUserToDeleteRows = false;
                            break;
                        }
                    }
                }

            }

            isLoading = false;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //frmQCReporting oForm=(frmQCReporting)Application.OpenForms["frmQCReporting"];

            // Turn on timer again
            //oForm.Timer(true);
            this.Close();
        }

        private void btnOnlyErrors_Click(object sender, EventArgs e)
        {
            if (ShowErrors)
            {
                ShowErrors = false;
                grdStatus.DataSource = CurrentSite.imsSQL.QCResults(-1);
            }
            else
            {
                ShowErrors = true;
                grdStatus.DataSource = CurrentSite.imsSQL.QCResults(0);
            }
        }

        private void cboViewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (isLoading) { return; }

            try
            {
                grdStatus.AllowUserToAddRows = true;
                grdStatus.AllowUserToDeleteRows = true;
                grdStatus.AllowUserToOrderColumns = true;

                btnOnlyErrors.Enabled = false;
                var t = cboViewType.SelectedIndex.ToString();
                lblViewName.Text = cboViewType.Text;
                

                switch (t)
                {
                    case "0":
                        grdStatus.DataSource = CurrentSite.imsSQL.QCResults(-1);
                        grdStatus.ReadOnly = true;
                        btnOnlyErrors.Enabled = true;
                        
                        break;
                    case "1":
                        grdStatus.DataSource = CurrentSite.imsSQL.QCDailyResult();
                        grdStatus.ReadOnly = true;
                        
                        break;
                    case "2":
                        grdStatus.DataSource = CurrentSite.imsSQL.QC_Checksum_History();
                        grdStatus.ReadOnly = true;
                        
                        break;
                    case "3":
                        grdStatus.DataSource = CurrentSite.imsSQL.QCErrorlog();
                        grdStatus.ReadOnly = true;
                        break;
                    case "4":
                        grdStatus.DataSource = CurrentSite.imsSQL.QCShowReportingTotal();
                        grdStatus.ReadOnly = true;
                        break;
                    case "5":
                        grdStatus.DataSource = CurrentSite.imsSQL.QCShowCount("STAGE");
                        grdStatus.ReadOnly = true;
                        break;
                    case "6":
                        grdStatus.DataSource = CurrentSite.imsSQL.QCShowCount("DBO");
                        grdStatus.ReadOnly = true;
                        break;
                    case "7":
                        grdStatus.DataSource = CurrentSite.imsSQL.QCShowCount("HISTORY");
                        grdStatus.ReadOnly = true;
                        break;
                    case "8":
                        grdStatus.DataSource = CurrentSite.imsSQL.QC_History_Settings();
                        grdStatus.ReadOnly = false;
                        break;
                    case "9":
                        grdStatus.DataSource = CurrentSite.imsSQL.QC_AppEvent_Settings();
                        grdStatus.ReadOnly = false;
                        break;


                }

                
                grdStatus.AllowUserToAddRows = false;
                grdStatus.AllowUserToDeleteRows = false;
                

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in change view:" + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void frmQC_Result_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmQCReporting oForm = (frmQCReporting)Application.OpenForms["frmQCReporting"];
            // Turn on timer again
            oForm.Timer(true);
        }

        private void grdStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Do you want rerun Qualitycheck?", "Force run Qualitycheck", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                if (CurrentSite.imsSQL.setQC_ForceRunQualityCheckApp())
                {
                    MessageBox.Show("Added to Queue, close dialog to run again", "Force run Qualitycheck");
                }
            }
        }

        private void btnSaveRecordset_Click(object sender, EventArgs e)
        {
            
        }

        private void lblEnviroment_Click(object sender, EventArgs e)
        {

        }

        private void btnGetTables_Click(object sender, EventArgs e)
        {
            HelperPO oPO = new HelperPO();
            oPO.oTSCurrent = CurrentSite.POSite;

            oPO.xml_TableNames();
            oPO.PO_getCustomFields(oPO.Fields);



            if(oPO.xml_getTableCountAll())
            {
                // Save to database
                MessageBox.Show("Antall tabeller:" + oPO.Tables.Count.ToString());

                // save to database
                if(CurrentSite.imsSQL.QC_saveTableCountFromPO(oPO.Tables))
                {
                    MessageBox.Show("Count lagret til database:");
                }
                
            }



        }
    } // Class frmQC_Result
}// namespace : Intersoft_ProjectOnline_QC_2017
