
using Xunit;
using ActionAndFuncDelegatesInCSharp;

namespace ActionAndFuncDelegatesInCSharpTest;

public class ActionAndFuncDelegatesInCSharpTests
{
    private readonly StringWriter consoleOutput = new();

    public ActionAndFuncDelegatesInCSharpTests()
    {
        Console.SetOut(consoleOutput);
    }


    [Fact]
    public void WhenPrintMessageWithAction_ExpectedMessageShouldBeDisplayed()
    {
        const string message = "Hello World!";
  
        Program.PrintMessageWithAction(message);
        
        var printedMessage = PrintedOutputToArray();
        Assert.Equal(message, printedMessage[0]);
    }


    [Fact]
    public void WhenGetMessageLengthWithFunc_ResultMustBeAsExpected()
    {
        const string message = "Hello World!";
        var expected = message.Length;
        
        var result = Program.GetMessageLengthWithFunc(message);

        Assert.Equal(expected, result);
    }

    private string[] PrintedOutputToArray()
    {
        var printedString = consoleOutput.ToString();
        return printedString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    }
}