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
        public IActionResult GetmyDetails()
        {
            var oid= User.Claims.Where(cl => cl.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").FirstOrDefault().Value;
            var employee = _genericService.GetmyDetailsfromDb(oid);
            return View(employee);
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
            timeSheet.EmpId = new Guid(empId);
            timeSheet.CreatedOn = DateTime.Now;
            timeSheet.ModifiedOn = DateTime.Now;
            timeSheet.CreatedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            timeSheet.ModifiedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            timeSheet.ApprovalStatus = empId.ToUpper().ToString()== approverId.ToString().ToUpper()?true:false;
            timeSheet.ApprovalViewStatus = empId.ToUpper().ToString() == approverId.ToString().ToUpper() ? true : false;
            timeSheet.ApproverId = approverId;
            timeSheet.ApprovedOn = new DateTime(1753, 1, 1);
            if (empId.ToUpper().ToString() == approverId.ToString().ToUpper())
            {
                timeSheet.ApprovedBy= User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value; ;
                timeSheet.ApprovedOn = DateTime.Now;
            }
            
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
        [HttpGet]
        public IActionResult ApproveTimesheets()
        {
            var oid = User.Claims.Where(cl => cl.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").FirstOrDefault().Value;
            var timeSheets = _timeSheetService.GetTimeSheetApprovaData(oid);
            var username = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            ViewData["Username"] = username;
            return View(timeSheets);
        }
        public IActionResult UpdateStatus(int timesheetId,bool status)
        {
            var oid = User.Claims.Where(cl => cl.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").FirstOrDefault().Value;
            var timeSheets = _timeSheetService.GetTimeSheetApprovaData(oid);
            var username = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            ViewData["Username"] = username;
            TimeSheet timeSheetsView = new TimeSheet();
            timeSheetsView.ApprovalStatus = status;
            timeSheetsView.ApprovalViewStatus = true;
            timeSheetsView.Id = timesheetId;
            timeSheetsView.ModifiedBy = username;
            timeSheetsView.ApprovedBy = username;
            timeSheetsView.ApprovedOn = DateTime.Now;
            timeSheetsView.ModifiedOn = DateTime.Now;
            _timeSheetService.UpdateTimesheetStatus(timeSheetsView);
            return View("ApproveTimesheets", timeSheets);
        }

    }
}
