using ActionAndFuncDelegatesInCSharp;

namespace Tests;

[TestClass]
public class ProgramLogicUnitTest
{
	private ProgramLogic _programLogic;
	private StringWriter _stringWriter;

	[TestInitialize]
	public void SetUp()
	{
		_programLogic = new ProgramLogic();
		_stringWriter = new StringWriter();

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