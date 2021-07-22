using Dapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SimpleSheets.Data.Interface;
using SimpleSheets.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSheets.Data.Impls
{
    public class DashboardRepo : BaseRepo, IDashboardRepo
    {
        public DashboardRepo(IDbConnectionFactory dbConnectionFactory,
            IConfiguration config, ILogger<DashboardRepo> logger, IMemoryCache memoryCache) :
            base(dbConnectionFactory, config, logger, memoryCache)
        {

        }

        public IEnumerable<EmployeeWorkPerProject> GetEmployeeWorkPerProject(string empId)
        {
            _logger.LogInformation("Entered into GetEmployeeWorkPerProject Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            int attempts = 0;
            try
            {
                attempts++;
                IEnumerable<EmployeeWorkPerProject> employeeWorkPerProjects;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {
                    string query = "select ProjectTitle,NoOfHours,TimeSheetEntryDate from vw_EmployeeWorkPerProject where empid=@Empid and TimeSheetEntryDate=@Datetime";
                    employeeWorkPerProjects = conn.Query<EmployeeWorkPerProject>(query, new { Empid=empId,  Datetime=DateTime.Now.Date},
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited GetEmployeeWorkPerProject Method");

                }
                _logger.LogInformation("Exited GetEmployeeWorkPerProject Method");
                return employeeWorkPerProjects;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                _logger.LogInformation("Error in  GetEmployeeWorkPerProject Method" + " " + ex);
                throw ex;

            }
        }
        public IEnumerable<EmployeeWorkPerProject> GetEmployeeWorkHoursInAWeek(string empId)
        {
            _logger.LogInformation("Entered into GetEmployeeWorkPerProject Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            int attempts = 0;
            try
            {
                attempts++;
                IEnumerable<EmployeeWorkPerProject> employeeWorkPerProjects;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {
                    string query = "Select TimeSheetEntryDate,sum(NoOfHours) As NoOfHours from Timesheet  where empid=@Empid and TimeSheetEntryDate>@Datetime and TimeTypeId=1 group by TimeSheetEntryDate";
                    employeeWorkPerProjects = conn.Query<EmployeeWorkPerProject>(query, new { Empid = empId, Datetime = DateTime.Now.AddDays(-7)},
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited GetEmployeeWorkPerProject Method");

                }
                _logger.LogInformation("Exited GetEmployeeWorkPerProject Method");
                return employeeWorkPerProjects;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                _logger.LogInformation("Error in  GetEmployeeWorkPerProject Method" + " " + ex);
                throw ex;

            }
        }
    }
}
