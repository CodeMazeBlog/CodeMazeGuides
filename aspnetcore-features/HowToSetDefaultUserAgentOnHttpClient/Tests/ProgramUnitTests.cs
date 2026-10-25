using HowToSetDefaultUserAgentOnHttpClient;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public class ProgramUnitTests
{
    [Fact]
    public void WhenUserAgentStringIsProvided_ThenSetUserAgentOnHttpRequestMessageSetsTheHeader()
    {
        //Arrange
        var userAgentValue = "CodeMazeDesktopApp/1.1";

        //Act
        var actualOutput = Program.SetUserAgentOnHttpRequestMessage(userAgentValue);

        //Assert
        Assert.Equal(userAgentValue, actualOutput);
    }

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
        var httpClientFactory = host.Services.GetRequiredService<IHttpClientFactory>();

        var actualOutput = Program.GetDefaultAgentOnHttpClient(httpClientFactory);

        //Assert
        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void WhenClientDefaultsAreConfigured_ThenEveryClientGetsDefaultUserAgent()
    {
        //Arrange
        var expectedOutput = "CodeMazeDesktopApp/1.1";

        //Act
        var host = Program.BuildHostWithUserAgentForAllClients();
        var httpClientFactory = host.Services.GetRequiredService<IHttpClientFactory>();

        var namedClient = httpClientFactory.CreateClient("AnyName");
        var defaultClient = httpClientFactory.CreateClient();

        //Assert
        Assert.Equal(expectedOutput, namedClient.DefaultRequestHeaders.UserAgent.ToString());
        Assert.Equal(expectedOutput, defaultClient.DefaultRequestHeaders.UserAgent.ToString());
    }
}
