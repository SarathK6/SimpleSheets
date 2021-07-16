using SimpleSheets.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Interface
{
    public interface IConnectionDetail
    {
        string DbConnectionName { get; set; }
        DbConnectionType? DbConnectionType { get; set; }
        string ConnectionString { get; set; }
    }
}
