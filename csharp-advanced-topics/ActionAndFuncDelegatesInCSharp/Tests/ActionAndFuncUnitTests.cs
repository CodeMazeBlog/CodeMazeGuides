
namespace Tests
{
	public class ActionAndFuncUnitTests
	{
		[Fact]
		public void WhenTwoNumbersAreEntered_ThenPerformActionDelegateCalculations()
		{
			// Arrange
			var expectedAdditionResult = "Addition result: 6";
			var expectedDivisionResult = "Division result: 2";
			var expectedSubtractionResult = "Subtraction result: 2";
			var expectedMultiplicationResult = "Multiplication result: 8";

			// Act
			using (var output = new ConsoleOutput())
			{
				Program.FuncDelegateSample();
				var consoleOutput = output.GetOutput();

				// Assert
				Assert.Contains(expectedAdditionResult, consoleOutput);
				Assert.Contains(expectedDivisionResult, consoleOutput);
				Assert.Contains(expectedSubtractionResult, consoleOutput);
				Assert.Contains(expectedMultiplicationResult, consoleOutput);
			}
		}

		[Fact]
		public void WhenTwoNumbersAreEntered_ThenPerformFuncDelegateCalculations()
		{
			// Arrange
			var expectedAdditionResult = "Addition result: 6";
			var expectedSubtractionResult = "Subtraction result: 2";
			var expectedMultiplicationResult = "Multiplication result: 8";
			var expectedDivisionResult = "Division result: 2";

			// Act
			using (var output = new ConsoleOutput())
			{
				Program.FuncDelegateSample();
				var consoleOutput = output.GetOutput();

				// Assert
				Assert.Contains(expectedAdditionResult, consoleOutput);
				Assert.Contains(expectedSubtractionResult, consoleOutput);
				Assert.Contains(expectedMultiplicationResult, consoleOutput);
				Assert.Contains(expectedDivisionResult, consoleOutput);
			}
		}
	}
}
