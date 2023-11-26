using ActionFuncDemo;

namespace Tests;

public class ActionExampleTests
{
    [Fact]
    public void PrintToConsole_Should_Print_Correctly()
    {
        var number = 10;
        var text = "Hello, World!";
        var value = 5.7;
        var expectedOutput = $"Received: {number}, {text}, {value}";

        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);
            ActionExample.PrintToConsole(number, text, value);
            var consoleResult = stringWriter.ToString().Trim();
            Assert.Contains(expectedOutput, consoleResult);
        }
    }
}