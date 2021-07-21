using SimpleSheets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Services.Interfaces
{
    public interface IDashboardService
    {
        public IEnumerable<EmployeeWorkPerProject> GetEmployeeWorkPerProject(string empId);
        public List<WorkHistory> GetEmployeeWorkHoursInAWeek(string empId);
    }
}
