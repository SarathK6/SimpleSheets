using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public class Roles
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Role Title")]
        [Remote(action: "IsRoleExists", controller: "Admin", ErrorMessage = "Role Title already present")]
        public string RoleTitle { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
