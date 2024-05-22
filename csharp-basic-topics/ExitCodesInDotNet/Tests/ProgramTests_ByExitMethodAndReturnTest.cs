namespace Tests;

public class ProgramTests_ByExitMethodAndReturnTest
{
    [Fact]
    public void WhenRunningConsoleAppByExitMethodAndReturn_ThenExitCodeIsExpected()
    {
        // Arrange
        const int expectedExitCode = 1;

        // Act
        var targetConsoleApp = "ByExitMethodAndReturn";
        var exitCode = ConsoleAppTestHelper.RunConsoleAppAndGetExitCode(targetConsoleApp);

        // Assert
        Assert.Equal(expectedExitCode, exitCode);
    }
}