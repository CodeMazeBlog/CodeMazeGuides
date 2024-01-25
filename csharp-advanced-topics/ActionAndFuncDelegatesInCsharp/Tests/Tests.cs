using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class Tests
	{
		[TestMethod]
		public void GivenValidNameAndAge_WhenPrintDetailsIsCalled()
		{
			Action<string, int> printDetails = (name, age) =>
				Console.WriteLine($"Name: {name}, Age: {age}");

			string expectedOutput = "Name: John Doe, Age: 30\r\n";
			using (StringWriter sw = new StringWriter())
			{
				Console.SetOut(sw);
				printDetails("John Doe", 30);
				Assert.AreEqual(expectedOutput, sw.ToString());
			}
		}
		[TestMethod]
		public void GivenGreetPersonFunction_WhenCallingWithValidNameAndAge()
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