namespace Tests
{
    public class NetVersionTests
    {
        [Fact]
        public void WhenCheckingNetVersion_ThenShouldNotBeNull()
        {
            var netVersion = System.Environment.Version;
            
            Assert.NotNull(netVersion);
        }
    }
}