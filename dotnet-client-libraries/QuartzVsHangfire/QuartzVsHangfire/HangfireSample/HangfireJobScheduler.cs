using Hangfire;
using QuartzVsHangfire.Services;

namespace QuartzVsHangfire.HangfireSample;

// Hangfire is built around a persistent job queue. We hand it work and it
// stores, runs, and retries that work for us. These two calls are the model.
public static class HangfireJobScheduler
{
    // Hangfire: enqueue now, retry automatically, watch it in the dashboard
    public static string EnqueueWelcomeEmail(int userId) =>
        BackgroundJob.Enqueue<IEmailSender>(x => x.SendWelcomeAsync(userId));

    public static void ScheduleNightlyReport() =>
        RecurringJob.AddOrUpdate<IReportBuilder>("nightly", x => x.RunAsync(), Cron.Daily);
}
