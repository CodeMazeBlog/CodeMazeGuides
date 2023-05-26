
namespace Tests
{
	public class CalculatorUnitTest
	{
		[Fact]
		public void WhenTwoNumbersAreAdded_ThenConfirmAdditionIsSuccessful()
		{
			// Arrange
			var calculator = new Calculator();

			// Act
			var result = calculator.Add(10, 5);

			// Assert
			Assert.Equal(15, result);
		}

		[Fact]
		public void WhenTwoNumbersAreSubtracted_ThenConfirmSubtractionIsSuccessful()
		{
			// Arrange
			var calculator = new Calculator();

			// Act
			var result = calculator.Subtract(10, 5);

			// Assert
			Assert.Equal(5, result);
		}

		[Fact]
		public void WhenTwoNumbersAreMultiplied_ThenConfirmMultiplicationIsSuccessful()
		{
			// Arrange
			var calculator = new Calculator();

			// Act
			var result = calculator.Multiply(10, 5);

			// Assert
			Assert.Equal(50, result);
		}

		[Fact]
		public void WhenTwoNumbersAreDivided_ThenConfirmDivisionIsSuccessful()
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
