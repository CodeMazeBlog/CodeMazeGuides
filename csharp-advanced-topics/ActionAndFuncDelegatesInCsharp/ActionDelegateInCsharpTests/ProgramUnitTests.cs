namespace ActionDelegateInCsharpTests;

public class ProgramUnitTests
{
    private string CaptureConsoleOutput(Action action)
    {
        using var writer = new StringWriter();
        Console.SetOut(writer);
        action();
        return writer.ToString().Trim();
    }

    [Fact]
    public void WhenInvokingGreet_ThenPrintHelloWorld()
    {
        // Arrange
        var message = "Hello World!";
        Action greet = () => Console.WriteLine(message);

        // Act
        var output = CaptureConsoleOutput(() => greet());

        // Assert
        Assert.Equal(message, output);
    }

    [Fact]
    public void WhenInvokingGreetMessage_ThenPrintGivenMessage()
    {
        // Arrange
        var message = "Hello World!";
        Action<string> greetMessage = message => Console.WriteLine(message);

        // Act
        var output = CaptureConsoleOutput(() => greetMessage(message));

        // Assert
        Assert.Equal(message, output);
    }

    [Fact]
    public void WhenExecutingCallback_ThenPrintGivenMessage()
    {
        // Arrange
        var message = "Hello World!";
        Action callback = () => Console.WriteLine(message);

        // Act
        var output = CaptureConsoleOutput(() => ActionDelegateInCsharp.Program.Execute(callback));

        // Assert
        Assert.Equal(message, output);
    }

    [Fact]
    public void WhenExecutingGreetWithName_ThenPrintHelloName()
    {
        // Arrange
        var message = "Hello John!";
        Action<string> greet = message => Console.WriteLine(message);

        // Act
        var output = CaptureConsoleOutput(() => ActionDelegateInCsharp.Program.Execute("John", greet));

        // Assert
        Assert.Equal(message, output);
    }
}
