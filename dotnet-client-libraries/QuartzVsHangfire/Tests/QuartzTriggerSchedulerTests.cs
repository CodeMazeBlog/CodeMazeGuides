using Quartz;
using Quartz.Impl.Triggers;
using QuartzVsHangfire.QuartzSample;

namespace Tests;

public class QuartzTriggerSchedulerTests
{
    [Fact]
    public void WhenBuildNightlyTrigger_ThenTriggerHasNightlyIdentity()
    {
        var trigger = QuartzTriggerScheduler.BuildNightlyTrigger();

        Assert.Equal("nightly", trigger.Key.Name);
    }

    [Fact]
    public void WhenBuildNightlyTrigger_ThenTriggerUsesTheExpectedCronExpression()
    {
        var trigger = QuartzTriggerScheduler.BuildNightlyTrigger();

        var cronTrigger = Assert.IsType<CronTriggerImpl>(trigger);
        Assert.Equal("0 0 2 * * ?", cronTrigger.CronExpressionString);
    }
}
