using System;
using Xunit;
using ActionAndFunc;

namespace TestProject1
{
    public class ActionDelegateUnitTest
    {
        [Fact]
        public void WhenNumberIsPassedToDoubleNumber_ThenNumberShouldBeDoubled()
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
    }
}
