using FuncDelegates;

namespace Tests
{
    [Collection("Calculation Collection")] // Use the shared CalculationFixture
    public class FuncDelegatesUnitTest
    {
        private readonly Calculation _calculation;

        public FuncDelegatesUnitTest(CalculationFixture fixture)
        {
            _calculation = fixture.Calculation;
        }

        [Fact]
        public void WhenMultiplyOperationIsPerformedOnValuesTwentyAndTen_ThenReturnsCorrectResultTwoHundred()
        {
            // Act
            int result = _calculation.Calculate(_calculation.Multiply);

            // Assert
            Assert.Equal(200, result);
        }

        [Fact]
        public void WhenAddOperationIsPerformedOnValuesTwentyAndTen_ThenReturnsCorrectResultThirty()
        {
            // Act
            int result = _calculation.Calculate((a, b) => a + b);

            // Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void WhenSubtractOperationIsPerformedOnValuesTwentyAndTen_ThenReturnsCorrectResultTen()
        {
            // Act
            int result = _calculation.Calculate((a, b) => a - b);

            // Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void WhenDivideOperationIsPerformedOnValuesTewntyAndTen_ThenReturnsCorrectResultTwo()
        {
            // Act
            int result = _calculation.Calculate((a, b) => a / b);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void WhenMaxOperationIsPerformedOnValuesTwentyAndTen_ThenReturnsCorrectResultTwenty()
        {
            // Act
            int result = _calculation.Calculate((a, b) => Math.Max(a, b));

            // Assert
            Assert.Equal(20, result);
        }

        [Fact]
        public void WhenMinOperationIsPerformedOnValuesTwentyAndTen_ThenReturnsCorrectResultTen()
        {
            // Act
            int result = _calculation.Calculate((a, b) => Math.Min(a, b));

            // Assert
            Assert.Equal(10, result);
        }
    }
}