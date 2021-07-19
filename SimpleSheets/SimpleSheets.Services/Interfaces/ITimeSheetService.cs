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
        public Employee GetmyDetailsfromDb(string empid);
    }
}
