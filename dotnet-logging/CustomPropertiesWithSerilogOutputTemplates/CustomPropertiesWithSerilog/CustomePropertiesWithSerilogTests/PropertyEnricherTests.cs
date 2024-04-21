using CustomPropertiesWithSerilog;
using Serilog.Events;
using Serilog.Sinks.TestCorrelator;
using Serilog;

namespace CustomePropertiesWithSerilogTests;

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

        var sut = new CustomPropertiesWithPropertyEnricher(logger);

        using (TestCorrelator.CreateContext())
        {
            sut.LogUsingPropertyEnrichedLogger();
            var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();
            Assert.AreEqual(1, logEvents.Count());
            var evt = logEvents.FirstOrDefault();
            var evtProperty = evt.Properties.Single();
            var evtPropertyVal = evtProperty.Value as ScalarValue;
            Assert.AreEqual("Version", evtProperty.Key);
            Assert.AreEqual("1.0.0", evtPropertyVal.Value);
        }
    }

}
