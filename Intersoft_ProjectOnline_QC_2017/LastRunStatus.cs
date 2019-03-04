using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 
/// </summary>
namespace Intersoft_ProjectOnline_QC_2017
{
    class StatusCopy
    {
        public int ReadyToCopy { get; set; } = -1;
        public int Result { get; set; } = -1;
        public DateTime RunTime { get; set; }

        public bool CopyToReporting { get; set; } = false;
    } // class statuscopy


    class LastRunStatus
    {
        public Int64 OpExId { get; set; }
        public DateTime LastRefresh { get; set; }

        public Int64 History_OpExId { get; set; }
        public DateTime History_LastRefresh { get; set; }

        public Int64 Download_OpExId { get; set; }
        public DateTime Download_LastRefresh { get; set; }


        public int ReadyToRun { get; set; }

        // Is timesaldo refresh ready to run 
        public int PTR_ReadyToRun { get; set; }

        public int PRR_ReadyToRun { get; set; }

        public int POD_ReadyToRun { get; set; }

        public bool IsUpdated { get; set; } = false;

        public int UpdatedDays { get; set; } = 0;

        public bool StartusCheck()
        {
            bool bStatus = false;
            this.UpdatedDays = (int)(DateTime.Today - this.LastRefresh).TotalDays;

            if (this.UpdatedDays == 0)
            {
                this.IsUpdated = true;
                bStatus = false;
            }
            else
            {
                this.IsUpdated = false;
                bStatus = true;
            }

            return bStatus;
        }

    }// class LastRunStatus
}// namespace Intersoft_ProjectOnline_QC_2017
