using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Test.Classes
{
    public class LogManagerTests
    {
        [Fact]
        public void LogManager_Log_WritesToConsole()
        {
            // Arrange
            using ConsoleOutput consoleOutput = new();
            
            string message = "Test log message";

            // Act
            LogManager.Log(message);

            Console.WriteLine(consoleOutput.GetOutput());

            // Assert
            Assert.Contains($"LOG: {message}", consoleOutput.GetOutput());
        }
    }
}