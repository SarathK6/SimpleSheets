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

        public void AddEmployee(Employee employee)
        {
            _logger.LogInformation("Entered into AddEmployee Method");
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
                    string query = "Insert into Employee(EmpId  ,ManagerId  ,FullName  ,UserName , CreatedOn,CreatedBy , ModifiedOn,ModifiedBy)"
                        + "VALUES(@EmpId  ,@ManagerId  ,@FullName  ,@UserName , @CreatedOn,@CreatedBy , @ModifiedOn,@ModifiedBy)";
                    conn.ExecuteScalar<Projects>(query, employee,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited AddEmployee Method");

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                throw ex;

            }
        }

        public void AddEmployeeRole(EmployeeRoleMap employeeRoleMap)
        {
            _logger.LogInformation("Entered into AddEmployeeRole Method");
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
                    string query = "Insert into EmployeeRoleMap(EmpId,Role,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy)"
                        + "VALUES(@EmpId,@Role,@CreatedOn,@CreatedBy,@ModifiedOn,@ModifiedBy)";
                    conn.ExecuteScalar<Projects>(query, employeeRoleMap,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited AddEmployeeRole Method");

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                throw ex;

            }
        }

        public void AddRole(Roles roles)
        {
            _logger.LogInformation("Entered into AddRole Method");
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
                    string query = "Insert into Role(RoleTitle , CreatedOn,CreatedBy , ModifiedOn,ModifiedBy)"
                        + "VALUES(@RoleTitle , @CreatedOn,@CreatedBy , @ModifiedOn,@ModifiedBy)";
                    conn.ExecuteScalar<Projects>(query, roles,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited AddRole Method");

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

        public IEnumerable<EmployeeRoleMap> GetEmployeeProjectMap()
        {
            _logger.LogInformation("Entered into GetEmployeeProjectMap Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            int attempts = 0;
            try
            {
                attempts++;
                IEnumerable<EmployeeRoleMap> roles;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {
                    string query = "select * from  EmployeeRoleMap";
                    roles = conn.Query<EmployeeRoleMap>(query, null,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited GetEmployeeProjectMap Method");

                }
                _logger.LogInformation("Exited GetEmployee Method");
                return roles;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                _logger.LogInformation("Error in  GetEmployeeProjectMap Method" + " " + ex);
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

        public void DeleteRoleById(int id)
        {
            _logger.LogInformation("Entered into DeleteRoleById Method");
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
                    _logger.LogInformation("Exited DeleteRoleById Method");


                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public void DeleteEmployeeById(string id)
        {
            int roles;
            _logger.LogInformation("Entered into DeleteEmployeeById Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            DeleteEmployeeProjectMapEmployee(id);// delete employee proect map table record first
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            try
            {
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query = "Delete from Employee where EmpId=@Id";
                    roles = conn.Execute(query, new { Id = id });

                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };
                _logger.LogInformation("Exited DeleteEmployeeById Method");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        private void DeleteEmployeeProjectMapEmployee(string id)
        {
            _logger.LogInformation("Entered into DeleteEmployeeProjectMapEmployee Method");
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
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;

            }

        }
        public void DeleteProject(int projid)
        {
            _logger.LogInformation("Entered into DeleteProject Method");
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

                _logger.LogInformation("Exited DeleteProject Method");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public void DeleteEmployeeProjectMapPrjoect(int projid)
        {
            _logger.LogInformation("Entered into DeleteEmployeeProjectMapPrjoect Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            try
            {
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query1 = "Delete from EmployeeRoleMap where Id=@Id";
                    var roles1 = conn.Execute(query1, new { Id = projid });
                    Console.WriteLine(roles1);
                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };
                _logger.LogInformation("Exited DeleteEmployeeProjectMapPrjoect Method");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }

        }

        public void DeleteEmpRoleMap(string id)
        {
            int roles;
            _logger.LogInformation("Entered into DeleteEmpRoleMap Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            /*eleteEmployeeProjectMapEmployee(id);// delete empl*/
            var commandTimeout = int.Parse(_config["CommandTimeout"]);

            try
            {
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query = "Delete from EmployeeRoleMap where Id=@Id";
                    roles = conn.Execute(query, new { Id = id });

                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };
                _logger.LogInformation("Exited DeleteEmpRoleMap Method");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }

        }

        public void DeleteTimeType(int id)
        {
            int roles;
            _logger.LogInformation("Entered into DeleteTimeType Method");
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

                _logger.LogInformation("Exited DeleteTimeType Method");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }

        }

        private void DeleteTimeSheetTimetypes(int id)
        {
            int roles;
            _logger.LogInformation("Entered into DeleteTimeSheetTimetypes Method");
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
                _logger.LogInformation("Exited into DeleteTimeSheetTimetypes Method");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }


        }
        public Roles GetRolesbyId(int id)

        {
            _logger.LogInformation("Entered into GetRolesbyId Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            try
            {
                Roles roles;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query = "select * from Role where Id=@Id";
                    roles = conn.QuerySingleOrDefault<Roles>(query, new { Id = id },
                        commandTimeout: commandTimeout);

                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };
                _logger.LogInformation("Exited GetRolesbyId Method");
                return roles;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public Projects GetProjectById(int id)
        {

            _logger.LogInformation("Entered into GetProjectById Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            try
            {
                Projects roles;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query = "select * from Projects where Id=@Id";
                    roles = conn.QuerySingleOrDefault<Projects>(query, new { Id = id },
                        commandTimeout: commandTimeout);

                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };
                _logger.LogInformation("Exited GetProjectById Method");
                return roles;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }



        }

        public Employee GetEmployeeById(int id)
        {

            _logger.LogInformation("Entered into GetEmployeeById Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            try
            {
                Employee roles;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query = "select * from Employee where Id=@Id";
                    roles = conn.QuerySingleOrDefault<Employee>(query, new { Id = id },
                        commandTimeout: commandTimeout);

                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };
                _logger.LogInformation("Exited GetEmployeeById Method");
                return roles;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }

        }

        public TimeType GetTimeTypeById(int id)
        {

            _logger.LogInformation("Entered into GetTimeTypeById Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            try
            {
                TimeType roles;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {

                    string query = "select * from TimeType where Id=@Id";
                    roles = conn.QuerySingleOrDefault<TimeType>(query, new { Id = id },
                        commandTimeout: commandTimeout);

                }
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddDays(7)
                };
                _logger.LogInformation("Exited GetTimeTypeById Method");
                return roles;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }

        }

        public void UpdateTimeTypeById(TimeType roles)
        {
            _logger.LogInformation("Entered into UpdateTimeTypeById Method");
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
                    string query = "Update TimeType SET TimetypeTitle=@TimetypeTitle,ModifiedOn=@ModifiedOn,ModifiedBy=@ModifiedBy where Id=@Id";
                    conn.ExecuteScalar<TimeType>(query, roles,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited UpdateTimeTypeById Method");

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                throw ex;

            }


        }

        public void UpdateRoleById(Roles roles)
        {
            _logger.LogInformation("Entered into UpdateRoleById Method");
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
                    string query = "Update Role SET RoleTitle=@RoleTitle,ModifiedOn=@ModifiedOn,ModifiedBy=@ModifiedBy where Id=@Id";
                    conn.ExecuteScalar<Roles>(query, roles,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited UpdateRoleById Method");

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                throw ex;

            }


        }

        public void UpdateProjectById(Projects projects)
        {

            _logger.LogInformation("Entered into UpdateProjectById Method");
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
                    string query = "Update Projects SET ProjectTitle=@ProjectTitle,ModifiedOn=@ModifiedOn,ModifiedBy=@ModifiedBy where Id=@Id";
                    conn.ExecuteScalar<Roles>(query, projects,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited UpdateProjectById Method");

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                throw ex;

            }

        }
        public void UpdateEmployeeById(Employee employee)
        {

            _logger.LogInformation("Entered into UpdateEmployeeById Method");
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
                    string query = "Update Employee SET FullName=@FullName,UserName=@UserName,ModifiedOn=@ModifiedOn,ModifiedBy=@ModifiedBy where Id=@Id";
                    conn.ExecuteScalar<Roles>(query, employee,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited UpdateEmployeeById Method");

                }
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

