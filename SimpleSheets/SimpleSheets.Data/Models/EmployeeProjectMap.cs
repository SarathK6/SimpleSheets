using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public class EmployeeProjectMap
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ProjectAssigned { get; set; }
    }
}
