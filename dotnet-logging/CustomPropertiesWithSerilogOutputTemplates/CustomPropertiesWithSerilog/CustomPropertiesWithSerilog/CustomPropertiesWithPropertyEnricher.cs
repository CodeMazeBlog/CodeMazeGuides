using Serilog;

namespace CustomPropertiesWithSerilog;

public class CustomPropertiesWithPropertyEnricher
{
    private readonly ILogger _logger;

    public CustomPropertiesWithPropertyEnricher(ILogger logger)
    {
        _logger = logger;
    }

    public void LogUsingPropertyEnrichedLogger()
    {
        _logger.Information("Application Started");
    }
}
