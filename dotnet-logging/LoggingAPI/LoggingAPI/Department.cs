using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingAPI
{
    public class Department
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private readonly ILogger _logger;
            
        public Department(string name, string description, ILoggerFactory factory)
        {
            Name = name;
            Description = description;

            _logger = factory.CreateLogger<Department>();
            _logger.LogInformation("Department is " + Name + " " + Description);
        }
    }
}
