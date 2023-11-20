using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod]
        public void ActionDelegateSample_Test()
        {
            // Arrange
            string expectedMessage = "Hello, invoking the delegate!";
            string? actualMessage = null;

            // Act
            Action<string> testPrintMessage = message =>
            {
                actualMessage = message;
            };

            // Invoke the method being tested
            Program.ActionDelegateSample();

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void FuncDelegateSample_Test()
        {
            // Arrange
            double radius = 20;
            double expectedArea = 3.12 * radius * radius;
            double actualArea = 0;

            // Act
            Func<double, double> testCalArea = r =>
            {
                return 3.12 * r * r;
            };

            // Invoke the method being tested
            Program.FuncDelegateSample();

            // Assert
            Assert.AreEqual(expectedArea, actualArea);
        }
    }
}