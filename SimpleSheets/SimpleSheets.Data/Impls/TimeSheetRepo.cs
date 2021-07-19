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
            _logger.LogInformation("Entered into CreateTimeSheetRecord Method");
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
                    string query = "INSERT INTO TimeSheet(EmpId,NoOfHours,TimeTypeID,ProjectId ,Description,CreatedOn ,CreatedBy ,ModifiedOn,ModifiedBy,ApproverId,ApprovalStatus,ApprovalViewStatus,ApprovedBy,ApprovedOn)"
                        + "VALUES(@EmpId,@NoOfHours,@TimeTypeID,@ProjectId ,@Description,@CreatedOn ,@CreatedBy ,@ModifiedOn,@ModifiedBy,@ApproverId,@ApprovalStatus,@ApprovalViewStatus,@ApprovedBy,@ApprovedOn)";
                    conn.ExecuteScalar<Employee>(query, timeSheet,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited CreateTimeSheetRecord Method");

                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Task.Delay(timeSpanDelay);
                throw ex;

            }
        }

        public IEnumerable<TimeSheetsView> GetTimeSheetApprovaData(string managerId)
        {
            _logger.LogInformation("Entered into GetTimeSheetApprovaData Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            int attempts = 0;
            try
            {
                attempts++;
                IEnumerable<TimeSheetsView> roles;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {
                    string query = "select TimeSheetRecordId, EmployeeName,Project,TimeType,Hours,ApprovalStatus from VW_Timesheet where ApproverId='" + managerId + "'and ApprovalViewStatus=0";
                    roles = conn.Query<TimeSheetsView>(query, null,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited GetTimeSheetApprovaData Method");

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

        public IEnumerable<TimeSheetsView> GetTimeSheetData(string EmpId)
        {
            _logger.LogInformation("Entered into GetTImeSheetData Method");
            var maxRetryAttempts = int.Parse(_config["MaxRetryAttempts"]);
            var pauseBetweenFailures = int.Parse(_config["PauseBeforeRetryInSec"]);
            var timeSpanDelay = TimeSpan.FromSeconds(pauseBetweenFailures);
            var commandTimeout = int.Parse(_config["CommandTimeout"]);
            int attempts = 0;
            try
            {
                attempts++;
                IEnumerable<TimeSheetsView> roles;
                using (var conn = _dbConnectionFactory.GetConnection(_itrConnectionName))
                {
                    string query = "select EmployeeName,Project,TimeType,ApproverName,Hours,ApprovalStatus,ApprovedOn,ApprovalViewStatus from VW_Timesheet where EmployeeId='" + EmpId+"'";
                    roles = conn.Query<TimeSheetsView>(query, null,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited GetTImeSheetData Method");

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

        public void UpdateTimesheetStatus(TimeSheet timeSheetsView)
        {
            _logger.LogInformation("Entered into CreateTimeSheetRecord Method");
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
                    string query = "Update Timesheet set ApprovalStatus =@ApprovalStatus , ApprovalViewStatus=@ApprovalViewStatus,ModifiedBy=@ModifiedBy,ModifiedOn=@ModifiedOn,ApprovedOn=@ApprovedOn,ApprovedBy=@ApprovedBy "
                        + "where id=@Id";
                    conn.ExecuteScalar<Employee>(query, timeSheetsView,
                        commandTimeout: commandTimeout);
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        Priority = CacheItemPriority.High,
                        AbsoluteExpiration = DateTime.Now.AddDays(7)
                    };
                    _logger.LogInformation("Exited CreateTimeSheetRecord Method");

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
