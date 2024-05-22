namespace Tests;

public class ProgramTests_WithoutErrorHandlingTest
{
    [Fact]
    public void WhenRunningConsoleAppWithoutErrorHandling_ThenExitCodeIsNotExpected()
    {
        // Arrange
        var exitCodeExpected = 0;

        // Act
        var targetConsoleApp = "WithoutErrorHandling";
        var exitCodeResult = ConsoleAppTestHelper.RunConsoleAppAndGetExitCode(targetConsoleApp);

        // Assert
        // Used not equal because on windows it returns -532462766, on Ubuntu WSL returns 82, and on git hash returns 127.
        Assert.NotEqual(exitCodeExpected, exitCodeResult);
    }
}