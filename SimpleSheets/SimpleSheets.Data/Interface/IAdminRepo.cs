using SimpleSheets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Interface
{
    public interface IAdminRepo
    {
        public IEnumerable<Roles> GetRoles();
        public IEnumerable<Projects> GetProjects();
        public IEnumerable<Employee> GetEmployee();
        public IEnumerable<TimeType> GetTimeType();
        public IEnumerable<EmployeeProjectMap> GetEmployeeProjectMap();
        public void CreateRoles(Roles roles);
        public void CreateProjects(Projects projects);
        public void CreateEmployee(Employee employee);
        public void CreateTimeType(TimeType timeType);
        public void CreateEmployeeProjectMap(EmployeeProjectMapCreate employee);

        public void DeleteRoleById(int id);

        public void DeleteEmployeeById(int id);

        public void DeleteProject(int id);
        public void DeleteEmpProjMap(int id);
        public void DeleteTimeType(int id);
    }
}
