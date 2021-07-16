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
    public class TimeSheetRepo : BaseRepo, ITimeSheetRepo
    {
        public TimeSheetRepo(IDbConnectionFactory dbConnectionFactory,
            IConfiguration config, ILogger<TimeSheetRepo> logger, IMemoryCache memoryCache) :
            base(dbConnectionFactory, config, logger, memoryCache)
        {

        }

        public void CreateTimeSheetRecord(TimeSheet timeSheet)
        {
            _logger.LogInformation("Entered into GetAllKMLFilesAsync Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            int attempts = 0;
            try
            {
                attempts++;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {
                    string query = "INSERT INTO TimeSheet(MapId ,Hours ,TimeTypeId ,ApprovalStatus,Description ,CreatedOn  ,Last_updated)"
                        + "VALUES(@MapId,@Hours,@TimeTypeId,@ApprovalStatus,@Description,@Createdon,@Last_updated)";
                    conn.ExecuteScalar<Employee>(query, timeSheet,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited GetAllKMLFilesAsync Method");

                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                throw ex;

            }
        }

        public IEnumerable<EmployeeProjectMap> GetEmployeeProjectMapByUser(int userId)
        {
            _logger.LogInformation("Entered into GetAllKMLFilesAsync Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            int attempts = 0;
            try
            {
                attempts++;
                IEnumerable<EmployeeProjectMap> roles;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {
                    string query = "select * from  vw_EmployeeProjectMap where ResourceId ="+ userId.ToString();
                    roles = conn.Query<EmployeeProjectMap>(query, null,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited GetAllKMLFilesAsync Method");

                }
                return roles;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                throw ex;

            }
        }

        public IEnumerable<TimeSheet> GetTImeSheetData()
        {
            _logger.LogInformation("Entered into GetAllKMLFilesAsync Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            int attempts = 0;
            try
            {
                attempts++;
                IEnumerable<TimeSheet> roles;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {
                    string query = "SELECT Id ,MapId ,Hours ,TimeTypeId  ,ApprovalStatus,Description ,CreatedOn  ,Last_updated FROM TimeSheet";
                    roles = conn.Query<TimeSheet>(query, null,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited GetAllKMLFilesAsync Method");

                }
                return roles;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                throw ex;

            }
        }
    }
}
