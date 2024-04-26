namespace CustomPropertiesWithSerilogTests;

[TestClass]
public class PropertyEnricherTests
{
    [TestMethod]
    public async Task GivenPropertyEnricher_WhenCallingLogMethod_ThenAddCustomParameter()
    {
        var logger = new LoggerConfiguration()
           .Enrich.WithProperty("Version", "1.0.0")
           .WriteTo.TestCorrelator()
           .CreateLogger();

        var customProperties = new CustomPropertiesWithPropertyEnricher(logger);

        using (TestCorrelator.CreateContext())
        {
            customProperties.LogUsingPropertyEnrichedLogger();
            var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();

            Assert.AreEqual(1, logEvents.Count());

            var logEvent = logEvents.FirstOrDefault();
            var eventProperty = logEvent.Properties.Single();
            var eventPropertyValue = eventProperty.Value as ScalarValue;

            Assert.AreEqual("Version", eventProperty.Key);
            Assert.AreEqual("1.0.0", eventPropertyValue.Value);
        }
    }

}
