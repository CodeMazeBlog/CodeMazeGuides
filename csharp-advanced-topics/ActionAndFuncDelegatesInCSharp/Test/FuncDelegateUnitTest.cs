using System;
using Xunit;
using ActionAndFunc;

namespace TestProject1;
{
    public class FuncDelegateUnitTest
    {
        public void IsEven_ShouldReturnCorrectResult(int number, bool expected)
        {
            // Act
            var funcDelegate = new ActionFuncDelegate();
            bool result = funcDelegate.IsEven(number);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
