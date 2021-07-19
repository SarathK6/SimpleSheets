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
    public class AdminService : IAdminService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AdminService> _logger;
        private readonly IAdminRepo _adminRepo;

        public AdminService(ILogger<AdminService> logger, IConfiguration configuration, IAdminRepo adminRepo)
        {
            _configuration = configuration;
            _logger = logger;
            _adminRepo = adminRepo;
        }

        public void AddEmployee(Employee employee)
        {
            _adminRepo.AddEmployee(employee);
        }

        public void AddEmployeeRole(EmployeeRoleMap employeeRoleMap)
        {
            _adminRepo.AddEmployeeRole(employeeRoleMap);
        }

        public void AddRole(Roles roles)
        {
            _adminRepo.AddRole(roles);
        }

        public void CreateProjects(Projects projects)
        {
            _adminRepo.CreateProjects(projects);
        }

        public void CreateTimeType(TimeType timeType)
        {
            _adminRepo.CreateTimeType(timeType);
        }

        public IEnumerable<Employee> GetEmployee()
        {
            return _adminRepo.GetEmployee();
        }

        public IEnumerable<EmployeeRoleMap> GetEmployeeProjectMap()
        {
            return _adminRepo.GetEmployeeProjectMap();
        }

        public IEnumerable<Roles> GetRoles()
        {
            return _adminRepo.GetRoles();
        }

        public IEnumerable<TimeType> GetTimeType()
        {
            return _adminRepo.GetTimeType();
        }

        public void DeleteRoleById(int id)
        {
            _adminRepo.DeleteRoleById(id);
        }
        public void DeleteEmployeeById(string id)
        {
            _adminRepo.DeleteEmployeeById(id);

        }
        public void DeleteProject(int id)
        {
            _adminRepo.DeleteProject(id);
        }
        public void DeleteEmpRoleMap(string id)
        {
            _adminRepo.DeleteEmpRoleMap(id);
        }

        public void DeleteTimeType(int id)
        {
            _adminRepo.DeleteTimeType(id);
        }

        public Roles GetRolesbyId(int id)
        {
            return  _adminRepo.GetRolesbyId(id);
        }

        public void UpdateRoleById(Roles roles)
        {
            _adminRepo.UpdateRoleById(roles);
        
        }
        public Projects GetProjectById(int id)
        {
            return _adminRepo.GetProjectById(id);
        }

        public void UpdateProjectById(Projects projects)
        {
            _adminRepo.UpdateProjectById(projects);
        }

        public Employee GetEmployeeById(int id)
        {
            return _adminRepo.GetEmployeeById(id);
        }
        public void UpdateEmployeeById(Employee employee)
        {
            _adminRepo.UpdateEmployeeById(employee);
        }
        public TimeType GetTimeTypeById(int id)
        {
            return _adminRepo.GetTimeTypeById(id);
        }
        public void UpdateTimeTypeById(TimeType timeType)
        {

            _adminRepo.UpdateTimeTypeById(timeType);
        }

        public EmployeeRoleMap GetEmpRoleMapById(int id)
        {
                return   _adminRepo.GetEmpRoleMapById(id);

        }
        public void UpdateEmpRoleMapById(EmployeeRoleMap employeeRole)
        {
            _adminRepo.UpdateEmpRoleMapById(employeeRole);
        }
    }
}
