using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        private readonly string _userName;
        private readonly string _title;

        public AdminController(IAdminService adminService, IGenericService genericService, IHttpContextAccessor contextAccessor)
        {
            _adminService = adminService;
            _genericService = genericService;
            _userName= contextAccessor.HttpContext.User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            _title = "Admin";
        }
        public IActionResult Index()
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            return View();
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {
           ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            var employee=_adminService.GetEmployee();
            return View(employee);
        }
        [HttpGet]
        public IActionResult GetProjects()
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            var projects= _genericService.GetProjects();
            return View(projects);
        }
        [HttpGet]
        public IActionResult GetRoles()
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            var roles=_adminService.GetRoles();
            return View(roles);
        }
        [HttpGet]
        public IActionResult GetTimeType()
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            var timetypes=_adminService.GetTimeType();
            return View(timetypes);
        }
        [HttpGet]
        public IActionResult CreateTimeType()
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            return View();
        }
        public IActionResult CreateTimeType(TimeType timeType)
        {
            if (ModelState.IsValid)
            {
                ViewData["Username"] = _userName;
                timeType.CreatedOn = DateTime.Now;
                timeType.ModifiedOn = DateTime.Now;
                timeType.CreatedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
                timeType.ModifiedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
                _adminService.CreateTimeType(timeType);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Username"] = _userName;
                ViewData["Title"] = _title;
                return View();
            }
        }
        [HttpGet]
        public IActionResult CreateProjects()
        {
            ViewData["Username"] = _userName;
            return View();
        }

        [HttpPost]
        public IActionResult CreateProjects(Projects projects)
        {
            if (ModelState.IsValid)
            {
                ViewData["Username"] = _userName;
                projects.CreatedOn = DateTime.Now;
                projects.ModifiedOn = DateTime.Now;
                projects.CreatedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
                projects.ModifiedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
                _adminService.CreateProjects(projects);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Username"] = _userName;
                return View();
            }
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            ViewData["Username"] = _userName;
            var manager = _adminService.GetEmployee();
            ViewData["manager"] = manager;

            return View();
        }
        public IActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                ViewData["Username"] = _userName;
                ViewData["Title"] = _title;
                employee.CreatedOn = DateTime.Now;
                employee.ModifiedOn = DateTime.Now;
                employee.CreatedBy = _userName;
                employee.ModifiedBy = _userName;
                _adminService.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Username"] = _userName;
                var manager = _adminService.GetEmployee();
                ViewData["manager"] = manager;
                return View();
            }
        }
        [HttpGet]
        public IActionResult AddRoles()
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            return View();
        }
        [HttpPost]
        public IActionResult AddRoles(Roles roles)
        {
            if (ModelState.IsValid)
            {
                ViewData["Username"] = _userName;
                ViewData["Title"] = _title;
                roles.CreatedOn = DateTime.Now;
                roles.ModifiedOn = DateTime.Now;
                roles.CreatedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
                roles.ModifiedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
                _adminService.AddRole(roles);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Username"] = _userName;
                ViewData["Title"] = _title;
                return View();
            }
        }
        [HttpGet]
        public IActionResult GetEmployeeProjectMap()
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            var employee = _adminService.GetEmployeeProjectMap();
            return View(employee);
        }
        [HttpGet]
        public IActionResult AddEmployeeRole()
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            var roles = _adminService.GetRoles();
            var employees =_adminService.GetEmployee();
            ViewData["roles"] = roles;
            ViewData["employees"] = employees;
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployeeRole(EmployeeRoleMap emp)
        {
            if (ModelState.IsValid)
            {
                ViewData["Username"] = _userName;
                ViewData["Title"] = _title;
                emp.CreatedOn = DateTime.Now;
                emp.ModifiedOn = DateTime.Now;
                emp.CreatedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
                emp.ModifiedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
                _adminService.AddEmployeeRole(emp);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Username"] = _userName;
                ViewData["Title"] = _title;
                var roles = _adminService.GetRoles();
                var employees = _adminService.GetEmployee();
                ViewData["roles"] = roles;
                ViewData["employees"] = employees;
                return View();
            }
        }

        public IActionResult DeleteRoleById(int id)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            _adminService.DeleteRoleById(id);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployeeById(string id)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            _adminService.DeleteEmployeeById(id);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProject(int id)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            _adminService.DeleteProject(id);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmpRoleMap(string id)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            _adminService.DeleteEmpRoleMap(id);
            return RedirectToAction("Index");

        }

        public IActionResult DeleteTimeType(int id)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            _adminService.DeleteTimeType(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditRoleById(int id)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            var model=_adminService.GetRolesbyId(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditRoleById(Roles roles)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            roles.ModifiedOn = DateTime.Now;
            roles.ModifiedBy= User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            _adminService.UpdateRoleById(roles);
            return View("Index");
        }

        [HttpGet]
        public IActionResult UpdateProjectById(int id)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            var model = _adminService.GetProjectById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProjectById(Projects projects)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            projects.ModifiedBy= User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            projects.ModifiedOn = DateTime.Now;
            _adminService.UpdateProjectById(projects);            
            return View("Index");
        }

        [HttpGet]
        public IActionResult UpdateEmployeeById(int id)

        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            var model = _adminService.GetEmployeeById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateEmployeeById(Employee employee)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            employee.ModifiedOn = DateTime.Now;
            employee.ModifiedBy= User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            _adminService.UpdateEmployeeById(employee);
            return View("Index");
        }

        [HttpGet]
        public IActionResult UpdateTimeTypeById(int id)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            var model = _adminService.GetTimeTypeById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateTimeTypeById(TimeType timeType)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            timeType.ModifiedOn = DateTime.Now;
            timeType.ModifiedBy= User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            _adminService.UpdateTimeTypeById(timeType);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditEmpRoleMap(int id)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            ViewData["Roles"]= _adminService.GetRoles();
            var model = _adminService.GetEmpRoleMapById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditEmpRoleMap(EmployeeRoleMap emp)
        {
            ViewData["Username"] = _userName;
            ViewData["Title"] = _title;
            emp.ModifiedBy = User.Claims.Where(cl => cl.Type == "name").FirstOrDefault().Value;
            emp.ModifiedOn = DateTime.Now;
            _adminService.UpdateEmpRoleMapById(emp);
            return RedirectToAction("Index");

        }



    }
}
