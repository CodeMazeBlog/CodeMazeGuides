namespace Tests;

public class ProgramTests_ByExitMethodTest
{
    [Fact]
    public void WhenRunningConsoleAppByExitMethod_ThenExitCodeIsExpected()
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