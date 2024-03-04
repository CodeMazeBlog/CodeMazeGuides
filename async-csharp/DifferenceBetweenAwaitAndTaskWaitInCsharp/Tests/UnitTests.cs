using DifferenceBetweenAwaitAndTaskWaitInCsharp;

namespace Tests;

[TestClass]
public class UnitTests
{
    [TestMethod]
    public void GivenATask_WhenTaskWaitIsCalled_ThenCodeBlocks()
    {
        CodeExamples.BlockingCodeExample();
    }

    [TestMethod]
    public async Task GivenATask_WhenAwaitIsUsed_ThenCodeIsAsync()
    {
        await CodeExamples.AsynchronousCodeExampleAsync();
    }

    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void GivenAFailingTask_WhenTaskWaitIsCalled_ThenAggregateExceptionIsRaised()
    {
        CodeExamples.BlockingExceptionHandling();
    }

    [TestMethod]
    public async Task GivenAFailingTask_WhenAwaitIsCalled_ThenExceptionIsHandled()
    {
        await CodeExamples.AsynchronousExceptionHandlingAsync();
    }
}