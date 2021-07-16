using SimpleSheets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Interface
{
    public interface ITimeSheetRepo
    {
        public IEnumerable<TimeSheet> GetTImeSheetData();
        public IEnumerable<EmployeeProjectMap> GetEmployeeProjectMapByUser(int userId);
        public void CreateTimeSheetRecord(TimeSheet timeSheet);
    }
}
