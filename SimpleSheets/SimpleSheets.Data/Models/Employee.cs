using Microsoft.AspNetCore.Mvc;
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
        [Remote(action: "IsEmployeeExists", controller: "Admin", ErrorMessage = "Role already assigned")]
        public Guid EmpId { get; set; }
        [Required]
        [Display(Name = "Manager")]
        public Guid ManagerId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
