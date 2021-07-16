using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public class EmployeeProjectMapCreate
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int ProjectId { get; set; }

    }
}
