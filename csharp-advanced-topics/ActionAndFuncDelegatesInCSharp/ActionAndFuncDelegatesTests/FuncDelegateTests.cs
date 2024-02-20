using System;
using Xunit;

namespace ActionAndFuncDelegates.Tests
{
    public class FuncDelegatesTests
    {
        [Fact]
        public void WhenPerformingAddition_ShouldReturnSum()
        {
            // Arrange
            int x = 5;
            int y = 3;

            // Act
            int result = FuncDelegates.Add(x, y);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void WhenPerformingSubtraction_ShouldReturnDifference()
        {
            // Arrange
            int x = 7;
            int y = 4;

            // Act
            int result = FuncDelegates.Subtract(x, y);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void WhenPerformingMultiplication_ShouldReturnProduct()
        {
            // Arrange
            int x = 6;
            int y = 2;

            // Act
            int result = FuncDelegates.Multiply(x, y);

            // Assert
            Assert.Equal(12, result);
        }
    }
}
