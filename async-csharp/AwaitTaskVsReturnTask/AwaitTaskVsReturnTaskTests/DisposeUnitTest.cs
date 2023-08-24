using System;
using Xunit;
using System.Threading.Tasks;

namespace AwaitTaskVsReturnTaskTests;

public class DisposeUnitTest
{   
    [Fact]
    public async Task GivenTaskFromDisposableObject_WhenAwaited_ThenDisposeInvokedAfterTaskCompletion()
    {
        var resultOfAwaitedTask = await ReadTaskAsync();

        Assert.Equal("Dispose invoked after reading completed", resultOfAwaitedTask);
    }

    [Fact]
    public async Task GivenTaskFromDisposableObject_WhenReturned_ThenDisposeInvokedBeforeTaskCompletion()
    {
        var resultOfReturnedTask = await ReadTask();

        Assert.Equal("Dispose invoked before reading completed", resultOfReturnedTask);
    }

    private static async Task<string> ReadTaskAsync()
    {
        using (var reader = new DataReader())
            return await reader.ReadAsync();
    }

    private static Task<string> ReadTask()
    {
        using (var reader = new DataReader())
            return reader.ReadAsync();
    }
}