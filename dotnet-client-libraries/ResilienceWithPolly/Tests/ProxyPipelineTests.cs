using Microsoft.AspNetCore.Mvc;
using Monolith.Resilience;
using Polly;
using Polly.CircuitBreaker;

namespace Tests;

[TestClass]
public class ProxyPipelineTests
{
    private static ResiliencePipeline<IActionResult> BuildPipeline()
    {
        var builder = new ResiliencePipelineBuilder<IActionResult>();
        ProxyPipeline.Configure(builder);

        return builder.Build();
    }

    private static string? ContentOf(IActionResult result) =>
        ((ContentResult)result).Content;

    [TestMethod]
    public async Task GivenACallThatSucceeds_WhenExecutedThroughThePipeline_ThenItReturnsTheResult()
    {
        var pipeline = BuildPipeline();

        var result = await pipeline.ExecuteAsync(static _ =>
            ValueTask.FromResult<IActionResult>(new ContentResult { Content = "authors" }));

        Assert.AreEqual("authors", ContentOf(result));
    }

    [TestMethod]
    public async Task GivenACallThatFailsOnce_WhenExecutedThroughThePipeline_ThenTheRetryRecoversIt()
    {
        var pipeline = BuildPipeline();
        var attempts = 0;

        var result = await pipeline.ExecuteAsync(_ =>
        {
            attempts++;

            if (attempts == 1)
            {
                throw new InvalidOperationException("Oops!");
            }

            return ValueTask.FromResult<IActionResult>(new ContentResult { Content = "authors" });
        });

        Assert.AreEqual(2, attempts);
        Assert.AreEqual("authors", ContentOf(result));
    }

    [TestMethod]
    public async Task GivenACallThatAlwaysFails_WhenExecutedThroughThePipeline_ThenTheFallbackMessageIsReturned()
    {
        var pipeline = BuildPipeline();

        var result = await pipeline.ExecuteAsync<IActionResult>(static _ =>
            throw new InvalidOperationException("Oops!"));

        Assert.AreEqual(ProxyPipeline.FallbackMessage, ContentOf(result));
    }

    [TestMethod]
    public async Task GivenACallThatAlwaysFails_WhenTheThroughputThresholdIsReached_ThenTheCircuitOpensAndStopsCallingTheDependency()
    {
        var pipeline = BuildPipeline();
        var attempts = 0;

        // One execution is two attempts -- the call plus a single retry -- which
        // meets MinimumThroughput at a failure ratio of 1.0, so the circuit opens.
        await pipeline.ExecuteAsync<IActionResult>(_ =>
        {
            attempts++;

            throw new InvalidOperationException("Oops!");
        });

        Assert.AreEqual(2, attempts);

        var result = await pipeline.ExecuteAsync<IActionResult>(_ =>
        {
            attempts++;

            throw new InvalidOperationException("Oops!");
        });

        Assert.AreEqual(2, attempts, "The open circuit must short-circuit without calling the dependency again.");
        Assert.AreEqual(ProxyPipeline.FallbackMessage, ContentOf(result));
    }

    [TestMethod]
    public async Task GivenAnOpenCircuit_WhenTheFallbackIsRemoved_ThenABrokenCircuitExceptionSurfaces()
    {
        var pipeline = new ResiliencePipelineBuilder()
            .AddCircuitBreaker(new CircuitBreakerStrategyOptions
            {
                ShouldHandle = new PredicateBuilder().Handle<Exception>(),
                FailureRatio = 1.0,
                MinimumThroughput = 2,
                SamplingDuration = TimeSpan.FromSeconds(30),
                BreakDuration = TimeSpan.FromMinutes(1)
            })
            .Build();

        for (var i = 0; i < 2; i++)
        {
            await Assert.ThrowsExactlyAsync<InvalidOperationException>(async () =>
                await pipeline.ExecuteAsync(static _ => throw new InvalidOperationException("Oops!")));
        }

        await Assert.ThrowsExactlyAsync<BrokenCircuitException>(async () =>
            await pipeline.ExecuteAsync(static _ => ValueTask.CompletedTask));
    }
}
