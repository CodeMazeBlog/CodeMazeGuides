using System.Net;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;

namespace RetryHttpExceptionsWithPolly;

public static class CircuitBreakerStrategy
{
public static async Task ExecuteAsync()
{
    var retryOptions = new RetryStrategyOptions
    {
        MaxRetryAttempts = 20,
        Delay = TimeSpan.FromSeconds(1),
        OnRetry = async args => Console.WriteLine($"OnRetry, Attempt: {args.AttemptNumber}, Delay: {args.RetryDelay}")
    };
    
    var circuitBreakerOptions = new CircuitBreakerStrategyOptions
    {
        FailureRatio = 0.1,
        MinimumThroughput = 5,
        SamplingDuration = TimeSpan.FromSeconds(5),
        BreakDuration = TimeSpan.FromSeconds(5),
        OnClosed = async _ => Console.WriteLine("Circuit Closed"),
        OnOpened = async _ => Console.WriteLine("Circuit Opened"),
        OnHalfOpened = async _ => Console.WriteLine("Circuit Half-Opened")
    };

    var pipeline = new ResiliencePipelineBuilder()
    .AddRetry(retryOptions)
    .AddCircuitBreaker(circuitBreakerOptions)
    .Build();
    
    await pipeline.ExecuteAsync(async cancellationToken =>
    {
        var response = await new HttpClient().GetAsync("https://jsonplaceholder.typicode.com/users", cancellationToken);
        Console.WriteLine($"HTTP Status Code: {response.StatusCode}");
        response.EnsureSuccessStatusCode();
    });
}
}