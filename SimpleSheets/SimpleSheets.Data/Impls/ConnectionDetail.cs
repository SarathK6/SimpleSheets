using SimpleSheets.Data.Enums;
using SimpleSheets.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Impls
{
    public class ConnectionDetail : IConnectionDetail
    {
        public string DbConnectionName { get; set; }
        public DbConnectionType? DbConnectionType { get; set; }
        public string ConnectionString { get; set; }
        public ConnectionDetail(string dbConnectionName, DbConnectionType? dbConnectionType, string connectionString)
        {
            DbConnectionName = string.IsNullOrWhiteSpace(dbConnectionName) ? throw
                new ArgumentNullException(nameof(dbConnectionName),
                $"{nameof(dbConnectionName)} cannot be null") : dbConnectionName;
            DbConnectionType = dbConnectionType ?? throw
                new ArgumentNullException(nameof(dbConnectionType),
                $"{nameof(dbConnectionType)} cannot be null");
            ConnectionString = string.IsNullOrWhiteSpace(connectionString) ? throw
                new ArgumentNullException(nameof(connectionString),
                $"{nameof(connectionString)} cannot be null") : connectionString;
        }
    }
}
