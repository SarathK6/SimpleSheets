using SimpleSheets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Interface
{
    public interface IDashboardRepo
    {
        public IEnumerable<EmployeeWorkPerProject> GetEmployeeWorkPerProject(string empId);
        public IEnumerable<EmployeeWorkPerProject> GetEmployeeWorkHoursInAWeek(string empId);
    }
}
