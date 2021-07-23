using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace SimpleSheets.Data.Models
{
    public class TimeType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Time Type")]
        [Remote(action: "IsTimeTypeExists", controller: "Admin", ErrorMessage = "Time Type  already present")]
        public string TimetypeTitle { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
