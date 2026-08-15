using System.Collections.Specialized;
using Quartz;
using Quartz.Impl;

namespace QuartzVsHangfire.QuartzSample;

// Quartz.NET runs fine with no database: RAMJobStore is the default. Durable
// schedules are opt-in — we swap the job store type for an ADO.NET store.
public static class QuartzStorageConfig
{
    public static Task<IScheduler> CreateInMemorySchedulerAsync()
    {
        var properties = new NameValueCollection
        {
            ["quartz.jobStore.type"] = "Quartz.Simpl.RAMJobStore, Quartz"
        };

        var factory = new StdSchedulerFactory(properties);

        return factory.GetScheduler();
    }
}
