using NUnit.Framework;
using TaskExtensions = MultipleTasksDemo.Client.Extensions.TaskExtensions;

namespace Tests;

[TestFixture]
public class TaskExtensionsTests
{
    private static async Task<int> Succeed(int value)
    {
        await Task.Delay(10);
        return value;
    }

    private static async Task<int> Fail(string message)
    {
        await Task.Delay(10);
        throw new Exception(message);
    }

    [Test]
    public async Task WhenAll_ThrowsAggregateException()
    {
        await Assert.ThrowsAsync<AggregateException>(async () =>
            await TaskExtensions.WhenAll(Fail("Test Exception 1"), Fail("Test Exception 2"), Succeed(3)));
    }

    [Test]
    public async Task WhenAll_ReturnsIndividualExceptionsOnEachTask()
    {
        var aggregateException = await Assert.ThrowsAsync<AggregateException>(async () =>
            await TaskExtensions.WhenAll(Fail("Test Exception 1"), Fail("Test Exception 2"), Succeed(3)));

        Assert.That(aggregateException!.InnerExceptions.Select(e => e.Message),
            Is.EquivalentTo(new[] { "Test Exception 1", "Test Exception 2" }));
    }

    [Test]
    public async Task WhenAll_ReturnsResultsForEachTask()
    {
        var (result1, result2, result3) = await TaskExtensions.WhenAll(Succeed(1), Succeed(2), Succeed(3));

        Assert.That(result1, Is.EqualTo(1));
        Assert.That(result2, Is.EqualTo(2));
        Assert.That(result3, Is.EqualTo(3));
    }

    [Test]
    public async Task PlainTaskWhenAll_AwaitThrowsOnlyTheExceptionOfTheTaskThatFailedFirst()
    {
        var first = new TaskCompletionSource<int>();
        var second = new TaskCompletionSource<string>();
        var whenAll = Task.WhenAll(first.Task, second.Task);

        second.SetException(new Exception("Test Exception 2"));
        first.SetException(new Exception("Test Exception 1"));

        var exception = await Assert.ThrowsAsync<Exception>(async () => await whenAll);

        Assert.That(exception!.Message, Is.EqualTo("Test Exception 2"));
        Assert.That(whenAll.Exception!.InnerExceptions, Has.Count.EqualTo(2));
    }
}
