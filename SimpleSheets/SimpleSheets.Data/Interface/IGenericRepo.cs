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
        public Guid GetEmployeeManagerId(string empId);
        public Employee GetmyDetailsfromDb(string id);
    }
}
