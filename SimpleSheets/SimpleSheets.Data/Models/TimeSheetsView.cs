using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public class TimeSheetsView
    {
        public int TimeSheetRecordId { get; set; }

        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Project")]
        public string Project { get; set; }

        [Required]
        [Display(Name = "Time Type")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Time type")]
        public string TimeType { get; set; }

        [Display(Name = "Approver Name")]
        public string ApproverName { get; set; }
        public float Hours { get; set; }

        [Display(Name = "Approval status")]
        public bool ApprovalStatus { get; set; }
        public bool ApprovalViewStatus { get; set; }
        public DateTime ApprovedOn { get; set; }


        [Display(Name = "Time Sheet Entry Date")]
        [CustomAdmissionDate(ErrorMessage = "TimeSheet Entry Date must be less than or equal to Today's Date.")]      
        public DateTime TimeSheetEntryDate { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
