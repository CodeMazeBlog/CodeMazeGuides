using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingAPI
{
    public class Student
    {
        public string Name { get; set; }
        public string Department { get; set; }

        private readonly ILogger _logger;

        public Student(string name, string department, ILogger<Student> logger)
        {
            this.Name = name;
            this.Department = department;
            _logger = logger;

            _logger.LogInformation("A new student is created " + this.Name +" and his department is " + this.Department);
        }
    }
}
