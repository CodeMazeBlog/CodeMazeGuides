using FuncAndActionsInCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class FuncDelegatesTests
    {
        [Fact]
        public void WhenGettingRandomNumber_ThenReturnsInt()
        {
            // Act
            var number = FuncDelegates.GetRandomNumber();

            // Assert
            Assert.IsType<int>(number);
        }

        [Theory]
        [InlineData(10, 5, 15)]
        public void WhenAddingNumbers_ThenReturnsSum(int a, int b, int expectedSum)
        {
            // Act
            var result = FuncDelegates.Add(a, b);

            // Assert
            Assert.Equal(expectedSum, result);
        }

        [Theory]
        [InlineData(3, 4, 12)]
        public void WhenMultiplyingNumbers_ThenReturnsProduct(int a, int b, int expectedProduct)
        {
            // Act
            var product = FuncDelegates.Multiply(a, b);

            // Assert
            Assert.Equal(expectedProduct, product);
        }
    }
}
