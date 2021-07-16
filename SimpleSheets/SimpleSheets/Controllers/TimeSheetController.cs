using Microsoft.AspNetCore.Mvc;
using SimpleSheets.Data.Models;
using SimpleSheets.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSheets.Controllers
{
    public class TimeSheetController : Controller
    {
        private readonly ITimeSheetService _timeSheetService;
        private readonly IAdminService _adminService;

        public TimeSheetController(ITimeSheetService timeSheetService, IAdminService adminService)
        {
            _timeSheetService = timeSheetService;
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            var timeSheets = _timeSheetService.GetTImeSheetData();
            return View(timeSheets);
        }
        [HttpGet]
        public IActionResult CreateTimeSheet()
        {
            int userId = 1;
            var mapId = _timeSheetService.GetEmployeeProjectMapByUser(userId);
            var timeType = _adminService.GetTimeType();
            ViewData["mapId"] = mapId;
            ViewData["timeType"] = timeType;
            return View();
        }
        public IActionResult CreateTimeSheet(TimeSheet timeSheet)
        {
            timeSheet.CreatedOn = DateTime.Now;
            timeSheet.Last_updated = DateTime.Now;
            _timeSheetService.CreateTimeSheetRecord(timeSheet);
            return RedirectToAction("Index");
        }
    }
}
