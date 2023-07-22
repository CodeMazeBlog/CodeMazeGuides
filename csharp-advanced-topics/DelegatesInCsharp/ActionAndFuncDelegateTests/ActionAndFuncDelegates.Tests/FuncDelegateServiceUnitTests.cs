using ActionAndFuncDelegates.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates.Tests
{
    public class FuncDelegateServiceUnitTests
    {
        [Theory]
        [InlineData(5, 10, 15)] // 5 + 10 = 15
        [InlineData(-5, 10, 5)] // -5 + 10 = 5
        [InlineData(0, 0, 0)] // 0 + 0 = 0
        public void Add_GivenTwoNumbers_WhenAddIsCalled_ThenShouldReturnSum(int a, int b, int expectedSum)
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            funcDelegateService.AdditionFunc = (x, y) => x + y; // Set the AdditionFunc delegate

            // Act
            int actualSum = funcDelegateService.Add(a, b);

            // Assert
            Assert.Equal(expectedSum, actualSum);

        }

        [Theory]
        [InlineData(10, 5, 5)] // 10 - 5 = 5
        [InlineData(-5, 10, -15)] // -5 - 10 = -15
        [InlineData(0, 0, 0)] // 0 - 0 = 0
        public void Subtract_GivenTwoNumbers_WhenSubtractIsCalled_ThenShouldReturnDifference(int a, int b, int expectedDifference)
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            funcDelegateService.SubtractionFunc = (x, y) => x - y;

            // Act
            int actualDifference = funcDelegateService.Subtract(a, b);

            // Assert
            Assert.Equal(expectedDifference, actualDifference);
        }

        [Theory]
        [InlineData(5, 10, 50)] // 5 * 10 = 50
        [InlineData(-5, 10, -50)] // -5 * 10 = -50
        [InlineData(0, 0, 0)] // 0 * 0 = 0
        public void Multiply_GivenTwoNumbers_WhenMultiplyIsCalled_ThenShouldReturnProduct(int a, int b, int expectedProduct)
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            funcDelegateService.MultiplicationFunc = (x, y) => x * y; // Set the MultiplicationFunc delegate

            // Act
            int actualProduct = funcDelegateService.Multiply(a, b);

            // Assert
            Assert.Equal(expectedProduct, actualProduct);
        }

        [Theory]
        [InlineData(10, 2, 5)] // 10 / 2 = 5
        [InlineData(-10, 2, -5)] // -10 / 2 = -5
        [InlineData(5, 0, double.PositiveInfinity)] // 5 / 0 = Positive Infinity
        public void Divide_GivenTwoNumbers_WhenDivideIsCalled_ThenShouldReturnQuotient(int a, int b, double expectedQuotient)
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            funcDelegateService.DivisionFunc = (x, y) => (double)x / y; // Set the DivisionFunc delegate

            // Act
            double actualQuotient = funcDelegateService.Divide(a, b);

            // Assert
            Assert.Equal(expectedQuotient, actualQuotient);
        }

        [Fact]
        public void Divide_GivenZeroDividend_WhenDivideIsCalled_ThenShouldReturnZero()
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            funcDelegateService.DivisionFunc = (x, y) => (double)x / y;
            int dividend = 0;
            int divisor = 5;
            double expectedQuotient = 0;

            // Act
            double actualQuotient = funcDelegateService.Divide(dividend, divisor);

            // Assert
            Assert.Equal(expectedQuotient, actualQuotient);
        }

        [Fact]
        public void Divide_GivenDivisorEqualToZero_WhenDivideIsCalled_ThenShouldReturnPositiveInfinity()
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            funcDelegateService.DivisionFunc = (x, y) => (double)x / y;
            int dividend = 10;
            int divisor = 0;

            // Act
            double result = funcDelegateService.Divide(dividend, divisor);

            // Assert
            Assert.Equal(double.PositiveInfinity, result);
        }


        [Theory]
        [InlineData(100, 10)] // 10% tithe of 100 is 10
        [InlineData(500, 50)] // 10% tithe of 500 is 50
        [InlineData(1000, 100)] // 10% tithe of 1000 is 100
        public void CalculateTitheFunc_GivenEarnings_WhenCalculateTitheIsCalled_ThenShouldReturnCorrectTitheAmount(double earnings, double expectedTitheAmount)
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();

            // Act
            double actualTitheAmount = 0;
            funcDelegateService.CalculateTitheFunc = (e) => e * 0.1; // 10% tithe

            actualTitheAmount = funcDelegateService.CalculateTithe(earnings);

            // Assert
            Assert.Equal(expectedTitheAmount, actualTitheAmount, 2); // Using 2 decimal places for comparison
        }

        [Fact]
        public void CalculateTitheFunc_GivenNoCalculationDefined_WhenCalculateTitheIsCalled_ThenShouldThrowInvalidOperationException()
        {
            // Arrange
            var funcDelegateService = new FuncDelegateService();
            double earnings = 500;

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => funcDelegateService.CalculateTithe(earnings));
        }
    }
}
