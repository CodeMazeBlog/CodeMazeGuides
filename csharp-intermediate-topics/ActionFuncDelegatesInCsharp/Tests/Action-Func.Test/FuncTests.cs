using Action_Func;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ActionFunc.Test
{
    public class FuncTests
    {
        private readonly List<string> fruits;
        private readonly List<int> numbers;

        public FuncTests()
        {
            fruits = new List<string> { "Apple", "Banana", "Orange", "Mango", "Watermelon" };
            numbers = new List<int> { 10, 25, 7, 30, 15, 8, 64 };
        }

        [Fact]
        public void WhenGivenAListOfFruits_ThenShouldReturnLengthOfFruitNames()
        {
            // Arrange
            var expectedLengths = new List<int> { 5, 6, 6, 5, 10 };

            // Act
            var fruitNameLengths = FuncExample.GetFruitNameLengths(fruits);

            // Assert
            Assert.Equal(expectedLengths, fruitNameLengths);
        }

        [Theory]
        [InlineData(15, new int[] { 25, 30, 64 })]
        [InlineData(20, new int[] { 25, 30, 64 })]
        [InlineData(30, new int[] { 64 })]
        public void WhenGivenAListOfNumbersAndSpecifiedValue_ThenShouldFilterNumbersGreaterThanSpecifiedValue(int filterValue, int[] expectedNumbers)
        {
            // Act
            var filteredNumbers = FuncExample.GetFilteredNumbers(numbers, filterValue);

            // Assert
            Assert.Equal(expectedNumbers, filteredNumbers);
        }

        [Theory]
        [InlineData(10, 5, 15, 5)]
        [InlineData(30, 15, 45, 15)]
        [InlineData(-10, 5, -5, -15)]
        public void WhenGivenTwoNumbersToCalculate_ThenShouldReturnSumAndSubtractionResults(int firstNum, int secondNum, int expectedSum, int expectedSubtract)
        {
            // Act
            var (sum, subtract) = FuncExample.Calculate(firstNum, secondNum);

            // Assert
            Assert.Equal(expectedSum, sum);
            Assert.Equal(expectedSubtract, subtract);
        }
    }
}
