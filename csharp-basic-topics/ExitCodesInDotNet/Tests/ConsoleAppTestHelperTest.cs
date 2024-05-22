namespace Tests;

public class ConsoleAppTestHelperTest
{
    [Theory]
    [InlineData("0", 0)]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("hello", 1)]
    public void WhenRunningConsoleAppWithArgs_ThenExitCodeIsAsExpected(string consoleAppArgument, int expectedExitCode)
    {

        // Act
        var targetConsoleApp = "ByArgs";
        var exitCode = ConsoleAppTestHelper.RunConsoleAppAndGetExitCode(targetConsoleApp, consoleAppArgument);

        // Assert
        Assert.Equal(expectedExitCode, exitCode);
    }
}