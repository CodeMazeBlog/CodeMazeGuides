using Quartz;

namespace QuartzVsHangfire.QuartzSample;

// Quartz.NET has no automatic retry. We opt in by catching the failure and
// throwing a JobExecutionException that asks the scheduler to refire the job.
public class QuartzRetryJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            await DoWorkAsync(context);
        }
        catch (Exception ex)
        {
            throw new JobExecutionException(ex, refireImmediately: true);
        }
    }

    protected virtual Task DoWorkAsync(IJobExecutionContext context) => Task.CompletedTask;
}
