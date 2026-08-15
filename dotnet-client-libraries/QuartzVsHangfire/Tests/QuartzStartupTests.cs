using Microsoft.Extensions.DependencyInjection;
using Quartz;
using QuartzVsHangfire.QuartzSample;

namespace Tests;

public class QuartzStartupTests
{
    [Fact]
    public void WhenAddQuartzJobs_ThenTheSchedulerFactoryIsRegistered()
    {
        var services = new ServiceCollection();

        services.AddQuartzJobs();

        using var provider = services.BuildServiceProvider();
        var schedulerFactory = provider.GetService<ISchedulerFactory>();

        Assert.NotNull(schedulerFactory);
    }
}
