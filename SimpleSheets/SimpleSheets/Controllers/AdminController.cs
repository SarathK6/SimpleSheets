﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleSheets.Data.Models;
using SimpleSheets.Services.Interfaces;

namespace SimpleSheets.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IAdminService _adminService { get; }
        public IGenericService _genericService { get; }

        public AdminController(IAdminService adminService, IGenericService genericService)
        {
            _adminService = adminService;
            _genericService = genericService;

        }
        public IActionResult Index()
        {
            var username = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            ViewData["Username"] = username;
            return View();
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {
            var employee=_adminService.GetEmployee();
            return View(employee);
        }
        [HttpGet]
        public IActionResult GetProjects()
        {
            var projects= _genericService.GetProjects();
            return View(projects);
        }
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles=_adminService.GetRoles();
            return View(roles);
        }
        [HttpGet]
        public IActionResult GetTimeType()
        {
            var timetypes=_adminService.GetTimeType();
            return View(timetypes);
        }
        [HttpGet]
        public IActionResult CreateTimeType()
        {
            return View();
        }
        public IActionResult CreateTimeType(TimeType timeType)
        {
            timeType.CreatedOn = DateTime.Now;
            timeType.ModifiedOn = DateTime.Now;
            timeType.CreatedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            timeType.ModifiedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            _adminService.CreateTimeType(timeType);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateProjects()
        {
            return View();
        }
        public IActionResult CreateProjects(Projects projects)
        {
            projects.CreatedOn = DateTime.Now;
            projects.ModifiedOn = DateTime.Now;
            projects.CreatedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            projects.ModifiedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            _adminService.CreateProjects(projects);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            var manager = _adminService.GetEmployee();
            ViewData["manager"] = manager;

            return View();
        }
        public IActionResult AddEmployee(Employee employee)
        {
            employee.CreatedOn = DateTime.Now;
            employee.ModifiedOn = DateTime.Now;
            employee.CreatedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            employee.ModifiedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            _adminService.AddEmployee(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddRoles()
        {
            return View();
        }
        public IActionResult AddRoles(Roles roles)
        {
            roles.CreatedOn = DateTime.Now;
            roles.ModifiedOn = DateTime.Now;
            roles.CreatedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            roles.ModifiedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            _adminService.AddRole(roles);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetEmployeeProjectMap()
        {
            var employee = _adminService.GetEmployeeProjectMap();
            return View(employee);
        }
        [HttpGet]
        public IActionResult AddEmployeeRole()
        {
            var roles = _adminService.GetRoles();
            var employees =_adminService.GetEmployee();
            ViewBag["roles"] = roles;
            ViewBag["employees"] = employees;
            return View();
        }
    }
}