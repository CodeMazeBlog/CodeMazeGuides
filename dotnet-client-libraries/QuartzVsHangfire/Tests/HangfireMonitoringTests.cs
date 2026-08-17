using Hangfire;
using QuartzVsHangfire.HangfireSample;

namespace Tests;

[Collection("HangfireStorage")]
public class HangfireMonitoringTests
{
    static HangfireMonitoringTests()
    {
        GlobalConfiguration.Configuration.UseInMemoryStorage();
    }

    [Fact]
    public void WhenScheduledJobCount_ThenReadsFromTheMonitoringApi()
    {
        var count = HangfireMonitoring.ScheduledJobCount();

        Assert.True(count >= 0);
    }
}
