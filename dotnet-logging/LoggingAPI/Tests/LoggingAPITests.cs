using LoggingAPI;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.IO;

namespace Tests
{
    [TestClass]
    public class LoggingAPITests
    {
        [TestMethod]
        public void GivenLogger_ShouldLogInformation_WhenStudentIsCreated()
        {
            ILogger<Student> logger = Substitute.For<ILogger<Student>>();
            var student = new Student("John", "IT", logger);

            logger.Received(1).LogInformation("Name of student is John and his department is IT");
        }

        [TestMethod]
        public void GivenLoggerFactory_ShouldCreateLogger_WhenDepartmentIsCreated()
        {
            ILoggerFactory loggerFactory = Substitute.For<ILoggerFactory>();
            var department = new Department("IT", "Information Technology", loggerFactory);

            loggerFactory.Received(1).CreateLogger<Department>();
        }
    }
}