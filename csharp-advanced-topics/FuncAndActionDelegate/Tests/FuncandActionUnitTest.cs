using FuncAndActionDelegate;
using System.IO;

namespace Tests;

public class FuncTest
{
	private StringWriter _testWriter;
	
	private TextWriter _originalConsoleOut;

	public FuncTest()
	{
		_testWriter = new StringWriter();
		_originalConsoleOut = Console.Out;
		Console.SetOut(_testWriter);
	}

	[Fact]
	public void GivenTwoNumbers_WhenRunningFuncClassMethod_ThenReturnCorrectSum()
	{
		// Arrange
		var expectedOutput = "Sum of Numbers: 12";

		// Act
		FuncClass.RunAddNumbers();

		// Assert
		var output = _testWriter.ToString().Trim();
		Assert.Equal(expectedOutput, output);
	}

	[Fact]
	public void GivenTwoNumbers_WhenAddingUsingAddNumbersMethod_ThenReturnCorrectSum()
	{
		// Act
		int result = FuncClass.AddNumbers(5, 7);

		// Assert
		Assert.Equal(12, result);
	}


	[Fact]
	public void GreetingDelegate_HelloMethod_ShouldWriteCorrectMessageToConsole()
	{
		// Arrange
		var message = "Hello from Delegate";
		var expectedOutput = $"Hello says: {message}";

		// Act
		var greetingDelegate = new DelegateClass.GreetingDelegate(DelegateClass.Hello);
		greetingDelegate(message); // Invoke the delegate

		// Assert
		var output = _testWriter.ToString().Trim();
		Assert.Equal(expectedOutput, output);
	}

	[Fact]
	public void GivenActionDelegate_WhenInvoked_ThenOutputReceivedParametersToConsole()
	{
		// Act
		Action<int, string> actionDelegate = ActionClass.MyAction;
		ActionClass.RunMyAction();
	
		// Assert
		var output = _testWriter.ToString().Trim();
		Assert.Contains("Received parameters: 42, Hello", output);
	}

	public void Dispose()
	{
		Console.SetOut(_originalConsoleOut);
	}

}