namespace PluginPatternInCSharpTests
{
    [TestClass]
    public class PluginPatternInCSharpTests
    {
        [TestMethod]
        public void WhenMainIsInvoked_ThenProgramRunsWithoutIssues()
        {
            Program.Main(new [] {"temperature"});
        }

        [TestMethod]
        public void WhenMainIsInvoked_ThenProgramRuns()
        {
            Program.Main([]);
        }
    }
}