using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using QuartzVsHangfire.HangfireSample;

namespace Tests;

[Collection("HangfireStorage")]
public class HangfireStartupTests
{
    [Fact]
    public void WhenAddHangfireJobs_ThenTheBackgroundJobClientIsRegistered()
    {
        var services = new ServiceCollection();

        services.AddHangfireJobs();

        using var provider = services.BuildServiceProvider();
        var client = provider.GetService<IBackgroundJobClient>();

        Assert.NotNull(client);
    }
}
