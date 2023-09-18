using System;
using Xunit;
using ActionAndFunc;

namespace TestProject1
{
    public class ActionDelegateUnitTest
    {
        [Fact]
        public void DoubleNumber_ShouldDoubleNumber()
        {
            // Arrange
            var actionDelegate = new ActionFuncDelegate();
            int number = 3;
            string expectedOutput = "Double of 3 is: 6";

            // Redirect Console output to capture it
            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                ActionFuncDelegate.DoubleNumber(number);

                // Assert
                Assert.Equal(expectedOutput, consoleOutput.GetOutput());
            }
        }

        // Helper class to capture Console output
        private class ConsoleOutput : IDisposable
        {
            private StringWriter _stringWriter;
            private TextWriter _originalOutput;

            public ConsoleOutput()
            {
                _stringWriter = new StringWriter();
                _originalOutput = Console.Out;
                Console.SetOut(_stringWriter);
            }

            public string GetOutput()
            {
                return _stringWriter.ToString().Trim();
            }

            public void Dispose()
            {
                _stringWriter.Dispose();
                Console.SetOut(_originalOutput);
            }
        }
    }
}
