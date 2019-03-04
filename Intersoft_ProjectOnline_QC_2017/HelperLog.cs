using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace Intersoft_ProjectOnline_QC_2017
{
    /// <summary>
    /// Class to handle all around logging 
    /// Screen and database
    /// </summary>
    class HelperLog
    {
        public DBSiteSettings RunningSite { set; get; }
        public HelperSQL imsSQL = null;

        public Dictionary<int, LogItem> logItems = new Dictionary<int, LogItem>();
        public Dictionary<int, Logitem_Error> logErrorItems = new Dictionary<int, Logitem_Error>();
        /// <summary>
        /// Add log item to screen
        /// </summary>
        /// <param name="sAction"></param>
        /// <param name="sTopic"></param>
        public void LogToScreen_Action(string sAction, string sTopic)
        {
            frmQCReporting oForm = (frmQCReporting)Application.OpenForms["frmQCReporting"];
            //string tmpLog = "Topic: " + sTopic + " Action: " + sAction;

            oForm.grdRunStatus_Add(sAction, sTopic);
            oForm.Refresh();

        } // LogToScreen_Action

        public void StatusSubUpdate(int nStatus)
        {
            //IntersoftTimer oForm = (IntersoftTimer)Application.OpenForms["frmQCReporting"];

            //oForm.StatusSubUpdate(nStatus);
            //oForm.Refresh();

        } // StatusSubUpdate

        /// <summary>
        /// Add log to DB table
        /// </summary>
        public void LogToDB_Error(string exType, string exMessage, string exSource, string exStacktrace, string exNotes)
        {

            imsSQL = new HelperSQL();
            imsSQL.oCurrent = RunningSite;

            //imsSQL.oCurrent = oCurrent;

            if (imsSQL.addError(exType, exMessage, exSource, exStacktrace, exNotes))
            {
                // Error has been logged, log also to screen.

            }

            // Add error to screen

            frmQCReporting oForm = (frmQCReporting)Application.OpenForms["frmQCReporting"];
            //string tmpLog = "Topic: " + sTopic + " Action: " + sAction;

            oForm.grdRunStatus_Error(exSource,exMessage + ": " + exStacktrace);
            oForm.Refresh();

        } // LogToDB_Error

    }//Class: HelperLog
    
    class LogItem
    {
        public int LogType { get; set; } = -1;
        public string Site { get; set; } = "";
        public DateTime Date { get; set; }
        public string Topic { get; set; } = "";
        public string Action { get; set; } = "";
        public int Status { get; set; } = -1;
        public int Statusname { get; set; }


    }// class LogItem

    class Logitem_Error
    {
        public string Site { get; set; } = "";
        public DateTime Date { get; set; }
        public string exType { get; set; } = "";
        public string exMessage { get; set; } = "";
        public string exSource { get; set; } = "";
        public string exStacktrace { get; set; } = "";
        public string exNotes { get; set; } = "";
    }// class Logitem_Error
}// Namespace Intersoft_ProjectOnline_QC_2017
