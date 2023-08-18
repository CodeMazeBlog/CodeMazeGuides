using Serilog.Core;
using Serilog.Events;

namespace LogLevelsWithSerilog.Helper
{
    public class MyCustomSerilogEnricher : ILogEventEnricher
    {
        static readonly string _environment;

        static MyCustomSerilogEnricher()
        {
            _environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var enrichProperty = propertyFactory.CreateProperty("MyEnvironment", _environment);

            logEvent.AddOrUpdateProperty(enrichProperty);
        }
    }
}
