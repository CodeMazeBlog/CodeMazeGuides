using ExecutingPowerShellScript;

namespace Tests
{
    public  class PSCustomRunspaceTest
    {
        private PSCustomRunspace customRunspace;
        public PSCustomRunspaceTest()
        {
            customRunspace = new PSCustomRunspace();
        }

        [Fact]
        public void GivenName_WhenInvoked_ThenDoesntStartAProcess()
        {
            var result = customRunspace.StartAProcess("notepad");
            var expectedResult = false;

            Assert.Equal(expectedResult, result);
        }
    }
}
