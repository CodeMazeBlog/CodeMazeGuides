namespace ActionAndFuncDelegateInCSharp.Test;

public sealed class ActionDelegateTests
{
    private string message = string.Empty;
    void PrintMessage(string message)
    {
        this.message = message;
    }

    [Fact]
    public void IsValid_InputHelloWorld_ReturnEqual()
    {
        Action<string> printMessage = PrintMessage;
        printMessage("Hello World!");

        Assert.Equal(message, "Hello World!");
    }

    [Fact]
    public void IsNotValid_InputHelloWorld_ReturnNotEqual()
    {
        Action<string> printMessage = PrintMessage;
        printMessage("Hello World!");

        Assert.NotEqual(message, "Hello Word!");
    }

    [Fact]
    public void IsValid_InputHelloWorld_ReturnTrue()
    {
        Action<string> printMessage = PrintMessage;
        printMessage("Hello World!");

        bool result = message == "Hello World!";

        Assert.True(result);
    }

    [Fact]
    public void IsNotValid_InputHelloWorld_ReturnFalse()
    {
        Action<string> printMessage = PrintMessage;
        printMessage("Hello World!");

        bool result = message == "Hello Word!";

        Assert.False(result);
    }
}