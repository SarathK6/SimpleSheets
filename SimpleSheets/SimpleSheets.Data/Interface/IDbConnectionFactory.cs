using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SimpleSheets.Data.Interface
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetConnection(string connectionName);
    }
}
