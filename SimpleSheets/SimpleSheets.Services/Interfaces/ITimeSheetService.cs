using SimpleSheets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Services.Interfaces
{
    public interface ITimeSheetService
    {
        public IEnumerable<TimeSheetsView> GetTimeSheetData(string EmpId);
        public void CreateTimeSheetRecord(TimeSheet timeSheet);
        public IEnumerable<TimeSheetsView> GetTimeSheetApprovaData(string managerId);
        public void UpdateTimesheetStatus(TimeSheet timeSheetsView);

        public TimeSheetsView GetTimeSheetDataById(int id);

        public void UpdateTimesheetById(TimeSheet timeSheet);

        public void DeleteTimesheetById(int id);
    }
}
