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
            Student student = new Student("Test", "Test department", logger);

            logger.Received(1).LogInformation("A new student is created Test and his department is Test department");
        }

        [TestMethod]
        public void GivenLoggerFactory_ShouldCreateLogger_WhenDepartmentIsCreated()
        {
            ILoggerFactory loggerFactory = Substitute.For<ILoggerFactory>();
            Department department = new Department("Test", "Test department", loggerFactory);

            loggerFactory.Received(1).CreateLogger<Department>();
        }
    }
}