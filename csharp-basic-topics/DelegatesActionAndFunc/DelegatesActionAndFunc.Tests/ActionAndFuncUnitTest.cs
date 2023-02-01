using Xunit;

namespace DelegatesActionAndFunc.Tests;

public class ActionAndFuncUnitTest
{

    [Theory]
    [InlineData("JOHN", "JOHN")]
    [InlineData("penny", "Penny")]
    public void Capitalize_DifferentInput_ReturnsCorrectOutput(string input, string expectedOutput)
    {
        //Act
        var capitalizedWord = Program.Capitalize(input);

        //Assert
        Assert.Equal(capitalizedWord, expectedOutput);
    }

    [Fact]
    public void LogCurrentUTCDateTime_WritesOutputToConsole()
    {
        //Arrange
        StringWriter stringWriter = new ();
        Console.SetOut(stringWriter);
        string expectedStartOfLoggedOutput = $"Current date time is";

        //Act
        Program.LogCurrentUTCDateTime();

        //Assert
        Assert.StartsWith(expectedStartOfLoggedOutput, stringWriter.ToString());
    }
}