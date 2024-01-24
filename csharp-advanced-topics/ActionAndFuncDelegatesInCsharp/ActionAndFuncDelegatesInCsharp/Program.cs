namespace ActionAndFuncDelegatesInCsharp
{
	class Program
	{
		static void Main()
		{
			// Action delegate for logging
			Action<string> logMessage = (message) =>
			{
				Console.WriteLine($"[LOG]: {message}");
			};

			// Func delegate to calculate the square of a number
			Func<int, int> calculateSquare = (number) =>
			{
				return number * number;
			};

			// Example scenario: Logging and calculating square
			int inputNumber = 5;

			// Using Action to log a message
			logMessage("Starting the calculation...");

			// Using Func to calculate the square
			var result = calculateSquare(inputNumber);

			// Using Action to log the result
			logMessage($"The square of {inputNumber} is: {result}");

			// Additional Action for closing remarks
			Action<string> closingMessage = (message) =>
			{
				Console.WriteLine($"[CLOSING]: {message}");
			};

			// Using the additional Action to log a closing message
			closingMessage("Calculation complete. End of the program.");
		}
	}
}