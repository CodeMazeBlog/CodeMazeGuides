using Quartz;

namespace QuartzVsHangfire.QuartzSample;

// Quartz.NET runs fine with no database: the in-memory store is the default.
// 4.x removed StdSchedulerFactory, so a scheduler outside a container is built
// with QuartzSchedulerBuilder, the same builder AddQuartz configures.
public static class QuartzStorageConfig
{
    public static async Task<IScheduler> CreateInMemorySchedulerAsync()
    {
        var factory = QuartzSchedulerBuilder.Create().Build();

        return await factory.GetScheduler();
    }
}
