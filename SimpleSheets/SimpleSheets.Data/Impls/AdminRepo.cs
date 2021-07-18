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
    public class AdminRepo: BaseRepo, IAdminRepo
    {
        public AdminRepo(IDbConnectionFactory dbConnectionFactory,
            IConfiguration config, ILogger<AdminRepo> logger, IMemoryCache memoryCache) :
            base(dbConnectionFactory, config, logger, memoryCache)
        {

        }

        public void CreateProjects(Projects projects)
        {
            _logger.LogInformation("Entered into CreateProjects Method");
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
                    string query = "Insert into Projects(ProjectTitle,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy)"
                        + "VALUES(@ProjectTitle,@CreatedOn,@CreatedBy,@ModifiedOn,@ModifiedBy)";
                    conn.ExecuteScalar<Projects>(query, projects,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited CreateProjects Method");

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                throw ex;

            }

        }
        public void CreateTimeType(TimeType timeType)
        {
            _logger.LogInformation("Entered into CreateTimeType Method");
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
                    string query = "INSERT INTO TimeType(TimeTypeTitle,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy)"
                        + "values(@TimeTypeTitle,@CreatedOn,@CreatedBy,@ModifiedOn,@ModifiedBy)";
                    conn.ExecuteScalar<Roles>(query, timeType,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited CreateTimeType Method");

                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                throw ex;

            }
        }

        public IEnumerable<Employee> GetEmployee()
        {
            _logger.LogInformation("Entered into GetEmployee Method");
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
                    string query = "select * from  Employee";
                    roles = conn.Query<Employee>(query, null,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited GetAllKMLFilesAsync Method");

                }
                _logger.LogInformation("Exited GetEmployee Method");
                return roles;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                _logger.LogInformation("Error in  GetEmployee Method" + " " + ex);
                throw ex;

            }
        }

        public IEnumerable<Roles> GetRoles()
        {
            _logger.LogInformation("Entered into GetRoles Method");
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
                    string query = "SELECT * From Role";
                    roles = conn.Query<Roles>(query, null,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited GetAllKMLFilesAsync Method");

                }
                _logger.LogInformation("Exited GetRoles Method");
                return roles;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                _logger.LogInformation("Error in  GetRoles Method" + " " + ex);
                throw ex;

            }
        }

        public IEnumerable<TimeType> GetTimeType()
        {
            _logger.LogInformation("Entered into GetTimeType Method");
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
                    _logger.LogInformation("Exited GetTimeType Method");

                }
                return roles;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                _logger.LogInformation("Error in  GetTimeType Method" + " " + ex);
                throw ex;

            }
        }
    }
}
