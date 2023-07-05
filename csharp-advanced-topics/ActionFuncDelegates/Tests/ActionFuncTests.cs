using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Tests
{
	[TestClass]
	public class ActionFuncTests
	{
		[TestMethod]
		public void When_GreetUserWithValidName_Then_InvokeCallbackWithCorrectGreeting()
		{
			string name = "John";
			string expectedGreeting = "Hello, John!";
			string actualGreeting = null;

			//Act
			Program.GreetUser(name, (greeting) =>
			{
				actualGreeting = greeting;
			});

			// Assert
			Assert.AreEqual(expectedGreeting, actualGreeting);
		}

		[TestMethod]
		public void When_AddNumbersWithValidInputs_Then_ReturnCorrectSum()
		{
			// Arrange
			int a = 5;
			int b = 3;
			int expectedSum = 8;

			// Act
			int actualSum = Program.AddNumbers(a, b, (x, y) =>
			{
				return x + y;
			});

			// Assert
			Assert.AreEqual(expectedSum, actualSum);
		}
	}
}