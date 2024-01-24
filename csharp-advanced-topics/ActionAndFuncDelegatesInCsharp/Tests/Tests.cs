// Inside the existing "Program" class
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class Tests
	{
		[TestMethod]
		public void TestActionAndFuncDelegates_LogMessageAndCalculateSquare_CorrectOutput()
		{
			// Arrange
			Action<string> logMessage = (message) =>
			{
				Assert.IsNotNull(message);
				Console.WriteLine($"[LOG]: {message}");
			};

			Func<int, int> calculateSquare = (number) =>
			{
				return number * number;
			};

			Action<string> closingMessage = (message) =>
			{
				Assert.IsNotNull(message);
				Console.WriteLine($"[CLOSING]: {message}");
			};

			// Example scenario: Logging and calculating square
			int inputNumber = 5;

			// Act
			logMessage("Starting the calculation...");

			var result = calculateSquare(inputNumber);

			logMessage($"The square of {inputNumber} is: {result}");

			// Assert
			Assert.AreEqual(result, 25);

			// New line before the Then section
			closingMessage("Calculation complete. End of the program.");
		}
	}
}