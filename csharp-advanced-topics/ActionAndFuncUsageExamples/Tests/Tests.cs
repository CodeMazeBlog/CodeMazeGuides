using AutoFixture.Xunit2;
using System;
using Xunit;


namespace Tests
{
    public class Tests: IClassFixture<MathServiceTestFixure>
    {
        private readonly MathServiceTestFixure _mathServiceFixure;

        public Tests(MathServiceTestFixure mathServiceTestFixure)
        {
            _mathServiceFixure = mathServiceTestFixure;
        }

        [Theory]
        [InlineAutoData(1, 3, "X: 25.00% and Y: 75.00%")]
        [InlineAutoData(6, 4, "X: 60.00% and Y: 40.00%")]
        public void WhenCalledPerformOperation_ShouldReturnStringForSummation(int x, int y, string expectedResult) 
        {
            Func<int, int, double> summation = (p, q) => p + q;

            var actualResult = _mathServiceFixure.Sut.PerformOperation(x, y, arithmeticOperation: summation);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}