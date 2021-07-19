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
    public class TimeSheetService: ITimeSheetService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TimeSheetService> _logger;
        private readonly ITimeSheetRepo _timeSheetRepo;

        public TimeSheetService(ILogger<TimeSheetService> logger, IConfiguration configuration,ITimeSheetRepo timeSheetRepo)
        {
            _configuration = configuration;
            _logger = logger;
            _timeSheetRepo = timeSheetRepo;
        }

        public void CreateTimeSheetRecord(TimeSheet timeSheet)
        {
            _timeSheetRepo.CreateTimeSheetRecord(timeSheet);
        }

         public IEnumerable<TimeSheetsView> GetTimeSheetData(string EmpId)
        {
            return _timeSheetRepo.GetTimeSheetData(EmpId);
        }

        public Employee GetmyDetailsfromDb(string id)
        {
            return _timeSheetRepo.GetmyDetailsfromDb(id);
        }
    }
}
