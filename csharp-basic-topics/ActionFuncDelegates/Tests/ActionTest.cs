using System;
using System.IO;
using Xunit;

namespace ActionFuncDelegates.Tests
{
    public class ActionDelegatesTests
    {
        [Fact]
        public void TestActionDelegate()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                ActionDelegates.ActionDelegate();

                // Assert
                string consoleOutput = sw.ToString();
                Assert.Contains("Add Inputs: 30", consoleOutput);
                Assert.Contains("Subtract Inputs: 10", consoleOutput);
            }
        }

        [Fact]
        public void TestActionDelegateWithAnonymous()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                ActionDelegates.ActionDelegateWithAnonymous();

                // Assert
                string consoleOutput = sw.ToString();
                Assert.Contains("Subtract = 20", consoleOutput);
            }
        }

        [Fact]
        public void TestActionDelegateWithLambda()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                ActionDelegates.ActionDelegateWithLambda();

                // Assert
                string consoleOutput = sw.ToString();
                Assert.Contains("Result: 10", consoleOutput);
            }
        }
    }
}
