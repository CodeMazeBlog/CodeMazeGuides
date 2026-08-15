using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace QuartzVsHangfire.QuartzSample;

// Quartz.NET registers the scheduler, its jobs, and their triggers together.
// The job and the trigger are declared side by side, wired by the job key.
public static class QuartzStartup
{
    public static IServiceCollection AddQuartzJobs(this IServiceCollection services)
    {
        services.AddQuartz(configurator =>
        {
            var reportJob = new JobKey("nightly-report");

            configurator.AddJob<ReportJob>(reportJob);
            configurator.AddTrigger(trigger => trigger
                .ForJob(reportJob)
                .WithIdentity("nightly")
                .WithCronSchedule("0 0 2 * * ?"));
        });

        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        return services;
    }
}
