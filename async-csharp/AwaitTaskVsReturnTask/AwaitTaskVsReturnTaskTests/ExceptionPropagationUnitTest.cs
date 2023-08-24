using System;
using Xunit;
using System.Threading.Tasks;

namespace AwaitTaskVsReturnTaskTests;

public class ExceptionPropagationUnitTest
{
    [Fact]
    public async Task GivenTaskWithException_WhenReturned_ThenImmediatelyThrowsException()
    {
        Task? task = null;

        // Throws exception when we call the method
        await Assert.ThrowsAsync<Exception>(() => task = SimpleTask(20));

        Assert.Null(task);
    }

    [Fact]
    public async Task GivenTaskWithException_WhenAwaited_ThenCarriesExceptionWithTask()
    {
        // Does not throw exception when we call the method
        var task = SimpleTaskAsync(20);

        Assert.NotNull(task);

        // Throws exception while executing the task
        await Assert.ThrowsAsync<Exception>(async () => await task);

        Assert.True(task.IsFaulted);
    }

    private static Task SimpleTask(int duration)
    {
        if (duration > 10)
            throw new Exception("I don't want to delay so long");

        return Task.Delay(duration);
    }

    private static async Task SimpleTaskAsync(int duration)
    {
        if (duration > 10)
            throw new Exception("I don't want to delay so long");

        await Task.Delay(duration);
    }
}
