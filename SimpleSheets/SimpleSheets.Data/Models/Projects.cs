using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace SimpleSheets.Data.Models
{
    public class Projects
    {
        public int Id { get; set; }

        
        [Required]
        [Display(Name ="Project Title")]
        [Remote(action:"IsProjectExists", controller:"Admin",ErrorMessage ="Project Title already present")] 
        public string ProjectTitle { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
