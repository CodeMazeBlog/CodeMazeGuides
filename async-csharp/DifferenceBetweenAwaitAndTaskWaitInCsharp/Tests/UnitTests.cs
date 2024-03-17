using DifferenceBetweenAwaitAndTaskWaitInCsharp;

namespace Tests;

[TestClass]
public class UnitTests
{
    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void GivenAFailingTask_WhenTaskWaitIsCalled_ThenAggregateExceptionIsRaised()
    {
        CodeExamples.BlockingExceptionHandling();
    }
}