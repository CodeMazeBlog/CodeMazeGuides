namespace Tests;

public class ProgramTests_SetExitCodeTest
{
    [Fact]
    public void WhenSettingExitCode_ThenExitCodeIsExpected()
    {
        // Arrange
        const int expectedExitCode = 3;

        // Act
        var targetConsoleApp = "ByExitCode";
        var exitCode = ConsoleAppTestHelper.RunConsoleAppAndGetExitCode(targetConsoleApp);

        // Assert
        Assert.Equal(expectedExitCode, exitCode);
    }
}