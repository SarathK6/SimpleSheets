﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public  class TimeSheet
    {
        public int Id { get; set; }
        public Guid EmpId { get; set; }
        

        [Required]
        [Range(1, 10)]
        public float NoOfHours { get; set; }

        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Please select a valid Time type")]
        public int TimeTypeId { get; set; }

        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Please select a valid Project")]
        public int ProjectId { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Guid ApproverId { get; set; }
        public bool ApprovalStatus { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedOn { get; set; }
        public bool ApprovalViewStatus { get; set; }

        [CustomAdmissionDate(ErrorMessage = "TimeSheet Entry Date must be less than or equal to Today's Date.")]
        public DateTime TimeSheetEntryDate { get; set; }
    }

    public class CustomAdmissionDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now;
        }
    }
}
