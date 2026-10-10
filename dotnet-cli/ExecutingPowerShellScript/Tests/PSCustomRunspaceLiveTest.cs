using ExecutingPowerShellScript;

namespace Tests;

public class PSCustomRunspaceLiveTest
{
    [Fact]
    public void GivenCommand_WhenInvoked_ThenExecutesCommandGiven()
    {
        using var customRunspace = new PSCustomRunspace();

        var result = customRunspace.ExecuteCommand("Get-Date");

        Assert.Equal(DateTime.Now.ToShortDateString(), DateTime.Parse(result).ToShortDateString());
    }

    [Fact]
    public void GivenName_WhenInvoked_ThenDoesntStartAProcess()
    {
        using var customRunspace = new PSCustomRunspace();

        var result = customRunspace.StartProcess("notepad");

        Assert.False(result);
    }
}
