using DifferenceBetweenAwaitAndTaskWaitInCsharp;

namespace Tests;

[TestClass]
public class UnitTests
{
    [TestMethod]
    public void GivenAFailingTask_WhenTaskWaitIsCalled_ThenAggregateExceptionIsRaised()
    {
        Assert.ThrowsExactly<AggregateException>(() => CodeExamples.BlockingExceptionHandling());
    }
}