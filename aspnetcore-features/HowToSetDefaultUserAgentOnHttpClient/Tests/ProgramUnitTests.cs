using HowToSetDefaultUserAgentOnHttpClient;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public class ProgramUnitTests
{
    [Fact]
    public void WhenUserAgentPropertyIsProvided_ThenSetUserAgentOnHttpRequestMessageSetsTheHeader()
    {
        //Arrange
        var productName = "CodeMazeDesktopApp";
        var productVersion = "1.1";
        var expectedOutput = $"{productName}/{productVersion}";

        //Act
        var actualOutput = Program.SetUserAgentOnHttpRequestMessage(productName, productVersion);

        //Assert
        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void WhenHttpClientIsRegisteredWithHostBuilder_ThenHttpClientGetsDefaultUserAgent()
    {
        //Arrange
        var productName = "CodeMazeDesktopApp";
        var productVersion = "1.1";
        var expectedOutput = $"{productName}/{productVersion}";

        //Act
        var host = Program.BuildHost();
        var httpClientFactory = host.Services.GetService<IHttpClientFactory>();

        var actualOutput = Program.GetDefaultAgentOnHttpClient(httpClientFactory);

        //Assert
        Assert.Equal(expectedOutput, actualOutput);
    }
}