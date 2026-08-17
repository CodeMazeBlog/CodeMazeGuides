using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace QuartzVsHangfire.HangfireSample;

// One registration block wires the client, the storage, and the worker that
// drains the queue. After this, we inject IBackgroundJobClient and enqueue.
public static class HangfireStartup
{
    public static IServiceCollection AddHangfireJobs(this IServiceCollection services)
    {
        services.AddHangfire(config => config.UseInMemoryStorage());
        services.AddHangfireServer();

        return services;
    }
}
