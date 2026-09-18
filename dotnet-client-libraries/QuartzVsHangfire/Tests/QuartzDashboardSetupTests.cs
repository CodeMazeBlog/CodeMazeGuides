using Microsoft.Extensions.DependencyInjection;
using Quartz.Extensibility;
using QuartzVsHangfire.QuartzSample;

namespace Tests;

public class QuartzDashboardSetupTests
{
    [Fact]
    public void WhenAddDashboard_ThenTheExecutionHistoryStoreIsRegistered()
    {
        var services = new ServiceCollection();

        services.AddDashboard();

        using var provider = services.BuildServiceProvider();

        Assert.NotNull(provider.GetService<IExecutionHistoryStore>());
    }
}
