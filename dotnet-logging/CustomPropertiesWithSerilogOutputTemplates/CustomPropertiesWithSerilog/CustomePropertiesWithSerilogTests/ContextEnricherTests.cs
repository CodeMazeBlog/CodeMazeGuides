using CustomPropertiesWithSerilog;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.TestCorrelator;

namespace CustomePropertiesWithSerilogTests;

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

        var sut = new CustomPropertiesFromContextEnricher(logger);
        var userId = Guid.NewGuid().ToString();

        using (TestCorrelator.CreateContext())
        {
            sut.EnrichFromContextPushProperty(userId);
            var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();
            Assert.AreEqual(1, logEvents.Count());
            var evt = logEvents.FirstOrDefault();
            var evtProperty = evt.Properties.Single();
            var evtPropertyVal = evtProperty.Value as ScalarValue;
            Assert.AreEqual(userId, evtPropertyVal.Value);
        }
    }

    [TestMethod]
    public void GivenContextEnricher_WhenCallingLogContextScopedMethod_ThenAddCustomParameter()
    {
        var logger = new LoggerConfiguration()
           .Enrich.FromLogContext()
           .WriteTo.TestCorrelator()
           .CreateLogger();

        var sut = new CustomPropertiesFromContextEnricher(logger);
        var userId = Guid.NewGuid().ToString();

        using (TestCorrelator.CreateContext())
        {
            sut.EnrichFromContextPushPropertyScoped(userId);
            var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();
            Assert.AreEqual(1, logEvents.Count());
            var evt = logEvents.FirstOrDefault();
            var evtProperty = evt.Properties.Single();
            var evtPropertyVal = evtProperty.Value as ScalarValue;
            Assert.AreEqual(userId, evtPropertyVal.Value);
        }
    }

    [TestMethod]
    public void GivenContextEnricher_WhenCallingForContextMethod_ThenAddCustomParameter()
    {
        var logger = new LoggerConfiguration()
           .WriteTo.TestCorrelator()
           .CreateLogger();

        var sut = new CustomPropertiesFromContextEnricher(logger);
        var userId = Guid.NewGuid().ToString();

        using (TestCorrelator.CreateContext())
        {
            sut.EnrichFromContextForContext(userId);
            var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();
            Assert.AreEqual(1, logEvents.Count());
            var evt = logEvents.FirstOrDefault();
            var evtProperty = evt.Properties.Single();
            var evtPropertyVal = evtProperty.Value as ScalarValue;
            Assert.AreEqual(userId, evtPropertyVal.Value);
        }
    }
}