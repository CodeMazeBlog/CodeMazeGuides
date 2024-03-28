using HowToSetDefaultUserAgentOnHttpClient;
namespace Tests;

public class ProgramUnitTests
{
    [Fact]
    public void WhenUserAgentPropertyIsProvided_ThenSetUserAgentOnHttpRequestMessageSetsTheHeaderAndLogsToConsole()
    {
        //Arrange
        var productName = "CodeMazeDesktopApp";
        var productVersion = "1.1";
        var expectedOutput = $"The User-Agent header is set with value {productName}/{productVersion}";

        var actualOutputWriter = new StringWriter();
        Console.SetOut(actualOutputWriter);

        //Act
        Program.SetUserAgentOnHttpRequestMessage(productName, productVersion);

        //Assert
        var actualOutput = actualOutputWriter.ToString();
        var actualSanitizedOutput = actualOutput.Replace(Environment.NewLine, string.Empty);

        Assert.Contains(expectedOutput, actualSanitizedOutput);
    }

    [Fact]
    public void WhenUserAgentPropertyIsProvided_ThenSetUserAgentAsDefaultHeaderOnHttpClientSetsTheHeaderAndLogsToConsole()
    {
        //Arrange
        var productName = "CodeMazeDesktopApp";
        var productVersion = "1.1";
        var expectedOutput = $"The User-Agent header is set with value {productName}/{productVersion}";

        var actualOutputWriter = new StringWriter();
        Console.SetOut(actualOutputWriter);

        //Act
        Program.SetUserAgentAsDefaultHeaderOnHttpClient(productName, productVersion);

        //Assert
        var actualOutput = actualOutputWriter.ToString();
        var actualSanitizedOutput = actualOutput.Replace(Environment.NewLine, string.Empty);

        Assert.Contains(expectedOutput, actualSanitizedOutput);
        
    }
}