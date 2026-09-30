using Quartz;

namespace QuartzVsHangfire.QuartzSample;

// A listener is still the seam for custom monitoring. Since 4.x Quartz.NET also
// ships its own dashboard, so this is an extension point rather than the only way.
public class LoggingJobListener : IJobListener
{
    public string Name => "logging-job-listener";

    public int ExecutedCount { get; private set; }

    // 4.x: every listener member returns ValueTask. A 3.x Task signature still
    // compiles, stops implementing the interface member, and is refused at
    // registration.
    public ValueTask JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        => ValueTask.CompletedTask;

    public ValueTask JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        => ValueTask.CompletedTask;

    public ValueTask JobWasExecuted(IJobExecutionContext context, JobExecutionException? jobException,
        CancellationToken cancellationToken = default)
    {
        ExecutedCount++;

        return ValueTask.CompletedTask;
    }
}
