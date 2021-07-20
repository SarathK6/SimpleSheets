﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
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
        private readonly string _userName;
        private readonly string _empId;
        private readonly Guid _managerId;
        private readonly string _title;

        public TimeSheetController(ITimeSheetService timeSheetService, IGenericService genericService, IHttpContextAccessor contextAccessor)
        {
            _timeSheetService = timeSheetService;
            _genericService = genericService;
            _userName = contextAccessor.HttpContext.User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            _empId= contextAccessor.HttpContext.User.Claims.Where(cl => cl.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").FirstOrDefault().Value;
            _managerId= _genericService.GetEmployeeManagerId(_empId);
            _title = "Timsheets";
        }
        public IActionResult GetmyDetails()
        {
            var employee = _genericService.GetmyDetailsfromDb(_empId);
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            return View(employee);
        }
        public IActionResult Index()
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            return View();
        }
        [HttpGet]
        public IActionResult GetTimeSheets()
        {
            var timeSheets = _timeSheetService.GetTimeSheetData(_empId);
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            return View(timeSheets);
        }
        [HttpGet]
        public IActionResult CreateTimeSheet()
        {
            var timeType = _genericService.GetTimeType();
            var project = _genericService.GetProjects();
            ViewData["Username"] = _userName;
            ViewData["timeType"] = timeType;
            ViewData["projects"] = project;
            ViewData["EmpId"] = _empId;
            ViewData["EmpUserName"] = _userName;
            ViewData["Title"] = _title;
            return View();
        }
        public IActionResult CreateTimeSheet(TimeSheet timeSheet)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            timeSheet.EmpId = new Guid(_empId);
            timeSheet.CreatedOn = DateTime.Now;
            timeSheet.ModifiedOn = DateTime.Now;
            timeSheet.CreatedBy = _userName;
            timeSheet.ModifiedBy = _userName;
            timeSheet.ApprovalStatus = _empId.ToUpper().ToString()== _managerId.ToString().ToUpper()?true:false;
            timeSheet.ApprovalViewStatus = _empId.ToUpper().ToString() == _managerId.ToString().ToUpper() ? true : false;
            timeSheet.ApproverId = _managerId;
            timeSheet.ApprovedOn = new DateTime(1753, 1, 1);
            if (_empId.ToUpper().ToString() == _managerId.ToString().ToUpper())
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
            var timeSheets = _timeSheetService.GetTimeSheetApprovaData(_empId);
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            return View(timeSheets);
        }
        public IActionResult UpdateStatus(int timesheetId,bool status)
        {
            var timeSheets = _timeSheetService.GetTimeSheetApprovaData(_empId);
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            TimeSheet timeSheetsView = new TimeSheet();
            timeSheetsView.ApprovalStatus = status;
            timeSheetsView.ApprovalViewStatus = true;
            timeSheetsView.Id = timesheetId;
            timeSheetsView.ModifiedBy = _userName;
            timeSheetsView.ApprovedBy = _userName;
            timeSheetsView.ApprovedOn = DateTime.Now;
            timeSheetsView.ModifiedOn = DateTime.Now;
            _timeSheetService.UpdateTimesheetStatus(timeSheetsView);
            return View("ApproveTimesheets", timeSheets);
        }

    }
}
