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
        
    }
}
