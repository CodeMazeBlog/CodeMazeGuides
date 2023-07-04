using ActionFuncDelegates;

namespace ActionFuncTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void GreetUser_ShouldInvokeCallbackWithCorrectGreeting()
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
		public void AddNumbers_ShouldReturnCorrectSum()
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