namespace CustomPropertiesWithSerilogTests;

[TestClass]
public class ContextEnricherTests
{
    [TestMethod]
    public async Task GivenContextEnricher_WhenCallingLogContextMethod_ThenAddCustomParameter()
    {
        var logger = new LoggerConfiguration()
           .Enrich.FromLogContext()
           .WriteTo.TestCorrelator()
           .CreateLogger();

        var customProperties = new CustomPropertiesFromContextEnricher(logger);
        var userId = Guid.NewGuid().ToString();

        using (TestCorrelator.CreateContext())
        {
            customProperties.EnrichFromContextPushProperty(userId);
            var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();

            Assert.AreEqual(1, logEvents.Count());

            var logEvent = logEvents.FirstOrDefault();
            var eventProperty = logEvent.Properties.Single();
            var eventPropertyValue = eventProperty.Value as ScalarValue;

            Assert.AreEqual(userId, eventPropertyValue.Value);
        }
    }

    [TestMethod]
    public void GivenContextEnricher_WhenCallingLogContextScopedMethod_ThenAddCustomParameter()
    {
        var logger = new LoggerConfiguration()
           .Enrich.FromLogContext()
           .WriteTo.TestCorrelator()
           .CreateLogger();

        var customProperties = new CustomPropertiesFromContextEnricher(logger);
        var userId = Guid.NewGuid().ToString();

        using (TestCorrelator.CreateContext())
        {
            customProperties.EnrichFromContextPushPropertyScoped(userId);
            var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();

            Assert.AreEqual(1, logEvents.Count());

            var logEvent = logEvents.FirstOrDefault();
            var eventProperty = logEvent.Properties.Single();
            var eventPropertyValue = eventProperty.Value as ScalarValue;

            Assert.AreEqual(userId, eventPropertyValue.Value);
        }
    }

    [TestMethod]
    public void GivenContextEnricher_WhenCallingForContextMethod_ThenAddCustomParameter()
    {
        var logger = new LoggerConfiguration()
           .WriteTo.TestCorrelator()
           .CreateLogger();

        var customProperties = new CustomPropertiesFromContextEnricher(logger);
        var userId = Guid.NewGuid().ToString();

        using (TestCorrelator.CreateContext())
        {
            customProperties.EnrichFromContextForContext(userId);
            var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();

            Assert.AreEqual(1, logEvents.Count());

            var logEvent = logEvents.FirstOrDefault();
            var eventProperty = logEvent.Properties.Single();
            var eventPropertyValue = eventProperty.Value as ScalarValue;

            Assert.AreEqual(userId, eventPropertyValue.Value);
        }
    }
}