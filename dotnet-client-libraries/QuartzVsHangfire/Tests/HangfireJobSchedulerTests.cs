using Hangfire;
using Hangfire.InMemory;
using Hangfire.Storage;
using QuartzVsHangfire.HangfireSample;
using QuartzVsHangfire.Services;

namespace Tests;

[Collection("HangfireStorage")]
public class HangfireJobSchedulerTests
{
    static HangfireJobSchedulerTests()
    {
        // A single in-memory store backs every assertion, so the tests need no
        // SQL Server or Redis: Hangfire only needs storage to write to.
        GlobalConfiguration.Configuration.UseInMemoryStorage();
    }

    [Fact]
    public void GivenAUserId_WhenEnqueueWelcomeEmail_ThenEnqueuesTheSendWelcomeJob()
    {
        var jobId = HangfireJobScheduler.EnqueueWelcomeEmail(42);

        Assert.False(string.IsNullOrWhiteSpace(jobId));

        var details = JobStorage.Current.GetMonitoringApi().JobDetails(jobId);
        Assert.NotNull(details);
        Assert.Equal(nameof(IEmailSender.SendWelcomeAsync), details.Job.Method.Name);
    }

    [Fact]
    public void WhenScheduleNightlyReport_ThenRegistersTheNightlyRecurringJob()
    {
        HangfireJobScheduler.ScheduleNightlyReport();

        using var connection = JobStorage.Current.GetConnection();
        var recurringJobs = connection.GetRecurringJobs();

        Assert.Contains(recurringJobs, job => job.Id == "nightly");
    }
}
