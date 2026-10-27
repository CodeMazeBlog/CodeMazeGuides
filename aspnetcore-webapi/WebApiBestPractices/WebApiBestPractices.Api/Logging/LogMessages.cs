namespace WebApiBestPractices.Api.Logging;

public static partial class LogMessages
{
    [LoggerMessage(Level = LogLevel.Information, Message = "Returned {Count} owners from the database")]
    public static partial void OwnersReturned(this ILogger logger, int count);
}
