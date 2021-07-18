using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string ManagerId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
