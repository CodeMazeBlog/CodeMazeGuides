using DifferenceBetweenAwaitAndTaskWaitInCsharp;

namespace Tests;

[TestClass]
public class UnitTests
{
    [TestMethod]
    public void GivenATask_WhenTaskWaitIsCalled_ThenCodeBlocks()
    {
        Program.BlockingCodeExample();
    }

    [TestMethod]
    public async Task GivenATask_WhenAwaitIsUsed_ThenCodeIsAsync()
    {
        await Program.AsynchronousCodeExample();
    }

    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void GivenAFailingTask_WhenTaskWaitIsCalled_ThenAggregateExceptionIsRaised()
    {
        Program.BlockingExceptionHandling();
    }

    [TestMethod]
    public async Task GivenAFailingTask_WhenAwaitIsCalled_ThenExceptionIsHandled()
    {
        await Program.AsynchronousExceptionHandling();
    }
}