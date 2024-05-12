using System.Net;
using Polly;
using Polly.Retry;

namespace RetryHttpExceptionsWithPolly;

public static class RetryStrategy
{
    public static async Task ExecuteAsync()
    {
        var retryOptions = new RetryStrategyOptions
        {
            MaxRetryAttempts = 3,
            BackoffType = DelayBackoffType.Exponential,
            Delay = TimeSpan.FromSeconds(1),
            DelayGenerator = async arg =>
            {
                if(arg.Outcome.Exception is RateLimitedException rateLimitedException)
                    return rateLimitedException.RetryAfter;
                return null;
            },
            UseJitter = true,
            OnRetry = args =>
            {
                Console.WriteLine($"OnRetry, Attempt: {args.AttemptNumber}, Delay: {args.RetryDelay}");
                return default;
            }
        };

        var pipeline = new ResiliencePipelineBuilder()
            .AddRetry(retryOptions)
            .Build();

        await pipeline.ExecuteAsync(async cancellationToken =>
        {
            var response = await new HttpClient().GetAsync("https://jsonplaceholder.typicode.com/users", cancellationToken);
            Console.WriteLine($"HTTP Status Code: {response.StatusCode}");
            if(response.StatusCode == HttpStatusCode.TooManyRequests)
                throw new RateLimitedException(response.Headers.RetryAfter?.Delta);
            response.EnsureSuccessStatusCode();
        });
    }
}