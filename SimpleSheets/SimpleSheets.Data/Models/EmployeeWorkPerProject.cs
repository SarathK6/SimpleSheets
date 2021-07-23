using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public class EmployeeWorkPerProject
    {
        public Guid EmpId { get; set; }
        public string ProjectTitle { get; set; }
        public float NoOfHours { get; set; }
        public DateTime TImeSheetEntryDate { get; set; }
    }
}
