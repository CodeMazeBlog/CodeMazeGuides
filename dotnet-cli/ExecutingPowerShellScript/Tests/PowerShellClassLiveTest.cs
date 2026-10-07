using ExecutingPowerShellScript;

namespace Tests;

public class PowerShellClassLiveTest
{
    [Fact]
    public void GivenPath_WhenInvoked_ThenExecutesScript()
    {
        var powerShellClass = new PowerShellClass();
        var scriptPath = Path.Combine(AppContext.BaseDirectory, "echo.ps1");

        var result = powerShellClass.ExecuteScript(scriptPath);

        Assert.True(result);
    }

    [Fact]
    public void GivenCommand_WhenInvoked_ThenExecutesCommand()
    {
        var powerShellClass = new PowerShellClass();

        var result = powerShellClass.ExecuteCommand("Get-Date");

        Assert.NotEqual(string.Empty, result);
    }

    [Fact]
    public void GivenName_WhenInvoked_ThenStartsAProcess()
    {
        var powerShellClass = new PowerShellClass();

        var result = powerShellClass.StartProcess("notepad");

        Assert.True(result);
    }
}
