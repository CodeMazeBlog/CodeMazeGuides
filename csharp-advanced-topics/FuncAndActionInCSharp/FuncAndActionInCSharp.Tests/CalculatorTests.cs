namespace FuncAndActionInCSharp.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // ARRANGE
            Calculator calculator = new();

            // ACT
            int result = calculator.Add(3, 2);

            // ASSERT
            Assert.Equal(5, result);
        }

        [Fact]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            // ARRANGE
            Calculator calculator = new();

            // ACT
            int result = calculator.Subtract(5, 2);

            // ASSERT
            Assert.Equal(3, result);
        }
    }
}
