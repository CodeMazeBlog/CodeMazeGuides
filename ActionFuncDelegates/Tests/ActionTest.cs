using Xunit;
using System;

namespace ActionFuncDelegates.Tests
{
    public class ActionTest
    {
        [Fact]
        public void ActionDelegate_ShouldPrintCorrectResults()
        {
            // Arrange
            var consoleOutput = new ConsoleOutput();

            // Act
            ActionDelegates.ActionDelegate();

            // Assert
            var outputLines = consoleOutput.GetOutputLines();
            Assert.Contains("Add Inputs: 30", outputLines);
            Assert.Contains("Subtract Inputs: 10", outputLines);
        }

        [Fact]
        public void ActionDelegateAnonymous_ShouldPrintCorrectResults()
        {
            // Arrange
            var consoleOutput = new ConsoleOutput();

            // Act
            ActionDelegates.ActionDelegateWithAnonymous();

            // Assert
            var outputLines = consoleOutput.GetOutputLines();
            Assert.Contains("Subtract = 20", outputLines);
        }

        [Fact]
        public void ActionDelegateLambda_ShouldPrintCorrectResults()
        {
            // Arrange
            var consoleOutput = new ConsoleOutput();

            // Act
            ActionDelegates.ActionDelegateWithLambda();

            // Assert
            var outputLines = consoleOutput.GetOutputLines();
            Assert.Contains("Result: 10", outputLines);
        }
    }

    // Helper class to capture console output
    public class ConsoleOutput : IDisposable
    {
        private readonly StringWriter stringWriter;
        private readonly TextWriter originalOutput;

        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public List<string> GetOutputLines()
        {
            return stringWriter.ToString().Split(Environment.NewLine).ToList();
        }

       
    }

}
