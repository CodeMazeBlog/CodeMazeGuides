namespace ActionFuncDelegateTests
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void GreetDelegate_ShouldOutputCorrectGreeting()
		{
			// Arrange
			string name = "John";
			string expectedGreeting = "Hello, John!";
			string actualGreeting = null;

			// Act
			Action<string> greetDelegate = (n) =>
			{
				actualGreeting = $"Hello, {n}!";
			};

			greetDelegate.Invoke(name);

			// Assert
			Assert.AreEqual(expectedGreeting, actualGreeting);
		}

		[Test]
		public void SumDelegate_ShouldReturnCorrectSum()
		{
			// Arrange
			int a = 5;
			int b = 3;
			int expectedSum = 8;
			int actualSum = 0;

			// Act
			Func<int, int, int> sumDelegate = (x, y) =>
			{
				return x + y;
			};

			actualSum = sumDelegate.Invoke(a, b);

			// Assert
			Assert.AreEqual(expectedSum, actualSum);
		}
	}
}