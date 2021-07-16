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
        private readonly IAdminRepo _adminRepo;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AdminService> _logger;

        public AdminService(ILogger<AdminService> logger, IConfiguration configuration,IAdminRepo adminRepo)
        {
            _adminRepo = adminRepo;
            _configuration = configuration;
            _logger = logger;
        }

        public void CreateEmployee(Employee employee)
        {
            _adminRepo.CreateEmployee(employee);
        }

        public void CreateEmployeeProjectMap(EmployeeProjectMapCreate employee)
        {
            _adminRepo.CreateEmployeeProjectMap(employee);
        }

        public void CreateProjects(Projects projects)
        {
            _adminRepo.CreateProjects(projects);
        }

        public void CreateRoles(Roles roles)
        {
            _adminRepo.CreateRoles(roles);
        }

        public void CreateTimeType(TimeType timeType)
        {
            _adminRepo.CreateTimeType(timeType);
        }

        public IEnumerable<Employee> GetEmployee()
        {
            return _adminRepo.GetEmployee();
        }

        public IEnumerable<EmployeeProjectMap> GetEmployeeProjectMap()
        {
            return _adminRepo.GetEmployeeProjectMap();
        }

        public IEnumerable<Projects> GetProjects()
        {
            return _adminRepo.GetProjects();
        }

        public IEnumerable<Roles> GetRoles()
        {
            return _adminRepo.GetRoles();
        }

        public IEnumerable<TimeType> GetTimeType()
        {
            return _adminRepo.GetTimeType();
        }
    }
}
