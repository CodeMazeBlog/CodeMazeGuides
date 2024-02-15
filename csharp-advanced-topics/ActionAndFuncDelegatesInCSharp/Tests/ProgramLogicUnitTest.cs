using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
	[TestClass]
	public class ProgramLogicUnitTest
	{
		private StringWriter _stringWriter;
		private ProgramLogic _programLogic;

		[TestInitialize]
		public void SetUp()
		{
			_stringWriter = new StringWriter();
			_programLogic = new ProgramLogic();

			Console.SetOut(_stringWriter);
		}

		[TestCleanup]
		public void CleanUp()
		{
			Console.SetOut(Console.Out);
			_stringWriter.Dispose();
		}

		[TestMethod]
		public void WhenAddFunc_ThenPrintsExpectedResult()
		{
			_programLogic.AddFunc();

			Assert.AreEqual("5", _stringWriter.ToString().Trim());
		}

		[TestMethod]
		public void WhenGreetAction_ThenPrintsExpectedGreeting()
		{
			_programLogic.GreetAction();

			Assert.AreEqual("Hello!", _stringWriter.ToString().Trim());
		}

		[TestMethod]
		public void WhenGreetSomeoneAction_ThenPrintsExpectedPersonalGreeting()
		{
			_programLogic.GreetSomeoneAction();

			Assert.AreEqual("Hello, John!", _stringWriter.ToString().Trim());
		}
	}
}