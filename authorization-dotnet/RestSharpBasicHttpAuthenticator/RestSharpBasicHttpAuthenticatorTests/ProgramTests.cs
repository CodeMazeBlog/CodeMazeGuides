using RestSharpBasicHttpAuthenticator;
using Xunit;

namespace RestSharpBasicHttpAuthenticatorTests;

public class ProgramTests
{
    [Fact]
    public async Task WhenMainIsCalled_ThenWeGetOKStatusCode()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        await Program.Main();

        // Assert
        var result = output.ToString();
        Assert.Contains("OK", result);
    }
}