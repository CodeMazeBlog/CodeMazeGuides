using ExecutingPowerShellScript;

namespace Tests
{
    public class PowerShellClassLiveTest
    {
        [Fact]
        public void GivenCommand_WhenInvoked_ThenExecutesCommand()
        {
            var powerShellClass = new PowerShellClass();
            var result = powerShellClass.ExecuteCommand("Get-Date");
            var expected = true;

            Assert.Equal(expected, result!="");
        }

        [Fact]
        public void GivenName_WhenInvoked_ThenStartsAProcess()
        {
            var powerShellClass = new PowerShellClass();
            var result = powerShellClass.StartProcess("notepad");
            var expectedResult = "True";

            Assert.Equal(expectedResult, result.ToString());
        }
    }
}
