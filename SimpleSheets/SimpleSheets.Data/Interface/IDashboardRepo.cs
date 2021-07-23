using SimpleSheets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Interface
{
    public interface IDashboardRepo
    {
        public IEnumerable<EmployeeWorkPerProject> GetEmployeeWorkPerProject(string empId,DateTime dateTime);
        public IEnumerable<EmployeeWorkPerProject> GetEmployeeWorkHoursInAWeek(string empId);
    }
}
