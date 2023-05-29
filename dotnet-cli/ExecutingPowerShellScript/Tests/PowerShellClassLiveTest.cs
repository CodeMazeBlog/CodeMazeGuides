using ExecutingPowerShellScript;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class PowerShellClassLiveTest
    {
        [Fact]
        public void GivenCommand_WhenInvoked_ThenExecutesCommand()
        {
            PowerShellClass powerShellClass = new PowerShellClass();
            var result = powerShellClass.ExecuteCommand("Get-Date");
            var expected = true;

            Assert.Equal(expected, result!="");
        }

        [Fact]
        public void GivenName_WhenInvoked_ThenStartsAProcess()
        {
            PowerShellClass powerShellClass = new PowerShellClass();
            var result = powerShellClass.StartProcess("notepad");
            var expectedResult = "True";

            Assert.Equal(expectedResult, result.ToString());
        }
    }
}
