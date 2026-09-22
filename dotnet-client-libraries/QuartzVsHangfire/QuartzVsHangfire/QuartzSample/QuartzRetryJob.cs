using Quartz;

namespace QuartzVsHangfire.QuartzSample;

// Since 4.x the job no longer owns the retry. It throws, and the retry policy
// on the trigger decides whether and when the occurrence runs again.
public class QuartzRetryJob : IJob
{
    public async ValueTask Execute(IJobExecutionContext context, CancellationToken cancellationToken = default)
        => await DoWorkAsync(context, cancellationToken);

    protected virtual ValueTask DoWorkAsync(IJobExecutionContext context, CancellationToken cancellationToken)
        => ValueTask.CompletedTask;
}
