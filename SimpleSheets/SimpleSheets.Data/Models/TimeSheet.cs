using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public  class TimeSheet
    {
        public int Id { get; set; }
        public Guid EmpId { get; set; }
        public float NoOfHours { get; set; }
        public int TimeTypeId { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Guid ApproverId { get; set; }
        public bool ApprovalStatus { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedOn { get; set; }
    }
}
