namespace PluginPatternInCSharpTests
{
    [TestClass]
    public class PluginPatternInCSharpTests
    {
        [TestMethod]
        public void GivenCommandString_WhenMainIsInvoked_ThenProgramRunsWithoutIssues()
        {
            Program.Main(new [] {"temperature"});
        }
    }
}