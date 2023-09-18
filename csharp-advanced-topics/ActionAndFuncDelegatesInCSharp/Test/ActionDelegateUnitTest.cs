using System;
using Xunit;
using ActionAndFunc;

namespace TestProject1;
{
    public class ActionDelegateUnitTest
{
        [Fact]
        public void DoubleNumber_ShouldDoubleNumber()
        {
            // Arrange
            var actionDelegate = new ActionDelegate();
            int number = 3;
            string expectedOutput = "Double of 3 is: 6";

            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                actionDelegate.DoubleNumber(number);

                // Assert
                Assert.Equal(expectedOutput, consoleOutput.GetOuput());
            }
        }
    }
}
