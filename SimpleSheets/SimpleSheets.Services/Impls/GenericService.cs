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
    public class GenericService: IGenericService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<GenericService> _logger;
        private readonly IGenericRepo _genericRepo;

        public GenericService(ILogger<GenericService> logger, IConfiguration configuration, IGenericRepo genericRepo)
        {
            _configuration = configuration;
            _logger = logger;
            _genericRepo = genericRepo;
        }

        public IEnumerable<Projects> GetProjects()
        {
            return _genericRepo.GetProjects();
        }

        public IEnumerable<TimeType> GetTimeType()
        {
            return _genericRepo.GetTimeType();
        }
        public Guid GetEmployeeManagerId(string empId)
        {
            return _genericRepo.GetEmployeeManagerId(empId);
        }
        public Employee GetmyDetailsfromDb(string id)
        {
            return _genericRepo.GetmyDetailsfromDb(id);
        }

    }
}
