using Moq;
using Quartz;
using QuartzVsHangfire.QuartzSample;

namespace Tests;

public class LoggingJobListenerTests
{
    [Fact]
    public async Task WhenJobWasExecuted_ThenTheListenerCountsIt()
    {
        var listener = new LoggingJobListener();
        var context = new Mock<IJobExecutionContext>().Object;

        await listener.JobWasExecuted(context, jobException: null);

        Assert.Equal(1, listener.ExecutedCount);
    }
}
