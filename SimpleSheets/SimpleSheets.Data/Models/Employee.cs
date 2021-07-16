using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Last_updated { get; set; }
    }
}
