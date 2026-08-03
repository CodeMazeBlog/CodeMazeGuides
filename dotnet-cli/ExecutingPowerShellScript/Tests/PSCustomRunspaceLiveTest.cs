using ExecutingPowerShellScript;

namespace Tests
{
    public  class PSCustomRunspaceLiveTest
    {
        [Fact]
        public void GivenCommand_WhenInvoked_ThenExecutesCommandGiven()
        {
            var customRunspace = new PSCustomRunspace(); 
            var result = customRunspace.ExecuteCommand("Get-Date");
            var expectedResult = DateTime.Now.ToShortDateString();

            Assert.Equal(expectedResult, DateTime.Parse(result).ToShortDateString());
        }

        [Fact]
        public void GivenName_WhenInvoked_ThenDoesntStartAProcess()
        {
            var customRunspace = new PSCustomRunspace(); 
            var result = customRunspace.StartProcess("notepad");
            var expectedResult = false;

            Assert.Equal(expectedResult, result);
        }
    }
}
