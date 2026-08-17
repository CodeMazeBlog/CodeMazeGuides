using Moq;
using Quartz;
using QuartzVsHangfire.QuartzSample;

namespace Tests;

public class QuartzRetryJobTests
{
    private sealed class FailingRetryJob : QuartzRetryJob
    {
        protected override Task DoWorkAsync(IJobExecutionContext context)
            => throw new InvalidOperationException("work failed");
    }

    [Fact]
    public async Task GivenTheWorkThrows_WhenExecute_ThenWrapsItInARefiringJobExecutionException()
    {
        var job = new FailingRetryJob();
        var context = new Mock<IJobExecutionContext>().Object;

        var exception = await Assert.ThrowsAsync<JobExecutionException>(() => job.Execute(context));

        Assert.True(exception.RefireImmediately);
        Assert.IsType<InvalidOperationException>(exception.InnerException);
    }
}
