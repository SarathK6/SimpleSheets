using SimpleSheets.Data.Enums;
using SimpleSheets.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SimpleSheets.Data.Impls
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IList<IConnectionDetail> _connectionDetails;
        public DbConnectionFactory(IList<IConnectionDetail> connectionDetails)
        {
            _connectionDetails = connectionDetails ?? throw
                new ArgumentNullException(nameof(connectionDetails),
                $"{nameof(connectionDetails)} cannot be null");
        }
        public IDbConnection GetConnection(string connectionName)
        {
            var connectionDetail = _connectionDetails.FirstOrDefault(c =>
            c.DbConnectionName.ToLower() == connectionName.ToLower());
            if (connectionDetail == null)
            {
                throw
                    new ArgumentNullException(nameof(connectionName),
                    "invalid connection name");
            }
            return GetConnection(connectionDetail);
        }
        private IDbConnection GetConnection(IConnectionDetail connectionDetail)
        {
            switch (connectionDetail.DbConnectionType)
            {
                case DbConnectionType.SqlServer:
                    return new SqlConnection(connectionDetail.ConnectionString);
                //case DbConnectionType.Oracle:
                //    return new OracleConnection(connectionDetail.ConnectionString);
                //case DbConnectionType.MySql:
                //    return new MySqlConnection(connectionDetail.ConnectionString);
                default:
                    throw
                        new ArgumentException("invalid connection detail",
                        nameof(connectionDetail));
            }
        }
    }
}
