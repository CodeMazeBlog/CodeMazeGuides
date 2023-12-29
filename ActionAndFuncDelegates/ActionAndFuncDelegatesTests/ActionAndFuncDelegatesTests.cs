namespace ActionAndFuncDelegatesTests
{
    using Microsoft.VisualStudio.TestPlatform.TestHost;
    using System;
    using ActionAndFuncDelegates;
    using System.Collections.Generic;
    using Xunit;

    public class ActionAndFuncDelegatesTests
    {
        [Fact]
        public void WhenUsingPrintNumbers_ThenReturns12345()
        {
            // Arrange
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                // Act
                ActionAndFuncDelegates.PrintNumbers(numbers);

                // Assert
                Assert.Equal("1 2 3 4 5 ", stringWriter.ToString());
            }
        }

        [Fact]
        public void WhenUsingTestCalculateSum_ThenReturn15()
        {
            // Arrange
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            int sum = ActionAndFuncDelegates.CalculateSum(numbers);

            // Assert
            Assert.Equal(15, sum);
        }
    }

}