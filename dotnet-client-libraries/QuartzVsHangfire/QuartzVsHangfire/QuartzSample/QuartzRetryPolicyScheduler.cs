using Quartz;

namespace QuartzVsHangfire.QuartzSample;

// Quartz.NET 4.x retries a failed occurrence for us: the policy lives on the
// trigger, is persisted with it, and survives a restart or a failover.
public static class QuartzRetryPolicyScheduler
{
    public static ITrigger BuildWebhookTrigger() =>
        TriggerBuilder.Create<QuartzRetryJob>()
            .WithIdentity("webhook")
            .StartNow()
            .WithRetryPolicy(RetryPolicy.Explicit([
                TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(60),
                TimeSpan.FromSeconds(300)
            ]))
            .Build();

    public static RetryPolicy ExponentialBackoff() =>
        RetryPolicy.Exponential(maxAttempts: 5, initialDelay: TimeSpan.FromSeconds(30), factor: 2.0);
}
