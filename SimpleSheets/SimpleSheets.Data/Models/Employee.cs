using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public Guid EmpId { get; set; }
        [Required]
        public Guid ManagerId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
