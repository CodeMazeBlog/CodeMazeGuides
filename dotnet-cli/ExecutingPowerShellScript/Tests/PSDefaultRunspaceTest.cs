using ExecutingPowerShellScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
   
    public class PSDefaultRunspaceTest
    {
        private PSDefaultRunspace defaultRunspace;
        public PSDefaultRunspaceTest()
        {
            defaultRunspace= new PSDefaultRunspace();
        }

        [Fact]
        public void WhenInvokedReturnsListOfProcesses()
        {
            var result = defaultRunspace.GetRunningProcesses();
            var expectedType = "System.Collections.ObjectModel.Collection`1[System.Management.Automation.PSObject]";

            Assert.Equal(expectedType, result.GetType().ToString());
        }

        [Fact]
        public void WhenInvokedReturnsDetailedListOfProcesses()
        {
            var result = defaultRunspace.GetRunningProcessesDetails();
            var expectedType = "System.Collections.ObjectModel.Collection`1[System.Management.Automation.PSObject]";

            Assert.Equal(expectedType, result.GetType().ToString());
        }

        [Fact]
        public void GivenNameWhenInvokedStartsAProcess()
        {
            var result = defaultRunspace.StartAProcess("notepad");
            var expectedResult = true;

            Assert.Equal(expectedResult, result);
        }
    }
}
