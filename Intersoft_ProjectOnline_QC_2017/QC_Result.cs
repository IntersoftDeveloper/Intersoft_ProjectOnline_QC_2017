using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersoft_ProjectOnline_QC_2017
{
    /// <summary>
    /// This class is holding the result from database on the check on download
    /// 
    /// </summary>
    class QC_Result
    {
        public string Tablename { get; set; }
        public Int64 RC_SSIS { get; set; }
        public Int64 RC_Min_PO { get; set; }
        public Int64 RC_Max_PO { get; set; }
        public decimal T1_SSIS { get; set; }
        public decimal T1_Min_PO { get; set; }
        public decimal T1_Max_PO { get; set; }
        public decimal T2_SSIS { get; set; }
        public decimal T2_Min_PO { get; set; }
        public decimal T2_Max_PO { get; set; }
        public Int64 RC_Result { get; set; }
        public Int64 T1_Result { get; set; }
        public Int64 T2_Result { get; set; }
        public Int64 Table_Result { get; set; }
        public Int64 opExID { get; set; }
        public DateTime opRunTime { get; set; }
        public decimal RC_Day_Before { get; set; }
        public decimal RC_This_Day { get; set; }
        public decimal T1_Day_Before { get; set; }
        public decimal T1_This_Day { get; set; }
        public decimal T2_Day_Before { get; set; }
        public decimal T2_This_Day { get; set; }
        public string T1Description { get; set; }
        public string T2Description { get; set; }
        public decimal T1Factor { get; set; }
        public decimal T2Factor { get; set; }
    } // Class QC_Result
}// Namespace  Intersoft_ProjectOnline_QC_2017
