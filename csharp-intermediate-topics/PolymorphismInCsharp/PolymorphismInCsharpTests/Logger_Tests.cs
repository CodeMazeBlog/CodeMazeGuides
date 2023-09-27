using Moq;
using NUnit.Framework;
using System.IO;
using Polymorphism;

using System;

namespace PolymorphismTest
{
    public class Logger_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenLogMethodIsCalledThreeTimes_WeGetTheEntriesInTheLog()
        {
            string[] expected = new string[] { "info", "warning", "error" };
            var streamWriterMock = new Mock<StreamWriter>("output.log");
            Logger log = new Logger(streamWriterMock.Object);

            log.Log("info");
            log.Log("warning", LogLevels.Warning);
            log.Log("error", 3);

            foreach (var line in expected)
            {
                streamWriterMock.Verify(a => a.WriteLine(line), Times.Exactly(1));
            }
        }

        [Test]
        public void WhenLogMethodIsCalledWithErrorLogCode_WeGetException()
        {
            var streamWriterMock = new Mock<StreamWriter>("output.log");
            Logger log = new Logger(streamWriterMock.Object);

            Assert.Throws<Exception>(() => log.Log("error", 0));
        }
    }
}