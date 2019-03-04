using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersoft_ProjectOnline_QC_2017
{
    class ReportFieldTest
    {
        public decimal PO_Daystart_Test { get; set; }
        public string PO_Daystart_Test_Desc { get; set; }
    }
    class ReportTableTest
    {
        public string Tablename { get; set; }
        public decimal PO_Daystart_Count { get; set; }

        public ReportFieldTest Test1 { get; set; } = new ReportFieldTest();
        public ReportFieldTest Test2 { get; set; } = new ReportFieldTest();

        public long OPEXID_Previous { get; set; }
        public long OPEXID_Current { get; set; } = -1000;

        
        public DateTime OPRuntime { get; set; } = new DateTime(2001, 1, 1);

        public DateTime OPTimeStamp { get; set; } = new DateTime(2001, 1, 1);

        public string SQL_Save(DateTime dtUpdate)
        {


        /* 
         * SELECT TOP 1000[Tablename]
            ,[PO_Daystart_Count]
            ,[PO_Daystart_Test1]
            ,[PO_Daystart_Test1_Desc]
            ,[PO_Daystart_Test2]
            ,[PO_Daystart_Test2_Desc]
            ,[PO_Runtime]
            ,[OPEXID_Previous]
            ,[OPEXID_Current]
        FROM
            [PSO_Norgesgruppen_Prod_V2].[dbo].[imsQC_DailyResult]

            // Huske å hente siste opexid
        */
        string tmpSQL = "";

            tmpSQL = "INSERT INTO [dbo].[imsQC_DailyResult]";
            tmpSQL += " (";
            tmpSQL += " [Tablename] ";
            tmpSQL += " ,[PO_Daystart_Count]";
            tmpSQL += " ,[PO_Daystart_Test1]";
            //tmpSQL += " ,[PO_Daystart_Test1_Desc]";
            tmpSQL += " ,[PO_Daystart_Test2]";
            //tmpSQL += " ,[PO_Daystart_Test2_Desc]";
            tmpSQL += " ,[PO_Runtime]";
            tmpSQL += " )";

            tmpSQL += " Values";
            tmpSQL += "(";
            tmpSQL += " '" + this.Tablename + "'";
            tmpSQL += " ," + this.PO_Daystart_Count +"";
            tmpSQL += " ," + this.Test1.PO_Daystart_Test +"";
            //tmpSQL += " ,'" + this.Test1.PO_Daystart_Test_Desc +"'";
            tmpSQL += " ," + this.Test2.PO_Daystart_Test + "";
            //tmpSQL += " ,'" + this.Test2.PO_Daystart_Test_Desc + "'";
            tmpSQL += " ," + dtUpdate;
            tmpSQL += "(";

            return tmpSQL;

        }
    }

    /// <summary>
    /// Keeping result of all tables that is in Excel
    /// </summary>
    class ReportTables
    {
        public Dictionary<string, ReportTableTest> tables = new Dictionary<string, ReportTableTest>();

        public bool DB_SaveResult()
        {
            bool bStatus = false;



            return bStatus;
        }
    }
    class ReportItem
    {
        /// <summary>
        /// Reportname only
        /// </summary>
        public string Reportname { set; get; }
        /// <summary>
        /// Reportpath, if diffrent from defaultreportpath
        /// </summary>
        public string ReportPath { set; get; }
        /// <summary>
        /// When was last refresh
        /// </summary>
        public DateTime LastRefresh { set; get; }
        public DateTime RefreshStart { set; get; }
        public DateTime RefreshFinish { set; get; }
        /// <summary>
        /// Status on report, explation below
        /// </summary>
        public Int32 Status { set; get; }
        /// <summary>
        /// If there are error or other message that resource should see
        /// </summary>
        public string RefreshMessage { set; get; }

        public ReportTables Daily_Result { get; set; } = new ReportTables();


    }
}
