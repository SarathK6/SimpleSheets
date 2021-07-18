using SimpleSheets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Services.Interfaces
{
    public interface IGenericService
    {
        public IEnumerable<TimeType> GetTimeType();
        public IEnumerable<Projects> GetProjects();
        public string GetEmployeeManagerId(string empId);
    }
}
