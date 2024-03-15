using ExecutingPowerShellScript;

namespace Tests
{
    public class ProcessStartLiveTest
    {
        [Fact]
        public void GivenPath_WhenInvoked_ThenExecutesGivenScript()
        {
            var processStart = new ProcessStart();
            var result = processStart.ExecuteScript(@"C:\Users\scule\Desktop\echo.ps1");
            var expected= "I am invoked using ProcessStartInfoClass!\r\n";

            Assert.Equal(expected, result.ToString());
        }

        [Fact]
        public void GivenCommand_WhenInvoked_ThenExecutesGivenCommand()
        {
            var processStart = new ProcessStart();
            var result= processStart.ExecuteCommand("echo 'I am invoked using echo command!'");
            var expected = "I am invoked using echo command!\r\n";

            Assert.Equal(expected, result.ToString());
        }
    }
}
