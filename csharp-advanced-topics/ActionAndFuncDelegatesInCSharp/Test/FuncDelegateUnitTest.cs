using System;
using Xunit;
using ActionAndFunc;

namespace TestProject1
{
    public class FuncDelegateUnitTest
    {
        [Theory]
        [InlineData(2, true)]
        [InlineData(3, false)]
        public void IsEven_ShouldReturnCorrectResult(int number, bool expected)
        {
            // Act
            bool result = ActionFuncDelegate.IsEven(number);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
