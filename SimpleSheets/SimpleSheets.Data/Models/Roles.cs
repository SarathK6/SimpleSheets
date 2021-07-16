using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Last_updated { get; set; }
    }
}
