using Xunit;
using System.Threading;
using System.Threading.Tasks;

namespace AwaitTaskVsReturnTaskTests;

public class AsyncLocalUnitTest
{
    private static readonly AsyncLocal<string> _context = new();

    private const string ParentValue = "Parent";
    private const string ChildAsyncValue = "ChildAsync";
    private const string ChildNonAsyncValue = "ChildNonAsync";

    [Fact]
    public async Task GivenParentAsyncTask_WhenUsingAsyncChildTask_ThenParentContextIsPersisted()
    {
        _context.Value = ParentValue;

        Assert.Equal(ParentValue, _context.Value);

        await ChildTaskAsync();

        Assert.Equal(ParentValue, _context.Value);
    }

    private static async Task ChildTaskAsync()
    {
        Assert.Equal(ParentValue, _context.Value);

        _context.Value = ChildAsyncValue;
        await Task.Yield();

        Assert.Equal(ChildAsyncValue, _context.Value);
    }

    [Fact]
    public async Task GivenParentAsyncTask_WhenUsingNonAsyncChildTask_ThenLocalContextIsPersisted()
    {
        _context.Value = ParentValue;

        Assert.Equal(ParentValue, _context.Value);

        await ChildTask();

        Assert.Equal(ChildNonAsyncValue, _context.Value);
    }

    private static Task ChildTask()
    {
        Assert.Equal(ParentValue, _context.Value);

        _context.Value = ChildNonAsyncValue;

        Assert.Equal(ChildNonAsyncValue, _context.Value);

        return Task.CompletedTask;
    }
}