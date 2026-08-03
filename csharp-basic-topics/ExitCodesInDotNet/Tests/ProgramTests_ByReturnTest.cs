namespace Tests;

public class ProgramTests_ByReturnTest
{
    [Fact]
    public void WhenRunningConsoleAppByReturn_ThenExitCodeIsExpected()
    {
        // Arrange
        const int expectedExitCode = 2;

        // Act
        var targetConsoleApp = "ByReturn";
        var exitCode = ConsoleAppTestHelper.RunConsoleAppAndGetExitCode(targetConsoleApp);

        // Assert
        Assert.Equal(expectedExitCode, exitCode);
    }
}