using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests
{
	[TestClass]
	public class Tests
	{
		[TestMethod]
		public void WhenPrintDetailsIsCalled_ThenCorrectDetailsArePrinted()
		{
			Action<string, int> printDetails = (name, age) =>
				Console.WriteLine($"Name: {name}, Age: {age}");

			string expectedOutput = "Name: John Doe, Age: 30\r\n";
			using (StringWriter sw = new StringWriter())
			{
				Console.SetOut(sw);

				// Act
				printDetails("John Doe", 30);

				// Assert
				Assert.AreEqual(expectedOutput, sw.ToString());
			}
		}
		[TestMethod]
		public void WhenCallingWithValidNameAndAge_ThenCorrectGreetingIsGenerated()
		{
			Func<string, int, string> greetPerson = (name, age) =>
			{
				return $"Hello, {name}! You are {age} years old.";
			};

			string greeting = greetPerson("Alice", 25);

			string expectedGreeting = "Hello, Alice! You are 25 years old.";
			Assert.AreEqual(expectedGreeting, greeting);
		}
	}
}