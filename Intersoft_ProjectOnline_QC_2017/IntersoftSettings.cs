using System;
using System.IO;
using System.Collections.Generic;
using System.Data;

namespace Intersoft_ProjectOnline_QC_2017
{
    class IntersoftSettings
    {
        public HelperSQL imsSQL = new HelperSQL();

        public QCGeneralSettings Settings = new QCGeneralSettings();
        public Int64 CurrentSite { get; set; } = 1;

        public StatusSettings isSettings_Loaded { get; set; } = new StatusSettings();
        public StatusSettings IsSettings_Loaded_DB { get; set; } = new StatusSettings();
        public StatusSettings IsSettings_Loaded_PO { get; set; } = new StatusSettings();
        public StatusSettings IsSettings_Loaded_File { get; set; } = new StatusSettings();
        
        /// <summary>
        /// Numbers of site that we will download from, min 1 site
        /// </summary>
        public int QC_SITE_NUMBERS { get; set; } = 1;

        /// <summary>
        /// Load all site values so they can be checked in seqvens
        /// </summary>
        /// <returns>true- ok load all</returns>
        public bool LoadSiteValues()
        {
            bool bStatus = false;

            Int64 nNumbersOfSite = 0;
            this.Settings.AppSet.AppName = typeof(Program).Assembly.GetName().Name;

            if (Int64.TryParse(Properties.Settings.Default.QC_NUMBERS_OF_SITE, out nNumbersOfSite))
            {
                this.Settings.QC_NumbersOfSites = nNumbersOfSite;
            }

            Int64 nQCTestType = 0;
            if (Int64.TryParse(Properties.Settings.Default.QC_TEST_TYPE, out nQCTestType))
            {
                this.Settings.QC_TEST_TYPE = nQCTestType;
            }
            

            // Load allsites

            // Create all sites
            for (int i = 1; i <= nNumbersOfSite; i++)
            {
                DBSiteSettings tmpSite = new DBSiteSettings();
                tmpSite.AppSet = this.Settings.AppSet;

                switch (i)
                {
                    case 1: // Loading settings to site 1
                            {
                                tmpSite.QC_SITE = Properties.Settings.Default.QC_SITE_1;
                                tmpSite.QC_SITE_DBC = Properties.Settings.Default.QC_SITE_DBC_1;

                                Int64 nSEQ = 0;

                                if (Int64.TryParse(Properties.Settings.Default.QC_SITE_SEQ_1.ToString(), out nSEQ))
                                {
                                    tmpSite.QC_SITE_SEQ = nSEQ;
                                }
                                break;
                            }

                    case 2: // Loading settings to site 2
                        {
                            tmpSite.QC_SITE = Properties.Settings.Default.QC_SITE_2;
                            tmpSite.QC_SITE_DBC = Properties.Settings.Default.QC_SITE_DBC_2;

                            Int64 nSEQ = 0;

                            if (Int64.TryParse(Properties.Settings.Default.QC_SITE_SEQ_2.ToString(), out nSEQ))
                            {
                                tmpSite.QC_SITE_SEQ = nSEQ;
                            }

                            break;
                        }
                    case 3: // Loading settings to site 3
                        {
                            tmpSite.QC_SITE = Properties.Settings.Default.QC_SITE_3;
                            tmpSite.QC_SITE_DBC = Properties.Settings.Default.QC_SITE_DBC_3;

                            Int64 nSEQ = 0;

                            if (Int64.TryParse(Properties.Settings.Default.QC_SITE_SEQ_3.ToString(), out nSEQ))
                            {
                                tmpSite.QC_SITE_SEQ = nSEQ;
                            }

                            break;
                        }

                    case 4: // Loading settings to site 4
                        {
                            tmpSite.QC_SITE = Properties.Settings.Default.QC_SITE_4;
                            tmpSite.QC_SITE_DBC = Properties.Settings.Default.QC_SITE_DBC_4;

                            Int64 nSEQ = 0;

                            if (Int64.TryParse(Properties.Settings.Default.QC_SITE_SEQ_4.ToString(), out nSEQ))
                            {
                                tmpSite.QC_SITE_SEQ = nSEQ;
                            }
                            break;
                        }

                    case 5: // Loading settings to site 5
                        {
                            tmpSite.QC_SITE = Properties.Settings.Default.QC_SITE_5;
                            tmpSite.QC_SITE_DBC = Properties.Settings.Default.QC_SITE_DBC_5;

                            Int64 nSEQ = 0;

                            if (Int64.TryParse(Properties.Settings.Default.QC_SITE_SEQ_5.ToString(), out nSEQ))
                            {
                                tmpSite.QC_SITE_SEQ = nSEQ;
                            }
                            break;
                        }
                }

                if (tmpSite.DB_Load_POSiteSettings())
                {
                    // Settings to Project Online is 
                    // Is it possible to login
                    if (tmpSite.POSite.PO_Validate_ProjectOnline())
                    {
                        // Site is ok
                        this.IsSettings_Loaded_PO.Status = true;
                        this.IsSettings_Loaded_DB.Status = true;
                    }
                    else
                    {
                        // Site is ok
                        this.IsSettings_Loaded_PO.Status = false;
                        this.IsSettings_Loaded_DB.Status = true;
                        // give a message to user.
                        // not able login
                    }

                    // Validate if QualityCheck file is current.

                    if (tmpSite.POSite.PO_Validate_File())
                    {
                        this.IsSettings_Loaded_File.Status = true;
                        this.IsSettings_Loaded_File.Status_Message = "";
                    }
                    else
                    {
                        this.IsSettings_Loaded_File.Status = false;
                        this.IsSettings_Loaded_File.Status_Message= "File does not exist.";
                    }   

                    // Setting to site is loaded
                    //TODO: Check settings

                }
                else
                {
                    // Settings to Project Online , give a message
                }

                this.Settings.Sites.Add("SITE" + i.ToString(), tmpSite);
            }

            bStatus = true;

            return bStatus;
        }

    }//class IntersoftSettings

    /// <summary>
    /// QCGenralSettings is all settings around this application
    /// 
    /// </summary>
    class QCGeneralSettings
    {
        public int CurrentSite = 1;
        public IntersoftAppSettings AppSet = new IntersoftAppSettings();

        // Holding all site settings
        public Dictionary<string, DBSiteSettings> Sites = new Dictionary<string, DBSiteSettings>();

        public Int64 QC_NumbersOfSites { get; set; } = 1; // max 5 site is supportet

        public Int64 QC_TEST_TYPE { get; set; } = 0; // Type test av resultat, 0 = default(Excel, gamel løsning), 1= applikajson(henter via rest)
        public DBSiteSettings Current { get; set; }

        /// <summary>
        /// Switch site settings
        /// </summary>
        /// <param name="nSiteNbr"></param>
        /// <returns></returns>
        public bool SiteSelect(Int64 nSiteNbr)
        {

            bool bStatus = false;

            try
            {
                DBSiteSettings oCurrentSite;

                if (this.Sites.TryGetValue("SITE" + nSiteNbr, out oCurrentSite))
                {
                    this.Current = oCurrentSite;
                    bStatus = true;
                }
            }
            catch(Exception ex)
            {
                // TODO: LOG ERROR

            }
            
            return bStatus;
        }


    }//class QCGeneralSettings

    /// <summary>
    /// Intersoft app settings are comming from database
    /// </summary>
    class IntersoftAppSettings
    {
        public string AppName { get; set; } = "";
        public string AppEvent { get; set; } = "DataQualityChecking";
        public string PTR_AppName { get; set; } = "IntersoftTimesaldoTimer2017";
        public string PTR_AppEvent { get; set; } = "TimesaldoUpdates";
        public string PRR_AppName { get; set; } = "IntersoftProjectOnlineReportAutoRefresh";
        public string PRR_AppEvent { get; set; } = "Refresh_PO_Reports";
        public string POD_AppName { get; set; } = "IntersoftReportingSolution2017";
        public string POD_AppEvent { get; set; } = "DownloadProjectOnlineData";
    }// Class IntersoftAppSettings

    /// <summary>
    /// DBSiteSettings are comming from App.config
    /// QC_SITE - a name to the site, at yours chooise
    /// QC_SITE_DBC - Connection string to database, here is where we get PO_SiteSettings values
    /// QC_SITE_SEQ - when is application going to run, the order.
    /// </summary>
    class DBSiteSettings
    {
        public HelperSQL imsSQL = new HelperSQL();
        public HelperLog imsLOG = new HelperLog();

        public IntersoftAppSettings AppSet { get; set; }

        public LastRunStatus runStatus { get; set; }

        public StatusSettings Status_Database = new StatusSettings();
        public StatusSettings Status_ProjectOnline = new StatusSettings();
        public bool UpdateSettings { set; get; } = false;

        public string QC_SITE { get; set; } = "";
        public string QC_SITE_DBC { get; set; } = "";
        public Int64 QC_SITE_SEQ { get; set; } = 0;

        public int GridNbr { get; set; } = 0;

        public POSiteSettings POSite { get; set; } = new POSiteSettings();

        public bool Missing_Connectionstring()
        {
            if(this.QC_SITE_DBC.Length>5)
            { return true; }
            else
            { return false; }
        }

        public bool Missing_File()
        {
            return true;
        }

        public bool DB_Load_POSiteSettings()
        {
            bool bStatus = false;
            // Load all settings from database into POSiteSettings
            imsSQL.oCurrent = this;
            
            if (imsSQL.getPoSiteSettings(this.POSite))
            {
                bStatus = true;
            }
            return bStatus ;
        }
        public bool DB_CheckLastRun()
        {
            bool bStatus = false;

            //this.RunStatus = imsSQL.

            return bStatus;

        }
        public bool DBReadyToRun()
        {
            bool bStatus = false;
            try
            {
                // get last run status 
                runStatus = imsSQL.getOpExId();

                if (runStatus != null)
                {
                    // Check the run status report run
                    runStatus.ReadyToRun = imsSQL.getStartReportRun();

                    // Check last run status on download
                    // Check last run status on History

                    // Check the run status of Timesaldo synkronisering
                    runStatus.PTR_ReadyToRun = imsSQL.getIMS_PTS_StatusCheck();

                    // Check the run status of report refresh
                    runStatus.PRR_ReadyToRun = imsSQL.getIMS_PRR_StatusCheck();


                    bStatus = true;
                }

            }
            catch (Exception ex)
            {
                //TODO: add error code
                imsLOG.LogToDB_Error("Exeption", ex.Message, ex.Source, ex.StackTrace, "MainQualityChecker:DBReadyToRun");
            }
            

            return bStatus;
        }

        public bool DBReportUpdateRunning()
        {
            bool bStatus = imsSQL.setQC_RunningApp();

            return bStatus;

        }
        public bool DBStartQualityCheckerRunning()
        {
            bool bStatus = imsSQL.setQC_StartApp();

            return bStatus;
        }

        public bool DBTestConnection()
        {
            return imsSQL.Open_Connection();

        }

        public DataTable QC_getResult(int Status)
        {
            return imsSQL.QCResults(Status);
        }

    }//class DBSiteSettings


    /// <summary>
    /// POSiteSettings 
    /// These values are from database on each site
    /// </summary>
    class POSiteSettings
    {

        public bool Status_ProjectOnline { get; set; } = false;
        public string Enviromentname { get; set; } = "";
        public string SP_Site { get; set; } = "";                           // Sharepoint site 
        public string PO_Site { get; set; } = "";                           // Project Online site
        public string PO_Username { get; set; } = "";                       // Account to logon to Project Online 
        public string PO_Password { get; set; } = "";                       // Password to account

        public int PO_Module_ReportRefresh { get; set; } = 0;               // Is report refresh in use on this site
        public int PO_Module_Timesaldo { get; set; } = 0;                   // Is timesaldo module use on this site
        public int PO_Module_History { get; set; } = 0;                     // Is historical data in use

        public int QC_UseQualityCheckFile { get; set; } = 1;                // Are QC Checkfile going to be used.
        public string QC_Filename { get; set; }                             // Name of quality check file
        public string QC_Filepath { get; set; }                             // Where is the file at

        public string QC_MailTo { get; set; } = "";                         // Send mail to after download data

        // Give back full path to file
        public string QC_FullPath()
        {
            return this.QC_Filepath + QC_Filename;
        }


        public bool PO_SettingsIsLoaded { get; set; } = false;
        public bool PO_SettingsIsChecked { get; set; } = false;

        /// <summary>
        /// Validate ProjectOnline settings, 
        /// 1. Is site ok
        /// 2. Is username and password ok
        /// </summary>
        /// <returns>true, when ok</returns>
        public bool PO_Validate_ProjectOnline() 
        {
            bool bStatus = false;
            this.Status_ProjectOnline = false;
            HelperPO imsPO = new HelperPO();


            imsPO.oTSCurrent = this;
            if (imsPO.PO_Login()==1)
            {
                this.Status_ProjectOnline = true;
                bStatus = true;
            }

            return bStatus;
        }

        /// <summary>
        /// Validate file setting
        /// Check that file exist
        /// </summary>
        /// <returns>true, </returns>
        public bool PO_Validate_File()
        {
            string curFile = this.QC_Filepath + this.QC_Filename;   
            if (File.Exists(curFile))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }// class POSiteSettings

    /// <summary>
    /// 
    /// </summary>
    class StatusSettings
    {
        public bool Status { get; set; } = false;
        public string Status_Message = "";
    }// class statussettings

}//Namespace Intersoft_ProjectOnline_QC_2017
