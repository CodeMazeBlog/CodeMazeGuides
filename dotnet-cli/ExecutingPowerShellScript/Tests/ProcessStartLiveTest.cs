using ExecutingPowerShellScript;

namespace Tests;

public class ProcessStartLiveTest
{
    [Fact]
    public async Task GivenPath_WhenInvoked_ThenExecutesGivenScript()
    {
        var processStart = new ProcessStart();
        var scriptPath = Path.Combine(AppContext.BaseDirectory, "echo.ps1");

        var result = await processStart.ExecuteScriptAsync(scriptPath);

        Assert.Equal(0, result.ExitCode);
        Assert.Equal("I am invoked using ProcessStartInfoClass!" + Environment.NewLine, result.Output);
        Assert.Equal(string.Empty, result.Error);
    }

    [Fact]
    public async Task GivenCommand_WhenInvoked_ThenExecutesGivenCommand()
    {
        var processStart = new ProcessStart();

        var result = await processStart.ExecuteCommandAsync("echo 'I am invoked using echo command!'");

        Assert.Equal(0, result.ExitCode);
        Assert.Equal("I am invoked using echo command!" + Environment.NewLine, result.Output);
    }

    [Fact]
    public async Task GivenFailingCommand_WhenInvoked_ThenReturnsNonZeroExitCodeAndError()
    {
        var processStart = new ProcessStart();

        var result = await processStart.ExecuteCommandAsync("Get-Item 'does-not-exist.txt'");

        Assert.Equal(1, result.ExitCode);
        Assert.NotEqual(string.Empty, result.Error);
    }
}
