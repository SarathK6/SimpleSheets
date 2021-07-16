using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SimpleSheets.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSheets.Data.Impls
{
    public class BaseRepo
    {
        protected readonly IDbConnectionFactory _dbConnectionFactory;
        protected readonly IConfiguration _config;
        protected readonly ILogger<BaseRepo> _logger;
        protected readonly string _itrConnectionName = "ITRConnection";
        protected readonly IMemoryCache _memoryCache;
        public BaseRepo(IDbConnectionFactory dbConnectionFactory,
            IConfiguration config, ILogger<BaseRepo> logger, IMemoryCache memoryCache)
        {
            _dbConnectionFactory = dbConnectionFactory ?? throw
                new ArgumentNullException(nameof(dbConnectionFactory),
                $"{nameof(dbConnectionFactory)} cannot be null");
            _config = config;
            _logger = logger;
            _memoryCache = memoryCache;
        }
    }
}
