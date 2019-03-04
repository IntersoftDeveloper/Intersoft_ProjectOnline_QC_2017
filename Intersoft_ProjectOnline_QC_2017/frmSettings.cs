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
    public partial class frmSettings : Form
    {
        private bool isLoading = false;
        private int SelectedNbr = 1;
        
        private MainQualityChecker mainQC = new MainQualityChecker();
        private DBSiteSettings CurrentSite = null;

        private bool Site_Selected()
        {
            bool bStatus = false;
            pnlDatabaseSetting.Visible = false;
            txtQC_SITE_Name.Text = "";
            txtQC_SITE_DBC.Text = "";
            txtQC_SITE_SEQ.Text = "";

            foreach (var t in mainQC.oCurrent.Settings.Sites)
            {
                if (t.Value.QC_SITE_SEQ == SelectedNbr)
                {
                    CurrentSite = t.Value;

                    txtQC_SITE_Name.Text = CurrentSite.QC_SITE;
                    txtQC_SITE_DBC.Text = t.Value.QC_SITE_DBC;
                    txtQC_SITE_SEQ.Text = t.Value.QC_SITE_SEQ.ToString();


                    // If connection to database then we should have settings.
                    if(t.Value.Status_Database.Status)
                    {
                        // Get values from database
                        pnlDatabaseSetting.Visible = true;

                        // Site settings
                        txtPO_Site_PWA.Text = CurrentSite.POSite.PO_Site;
                        txtPO_Username.Text = CurrentSite.POSite.PO_Username;
                        txtPO_Password.Text = CurrentSite.POSite.PO_Password;

                        // QC Settings

                        txtQC_File.Text = CurrentSite.POSite.QC_FullPath();


                        // Mail settings
                        txtQC_Mail.Text = CurrentSite.POSite.QC_MailTo;

                    }

                    bStatus = true;
                    break;
                }
            }

            

            return bStatus;
        }

        

        public frmSettings()
        {
            InitializeComponent();
        }


        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            // Before save we need to check enviroments.

            //Properties.Settings.Default.PROD_DBConnection = txtPROD_CON.Text;
       
            Properties.Settings.Default.Save();
        }

        private void btnValidate_Prod_Click(object sender, EventArgs e)
        {
            // Check that a connection to database

        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            isLoading = true;
            
            // All default site
            Dictionary<int, string> colSite = new Dictionary<int, string>();

            colSite.Add(1, "Site 1");
            colSite.Add(2, "Site 2");
            colSite.Add(3, "Site 3");
            colSite.Add(4, "Site 4");
            colSite.Add(5, "Site 5");

            // Add sites to 

            cboEnviroments.DataSource = new BindingSource(colSite, null);
            cboEnviroments.DisplayMember = "Value";
            cboEnviroments.ValueMember = "Key";

            lstSites.DataSource = new BindingSource(colSite, null);
            lstSites.DisplayMember = "Value";
            lstSites.ValueMember = "Key";


            // Get all enviroments
            if (mainQC.oCurrent.LoadSiteValues())
            {
                if(Site_Selected())
                {
                    // Ready
                }
            }
            else
            {
                // settings are not loaded, could be all new

            }



            // Check how many active 1-5
            // Load all 

            isLoading = false;
        }

        private void txtPROD_CON_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmQCReporting oForm = (frmQCReporting)Application.OpenForms["frmQCReporting"];
            // Turn on timer again
            oForm.Timer(true);
        }

        private void cboEnviroments_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (isLoading) { return; }

            var t = cboEnviroments.SelectedIndex;

            SelectedNbr = t+1;

            Site_Selected();
        }

        private void txtQC_SITE_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstSites_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (isLoading) { return; }

            var t = lstSites.SelectedIndex;

            SelectedNbr = t + 1;

            Site_Selected();
        }

        private void txtQC_Mail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            fldFileReport.InitialDirectory = CurrentSite.POSite.QC_Filepath;
            if (CurrentSite.POSite.QC_Filename.Length > 0)
            {
                fldFileReport.FileName = CurrentSite.POSite.QC_Filename;
            }

            fldFileReport.ShowDialog();

            if (fldFileReport.FileName.Length>0)
            {
                CurrentSite.POSite.QC_Filename = fldFileReport.FileName;
            }

        }
    }
}
