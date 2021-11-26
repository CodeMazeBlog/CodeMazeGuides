using ActionAndFuncDelegates;
using System;
using Xunit;

namespace Tests
{
    public class ActionAndFuncDelegatesUnitTests
    {
        [Theory]
        [InlineData(new int[] { 3, 5, 7, 9 }, 24)]
        [InlineData(new int[] { 3, 5, 5, 9 }, 22)]
        public void whenOddNumbersAndOddValidationMethodAsParameters_thenSumOfNumbers(int[] numbers, int sum)
        {
            var result = NumberOperations.SumNumbers(numbers, NumberOperations.IsOdd, NumberOperations.ThrowNumberShouldBeOddException);
            Assert.Equal(sum, result);
        }

        [Theory]
        [InlineData(new int[] { 3, 5, 6, 9 }, 6)]
        [InlineData(new int[] { 1, 5, 3, 2, 8 }, 2)]
        public void whenOneOrMoreEvenNumbersAndOddValidationMethodAsParameter_thenThrowExceptionWithFirstEvenNumber(int[] numbers, int evenNumber)
        {
            Func<object> act = () => NumberOperations.SumNumbers(numbers, NumberOperations.IsOdd, NumberOperations.ThrowNumberShouldBeOddException);

            var exception = Assert.Throws<Exception>(act);
            Assert.Contains(evenNumber.ToString(), exception.Message);
        }
    }
}