using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SimpleSheets.Data.Interface;
using SimpleSheets.Data.Models;
using SimpleSheets.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Services.Impls
{
    public class DashboardService : IDashboardService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DashboardService> _logger;
        private readonly IDashboardRepo _dashboardRepo;
        public DashboardService(ILogger<DashboardService> logger, IConfiguration configuration, IDashboardRepo dashboardRepo)
        {
            _configuration = configuration;
            _logger = logger;
            _dashboardRepo = dashboardRepo;
        }
        public IEnumerable<EmployeeWorkPerProject> GetEmployeeWorkPerProject(string empId)
        {
            return _dashboardRepo.GetEmployeeWorkPerProject(empId);
        }
        public List<WorkHistory> GetEmployeeWorkHoursInAWeek(string empId)
        {
            EmployeeWorkPerProject employeeWorkPerProject = new EmployeeWorkPerProject();
            List<WorkHistory> workHistory = new List<WorkHistory>();
            var epps = _dashboardRepo.GetEmployeeWorkHoursInAWeek(empId);
            Dictionary<DateTime, int> keyValuePairs = new Dictionary<DateTime, int>();
            for (int i=0;i<7;i++)
            {
                var dateCompare = DateTime.Now.AddDays(-i);
                bool dateFound = false;
                foreach (var item in epps)
                {
                    if (item.TImeSheetEntryDate.Date.CompareTo(dateCompare.Date) == 0)
                    {
                        keyValuePairs.Add(item.TImeSheetEntryDate, item.NoOfHours);
                        dateFound = true;
                        break;
                    }

                }
                if (!dateFound)
                {
                    keyValuePairs.Add(dateCompare, 0);
                }
            }
            foreach (var item in keyValuePairs)
            {
                WorkHistory workHistory1 = new WorkHistory();
                workHistory1.TImeSheetEntryDate = item.Key.Date.ToString().Replace("12:00:00 AM", "");
                workHistory1.NoOfHours = item.Value;
                workHistory.Add(workHistory1);
            }
            return workHistory;
        }

    }
}
