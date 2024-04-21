using Serilog;
using Serilog.Context;

namespace CustomPropertiesWithSerilog;

public class CustomPropertiesFromContextEnricher
{
    private readonly ILogger _logger;

    public CustomPropertiesFromContextEnricher(ILogger logger)
    {
        _logger = logger;
    }

    public void EnrichFromContextPushProperty(string userId)
    {
        LogContext.PushProperty("UserId", userId);
        _logger.Information("User Tried to Login");
    }

    public void EnrichFromContextPushPropertyScoped(string userId)
    {
        using (LogContext.PushProperty("UserId", userId))
        {
            _logger.Information("User Tried to Login");
        }
    }

    public void EnrichFromContextForContext(string userId)
    {
        _logger.ForContext("UserId", userId).Information("User tried to login");
    }
}
