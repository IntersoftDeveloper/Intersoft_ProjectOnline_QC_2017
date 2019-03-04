using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Intersoft_ProjectOnline_QC_2017
{
    class HelperSQL
    {
        SqlConnection DestConnection;
        HelperLog imsLOG = new HelperLog();
        
        
        // Settings for each site
        public DBSiteSettings oCurrent { get; set; }

        /// <summary>
        /// Test connections string
        /// </summary>
        /// <param name="testConnectionString"></param>
        /// <returns>true, if connectionstring is ok</returns>
        public bool TEST_Connection_Settings(string testConnectionString)
        {
            bool bStatus = false;

            try
            {
                if (DestConnection == null)
                    { DestConnection = new SqlConnection(testConnectionString); }

                if (DestConnection.State == ConnectionState.Closed)
                {
                    DestConnection = new SqlConnection(testConnectionString);
                    DestConnection.Open();
                    bStatus = true;
                }
                else if (DestConnection.State == ConnectionState.Open)
                {
                    bStatus = true;
                }
            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: TEST_Connection_Settings");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: TEST_Connection_Settings");
            }


            return bStatus;
        }
        /// <summary>
        /// Open database connection
        /// </summary>
        /// <returns>true, if database is open</returns>
        public bool Open_Connection()
        {
            bool bStatus = false;

            try
            {
                if(oCurrent== null)
                {
                    return false;
                }
                
                if (DestConnection == null)
                { DestConnection = new SqlConnection(oCurrent.QC_SITE_DBC); }

                if (DestConnection.State == ConnectionState.Closed)
                {
                    DestConnection = new SqlConnection(oCurrent.QC_SITE_DBC);
                    DestConnection.Open();
                    bStatus = true;
                }
                else if (DestConnection.State == ConnectionState.Open)
                {
                    bStatus = true;
                    
                }
            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                //imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: Open_Connection");
            }
            catch (Exception ex)
            {
                //imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: Open_Connection");
                //addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace,"");
            }

            oCurrent.Status_Database.Status = bStatus;
            return bStatus;
        }

        /// <summary>
        /// Close connection to database
        /// </summary>
        /// <returns></returns>
        public bool Close_Connection()
        {
            bool bStatus = false;

            if (DestConnection != null && DestConnection.State == ConnectionState.Open)
            {
                DestConnection.Close();
                bStatus = true;
            }
            return bStatus;
        }

        /// <summary>
        ///  Get the latest opExId
        /// </summary>
        /// <returns></returns>
        public LastRunStatus getOpExId()
        {
            LastRunStatus tmpStatus = null;

            if (Open_Connection())
            {
                try
                {
                    DataSet ds = new DataSet();
                    string sqlstr = "SELECT * FROM [dbo].[imsLastRefresh]";
                    SqlDataAdapter ws_sql_adapter = new SqlDataAdapter(sqlstr, DestConnection);

                    ws_sql_adapter.Fill(ds, "imsLastRefresh");
                    DataTable dt = ds.Tables["imsLastRefresh"];
                    tmpStatus = new LastRunStatus();



                    if (dt.Rows.Count > 0)
                    {
                        // Report schema refresh
                        object _SchemaLastRefresh = DBConvert.To<DateTime?>(dt.Rows[0]["SchemaLastRefresh"]);
                        object _OpExId = DBConvert.To<int?>( dt.Rows[0]["OpExId"]);

                        if (_OpExId != null)
                        { tmpStatus.OpExId = (int)_OpExId; }
                        else
                        { tmpStatus.OpExId = 99; }

                        if (_SchemaLastRefresh != null)
                        { tmpStatus.LastRefresh = (DateTime)_SchemaLastRefresh; }
                        else
                        { tmpStatus.LastRefresh = new DateTime(2000, 1, 1); }

                        // History
                        object _History_LastRefresh_Date = DBConvert.To<DateTime?>(dt.Rows[0]["History_LastRefresh_Date"]);
                        object _History_OpExId = DBConvert.To<int?>(dt.Rows[0]["History_OpExId"]);

                        if (_History_OpExId != null)
                        { tmpStatus.History_OpExId = (int)_History_OpExId; }
                        else
                        { tmpStatus.History_OpExId = 89; }

                        if (_History_LastRefresh_Date != null)
                        { tmpStatus.History_LastRefresh = (DateTime)_History_LastRefresh_Date; }
                        else
                        { tmpStatus.History_LastRefresh = new DateTime(2000, 1, 1); }


                        // Download
                        object _Download_LastRefresh_Date = DBConvert.To<DateTime?>(dt.Rows[0]["Download_LastRefresh_Date"]);
                        object _Download_OpExId = DBConvert.To<int?>(dt.Rows[0]["Download_OpExId"]);

                        if (_Download_OpExId != null)
                        { tmpStatus.Download_OpExId = (int)_Download_OpExId; }
                        else
                        { tmpStatus.Download_OpExId = 79; }

                        if (_Download_LastRefresh_Date != null)
                        { tmpStatus.Download_LastRefresh = (DateTime)_Download_LastRefresh_Date; }
                        else
                        { tmpStatus.Download_LastRefresh = new DateTime(2000, 1, 1); }

                    }
                }
                catch (SqlException ex)
                {
                    addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                    imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getOpExId");
                }
                catch (Exception ex)
                {
                    imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getOpExId");
                }

            }

            return tmpStatus;

        }

        /// <summary>
        /// Test connection to database
        /// </summary>
        /// <returns></returns>
        public bool Connection_Test()
        {
            bool bStatus = false;

            try
            {

                if (Open_Connection())
                {
                    bStatus = true;
                }
            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: Connection_Test");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: Connection_Test");
            }

            return bStatus;
        }

        /// <summary>
        /// Logg error to database
        /// </summary>
        /// <param name="exType"></param>
        /// <param name="exMessage"></param>
        /// <param name="exSource"></param>
        /// <param name="exStacktrace"></param>
        /// <param name="exNotes"></param>
        /// <returns></returns>
        public bool addError(string exType, string exMessage, string exSource, string exStacktrace, string exNotes)
        {
            bool bStatus = false;

            try
            {
                if (Open_Connection())
                {
                    // Connection is ready


                    SqlCommand cmd = new SqlCommand("[dbo].[imsAppEvent_addToErrorLog]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    /// validere felter
                    /// Kjør stored proc : [Timesaldo_createUserInStatic]

                    SqlParameter param1 = new SqlParameter();
                    param1 = cmd.Parameters.Add("@AppName", System.Data.SqlDbType.NVarChar);
                    param1.Direction = System.Data.ParameterDirection.Input;
                    param1.Value = oCurrent.AppSet.AppName;

                    SqlParameter param2 = new SqlParameter();
                    param2 = cmd.Parameters.Add("@AppEvent", System.Data.SqlDbType.NVarChar);
                    param2.Direction = System.Data.ParameterDirection.Input;
                    param2.Value = oCurrent.AppSet.AppEvent;

                    SqlParameter param3 = new SqlParameter();
                    param3 = cmd.Parameters.Add("@exSource", System.Data.SqlDbType.NVarChar);
                    param3.Direction = System.Data.ParameterDirection.Input;
                    param3.Value = exSource;

                    SqlParameter param4 = new SqlParameter();
                    param4 = cmd.Parameters.Add("@exType", System.Data.SqlDbType.NVarChar);
                    param4.Direction = System.Data.ParameterDirection.Input;
                    param4.Value = exType;

                    SqlParameter param5 = new SqlParameter();
                    param5 = cmd.Parameters.Add("@exMessage", System.Data.SqlDbType.NVarChar);
                    param5.Direction = System.Data.ParameterDirection.Input;
                    param5.Value = exMessage;

                    SqlParameter param6 = new SqlParameter();
                    param6 = cmd.Parameters.Add("@exStackTrace", System.Data.SqlDbType.NText);
                    param6.Direction = System.Data.ParameterDirection.Input;
                    param6.Value = exStacktrace;

                    SqlParameter param7 = new SqlParameter();
                    param7 = cmd.Parameters.Add("@Notes", System.Data.SqlDbType.NVarChar);
                    param7.Direction = System.Data.ParameterDirection.Input;
                    param7.Value = exNotes;

                    cmd.ExecuteNonQuery();

                    bStatus = true;
                }

            }

            catch (Exception ex)
            {
                imsLOG.LogToScreen_Action(ex.Message, "imssql:addError");
            }

            return bStatus;
        }

        public bool setFinishReportRun()
        {
            bool bStatus = false;
            try
            {
                if (Open_Connection())
                {
                    // Connection is ready
                    SqlCommand cmd = new SqlCommand("[dbo].[imsAppEvent_setReadyToRun]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    /// validere felter
                    /// Kjør stored proc : [Timesaldo_createUserInStatic]

                    SqlParameter param1 = new SqlParameter();
                    param1 = cmd.Parameters.Add("@AppEvent", System.Data.SqlDbType.NVarChar);
                    param1.Direction = System.Data.ParameterDirection.Input;
                    param1.Value = oCurrent.AppSet.AppEvent;

                    SqlParameter param2 = new SqlParameter();
                    param2 = cmd.Parameters.Add("@AppName", System.Data.SqlDbType.NVarChar);
                    param2.Direction = System.Data.ParameterDirection.Input;
                    param2.Value = oCurrent.AppSet.AppName;

                    SqlParameter param3 = new SqlParameter();
                    param3 = cmd.Parameters.Add("@AppEventReadyToRun", System.Data.SqlDbType.Int);
                    param3.Direction = System.Data.ParameterDirection.Input;
                    param3.Value = -1;

                    cmd.ExecuteNonQuery();

                    bStatus = true;


                }
            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: setFinishReportRun");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: setFinishReportRun");
            }

            return bStatus;
        }

        public bool setQC_RunningApp()
        {
            bool bStatus = false;
            try
            {
                if (Open_Connection())
                {

                    SqlCommand cmd = new SqlCommand("[dbo].[imsAppEvent_setReadyToRun]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SqlParameter param1 = new SqlParameter();
                    param1 = cmd.Parameters.Add("@AppEvent", System.Data.SqlDbType.NVarChar);
                    param1.Direction = System.Data.ParameterDirection.Input;
                    param1.Value = oCurrent.AppSet.AppEvent;

                    SqlParameter param2 = new SqlParameter();
                    param2 = cmd.Parameters.Add("@AppName", System.Data.SqlDbType.NVarChar);
                    param2.Direction = System.Data.ParameterDirection.Input;
                    param2.Value = oCurrent.AppSet.AppName;

                    SqlParameter param3 = new SqlParameter();
                    param3 = cmd.Parameters.Add("@AppEventReadyToRun", System.Data.SqlDbType.Int);
                    param3.Direction = System.Data.ParameterDirection.Input;
                    param3.Value = 2;

                    cmd.ExecuteNonQuery();

                    bStatus = true;
                }
            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: setQC_RunningApp");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: setQC_RunningApp");
            }

            return bStatus;
        }

        public bool setQC_StartApp()
        {
            bool bStatus = false;
            try
            {
                if (Open_Connection())
                {

                    SqlCommand cmd = new SqlCommand("[dbo].[imsAppEvent_setReadyToRun]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SqlParameter param1 = new SqlParameter();
                    param1 = cmd.Parameters.Add("@AppEvent", System.Data.SqlDbType.NVarChar);
                    param1.Direction = System.Data.ParameterDirection.Input;
                    param1.Value = oCurrent.AppSet.AppEvent;

                    SqlParameter param2 = new SqlParameter();
                    param2 = cmd.Parameters.Add("@AppName", System.Data.SqlDbType.NVarChar);
                    param2.Direction = System.Data.ParameterDirection.Input;
                    param2.Value = oCurrent.AppSet.AppName;

                    SqlParameter param3 = new SqlParameter();
                    param3 = cmd.Parameters.Add("@AppEventReadyToRun", System.Data.SqlDbType.Int);
                    param3.Direction = System.Data.ParameterDirection.Input;
                    param3.Value = 5500;

                    cmd.ExecuteNonQuery();

                    bStatus = true;
                }
            }
            catch (SqlException ex)
            {
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: setQC_StartApp");
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: setQC_StartApp");
            }

            return bStatus;
        }

        public bool setQC_ForceRunQualityCheckApp()
        {
            bool bStatus = false;
            try
            {
                if (Open_Connection())
                {

                    SqlCommand cmd = new SqlCommand("[dbo].[imsAppEvent_setReadyToRun]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SqlParameter param1 = new SqlParameter();
                    param1 = cmd.Parameters.Add("@AppEvent", System.Data.SqlDbType.NVarChar);
                    param1.Direction = System.Data.ParameterDirection.Input;
                    param1.Value = oCurrent.AppSet.AppEvent;

                    SqlParameter param2 = new SqlParameter();
                    param2 = cmd.Parameters.Add("@AppName", System.Data.SqlDbType.NVarChar);
                    param2.Direction = System.Data.ParameterDirection.Input;
                    param2.Value = oCurrent.AppSet.AppName;

                    SqlParameter param3 = new SqlParameter();
                    param3 = cmd.Parameters.Add("@AppEventReadyToRun", System.Data.SqlDbType.Int);
                    param3.Direction = System.Data.ParameterDirection.Input;
                    param3.Value = 5000;

                    cmd.ExecuteNonQuery();

                    bStatus = true;
                }
            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: setQC_RunningApp");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: setQC_RunningApp");
            }

            return bStatus;
        }

        public bool addDailyResult(ReportTableTest oTable)
        {
            bool bStatus = false;
            try
            {
                if (Open_Connection())
                {
                    // Connection is ready

                    LastRunStatus tmpStatus = getOpExId();

                    SqlCommand cmd = new SqlCommand("[dbo].[imsQC_addDailyResult]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    /// validere felter
                    /// Kjør stored proc : [Timesaldo_createUserInStatic]

                    SqlParameter param1 = new SqlParameter();
                    param1 = cmd.Parameters.Add("@Tablename", System.Data.SqlDbType.NVarChar);
                    param1.Direction = System.Data.ParameterDirection.Input;
                    param1.Value = oTable.Tablename;

                    SqlParameter param2 = new SqlParameter();
                    param2 = cmd.Parameters.Add("@Daystart_Count", System.Data.SqlDbType.Int);
                    param2.Direction = System.Data.ParameterDirection.Input;
                    param2.Value = oTable.PO_Daystart_Count;

                    SqlParameter param3 = new SqlParameter();
                    param3 = cmd.Parameters.Add("@Daystart_Test1", System.Data.SqlDbType.Decimal);
                    param3.Direction = System.Data.ParameterDirection.Input;
                    param3.Value = oTable.Test1.PO_Daystart_Test;

                    SqlParameter param4 = new SqlParameter();
                    param4 = cmd.Parameters.Add("@Daystart_Test2", System.Data.SqlDbType.Decimal);
                    param4.Direction = System.Data.ParameterDirection.Input;
                    param4.Value = oTable.Test2.PO_Daystart_Test;

                    SqlParameter param5 = new SqlParameter();
                    param5 = cmd.Parameters.Add("@Runtime", System.Data.SqlDbType.DateTime);
                    param5.Direction = System.Data.ParameterDirection.Input;
                    param5.Value = oTable.OPRuntime;

                    SqlParameter param6 = new SqlParameter();
                    param6 = cmd.Parameters.Add("@OPEXID", System.Data.SqlDbType.Int);
                    param6.Direction = System.Data.ParameterDirection.Input;
                    param6.Value = tmpStatus.Download_OpExId;

                    SqlParameter param7 = new SqlParameter();
                    param7 = cmd.Parameters.Add("@OPTimestamp", System.Data.SqlDbType.DateTime);
                    param7.Direction = System.Data.ParameterDirection.Input;
                    param7.Value = tmpStatus.Download_LastRefresh;

                    cmd.ExecuteNonQuery();

                    
                    bStatus = true;
                }

            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: addDailyResult");
            }
            catch (Exception ex)
            { 
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: addDailyResult");
            }

            return bStatus;
        }

        /// <summary>
        /// Checking status for running reports
        /// </summary>
        /// <returns></returns>
        public int getStartReportRun()
        {
            Int32 tmpStatus = -1;

            try
            {
                if (Open_Connection())
                {
                    // Connection is ready

                    SqlCommand cmd = new SqlCommand("[dbo].[imsAppEvent_getReadyToRun]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    /// validere felter
                    /// Kjør stored proc : [Timesaldo_createUserInStatic]

                    SqlParameter param1 = new SqlParameter();
                    param1 = cmd.Parameters.Add("@AppEvent", System.Data.SqlDbType.NVarChar);
                    param1.Direction = System.Data.ParameterDirection.Input;
                    param1.Value = oCurrent.AppSet.AppEvent;

                    SqlParameter param2 = new SqlParameter();
                    param2 = cmd.Parameters.Add("@AppName", System.Data.SqlDbType.NVarChar);
                    param2.Direction = System.Data.ParameterDirection.Input;
                    param2.Value = oCurrent.AppSet.AppName;

                    SqlParameter param3 = new SqlParameter();
                    param3 = cmd.Parameters.Add("@Status", System.Data.SqlDbType.Int);
                    param3.Direction = System.Data.ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    if (!DBNull.Value.Equals(cmd.Parameters["@Status"].Value))
                    {
                        tmpStatus = Convert.ToInt32(cmd.Parameters["@Status"].Value);
                    }
                    else
                    {
                        tmpStatus = -99;
                    }

                }
            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getStartReportRun");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getStartReportRun");
            }

            return tmpStatus;
        }

        /// <summary>
        /// Get status from Timesaldo synkroniseringsapplikasjon
        /// 
        /// </summary>
        /// <returns></returns>
        public int getIMS_PTS_StatusCheck()
        {
            Int32 tmpStatus = -1;

            try
            {
                if (Open_Connection())
                {
                    // Connection is ready

                    SqlCommand cmd = new SqlCommand("[dbo].[imsAppEvent_getReadyToRun]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    /// validere felter
                    /// Kjør stored proc : [Timesaldo_createUserInStatic]

                    SqlParameter param1 = new SqlParameter();
                    param1 = cmd.Parameters.Add("@AppEvent", System.Data.SqlDbType.NVarChar);
                    param1.Direction = System.Data.ParameterDirection.Input;
                    param1.Value = oCurrent.AppSet.PTR_AppEvent;

                    SqlParameter param2 = new SqlParameter();
                    param2 = cmd.Parameters.Add("@AppName", System.Data.SqlDbType.NVarChar);
                    param2.Direction = System.Data.ParameterDirection.Input;
                    param2.Value = oCurrent.AppSet.PTR_AppName;

                    SqlParameter param3 = new SqlParameter();
                    param3 = cmd.Parameters.Add("@Status", System.Data.SqlDbType.Int);
                    param3.Direction = System.Data.ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    
                    tmpStatus = DBConvert.To<Int32>(cmd.Parameters["@Status"].Value);

                }
            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getIMS_PTS_StatusCheck");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getIMS_PTS_StatusCheck");
            }

            return tmpStatus;
        }

        /// <summary>
        /// Checking status of Project Reports Refresh
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public int getIMS_PRR_StatusCheck()
        {
            Int32 tmpStatus = -1;

            try
            {
                if (Open_Connection())
                {
                    // Connection is ready

                    SqlCommand cmd = new SqlCommand("[dbo].[imsAppEvent_getReadyToRun]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    /// validere felter
                    /// Kjør stored proc : [Timesaldo_createUserInStatic]

                    SqlParameter param1 = new SqlParameter();
                    param1 = cmd.Parameters.Add("@AppEvent", System.Data.SqlDbType.NVarChar);
                    param1.Direction = System.Data.ParameterDirection.Input;
                    param1.Value = oCurrent.AppSet.PRR_AppEvent;

                    SqlParameter param2 = new SqlParameter();
                    param2 = cmd.Parameters.Add("@AppName", System.Data.SqlDbType.NVarChar);
                    param2.Direction = System.Data.ParameterDirection.Input;
                    param2.Value = oCurrent.AppSet.PRR_AppName;

                    SqlParameter param3 = new SqlParameter();
                    param3 = cmd.Parameters.Add("@Status", System.Data.SqlDbType.Int);
                    param3.Direction = System.Data.ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    tmpStatus = DBConvert.To<Int32>(cmd.Parameters["@Status"].Value);

                }
            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getIMS_PRR_StatusCheck");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getIMS_PRR_StatusCheck");
            }
            return tmpStatus;
        }

        /// <summary>
        /// Checking status of Project online data download
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public int getIMS_POD_StatusCheck()
        {
            Int32 tmpStatus = -1;

            try
            {
                if (Open_Connection())
                {
                    // Connection is ready

                    SqlCommand cmd = new SqlCommand("[dbo].[imsAppEvent_getReadyToRun]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    /// validere felter
                    /// Kjør stored proc : [Timesaldo_createUserInStatic]

                    SqlParameter param1 = new SqlParameter();
                    param1 = cmd.Parameters.Add("@AppEvent", System.Data.SqlDbType.NVarChar);
                    param1.Direction = System.Data.ParameterDirection.Input;
                    param1.Value = oCurrent.AppSet.POD_AppEvent;

                    SqlParameter param2 = new SqlParameter();
                    param2 = cmd.Parameters.Add("@AppName", System.Data.SqlDbType.NVarChar);
                    param2.Direction = System.Data.ParameterDirection.Input;
                    param2.Value = oCurrent.AppSet.POD_AppName;

                    SqlParameter param3 = new SqlParameter();
                    param3 = cmd.Parameters.Add("@Status", System.Data.SqlDbType.Int);
                    param3.Direction = System.Data.ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    tmpStatus = DBConvert.To<Int32>(cmd.Parameters["@Status"].Value);

                }
            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getIMS_POD_StatusCheck");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getIMS_POD_StatusCheck");
            }
            return tmpStatus;
        }

        /// <summary>
        /// Copy today result into 
        /// </summary>
        /// <returns></returns>
        public bool CopyTodayToYesterday()
        {
            bool bStatus = false;

            try
            {
                if (Open_Connection())
                {
                    // Connection is ready
                    imsLOG.LogToScreen_Action("CopyTodayToYesterday", "Start copy from today -> yesterday");

                    SqlCommand cmd = new SqlCommand("[dbo].[imsQC_CopyTodayToYesterday]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    
                    cmd.ExecuteNonQuery();


                    imsLOG.LogToScreen_Action("CopyTodayToYesterday", "Start copy from today -> yesterday - [OK]");
                    bStatus = true;
                }

            }

            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: CopyTodayToYesterday");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: CopyTodayToYesterday");
            }

            return bStatus;
        }
        
        /// <summary>
        /// Check if result is goood
        ///
        /// </summary>
        /// <returns>1- if good, 0 - do not copy</returns>
        public StatusCopy ReadyToCopy()
        {
            
            StatusCopy tmpStatus = new StatusCopy() ;

            try
            {
                if (Open_Connection())
                {
                    // Connection is ready
                    DataSet ds = new DataSet();
                    string sqlstr = "[dbo].[imsQC_ReadyToCopy]";
                    SqlDataAdapter ws_sql_adapter = new SqlDataAdapter(sqlstr, DestConnection);

                    ws_sql_adapter.Fill(ds, "StatusCopy");
                    DataTable dt = ds.Tables["StatusCopy"];
                    tmpStatus = new StatusCopy();



                    if (dt.Rows.Count > 0)
                    {
                        // get values
                        tmpStatus.ReadyToCopy = dt.Rows[0].Field<Int32>(0);
                        tmpStatus.Result = dt.Rows[0].Field<Int32>(1);
                        tmpStatus.RunTime = dt.Rows[0].Field<DateTime>(2);
                    }
                    
                }

            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: ReadyToCopy");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: ReadyToCopy");
            }

            return tmpStatus;
        }

        /// <summary>
        /// If readytocopy returns 1 then copy stage schema to production schema
        /// </summary>
        /// <returns>1- all ok, 0 - somethings wrong</returns>
        public bool Copy_Stage_To_Reporting()
        {
            bool bStatus = false;

            try
            {
                if (Open_Connection())
                {
                    // Connection is ready

                    imsLOG.LogToScreen_Action("Copy_Stage_To_Reporting", "Start copy tables");

                    SqlCommand cmd = new SqlCommand("[stage].[PROD_Copy_ALL_Tables]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;
                    cmd.ExecuteNonQuery();

                    imsLOG.LogToScreen_Action("Copy_Stage_To_Reporting", "Start copy tables - [OK]");

                    bStatus = true;
                }

            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: Copy_Stage_To_Reporting");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: Copy_Stage_To_Reporting");
            }

            return bStatus;
        }
        /// <summary>
        /// Getting history on selected tables that are defined in table settings.
        /// </summary>
        /// <returns></returns>
        public bool getHistoryBetween_Stage_and_Reporting()
        {
            bool bStatus = false;

            try
            {
                if (Open_Connection())
                {
                    // Connection is ready

                    imsLOG.LogToScreen_Action("Copy stage to production", "IMSSQL: Make history between stage and reporting");

                    //SqlCommand cmd = new SqlCommand("[history].[Compare_All_Tables]", DestConnection);
                    
                    SqlCommand cmd = new SqlCommand("[history].[getHistoryOnTableALL]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;
                    cmd.ExecuteNonQuery();


                    bStatus = true;
                }

            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getHistoryBetween_Stage_and_Reporting");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getHistoryBetween_Stage_and_Reporting");
            }

            return bStatus;
        }
        public bool CopyResultToHistory()
        {
            bool bStatus = false;

            try
            {
                if (Open_Connection())
                {
                    // Connection is ready


                    SqlCommand cmd = new SqlCommand("[dbo].[imsQC_CopyResultToHistory]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;


                    cmd.ExecuteNonQuery();

                    bStatus = true;
                }

            }

            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: CopyResultToHistory");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: CopyResultToHistory");
            }

            return bStatus;
        }

        /// <summary>
        /// Saving settings to database
        /// </summary>
        /// <param name="tmpSettings"></param>
        /// <returns></returns>
        public bool setPOSiteSettings(POSiteSettings tmpSettings)
        {
            bool bStatus = false;



            return bStatus;
        }

        /// <summary>
        /// Getting settings from database
        /// </summary>
        /// <param name="tmpSettings"></param>
        /// <returns></returns>
        public bool getPoSiteSettings(POSiteSettings tmpSettings)
        {
            bool bStatus = false;
            
            string sSQL = "SELECT TOP 1 [Environment_Id]"
                + " ,[Environment]"
                + " ,[Environment_Description]"
                + " ,[PO_SITE]"
                + " ,[PO_Username]"
                + " ,[PO_Password]"
                + " ,[PWA_Site]"
                + " ,[QC_UseExcelQuality]"
                + " ,[QC_Filename]"
                + " ,[QC_Filepath]"
                + " ,[JobMailAlerts]"
                + " ,[PO_Module_ReportRefresh]"
                + " ,[PO_Module_Timesaldo]"
                + " ,[PO_Module_History]"
            + " FROM [ims].[imsAppSiteSettings]";

            if (Open_Connection())
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DestConnection;
                cmd.CommandTimeout = 600;
                cmd.CommandText = sSQL;
                

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        tmpSettings.Enviromentname = DBHelper.GetValue<string>(reader, "Environment");
                        tmpSettings.PO_Site = DBHelper.GetValue<string>(reader, "PO_SITE");
                        tmpSettings.PO_Username = DBHelper.GetValue<string>(reader, "PO_Username");
                        tmpSettings.PO_Password = DBHelper.GetValue<string>(reader, "PO_Password");

                        tmpSettings.PO_Module_ReportRefresh = DBHelper.GetValue<int>(reader, "PO_Module_ReportRefresh");
                        tmpSettings.PO_Module_Timesaldo = DBHelper.GetValue<int>(reader, "PO_Module_Timesaldo");
                        tmpSettings.PO_Module_History = DBHelper.GetValue<int>(reader, "PO_Module_History");

                        tmpSettings.QC_Filepath = DBHelper.GetValue<string>(reader, "QC_Filepath");
                        tmpSettings.QC_Filename = DBHelper.GetValue<string>(reader, "QC_Filename");

                        tmpSettings.QC_MailTo = DBHelper.GetValue<string>(reader, "JobMailAlerts");
                        tmpSettings.PO_SettingsIsLoaded = true;

                    }

                    reader.Close();

                    bStatus = true;
                }
                catch (SqlException ex)
                {
                    addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                    imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getPoSiteSettings");
                }
                catch (Exception ex)
                {
                    imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: getPoSiteSettings");
                }

                DestConnection.Close();

                
            }

            return bStatus;
        }

        /// <summary>
        /// Getting result of table QualityView
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public DataTable QCResults(int Status)
        {
            // Holds value from database
            DataTable tmpTable = new DataTable();
            if (Open_Connection())
            {

                try
                {

                    DataSet ds = new DataSet();
                    string sqlstr = "";

                    if (Status == -1)
                    {
                        sqlstr = "SELECT * FROM [dbo].[imsQCToday]";
                    }
                    else
                    {
                        sqlstr = "SELECT * FROM [dbo].[imsQCToday]";
                        sqlstr += " WHERE [Table_Result] = " + Status.ToString();
                    }
                    SqlDataAdapter ws_sql_adapter = new SqlDataAdapter(sqlstr, DestConnection);

                    ws_sql_adapter.Fill(ds, "QC_Result");
                    tmpTable = ds.Tables["QC_Result"];
                    
                }
                catch(SqlException ex)
                {
                    // If error add to database
                    addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                }
            }

            return tmpTable;


        }// QCResults
        public DataTable QCDailyResult()
        {
            // Holds value from database
            DataTable tmpTable = new DataTable();
            if (Open_Connection())
            {

                try
                {

                    DataSet ds = new DataSet();
                    string sqlstr = "";

                    
                    sqlstr = "SELECT * FROM [dbo].[imsQC_DailyResult]";
                    
                    SqlDataAdapter ws_sql_adapter = new SqlDataAdapter(sqlstr, DestConnection);

                    ws_sql_adapter.Fill(ds, "QC_DailyResult");
                    tmpTable = ds.Tables["QC_DailyResult"];

                }
                catch (SqlException ex)
                {
                    // If error add to database
                    addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                }
            }

            return tmpTable;


        }// QCDailyResult

        public DataTable QCErrorlog()
        {
            // Holds value from database
            DataTable tmpTable = new DataTable();
            if (Open_Connection())
            {

                try
                {

                    DataSet ds = new DataSet();
                    string sqlstr = "";


                    sqlstr = "SELECT * FROM [dbo].[SSISErrorLog]";

                    SqlDataAdapter ws_sql_adapter = new SqlDataAdapter(sqlstr, DestConnection);

                    ws_sql_adapter.Fill(ds, "QC_Errorlog");
                    tmpTable = ds.Tables["QC_Errorlog"];

                }
                catch (SqlException ex)
                {
                    // If error add to database
                    addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                }
            }

            return tmpTable;


        }// QCErrorlog

        public DataTable QCShowReportingTotal()
        {
            // [log].[History_Reporting_State_Total]
            // Holds value from database
            DataTable tmpTable = new DataTable();
            if (Open_Connection())
            {

                try
                {

                    DataSet ds = new DataSet();
                    string sqlstr = "";


                    sqlstr = "SELECT * FROM [log].[History_Reporting_State_Total] ORDER BY opRunTime DESC";

                    SqlDataAdapter ws_sql_adapter = new SqlDataAdapter(sqlstr, DestConnection);

                    ws_sql_adapter.Fill(ds, "QC_ReportingStatelog");
                    tmpTable = ds.Tables["QC_ReportingStatelog"];

                }
                catch (SqlException ex)
                {
                    // If error add to database
                    addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                }
            }

            return tmpTable;
        }

        public DataTable QCShowCount(string sSchema)
        {
            // [log].[History_Reporting_State_Total]
            // Holds value from database
            DataTable tmpTable = new DataTable();
            if (Open_Connection())
            {

                try
                {

                    DataSet ds = new DataSet();
                    string sqlstr = "";

                    switch (sSchema.ToUpper())
                    {
                        case "DBO":
                            {
                                sqlstr = "EXEC [dbo].[Log_Table_RowsCount_Real_DBO]";
                                break;
                            }
                        case "STAGE":
                            {
                                sqlstr = "EXEC [dbo].[Log_Table_RowsCount_Real_Stage]";
                                break;
                            }
                        case "HISTORY":
                            {
                                sqlstr = "EXEC [dbo].[Log_Table_RowsCount_Real_History]";
                                break;
                            }
                    }
                

                    //sqlstr = "EXEC [dbo].[Log_Table_RowsCount_Real_DBO]";

                    SqlDataAdapter ws_sql_adapter = new SqlDataAdapter(sqlstr, DestConnection);

                    ws_sql_adapter.Fill(ds, "QC_Rowcount");
                    tmpTable = ds.Tables["QC_Rowcount"];

                }
                catch (SqlException ex)
                {
                    // If error add to database
                    addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                }
            }

            return tmpTable;
        }
        public DataTable QC_Checksum_History()
        {
            //imsOC_Checksum_History
            // [dbo].[imsOC_Checksum_History]
            // Holds value from database
            DataTable tmpTable = new DataTable();
            if (Open_Connection())
            {

                try
                {

                    DataSet ds = new DataSet();
                    string sqlstr = "";


                    sqlstr = "SELECT * FROM [dbo].[imsOC_Checksum_History] ORDER BY Tablename ASC";

                    SqlDataAdapter ws_sql_adapter = new SqlDataAdapter(sqlstr, DestConnection);

                    ws_sql_adapter.Fill(ds, "QC_ReportingStatelog");
                    tmpTable = ds.Tables["QC_ReportingStatelog"];

                }
                catch (SqlException ex)
                {
                    // If error add to database
                    addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                }
            }

            return tmpTable;
        }

        public DataTable QC_History_Settings()
        {
            //imsOC_Checksum_History
            // [dbo].[imsOC_Checksum_History]
            // Holds value from database
            DataTable tmpTable = new DataTable();
            if (Open_Connection())
            {

                try
                {

                    DataSet ds = new DataSet();
                    string sqlstr = "";


                    sqlstr = "SELECT * FROM [ims].[History_Table_Settings] ORDER BY Tablename ASC";

                    SqlDataAdapter ws_sql_adapter = new SqlDataAdapter(sqlstr, DestConnection);

                    ws_sql_adapter.Fill(ds, "QC_ReportingStatelog");
                    tmpTable = ds.Tables["QC_ReportingStatelog"];

                }
                catch (SqlException ex)
                {
                    // If error add to database
                    addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                }
            }

            return tmpTable;
        }
        public DataTable QC_AppEvent_Settings()
        {
            //imsOC_Checksum_History
            // [dbo].[imsOC_Checksum_History]
            // Holds value from database
            DataTable tmpTable = new DataTable();
            if (Open_Connection())
            {

                try
                {

                    DataSet ds = new DataSet();
                    string sqlstr = "";


                    sqlstr = "SELECT * FROM [dbo].[imsAppEvents]";

                    SqlDataAdapter ws_sql_adapter = new SqlDataAdapter(sqlstr, DestConnection);

                    ws_sql_adapter.Fill(ds, "QC_ReportingStatelog");
                    tmpTable = ds.Tables["QC_ReportingStatelog"];

                }
                catch (SqlException ex)
                {
                    // If error add to database
                    addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                }
            }

            return tmpTable;
        }
        public bool ReRun_QualityCheck()
        {

            return true;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QC_saveTableCountFromPO(HashSet<poTable> loTables)
        {
            bool bStatus = false;
            // Get table by table and save count to DB

            //[ims].[PO_TableCountAdd]

            try
            {
                if (Open_Connection())
                {
                    LastRunStatus tmpStatus = getOpExId();

                     
                    foreach (poTable oTable in loTables)
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("[ims].[PO_TableCountAdd]", DestConnection);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;

                            SqlParameter param1 = new SqlParameter();
                            param1 = cmd.Parameters.Add("@Tablename", System.Data.SqlDbType.NVarChar);
                            param1.Direction = System.Data.ParameterDirection.Input;
                            param1.Value = oTable.TableName;

                            SqlParameter param2 = new SqlParameter();
                            param2 = cmd.Parameters.Add("@Tablecount", System.Data.SqlDbType.Int);
                            param2.Direction = System.Data.ParameterDirection.Input;
                            param2.Value = oTable.TableCount;

                            cmd.ExecuteNonQuery();

                        }
                        catch (SqlException ex)
                        {
                            addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                            imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: CopyResultToHistory");
                        }
                        catch (Exception ex)
                        {
                            imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: CopyResultToHistory");
                        }
                    }

                    bStatus = true;
                }

            }

            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: CopyResultToHistory");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: CopyResultToHistory");
            }


            return bStatus;
        }
        public bool QC_saveTableCountFromPO_Before(HashSet<poTable> loTables)
        {
            bool bStatus = false;
            // Get table by table and save count to DB

            try
            {
                if (Open_Connection())
                {
                    LastRunStatus tmpStatus = getOpExId();

                    foreach (poTable oTable in loTables)
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("[ims].[PO_BEFORE_TableCountAdd]", DestConnection);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;

                            SqlParameter param1 = new SqlParameter();
                            param1 = cmd.Parameters.Add("@Tablename", System.Data.SqlDbType.NVarChar);
                            param1.Direction = System.Data.ParameterDirection.Input;
                            param1.Value = oTable.TableName;

                            SqlParameter param2 = new SqlParameter();
                            param2 = cmd.Parameters.Add("@Tablecount", System.Data.SqlDbType.Int);
                            param2.Direction = System.Data.ParameterDirection.Input;
                            param2.Value = oTable.TableCount;

                            cmd.ExecuteNonQuery();

                        }
                        catch (SqlException ex)
                        {
                            addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                            imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: QC_saveTableCountFromPO_Before");
                        }
                        catch (Exception ex)
                        {
                            imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: QC_saveTableCountFromPO_Before");
                        }
                    }

                    bStatus = true;
                }

            }

            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: QC_saveTableCountFromPO_Before");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: QC_saveTableCountFromPO_Before");
            }


            return bStatus;
        }

        /// <summary>
        /// Save table to database
        /// </summary>
        /// <param name="loTables"></param>
        /// <returns></returns>
        public bool PO_saveTableNames(HashSet<poTable> loTables)
        {
            bool bStatus = false;
            // Get table by table and save count to DB
            //[ims].[PO_TableCountAdd]

            try
            {
                if (Open_Connection())
                {
                    LastRunStatus tmpStatus = getOpExId();


                    foreach (poTable oTable in loTables)
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("[ims].[PO_Table_Add]", DestConnection);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;

                            SqlParameter param1 = new SqlParameter();
                            param1 = cmd.Parameters.Add("@Tablename", System.Data.SqlDbType.NVarChar);
                            param1.Direction = System.Data.ParameterDirection.Input;
                            param1.Value = oTable.TableName;

                            

                            cmd.ExecuteNonQuery();

                        }
                        catch (SqlException ex)
                        {
                            addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                            imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: PO_saveTableName");
                        }
                        catch (Exception ex)
                        {
                            imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: PO_saveTableName");
                        }
                    }

                    bStatus = true;
                }

            }

            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: CopyResultToHistory");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: CopyResultToHistory");
            }


            return bStatus;
        }
        public bool PO_saveFieldNames(HashSet<poField> loFields)
        {
            bool bStatus = false;
            // Get table by table and save count to DB
            //[ims].[PO_TableCountAdd]

            try
            {
                if (Open_Connection())
                {
                    foreach (poField oField in loFields)
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("[ims].[PO_Table_Field_Add]", DestConnection);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;

                            SqlParameter param1 = new SqlParameter();
                            param1 = cmd.Parameters.Add("@Tablename", System.Data.SqlDbType.NVarChar);
                            param1.Direction = System.Data.ParameterDirection.Input;
                            param1.Value = oField.TableName;

                            SqlParameter param2 = new SqlParameter();
                            param2 = cmd.Parameters.Add("@Fieldname", System.Data.SqlDbType.NVarChar);
                            param2.Direction = System.Data.ParameterDirection.Input;
                            param2.Value = oField.Fieldname;

                            SqlParameter param3 = new SqlParameter();
                            param3 = cmd.Parameters.Add("@FieldUID", System.Data.SqlDbType.UniqueIdentifier);
                            param3.Direction = System.Data.ParameterDirection.Input;
                            param3.Value = oField.FieldGUid;

                            SqlParameter param4 = new SqlParameter();
                            param4 = cmd.Parameters.Add("@EntityName", System.Data.SqlDbType.NVarChar);
                            param4.Direction = System.Data.ParameterDirection.Input;
                            param4.Value = oField.EntityName;

                            SqlParameter param5 = new SqlParameter();
                            param5 = cmd.Parameters.Add("@IsNullable", System.Data.SqlDbType.Bit);
                            param5.Direction = System.Data.ParameterDirection.Input;
                            param5.Value = oField.Fieldnullable;

                            SqlParameter param6 = new SqlParameter();
                            param6 = cmd.Parameters.Add("@IsRequird", System.Data.SqlDbType.Bit);
                            param6.Direction = System.Data.ParameterDirection.Input;
                            param6.Value = oField.Fieldrequird;

                            SqlParameter param7 = new SqlParameter();
                            param7 = cmd.Parameters.Add("@FieldType", System.Data.SqlDbType.NVarChar);
                            param7.Direction = System.Data.ParameterDirection.Input;
                            param7.Value = oField.Fieldtype;

                            SqlParameter param8 = new SqlParameter();
                            param8 = cmd.Parameters.Add("@InternalName", System.Data.SqlDbType.NVarChar);
                            param8.Direction = System.Data.ParameterDirection.Input;
                            param8.Value = oField.InternalName;

                            SqlParameter param9 = new SqlParameter();
                            param9 = cmd.Parameters.Add("@IsCustomField", System.Data.SqlDbType.Bit);
                            param9.Direction = System.Data.ParameterDirection.Input;
                            param9.Value = oField.IsCustomfield;


                            cmd.ExecuteNonQuery();

                        }
                        catch (SqlException ex)
                        {
                            addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                            imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: PO_saveTableName");
                        }
                        catch (Exception ex)
                        {
                            imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: PO_saveTableName");
                        }
                    }

                    bStatus = true;
                }

            }

            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: PO_saveFieldNames");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: PO_saveFieldNames");
            }


            return bStatus;
        }
        public bool PO_setFinish_Before()
        {
            bool bStatus = false;
            try
            {
                if (Open_Connection())
                {

                    SqlCommand cmd = new SqlCommand("[dbo].[imsAppEvent_setReadyToRun]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;

                    SqlParameter param1 = new SqlParameter();
                    param1 = cmd.Parameters.Add("@AppEvent", System.Data.SqlDbType.NVarChar);
                    param1.Direction = System.Data.ParameterDirection.Input;
                    param1.Value = oCurrent.AppSet.AppEvent;

                    SqlParameter param2 = new SqlParameter();
                    param2 = cmd.Parameters.Add("@AppName", System.Data.SqlDbType.NVarChar);
                    param2.Direction = System.Data.ParameterDirection.Input;
                    param2.Value = oCurrent.AppSet.AppName;

                    SqlParameter param3 = new SqlParameter();
                    param3 = cmd.Parameters.Add("@AppEventReadyToRun", System.Data.SqlDbType.Int);
                    param3.Direction = System.Data.ParameterDirection.Input;
                    param3.Value = 2501;

                    cmd.ExecuteNonQuery();

                    bStatus = true;
                }
            }
            catch (SqlException ex)
            {
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: setQC_StartApp");
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: setQC_StartApp");
            }

            return bStatus;
        }

        public StatusCopy PO_ReadyToCopy()
        {

            StatusCopy tmpStatus = new StatusCopy();

            try
            {
                if (Open_Connection())
                {
                    // Connection is ready
                    DataSet ds = new DataSet();
                    string sqlstr = "[ims].[PO_ReadyToCopy]";
                    SqlDataAdapter ws_sql_adapter = new SqlDataAdapter(sqlstr, DestConnection);

                    ws_sql_adapter.Fill(ds, "StatusCopy");
                    DataTable dt = ds.Tables["StatusCopy"];
                    tmpStatus = new StatusCopy();



                    if (dt.Rows.Count > 0)
                    {
                        // get values
                        tmpStatus.ReadyToCopy = dt.Rows[0].Field<Int32>(0);
                        tmpStatus.Result = dt.Rows[0].Field<Int32>(1);
                        tmpStatus.RunTime = dt.Rows[0].Field<DateTime>(2);
                    }

                }

            }
            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: ReadyToCopy");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: ReadyToCopy");
            }

            return tmpStatus;
        }

        /// <summary>
        /// Copy todays result to yesterdays table
        /// 
        /// </summary>
        /// <returns>true- when ok, false- when fails </returns>
        public bool PO_ResultCopyFromTodayToYesterday()
        {
            bool bStatus = false;

            try
            {
                if (Open_Connection())
                {
                    // Connection is ready
                    imsLOG.LogToScreen_Action("PO CopyTodayToYesterday", "Start copy from today -> yesterday");

                    SqlCommand cmd = new SqlCommand("[ims].[PO_CopyTodayToYesterday]", DestConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;


                    cmd.ExecuteNonQuery();


                    imsLOG.LogToScreen_Action("PO CopyTodayToYesterday", "Start copy from today -> yesterday - [OK]");
                    bStatus = true;
                }

            }

            catch (SqlException ex)
            {
                addError("SQLExeption", ex.Message, ex.Source, ex.StackTrace, ex.Procedure);
                imsLOG.LogToDB_Error("SQL", ex.Message, ex.Source, ex.StackTrace, "Helpersql: PO_ResultCopyFromTodayToYesterday");
            }
            catch (Exception ex)
            {
                imsLOG.LogToDB_Error("", ex.Message, ex.Source, ex.StackTrace, "Helpersql: PO_ResultCopyFromTodayToYesterday");
            }

            return bStatus;
        }
    }// class HelperSQL
}// namespace Intersoft_ProjectOnline_QC_2017
