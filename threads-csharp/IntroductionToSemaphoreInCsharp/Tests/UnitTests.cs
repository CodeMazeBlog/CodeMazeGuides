using IntroductionToSemaphoreInCsharp;
using System.Diagnostics;

namespace Tests;

[TestClass]
public class UnitTests
{
    const int SleepDelay = 200;

    [TestMethod]
    public async Task GivenSomeConcurrentCode_WhenAccessWithSemaphoreAsyncIsInvoked_ThenAllThreadsExecuteAndTheCallerIsBlocked()
    {
        var stopwatch = Stopwatch.StartNew();
        var task = ExampleWithSemaphore.AccessWithSemaphoreAsync(SleepDelay);
        var callerBlockedMs = stopwatch.ElapsedMilliseconds;
        var output = await task;

        Assert.AreEqual(Constants.NumberOfThreads, output.Count);
        Assert.IsGreaterThanOrEqualTo(SleepDelay, callerBlockedMs);
    }

    [TestMethod]
    public async Task GivenSomeConcurrentCode_WhenAccessWithSemaphoreSlimAsyncIsInvoked_ThenAllThreadsExecuteAndTheCallerIsNotBlocked()
    {
        var stopwatch = Stopwatch.StartNew();
        var task = ExampleWithSemaphoreSlim.AccessWithSemaphoreSlimAsync(SleepDelay);
        var callerBlockedMs = stopwatch.ElapsedMilliseconds;
        var output = await task;

        Assert.AreEqual(Constants.NumberOfThreads, output.Count);
        Assert.IsLessThan(SleepDelay, callerBlockedMs);
    }

    [TestMethod]
    public void GivenASemaphore_WhenReleaseMultipleTimesIsInvoked_ThenAnExceptionIsThrown()
    {
        Assert.ThrowsExactly<SemaphoreFullException>(ExampleWithSemaphore.ReleaseMultipleTimes);
    }

    [TestMethod]
    public void GivenASemaphoreSlimWithoutMaxCount_WhenReleasedOnceTooOften_ThenTheCountGrowsWithoutAnException()
    {
        using var semaphoreSlim = new SemaphoreSlim(1);

        semaphoreSlim.Wait();
        semaphoreSlim.Release();
        semaphoreSlim.Release();

        Assert.AreEqual(2, semaphoreSlim.CurrentCount);
    }
}
