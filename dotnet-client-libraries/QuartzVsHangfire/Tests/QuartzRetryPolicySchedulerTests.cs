using QuartzVsHangfire.QuartzSample;

namespace Tests;

public class QuartzRetryPolicySchedulerTests
{
    [Fact]
    public void WhenBuildWebhookTrigger_ThenTheTriggerCarriesTheRetryPolicy()
    {
        var trigger = QuartzRetryPolicyScheduler.BuildWebhookTrigger();

        var policy = trigger.RetryPolicy;

        Assert.NotNull(policy);
        Assert.Equal(3, policy.MaxAttempts);
        Assert.Equal(TimeSpan.FromSeconds(10), policy.DelayFor(1));
        Assert.Equal(TimeSpan.FromSeconds(60), policy.DelayFor(2));
    }

    [Fact]
    public void WhenExponentialBackoff_ThenTheDelayDoubles()
    {
        var policy = QuartzRetryPolicyScheduler.ExponentialBackoff();

        Assert.Equal(5, policy.MaxAttempts);
        Assert.Equal(TimeSpan.FromSeconds(30), policy.DelayFor(1));
        Assert.Equal(TimeSpan.FromSeconds(60), policy.DelayFor(2));
    }
}
