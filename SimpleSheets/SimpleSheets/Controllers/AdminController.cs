using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleSheets.Data.Models;
using SimpleSheets.Models;
using SimpleSheets.Services.Interfaces;

namespace SimpleSheets.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetRoles()
        {
            var roles = _adminService.GetRoles();
            return View(roles);
        }
        [HttpPost]
        public IActionResult GetProjects()
        {
            var projects = _adminService.GetProjects();
            return View(projects);
        }
        [HttpPost]
        public IActionResult GetEmployee()
        {
            var employees = _adminService.GetEmployee();
            return View(employees);
        }
        [HttpPost]
        public IActionResult GetTimeType()
        {
            var timeType = _adminService.GetTimeType();
            return View(timeType);
        }
        [HttpPost]
        public IActionResult GetEmployeeProjectMap()
        {
            var employeeProjectMap = _adminService.GetEmployeeProjectMap();
            return View(employeeProjectMap);
        }
    }
}