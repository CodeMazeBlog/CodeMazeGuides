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
        public void WhenInvokedThenReturnsListOfProcesses()
        {
            var result = defaultRunspace.GetRunningProcesses();
            var expectedType = "System.Collections.ObjectModel.Collection`1[System.Management.Automation.PSObject]";

            Assert.Equal(expectedType, result.GetType().ToString());
        }

        [Fact]
        public void WhenInvokedThenReturnsDetailedListOfProcesses()
        {
            var result = defaultRunspace.GetRunningProcessesDetails();
            var expectedType = "System.Collections.ObjectModel.Collection`1[System.Management.Automation.PSObject]";

            Assert.Equal(expectedType, result.GetType().ToString());
        }

        [Fact]
        public void GivenNameWhenInvokedThenStartsAProcess()
        {
            var result = defaultRunspace.StartAProcess("notepad");
            var expectedResult = true;

            Assert.Equal(expectedResult, result);
        }
    }
}
