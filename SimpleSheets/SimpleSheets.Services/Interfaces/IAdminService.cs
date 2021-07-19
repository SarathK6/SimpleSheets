using SimpleSheets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Services.Interfaces
{
    public interface IAdminService
    {
        public IEnumerable<Employee> GetEmployee();
        public IEnumerable<Roles> GetRoles();
        public IEnumerable<TimeType> GetTimeType();
        public void CreateProjects(Projects projects);
        public void CreateTimeType(TimeType timeType);
        public void AddEmployee(Employee employee);
        public void AddRole(Roles roles);
        public void AddEmployeeRole(EmployeeRoleMap employeeRoleMap);
        public IEnumerable<EmployeeRoleMap> GetEmployeeProjectMap();
        public void DeleteRoleById(int id);

        public void DeleteEmployeeById(string id);

        public void DeleteProject(int id);

        public void DeleteEmpRoleMap(string id);

        public void DeleteTimeType(int id);
    }
}
