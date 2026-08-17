using Hangfire;

namespace QuartzVsHangfire.HangfireSample;

// Hangfire retries failed jobs for us. We do not write a retry loop; we declare
// the policy with an attribute and Hangfire re-runs the job on the schedule below.
public class HangfireRetryPolicy
{
    [AutomaticRetry(Attempts = 5, DelaysInSeconds = new[] { 10, 60, 300 })]
    public Task SendWebhookAsync(string url)
    {
        Console.WriteLine($"Posting to {url}. If this throws, Hangfire retries it.");

        return Task.CompletedTask;
    }
}
