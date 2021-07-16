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
                
    }
}
