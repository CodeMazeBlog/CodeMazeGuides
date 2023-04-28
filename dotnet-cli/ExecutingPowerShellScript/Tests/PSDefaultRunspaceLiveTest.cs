using ExecutingPowerShellScript;

namespace Tests
{
    public class PSDefaultRunspaceLiveTest
    {
        private PSDefaultRunspace defaultRunspace;
        public PSDefaultRunspaceLiveTest()
        {
            defaultRunspace= new PSDefaultRunspace();
        }

        [Fact]
        public void GivenPath_WhenInvoked_ThenExecutesScript()
        {
            var result = defaultRunspace.ExecuteScript(@"C:\Users\scule\Desktop\pws.ps1");
            var expectedType = true;

            Assert.Equal(expectedType, result);
        }

        [Fact]
        public void WhenInvoked_ThenReturnsListOfProcesses()
        {
            var result = defaultRunspace.GetRunningProcesses();
            var expectedType = "System.Collections.ObjectModel.Collection`1[System.Management.Automation.PSObject]";

            Assert.Equal(expectedType, result.GetType().ToString());
        }

        [Fact]
        public void WhenInvoked_ThenReturnsDetailedListOfProcesses()
        {
            var result = defaultRunspace.GetRunningProcessesDetails();
            var expectedType = "System.Collections.ObjectModel.Collection`1[System.Management.Automation.PSObject]";

            Assert.Equal(expectedType, result.GetType().ToString());
        }

        [Fact]
        public void GivenName_WhenInvoked_ThenStartsAProcess()
        {
            var result = defaultRunspace.StartAProcess("notepad");
            var expectedResult = true;

            Assert.Equal(expectedResult, result);
        }
    }
}
