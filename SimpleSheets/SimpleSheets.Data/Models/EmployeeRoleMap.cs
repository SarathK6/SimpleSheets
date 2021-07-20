using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public class EmployeeRoleMap
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage="Please select an Employee")]
        public Guid EmpId { get; set; }

        [Required(ErrorMessage ="Please select a Role")]
        public string Role { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
