using SimpleSheets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Services.Interfaces
{
    public interface ITimeSheetService
    {
        public IEnumerable<TimeSheet> GetTImeSheetData();
        public IEnumerable<EmployeeProjectMap> GetEmployeeProjectMapByUser(int userId);
        public void CreateTimeSheetRecord(TimeSheet timeSheet);
    }
}
