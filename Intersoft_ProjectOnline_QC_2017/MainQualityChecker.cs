using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

/// <summary>
/// 
/// </summary>
namespace Intersoft_ProjectOnline_QC_2017
{
    /// <summary>
    /// Controlling action around Excel and Quality check file in Excel
    /// Open, Refresh, Save to database
    /// </summary>
    class MainQualityChecker
    {
        private HelperSQL imsSQL = new HelperSQL();
        private HelperLog imsLOG = new HelperLog();

        public Dictionary<string, ReportTableTest> oTables = new Dictionary<string, ReportTableTest>();

        public IntersoftSettings oCurrent = new IntersoftSettings();

        public DBSiteSettings RunningSite { set; get; }

        public LastRunStatus runStatus { get; set; } = new LastRunStatus();
        public StatusCopy copyStatus { get; set; } = new StatusCopy();

        public bool IsRefreshing { get; set; } = false;

        /// <summary>
        /// Run Report Quality checker
        /// </summary>
        /// <returns></returns>
        public bool Main_Report_Checker_2017()
        {
            bool bStatus = false;
            oTables = new Dictionary<string, ReportTableTest>();

            try
            {
                // Refresh Excel sheet in database
                if (readExcelQualityReport(oTables))
                {

                    // Read is good
                    if (addResultToDatabase(oTables))
                    {
                        // Adding to database is good

                        
                        // for å sjekke uten å laste ned
                        if(runResultCheck())
                        { bStatus = true; }
                    }
                }
            }
            catch(Exception ex)
            {
                imsLOG.LogToScreen_Action(ex.Message, "Main_Report_Checker_2017");
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "MainQualityChecker: Main_Report_Checker_2017");
            }

            return bStatus;
        }

        /// <summary>
        ///  Run Quality Report Force??
        /// </summary>
        /// <returns></returns>
        public bool runExcelQualityReport()
        {

            bool bStatus = false;
            // Initialize objects

            string tmpFilename = "";

            // Create object and make sure that no message are showed in client.
            Excel.Application xlApp;
            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;

            try
            {
                

                //Excel.Workbook xlWorkBook;
                imsLOG.LogToScreen_Action("EXCEL", "Start application");
                // open excel file

                xlApp.Visible = true;



                // Get file for running site
                tmpFilename = RunningSite.POSite.QC_FullPath();




                // Open Excel sheet
                imsLOG.LogToScreen_Action("Open xls file: ", "Reportname:" + tmpFilename);
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(tmpFilename, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);



                // Open for edit
                //xlWorkBook.LockServerFile();

                // Go thru all connections and set background Query to false, so execl is holding report open under refresh.
                foreach (Excel.WorkbookConnection cnn in xlWorkBook.Connections)
                {
                    switch (cnn.Type.ToString())
                    {
                        case "xlConnectionTypeDATAFEED":
                            {

                                break;
                            }
                        case "xlConnectionTypeODBC":
                            {
                                cnn.ODBCConnection.BackgroundQuery = false;
                                break;
                            }
                        case "xlConnectionTypeOLEDB":
                            {
                                cnn.OLEDBConnection.BackgroundQuery = false;
                                break;
                            }
                    }
                }

                // Refreshing all dataconnection in Excel book
                xlWorkBook.RefreshAll();



                // Set in sleep 30 sec
                System.Threading.Thread.Sleep(30000);

                // Save Excel
                xlApp.DisplayAlerts = false;
                xlWorkBook.Save();

                System.Threading.Thread.Sleep(30000);

                // Close Excel
                xlWorkBook.Close(true, null, null);

                imsLOG.LogToScreen_Action("Close xls file: ", "Reportname:" + tmpFilename);

                bStatus = true;
            }
            catch (COMException ex)
            {
                imsLOG.LogToScreen_Action("COM ERR: Filename:" + tmpFilename, "runExcelQualityReport");
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "MainQualityChecker: runExcelQualityReport");
            }
            catch (System.Exception ex)
            {
                // Log error

                imsLOG.LogToScreen_Action("ERR: Filename:" + tmpFilename, "runExcelQualityReport");
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "MainQualityChecker: runExcelQualityReport");
                //imsLOG.LogToScreen_Action("ERR:" + ex.Message, "runExcelQualityReport");

                // Handel all errors.
            }
            finally
            {
                // Clean up and Quit Excel
                xlApp.DisplayAlerts = false;
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                imsLOG.LogToScreen_Action("EXCEL", "Quit application");
            }

            return bStatus;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loTables"></param>
        /// <returns></returns>
        public bool readExcelQualityReport(Dictionary<string, ReportTableTest> loTables)
        {
            bool bStatus = false;
            int rowCount = 0;
            int colCount = 0;

           
            // Initialize objects
            Excel.Application xlApp;
            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;

            imsLOG.LogToScreen_Action("EXCEL", "Start application");

            try
            {

                xlApp.Visible = true;

                string tmpFilename =RunningSite.POSite.QC_FullPath();// QualityChecker_FullPath;

                imsLOG.LogToScreen_Action("Open file", tmpFilename);

                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(tmpFilename, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);

                // Open for edit
                //xlWorkBook.LockServerFile();

                // Get sheet
                // May need to use index
                Excel.Worksheet xlWorksheet = xlWorkBook.Sheets["QualityCheckResult"];

                // Get range
                Excel.Range xlRange = xlWorksheet.UsedRange;

                rowCount = xlRange.Rows.Count;
                colCount = xlRange.Columns.Count;


                // Read range in excel sheet
                for (int i = 1; i <= rowCount; i++)
                {
                    // Create object on each row
                    ReportTableTest oTable = new ReportTableTest();

                    for (int j = 1; j <= colCount; j++)
                    {
                        /*
                         Table	
                         Row Count PO day Start 
             
                         Test 1 PO day Start 
                         --Test 1 Description	
             
                         Test 2 PO day Start	
                         --Test 2 Description	
             
                         TimeStamp	
                         --PreviousOpExId	
                         --Current OpexId
                         
                         */

                        // Check and validate columns data


                        //Get values from Excel sheet and store values to database
                        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        {
                            
                            // Go thru values 
                            if (i > 1)
                            {
                                decimal dValue = 0;
                                string oValue = "";
                                string oValue2 = "";

                                DateTime dtValue = DateTime.Now;

                                oValue = Convert.ToString(xlRange.Cells[i, j].Value2);
                                oValue2 = Convert.ToString(xlRange.Cells[i, j].Value);

                                switch (j)
                                {
                                    case 1: // Field = table, string
                                        oTable.Tablename = oValue;
                                        break;
                                    case 2: // Field = Row Count, double
                                        if (decimal.TryParse(oValue, out dValue))
                                        {
                                            oTable.PO_Daystart_Count = dValue;
                                        }
                                        break;
                                    case 3: // Field = TEST 1 PO Day Start
                                        if (decimal.TryParse(oValue, out dValue))
                                        {
                                            oTable.Test1.PO_Daystart_Test = dValue;
                                        }
                                        break;
                                    case 4:// Field = TEST 2 PO Day Start
                                        if (decimal.TryParse(oValue, out dValue))
                                        {
                                            oTable.Test2.PO_Daystart_Test = dValue;
                                        }
                                        break;
                                    case 5: // Field = Timestamp 
                                        if (DateTime.TryParse(oValue2,out dtValue))
                                        {
                                            oTable.OPTimeStamp = dtValue;
                                        }
                                        break;
                                    case 7:
                                        oTable.OPRuntime = xlRange.Cells[i, j].Value2;
                                        break;
                                    case 8:
                                        //oTable.OPEXID_Previous = xlRange.Cells[i, j].Value2;
                                        break;
                                    case 9:
                                        //oTable.OPEXID_Current = xlRange.Cells[i, j].Value2;
                                        break;
                                }
                            }
                        }
                    }


                    // Add row to dictonary
                    if (i > 1)
                    {
                        loTables.Add(oTable.Tablename, oTable);
                    }
                }


                // close excel and clean up 
                xlApp.DisplayAlerts = false;
                xlWorkBook.Save();
                xlWorkBook.Close(true, null, null);
                bStatus = true;

                imsLOG.LogToScreen_Action("EXCEL", "Read table result - [ok]");
            }
            catch (System.Exception ex)
            {
                // Log error to screen
                imsLOG.LogToScreen_Action("EXCEL", "Read table result - [ERROR]");
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "MainQualityChecker: readExcelQualityReport");
            }
            finally
            {
                xlApp.DisplayAlerts = true;
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                imsLOG.LogToScreen_Action("EXCEL", "Quit application");
            }

            return bStatus;
        }

        /// <summary>
        /// Addding result to database
        /// </summary>
        /// <returns>true, if ok</returns>
        public bool addResultToDatabase(Dictionary<string, ReportTableTest> loTables)
        {
            bool bStatus = false;

            imsSQL.oCurrent = this.RunningSite;

            try
            {
                // Copy daily to yesterday
                imsLOG.LogToScreen_Action("addResultToDatabase", "Start copy today to yesterday");
                if (imsSQL.CopyTodayToYesterday())
                {

                    
                    imsLOG.LogToScreen_Action("addResultToDatabase", "Adding result to database");
                    var enumeratorTables = loTables.GetEnumerator();


                    while (enumeratorTables.MoveNext())
                    {
                        ReportTableTest tmpTable;
                        var oItem = enumeratorTables.Current;
                        tmpTable = oItem.Value;


                        if (imsSQL.addDailyResult(tmpTable))
                        {
                            //imsLOG.LogToScreen_Action("addResultToDatabase", "Adding result to database -[OK]");
                            bStatus = true;
                        }
                    }
                }


                // Run copy to history
                
                imsLOG.LogToScreen_Action("addResultToDatabase", "Copy result to history");
                if (imsSQL.CopyResultToHistory())
                {
                    imsLOG.LogToScreen_Action("addResultToDatabase", "Copy result to history - [OK]");
                }
                else
                {
                    imsLOG.LogToScreen_Action("addResultToDatabase", "Copy result to history - [FAIL]");

                    bStatus = false;
                }

            }
            catch(Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "MainQualityChecker: addResultToDatabase");
            }

            return bStatus;
        }

        // Run storedproc in database for Check,Copy and history
        public bool runResultCheck()
        {
            bool bStatus = false;

            
            // There are two storedproc that is needed

            // Check the result
            try
            {
                // Add running site
                imsSQL.oCurrent = this.RunningSite;

                // Get copy status 
                copyStatus = imsSQL.ReadyToCopy();
                imsLOG.LogToScreen_Action("Get Copy Status", "runResultCheck");

                if (copyStatus.ReadyToCopy ==1)
                {
                    // First we need to take history
                    imsLOG.LogToScreen_Action("ReadyToTakeHistory", "runResultCheck");

                    if (imsSQL.getHistoryBetween_Stage_and_Reporting())
                    {
                        imsLOG.LogToScreen_Action("OK: History between stage and reporting", "runResultCheck");

                        imsLOG.LogToScreen_Action("ReadyToCopy", "runResultCheck");
                        bStatus = true;

                        // when history is taken, we can make copy from stage to reporting
                        
                        if (imsSQL.Copy_Stage_To_Reporting())
                        {
                            imsLOG.LogToScreen_Action("OK: Copy stage to reporting", "runResultCheck");
                            copyStatus.CopyToReporting = true;
                            imsSQL.setQC_RunningApp();
                        }
                        else
                        {
                            imsLOG.LogToScreen_Action("Failed: Copy stage to reporting", "runResultCheck");
                        }
                        
                    }
                    else
                    {
                        imsLOG.LogToScreen_Action("Failed: History between stage and reporting", "runResultCheck");
                    }

                }
                else
                {
                    imsLOG.LogToScreen_Action("Failed: Ready to copy" + copyStatus.ReadyToCopy.ToString(), "runResultCheck");
                }
            }
            catch(Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "MainQualityChecker: runStatus");
            }


            return bStatus;
        }
        public bool PO_runResultCheck()
        {
            bool bStatus = false;


            // There are two storedproc that is needed

            // Check the result
            try
            {
                // Add running site
                imsSQL.oCurrent = this.RunningSite;

                // Get copy status 
                copyStatus = imsSQL.PO_ReadyToCopy();
                imsLOG.LogToScreen_Action("Get Copy Status", "runResultCheck");

                if (copyStatus.ReadyToCopy == 1)
                {
                    // First we need to take history
                    imsLOG.LogToScreen_Action("ReadyToTakeHistory", "runResultCheck");

                    if (imsSQL.getHistoryBetween_Stage_and_Reporting())
                    {
                        imsLOG.LogToScreen_Action("OK: History between stage and reporting", "runResultCheck");

                        imsLOG.LogToScreen_Action("ReadyToCopy", "runResultCheck");
                        bStatus = true;

                        // when history is taken, we can make copy from stage to reporting

                        if (imsSQL.Copy_Stage_To_Reporting())
                        {
                            imsLOG.LogToScreen_Action("OK: Copy stage to reporting", "runResultCheck");
                            copyStatus.CopyToReporting = true;
                            imsSQL.setQC_RunningApp();
                        }
                        else
                        {
                            imsLOG.LogToScreen_Action("Failed: Copy stage to reporting", "runResultCheck");
                        }

                    }
                    else
                    {
                        imsLOG.LogToScreen_Action("Failed: History between stage and reporting", "runResultCheck");
                    }

                }
                else
                {
                    imsLOG.LogToScreen_Action("Failed: Ready to copy" + copyStatus.ReadyToCopy.ToString(), "runResultCheck");
                }
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "MainQualityChecker: runStatus");
            }


            return bStatus;
        }

        public bool DBReadyToRun()
        {
            bool bStatus = false;
            try
            {
                // get last run status 
                runStatus = imsSQL.getOpExId();

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
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("Exeption", ex.Message, ex.Source, ex.StackTrace, "MainQualityChecker:DBReadyToRun");
            }
            finally
            {
                /// This code is running anytime

            }

            return bStatus;
        }

        public bool PO_getTableCount()
        {
            bool bStatus = false;

            try
            {
                HelperPO oPO = new HelperPO();

                oPO.oTSCurrent = RunningSite.POSite;

                imsLOG.LogToScreen_Action("PO", "GET ALL TABLES");

                oPO.xml_TableNames();

                // Check all po_fields
                

                imsLOG.LogToScreen_Action("PO", "GET TABLE COUNT");
                if (oPO.xml_getTableCountAll())
                {
                    imsLOG.LogToScreen_Action("PO", "SAVE TABLE COUNT TO DB");
                    // save to database
                    if (RunningSite.imsSQL.QC_saveTableCountFromPO(oPO.Tables))
                    {
                        imsLOG.LogToScreen_Action("PO", "ALL TABLECOUNT IS SAVED  TO DB");
                    }

                }

                imsLOG.LogToScreen_Action("PO", "GETTING CUSTOMFIELD FROM PO");
                if (oPO.PO_getCustomFields(oPO.Fields))
                {
                    // all fields have been collected
                    imsLOG.LogToScreen_Action("PO", "UPDATED CUSTOMFIELD FROM PO");
                }


                imsLOG.LogToScreen_Action("PO", "SAVE TABLENAMES TO DB");

                if (RunningSite.imsSQL.PO_saveTableNames(oPO.Tables))
                {
                    imsLOG.LogToScreen_Action("PO", "ALL TABLENAMES IS SAVED TO DB");
                }

                imsLOG.LogToScreen_Action("PO", "SAVE FIELDSNAME TO DB");

                if (RunningSite.imsSQL.PO_saveFieldNames(oPO.Fields))
                {
                    imsLOG.LogToScreen_Action("PO", "ALL FIELDSNAMES IS SAVED TO DB");
                }

                imsLOG.LogToScreen_Action("PO", "COMPARE FIELDSNAME IF ANY CHANGES");


                bStatus = true;
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("Exeption", ex.Message, ex.Source, ex.StackTrace, "MainQualityChecker:PO_getTableCount");
            }

            return bStatus;
        }
        public bool PO_getTableCount_Before()
        {
            bool bStatus = false;

            try
            {
                HelperPO oPO = new HelperPO();

                oPO.oTSCurrent = RunningSite.POSite;

                imsLOG.LogToScreen_Action("PO:BEFORE", " GET ALL TABLES");

                oPO.xml_TableNames();

                imsLOG.LogToScreen_Action("PO:BEFORE", "GET TABLE COUNT");
                if (oPO.xml_getTableCountAll())
                {
                    imsLOG.LogToScreen_Action("PO:BEFORE", "SAVE TABLE COUNT TO DB");
                    // save to database
                    if (RunningSite.imsSQL.QC_saveTableCountFromPO_Before(oPO.Tables))
                    {
                        if (RunningSite.imsSQL.PO_setFinish_Before())
                        {
                            imsLOG.LogToScreen_Action("PO:BEFORE", "ALL TABLECOUNT IS SAVED  TO DB");
                        }
                    }
                }


                bStatus = true;
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("Exeption", ex.Message, ex.Source, ex.StackTrace, "MainQualityChecker:PO_getTableCount");
            }

            return bStatus;
        }

    } // Class MainQualityChecker
} // Namespace Intersoft_ProjectOnline_QC_2017
