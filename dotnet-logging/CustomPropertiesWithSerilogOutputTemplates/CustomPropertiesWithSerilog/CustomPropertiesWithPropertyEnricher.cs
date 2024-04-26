using Serilog;

namespace CustomPropertiesWithSerilog;

public class CustomPropertiesWithPropertyEnricher(ILogger logger)
{
    private readonly ILogger _logger = logger;

    public void LogUsingPropertyEnrichedLogger()
    {
        _logger.Information("Application Started");
    }
}
