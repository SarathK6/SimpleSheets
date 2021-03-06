using SimpleSheets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Interface
{
    public interface ITimeSheetRepo
    {
        public IEnumerable<TimeSheetsView> GetTimeSheetData(string EmpId);
        public void CreateTimeSheetRecord(TimeSheet timeSheet);
        public IEnumerable<TimeSheetsView> GetTimeSheetApprovaData(string managerId);
        public void UpdateTimesheetStatus(TimeSheet timeSheetsView);

        public TimeSheetsView GetTimeSheetDataById(int id);

        public void UpdateTimesheetById(TimeSheet timesheet);

        public void DeleteTimesheetById(int id);
    }
}
