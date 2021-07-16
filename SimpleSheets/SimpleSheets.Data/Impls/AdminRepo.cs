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
    public class AdminRepo : BaseRepo, IAdminRepo
    {
        public AdminRepo(IDbConnectionFactory dbConnectionFactory,
            IConfiguration config, ILogger<AdminRepo> logger, IMemoryCache memoryCache) :
            base(dbConnectionFactory, config, logger, memoryCache)
        {

        }

        public IEnumerable<Employee> GetEmployee()
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
                IEnumerable<Employee> roles;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {
                    string query = "select Id,FullName,UserName,RoleId,CreatedOn,Last_updated from  Employee";
                    roles = conn.Query<Employee>(query, null,
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

        public IEnumerable<EmployeeProjectMap> GetEmployeeProjectMap()
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
                    string query = "select * from vw_EmployeeProjectMap";
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

        public IEnumerable<Projects> GetProjects()
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
                IEnumerable<Projects> roles;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {
                    string query = "SELECT Id, Title From Projects";
                    roles = conn.Query<Projects>(query, null,
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

        public IEnumerable<Roles> GetRoles()
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
                IEnumerable<Roles> roles;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {
                    string query = "SELECT Id, Title,CreatedOn,Last_updated From Role";
                    roles = conn.Query<Roles>(query, null,
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

        public IEnumerable<TimeType> GetTimeType()
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
                IEnumerable<TimeType> roles;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {
                    string query = "select * from TimeType";
                    roles = conn.Query<TimeType>(query, null,
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
