using Quartz;

namespace QuartzVsHangfire.QuartzSample;

// Quartz.NET has no dashboard. Monitoring is a listener we attach to the
// scheduler. This one counts completed jobs — the hook a custom UI would use.
public class LoggingJobListener : IJobListener
{
    public string Name => "logging-job-listener";

    public int ExecutedCount { get; private set; }

    public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        => Task.CompletedTask;

    public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        => Task.CompletedTask;

    public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException? jobException,
        CancellationToken cancellationToken = default)
    {
        ExecutedCount++;

        return Task.CompletedTask;
    }
}
