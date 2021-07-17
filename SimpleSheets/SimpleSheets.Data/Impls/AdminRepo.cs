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

        public void CreateEmployee(Employee employee)
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
                    string query = "INSERT INTO Employee(FullName,UserName,RoleId,Createdon,Last_updated)"
                        + "VALUES(@FullName, @UserName, @RoleId, @Createdon, @Last_updated)";
                    conn.ExecuteScalar<Employee>(query, employee,
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

        public void CreateEmployeeProjectMap(EmployeeProjectMapCreate employee)
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
                    string query = "INSERT INTO EmployeeProjectMap(empId,projectId)"
                                    + "VALUES(@EmpId, @ProjectId)";
                    conn.ExecuteScalar<EmployeeProjectMapCreate>(query, employee,
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

        public void CreateProjects(Projects projects)
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
                    string query = "INSERT INTO Projects(Title)"
                        + "VALUES(@Title)";
                    conn.ExecuteScalar<Projects>(query, projects,
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

        public void CreateRoles(Roles roles)
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
                    string query = "INSERT INTO Role(Title,Createdon,Last_updated)"
                        + "VALUES(@Title,@Createdon,@Last_updated)";
                    conn.ExecuteScalar<Roles>(query, roles,
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

        public void CreateTimeType(TimeType timeType)
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
                    string query = "INSERT INTO TimeType(TimeType)"
                        + "values(@TimeType)";
                    conn.ExecuteScalar<Roles>(query, timeType,
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

        public void DeleteRoleById(int id)
        {
            _logger.LogInformation("Entered into GetAllKMLFilesAsync Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);

            try
            {
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {
                    string query = "Delete from Role where Id=@Id";
                    var roles = conn.ExecuteAsync(query, new { Id = id });
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited GetAllKMLFilesAsync Method");


                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public void DeleteEmployeeById(int id)
        {
            int roles;
            _logger.LogInformation("Entered into GetAllKMLFilesAsync Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            DeleteEmployeeProjectMapEmployee(id);// delete employee proect map table record first
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            try
            {
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query = "Delete from Employee where Id=@Id";
                    roles = conn.Execute(query, new { Id = id });

                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };
                _logger.LogInformation("Exited GetAllKMLFilesAsync Method");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        private void DeleteEmployeeProjectMapEmployee(int id)
        {
            _logger.LogInformation("Entered into GetAllKMLFilesAsync Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);

            try
            {

                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query1 = "Delete from EmployeeProjectMap where empId=@Id";
                    var roles1 = conn.Execute(query1, new { Id = id });
                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };
            }
            catch(Exception e)
            {

            }
            
        }
        public void DeleteProject(int projid)
        {
            _logger.LogInformation("Entered into GetAllKMLFilesAsync Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            DeleteEmployeeProjectMapPrjoect(projid);//need to delete proect mapping record first
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            try
            {
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query1 = "Delete from Projects where Id=@Id";
                    var roles1 = conn.Execute(query1, new { Id = projid });
                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };

                _logger.LogInformation("Exited GetAllKMLFilesAsync Method");
            }
            catch(Exception e)
            {

            }
        }

        public void DeleteEmployeeProjectMapPrjoect(int projid)
        {
            _logger.LogInformation("Entered into GetAllKMLFilesAsync Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            try
            {
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query1 = "Delete from EmployeeProjectMap where projectId=@Id";
                    var roles1 = conn.Execute(query1, new { Id = projid });
                    Console.WriteLine(roles1);
                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };
                _logger.LogInformation("Exited GetAllKMLFilesAsync Method");
            }
            catch(Exception e)
            {

            }

        }

        public void DeleteEmpProjMap(int id)
        {
            int roles;
            _logger.LogInformation("Entered into GetAllKMLFilesAsync Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            DeleteEmployeeProjectMapEmployee(id);// delete employee proect map table record first
            var commandTimeout = int.Parse(_config["CommandTimeout"]);

            try
            {
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query = "Delete from EmployeeProjectMap where Id=@Id";
                    roles = conn.Execute(query, new { Id = id });

                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };
                _logger.LogInformation("Exited GetAllKMLFilesAsync Method");
            }
            catch(Exception e)
            {

            }

        }

        public void DeleteTimeType(int id)
        {
            int roles;
            _logger.LogInformation("Entered into GetAllKMLFilesAsync Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            DeleteTimeSheetTimetypes(id);// delete employee proect map table record first
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            try
            {
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query = "Delete from TimeType where Id=@Id";
                    roles = conn.Execute(query, new { Id = id });

                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };

                _logger.LogInformation("Exited GetAllKMLFilesAsync Method");
            }
            catch(Exception e)
            {
                _logger.LogInformation("Entered into GetAllKMLFilesAsync Method");
                
            }

        }

        private void DeleteTimeSheetTimetypes(int id)
        {
            int roles;
            _logger.LogInformation("Entered into GetAllKMLFilesAsync Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
        
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            try
            {
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query = "Delete from TimeSheet where TimeTypeID=@Id";
                    roles = conn.Execute(query, new { Id = id });

                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };
            }
            catch(Exception e)
            {

            }


        }
    }
}
