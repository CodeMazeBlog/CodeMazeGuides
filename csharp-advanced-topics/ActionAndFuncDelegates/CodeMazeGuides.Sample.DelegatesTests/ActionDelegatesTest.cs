using CodeMazeGuides.Sample.Delegates;

namespace CodeMazeGuides.Sample.DelegatesTests
{
	public class ActionDelegatesTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Given_WelcomeToActionDelegate_When_Invoked_Then_DisplaysWelcomeMessage()
		{
			// Given
			StringWriter stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			string expectedMessage = "You are welcome to Action Delegate sample that takes no parameter";

			// When
			ActionDelegates.WelcomeToActionDelegate();

			// Then
			string consoleOutput = stringWriter.ToString().Trim();
			Assert.AreEqual(expectedMessage, consoleOutput);
		}

		[Test]
		public void Given_WelcomeToActionDelegateWithParam_When_InvokedWithValidName_Then_DisplaysWelcomeMessage()
		{
			// Given
			StringWriter stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			string expectedMessage = "Dear Alice!, you are welcome to Action Delegate sample that takes one parameter";

			// When
			ActionDelegates.WelcomeToActionDelegateWithParam("Alice");

			// Then
			string consoleOutput = stringWriter.ToString().Trim();
			Assert.AreEqual(expectedMessage, consoleOutput);
		}

		[Test]
		public void Given_ProductOfTwoNos_When_InvokedWithValidNumbers_Then_DisplaysProduct()
		{
			// Given
			StringWriter stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			int num1 = 5;
			int num2 = 7;
			int expectedProduct = num1 * num2;
			string expectedMessage = $"Product: {expectedProduct}";

			// When
			ActionDelegates.ProductOfTwoNos(num1, num2);

			// Then
			string consoleOutput = stringWriter.ToString().Trim();
			Assert.AreEqual(expectedMessage, consoleOutput);
		}

		[Test]
		public void Given_DisplayStdInfo_When_InvokedWithValidInfo_Then_DisplaysStudentInformation()
		{
			// Given
			StringWriter stringWriter = new StringWriter();
			Console.SetOut(stringWriter);

			string name1 = "Alice";
			int age1 = 20;
			string name2 = "Charice";
			int age2 = 22;

			string expectedOutput = $"Name: {name1}, Age: {age1}\r\nName: {name2}, Age: {age2}";

			// When
			ActionDelegates.DisplayStdInfo(name1, age1, name2, age2);

			// Then
			string consoleOutput = stringWriter.ToString().Trim();
			Assert.AreEqual(expectedOutput, consoleOutput);
		}
	}
}