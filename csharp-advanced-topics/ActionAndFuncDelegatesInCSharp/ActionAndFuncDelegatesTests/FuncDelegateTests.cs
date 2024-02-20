using System;
using Xunit;

namespace ActionAndFuncDelegates.Tests
{
    public class FuncDelegatesTests
    {
        [Fact]
        public void Add_ShouldReturnSum()
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
        public void Subtract_ShouldReturnDifference()
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
        public void Multiply_ShouldReturnProduct()
        {
            // Arrange
            int x = 6;
            int y = 2;

            // Act
            int result = FuncDelegates.Multiply(x, y);

            // Assert
            Assert.Equal(12, result);
        }

        [Fact]
        public void PerformAddition_ShouldReturnSum()
        {
            // Arrange
            int a = 10;
            int b = 5;

            // Act
            int result = FuncDelegates.PerformAddition(a, b);

            // Assert
            Assert.Equal(15, result);
        }
    }
}
