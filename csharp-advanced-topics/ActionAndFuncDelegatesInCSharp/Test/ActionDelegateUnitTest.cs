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
            int number = 3;
            string expectedOutput = "Double of 3 is: 6";
            
            // Act
            int result = ActionFuncDelegate.DoubleNumber(number);

            // Assert
            Assert.Equal(expectedOutput, result);
        }
    }
}
