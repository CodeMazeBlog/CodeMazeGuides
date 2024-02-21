using AwaitVsWait.Examples;

namespace Tests;

[TestClass]
public class AwaitVsWaitTest
{
    protected Awaitables awaitables = new Awaitables();
    protected TaskWait taskWait = new TaskWait();

    [TestMethod]
    public void GivenNoParameterIsRequired_WhenExecuteMethodOfAwaitClassIsCalled_ThenTwoMethodsAreRunConcurrently()
    {
        awaitables.Execute();
        Assert.AreNotEqual(awaitables.resultS, 0);
        Assert.AreNotEqual(awaitables.resultL, 0);
    }

    [TestMethod]
    public void GivenNoParameterIsRequired_WhenExecuteMethodOfTaskWaitClassIsCalled_ThenResultIsReturned()
    {
        taskWait.Execute();
        Assert.AreNotEqual(taskWait.result, 4);
    }
}