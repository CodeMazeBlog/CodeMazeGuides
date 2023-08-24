using Xunit;
using System.Threading.Tasks;

namespace AwaitTaskVsReturnTaskTests;

public class MiscellaneousUnitTest
{
    [Fact]
    public void GivenAsyncTask_WhenBlockedInNonUIThread_ThenDoesNotCauseDeadlock()
    {
        var result = ReadContent();

        Assert.Equal("Sample content", result);
    }

    // Bad code - this will cause deadlock if called from UI thread
    private static string ReadContent()
    {
        var task = ReadContentTaskAsync();

        return task.Result;
    }

    private static async Task<string> ReadContentTaskAsync()
    {
        await Task.Delay(20);

        return "Sample content";
    }

    [Fact]
    public async void GivenNonAsyncOverloadOfAsyncTask_WhenGetsCalled_ThenProducesExpectedOutcome()
    {
        var result = await CalculateTask();

        Assert.Equal(3.5m, result);
    }

    private static async Task<decimal> CalculateTaskAsync(bool roundUp)
    {
        await Task.Delay(10);

        return roundUp ? 3.5m : 3.48m;
    }

    private static Task<decimal> CalculateTask() => CalculateTaskAsync(true);
}
