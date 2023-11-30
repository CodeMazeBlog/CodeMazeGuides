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
	public void RunAddNumbers_GivenTwoNumbers_WhenAdding_ThenReturnCorrectSum()
	{
		// Arrange
		string expectedOutput = "Sum of Numbers: 12";

		// Act
		FuncClass.RunAddNumbers();

		// Assert
		var output = _testWriter.ToString().Trim();
		Assert.Equal(expectedOutput, output);
	}

	[Fact]
	public void AddNumbersMethod_GivenTwoNumbers_WhenAdding_ThenReturnCorrectSum()
	{
		// Act
		int result = FuncClass.AddNumbersMethod(5, 7);

		// Assert
		Assert.Equal(12, result);
	}

	[Fact]
	public void GreetingDelegate_HelloMethod_ShouldWriteCorrectMessageToConsole()
	{
		// Arrange
		string message = "Hello from Delegate";
		string expectedOutput = "Hello says: " + message;

		// Act
		var greetingDelegate = new DelegateClass.GreetingDelegate(DelegateClass.Hello);
		greetingDelegate(message); // Invoke the delegate

		// Assert
		var output = _testWriter.ToString().Trim();
		Assert.Equal(expectedOutput, output);
	}

	[Fact]
	public void RunMyActionMethod_GivenActionDelegate_WhenInvoked_ThenOutputReceivedParametersToConsole()
	{

		// Act
		Action<int, string> actionDelegate = ActionClass.MyActionMethod;
		ActionClass.RunMyActionMethod();
	
		// Assert
		var output = _testWriter.ToString().Trim();
		Assert.Contains("Received parameters: 42, Hello", output);
	}

	public void Dispose()
	{
		Console.SetOut(_originalConsoleOut);
	}

}