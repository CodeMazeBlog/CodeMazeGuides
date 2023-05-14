using ExecutingPowerShellScript;

namespace Tests
{
    public  class PSCustomRunspaceLiveTest
    {
        [Fact]
        public void GivenCommand_WhenInvoked_ThenExecutesCommandGiven()
        {
            PSCustomRunspace customRunspace = new PSCustomRunspace(); 
            var result = customRunspace.ExecuteCommand("Get-Date");
            var expectedResult = true;

            Assert.Equal(expectedResult, result!="");
        }

        [Fact]
        public void GivenName_WhenInvoked_ThenDoesntStartAProcess()
        {
            PSCustomRunspace customRunspace = new PSCustomRunspace(); 
            var result = customRunspace.StartAProcess("notepad");
            var expectedResult = "False";

            Assert.Equal(expectedResult, result.ToString());
        }

    }
}
