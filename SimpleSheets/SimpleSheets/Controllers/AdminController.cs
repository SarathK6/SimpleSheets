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
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            var roles = _adminService.GetRoles();
            ViewData["Roles"] = roles;
            return View();
        }
        
        public IActionResult CreateEmployee(Employee employee)
        {
            employee.Last_updated = DateTime.Now;
            employee.CreatedOn = DateTime.Now;
            _adminService.CreateEmployee(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateProjects()
        {
            return View();
        }
        public IActionResult CreateProjects(Projects projects)
        {
            _adminService.CreateProjects(projects);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateRoles()
        {
            return View();
        }
        public IActionResult CreateRoles(Roles roles)
        {
            roles.CreatedOn = DateTime.Now;
            roles.Last_updated = DateTime.Now;
            _adminService.CreateRoles(roles);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateTimeType()
        {
            return View();
        }
        public IActionResult CreateTimeType(TimeType timeTypeCreated)
        {
            _adminService.CreateTimeType(timeTypeCreated);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateEmployeeProjectMap()
        {
            var employees = _adminService.GetEmployee();
            var projects = _adminService.GetProjects();
            ViewData["Employees"] = employees;
            ViewData["Projects"] = projects;
            return View();
        }
        public IActionResult CreateEmployeeProjectMap(EmployeeProjectMapCreate employeeProjectMapCreate)
        {
            _adminService.CreateEmployeeProjectMap(employeeProjectMapCreate);
            return RedirectToAction("Index");
        }
    }
}