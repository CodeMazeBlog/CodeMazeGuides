using Serilog;
using Serilog.Context;

namespace CustomPropertiesWithSerilog;

public class CustomPropertiesFromContextEnricher(ILogger logger)
{
    private readonly ILogger _logger = logger;

    public void EnrichFromContextPushProperty(string userId)
    {
        LogContext.PushProperty("UserId", userId);
        _logger.Information("User tried to login");
    }

    public void EnrichFromContextPushPropertyScoped(string userId)
    {
        using (LogContext.PushProperty("UserId", userId))
        {
            _logger.Information("User tried to login");
        }
    }

    public void EnrichFromContextForContext(string userId)
    {
        var contextLogger = _logger.ForContext("UserId", userId);
        contextLogger.Information("User tried to login");
    }
}
