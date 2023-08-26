using FuncDelegates;

namespace Tests
{
    public class FuncDelegatesUnitTest
    {
        [Fact]
        public void WhenMultiplyOperationIsPerformedOnValuesTwentyAndTen_ThenReturnsCorrectResultTwoHundred()
        {
            // Arrange
            Calculation calculation = new ();

            // Act
            int result = calculation.Calculate(calculation.Multiply);

            // Assert
            Assert.Equal(200, result);
        }


        [Fact]
        public void WhenAddOperationIsPerformedOnValuesTwentyAndTen_ThenReturnsCorrectResultThirty()
        {
            // Arrange
            Calculation calculation = new();

            // Act
            int result = calculation.Calculate((a, b) => a + b);

            // Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void WhenSubtractOperationIsPerformedOnValuesTwentyAndTen_ThenReturnsCorrectResultTen()
        {
            // Arrange
            Calculation calculation = new();

            // Act
            int result = calculation.Calculate((a, b) => a - b);

            // Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void WhenDivideOperationIsPerformedOnValuesTewntyAndTen_ThenReturnsCorrectResultTwo()
        {
            // Arrange
            Calculation calculation = new();

            // Act
            int result = calculation.Calculate((a, b) => a / b);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void WhenMaxOperationIsPerformedOnValuesTwentyAndTen_ThenReturnsCorrectResultTwenty()
        {
            // Arrange
            Calculation calculation = new();

            // Act
            int result = calculation.Calculate((a, b) => Math.Max(a, b));

            // Assert
            Assert.Equal(20, result);
        }

        [Fact]
        public void WhenMinOperationIsPerformedOnValuesTwentyAndTen_ThenReturnsCorrectResultTen()
        {
            // Arrange
            Calculation calculation = new();

            // Act
            int result = calculation.Calculate((a, b) => Math.Min(a, b));

            // Assert
            Assert.Equal(10, result);
        }

    }
}