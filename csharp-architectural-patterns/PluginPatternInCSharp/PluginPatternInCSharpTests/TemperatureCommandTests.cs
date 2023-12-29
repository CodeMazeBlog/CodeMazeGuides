namespace PluginPatternInCSharpTests
{
    [TestClass]
    public class TemperatureCommandTests
    {
        [TestMethod]
        public void WhenTemperatureCommandIsInvoked_TemperatureIsReportedWithoutIssues()
        {
            var sut = new TemperatureCommand.TemperatureCommand();

            sut.Invoke();
        }
    }
}