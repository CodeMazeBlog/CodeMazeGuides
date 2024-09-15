namespace Tests;

public class ProgramTests_WithErrorHandlingTest
{
    [Fact]
    public void WhenRunningConsoleAppWithErrorHandling_ThenExitCodeIsExpected()
    {
        // Arrange
        const int expectedExitCode = 1;

        // Act
        var targetConsoleApp = "WithErrorHandling";
        var exitCode = ConsoleAppTestHelper.RunConsoleAppAndGetExitCode(targetConsoleApp);

        // Assert
        Assert.Equal(expectedExitCode, exitCode);
    }
}