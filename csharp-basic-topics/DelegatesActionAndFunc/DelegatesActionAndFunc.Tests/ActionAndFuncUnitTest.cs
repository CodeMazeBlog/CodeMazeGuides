using Xunit;

namespace DelegatesActionAndFunc.Tests;

public class ActionAndFuncUnitTest
{

    [Theory]
    [InlineData("JOHN", "JOHN")]
    [InlineData("penny", "Penny")]
    public void WhenInputIsProvided_ThenItCapitalizesFirstLetter(string input, string expectedOutput)
    {
        //Act
        var capitalizedWord = Program.Capitalize(input);

        //Assert
        Assert.Equal(capitalizedWord, expectedOutput);
    }

    [Fact]
    public void WhenLogCurrentUTCDateTimeIsCalled_ThenCurrentDateTimeIsPrinted()
    {
        //Arrange
        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);
        string expectedStartOfLoggedOutput = $"Current date time is";

        //Act
        Program.LogCurrentUTCDateTime();

        //Assert
        Assert.StartsWith(expectedStartOfLoggedOutput, stringWriter.ToString());
    }
}