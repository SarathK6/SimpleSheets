using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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
        private readonly IGenericService _genericService;
        public TimeSheetController(ITimeSheetService timeSheetService, IGenericService genericService)
        {
            _timeSheetService = timeSheetService;
            _genericService = genericService;
            
        }
        public IActionResult Index()
        {
            var username = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            ViewData["Username"] = username;
            return View();
        }
        [HttpGet]
        public IActionResult GetTimeSheets()
        {
            var oid = User.Claims.Where(cl => cl.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").FirstOrDefault().Value;
            var timeSheets = _timeSheetService.GetTimeSheetData(oid);
            var username = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            ViewData["Username"] = username;
            return View(timeSheets);
        }
        [HttpGet]
        public IActionResult CreateTimeSheet()
        {
            var timeType = _genericService.GetTimeType();
            var project = _genericService.GetProjects();
            var username = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            ViewData["Username"] = username;
            ViewData["timeType"] = timeType;
            ViewData["projects"] = project;
            ViewData["EmpId"] = User.Claims.Where(cl => cl.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").FirstOrDefault().Value; ;
            ViewData["EmpUserName"] = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            return View();
        }
        public IActionResult CreateTimeSheet(TimeSheet timeSheet)
        {
            var empId= User.Claims.Where(cl => cl.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").FirstOrDefault().Value;
            var approverId= _genericService.GetEmployeeManagerId(empId);
            timeSheet.EmpId = empId;
            timeSheet.CreatedOn = DateTime.Now;
            timeSheet.ModifiedOn = DateTime.Now;
            timeSheet.CreatedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            timeSheet.ModifiedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            timeSheet.ApprovalStatus = false;
            timeSheet.ApproverId = approverId == null ? empId : approverId.ToString();
            _timeSheetService.CreateTimeSheetRecord(timeSheet);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("Logout")]
        [ValidateAntiForgeryToken]
        public async Task LogoutAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
            }
        }

    }
}
