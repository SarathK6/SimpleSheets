using SimpleSheets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Interface
{
    public interface IGenericRepo
    {
        public IEnumerable<TimeType> GetTimeType();
        public IEnumerable<Projects> GetProjects();
        public string GetEmployeeManagerId(string empId);
    }
}
