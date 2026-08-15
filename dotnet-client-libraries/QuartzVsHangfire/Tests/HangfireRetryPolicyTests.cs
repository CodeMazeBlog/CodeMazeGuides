using System.Reflection;
using Hangfire;
using QuartzVsHangfire.HangfireSample;

namespace Tests;

public class HangfireRetryPolicyTests
{
    [Fact]
    public void GivenTheSendWebhookMethod_WhenReadingItsAttributes_ThenAutomaticRetryIsConfigured()
    {
        var method = typeof(HangfireRetryPolicy).GetMethod(nameof(HangfireRetryPolicy.SendWebhookAsync));

        var retry = method!.GetCustomAttribute<AutomaticRetryAttribute>();

        Assert.NotNull(retry);
        Assert.Equal(5, retry!.Attempts);
    }
}
