using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public  class TimeSheet
    {
        public int Id { get; set; }
        public int MapId { get; set; }
        public float Hours { get; set; }
        public int TimeTypeId { get; set; }
        public bool ApprovalStatus { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Last_updated { get; set; }
    }
}
