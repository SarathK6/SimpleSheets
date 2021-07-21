using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleSheets.Services.Interfaces;

namespace SimpleSheets.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly IGenericService _genericService;
        private readonly string _userName;
        private readonly string _empId;
        private readonly Guid _managerId;
        private readonly string _title;
        private readonly bool _isAdmin;

        public DashBoardController(IDashboardService dashboardService, IGenericService genericService, IHttpContextAccessor contextAccessor)
        {
            _dashboardService = dashboardService;
            _genericService = genericService;
            _userName = contextAccessor.HttpContext.User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            _empId = contextAccessor.HttpContext.User.Claims.Where(cl => cl.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").FirstOrDefault().Value;
            _managerId = _genericService.GetEmployeeManagerId(_empId);
            _title = "Dashboard";
            _isAdmin = contextAccessor.HttpContext.User.IsInRole("Admin");
        }
        public IActionResult Index()
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            ViewData["_isAdmin"] = _isAdmin;
            return View();
        }
        [HttpGet]
        public JsonResult PopulationChart()
        {
            var timeSheets = _dashboardService.GetEmployeeWorkPerProject(_empId);
            return Json(timeSheets);
        }
        [HttpGet]
        public JsonResult GetEmployeeWorkHoursInAWeek()
        {
            var timeSheets = _dashboardService.GetEmployeeWorkHoursInAWeek(_empId);
            timeSheets.Reverse();
            return Json(timeSheets);
        }
    }
}