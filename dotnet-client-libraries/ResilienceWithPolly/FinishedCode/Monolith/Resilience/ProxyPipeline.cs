using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.Retry;

namespace Monolith.Resilience;

public static class ProxyPipeline
{
    public const string Name = "proxy";

    public const string FallbackMessage =
        "Sorry, we are currently experiencing issues. Please try again later";

    public static void Configure(ResiliencePipelineBuilder<IActionResult> builder) =>
        builder
            .AddFallback(new FallbackStrategyOptions<IActionResult>
            {
                ShouldHandle = new PredicateBuilder<IActionResult>().Handle<Exception>(),
                FallbackAction = static _ => Outcome.FromResultAsValueTask<IActionResult>(
                    new ContentResult { Content = FallbackMessage })
            })
            .AddRetry(new RetryStrategyOptions<IActionResult>
            {
                ShouldHandle = new PredicateBuilder<IActionResult>().Handle<Exception>(),
                MaxRetryAttempts = 1,
                Delay = TimeSpan.Zero
            })
            .AddCircuitBreaker(new CircuitBreakerStrategyOptions<IActionResult>
            {
                ShouldHandle = new PredicateBuilder<IActionResult>().Handle<Exception>(),
                FailureRatio = 1.0,
                MinimumThroughput = 2,
                SamplingDuration = TimeSpan.FromSeconds(30),
                BreakDuration = TimeSpan.FromMinutes(1)
            });
}
