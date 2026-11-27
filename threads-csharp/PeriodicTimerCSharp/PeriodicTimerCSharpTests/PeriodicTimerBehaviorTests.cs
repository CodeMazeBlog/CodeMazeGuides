using Microsoft.Extensions.Time.Testing;

namespace PeriodicTimerCSharpTests;

[TestClass]
public class PeriodicTimerBehaviorTests
{
    [TestMethod]
    public async Task GivenMissedTicks_WhenWeWaitAgain_ThenTheyCollapseIntoOne()
    {
        var time = new FakeTimeProvider();
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(1), time);

        time.Advance(TimeSpan.FromSeconds(3.5));

        Assert.IsTrue(await timer.WaitForNextTickAsync());

        var nextTick = timer.WaitForNextTickAsync();
        Assert.IsFalse(nextTick.IsCompleted);

        time.Advance(TimeSpan.FromSeconds(0.5));
        Assert.IsTrue(await nextTick);
    }

    [TestMethod]
    public void GivenAWaitInFlight_WhenWeWaitTwice_ThenTheSecondCallThrows()
    {
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

        _ = timer.WaitForNextTickAsync();

        Assert.ThrowsExactly<InvalidOperationException>(() => timer.WaitForNextTickAsync());
    }

    [TestMethod]
    public async Task GivenAWaitInFlight_WhenWeDisposeTheTimer_ThenTheWaitReturnsFalse()
    {
        var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
        var tick = timer.WaitForNextTickAsync();

        timer.Dispose();

        Assert.IsFalse(await tick);
    }

    [TestMethod]
    public void GivenANewPeriod_WhenTimePasses_ThenTheTimerTicksOnTheNewSchedule()
    {
        var time = new FakeTimeProvider();
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(1), time);

        timer.Period = TimeSpan.FromSeconds(5);
        var tick = timer.WaitForNextTickAsync();

        time.Advance(TimeSpan.FromSeconds(4));
        Assert.IsFalse(tick.IsCompleted);

        time.Advance(TimeSpan.FromSeconds(1));
        Assert.IsTrue(tick.IsCompleted);
    }
}
