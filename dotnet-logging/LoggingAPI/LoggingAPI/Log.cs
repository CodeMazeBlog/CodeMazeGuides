using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingAPI
{
    public class Log
    {
        private readonly ILogger _logger;

        public Log(ILogger<Log> logger)
        {
            _logger = logger;
        }

        public void logInfo(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
