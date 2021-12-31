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
        private readonly ILogger<Log> logger;
        private readonly Log logClass;

        public LoggingAPITests()
        {
            logger = Substitute.For<ILogger<Log>>();
            logClass = new Log(logger);
        }


        [TestMethod]
        public void GivenLogger_ShouldLogInformation()
        {
            logClass.logInfo("I am a log message");

            logger.Received(1).LogInformation("I am a log message");
        }
    }
}