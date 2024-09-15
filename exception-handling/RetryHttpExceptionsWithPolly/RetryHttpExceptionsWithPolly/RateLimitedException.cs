namespace RetryHttpExceptionsWithPolly;

public class RateLimitedException(TimeSpan? retryAfter) : Exception
{
    public TimeSpan? RetryAfter { get; } = retryAfter;
}