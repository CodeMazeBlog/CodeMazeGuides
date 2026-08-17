using Hangfire;

namespace QuartzVsHangfire.HangfireSample;

// Hangfire ships a queryable monitoring API — the same data the drop-in
// dashboard renders. Wiring the dashboard itself is one line in Startup:
//   app.UseHangfireDashboard("/hangfire");   // needs Hangfire.AspNetCore
public static class HangfireMonitoring
{
    public static long ScheduledJobCount()
    {
        var monitoringApi = JobStorage.Current.GetMonitoringApi();

        return monitoringApi.GetStatistics().Scheduled;
    }
}
