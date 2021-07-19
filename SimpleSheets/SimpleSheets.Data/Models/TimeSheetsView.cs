using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public class TimeSheetsView
    {
        public int TimeSheetRecordId { get; set; }
        public string EmployeeName { get; set; }
        public string Project { get; set; }
        public string TimeType { get; set; }
        public string ApproverName { get; set; }
        public int Hours { get; set; }
        public bool ApprovalStatus { get; set; }
        public bool ApprovalViewStatus { get; set; }
        public DateTime ApprovedOn { get; set; }
    }
}
