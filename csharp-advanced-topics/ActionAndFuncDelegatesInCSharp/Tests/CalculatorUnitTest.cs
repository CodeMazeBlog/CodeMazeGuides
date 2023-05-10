
namespace Tests
{
	public class CalculatorUnitTest
	{
		[Fact]
		public void whenTwoNumbersAreAdded_thenConfirmAdditionIsSuccessful()
		{
			// Arrange
			var calculator = new Calculator();

			// Act
			var result = calculator.Add(10, 5);

			// Assert
			Assert.Equal(15, result);
		}

		[Fact]
		public void whenTwoNumbersAreSubtracted_thenConfirmSubtractionIsSuccessful()
		{
			// Arrange
			var calculator = new Calculator();

			// Act
			var result = calculator.Subtract(10, 5);

			// Assert
			Assert.Equal(5, result);
		}

		[Fact]
		public void whenTwoNumbersAreMultiplied_thenConfirmMultiplicationIsSuccessful()
		{
			// Arrange
			var calculator = new Calculator();

			// Act
			var result = calculator.Multiply(10, 5);

			// Assert
			Assert.Equal(50, result);
		}

		[Fact]
		public void whenTwoNumbersAreDivided_thenConfirmDivisionIsSuccessful()
		{
			// Arrange
			var calculator = new Calculator();

			// Act
			var result = calculator.Divide(10, 5);

			// Assert
			Assert.Equal(2, result);
		}
	}
}
