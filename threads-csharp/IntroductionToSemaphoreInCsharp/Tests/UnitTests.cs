using IntroductionToSemaphoreInCsharp;
using System.Text;

namespace Tests;

[TestClass]
public class UnitTests
{
    private StringBuilder ConsoleOutput { get; } = new StringBuilder();

    [TestInitialize]
    public void Init()
    {
        Console.SetOut(new StringWriter(this.ConsoleOutput));
        this.ConsoleOutput.Clear();
    }

    [TestMethod]
    public void GivenSomeConcurrentCode_WhenAccessWithLockIsInvoked_ThenAllThreadsShouldExecute()
    {
        ExampleWithLock.AccessWithLock();
        AssertAllThreadsExecuted();
    }

    [TestMethod]
    public void GivenSomeConcurrentCode_WhenAccessWithMutexIsInvoked_ThenAllThreadsShouldExecute()
    {
        ExampleWithMutex.AccessWithMutex();
        AssertAllThreadsExecuted();
    }

    [TestMethod]
    public void GivenSomeConcurrentCode_WhenAccessWithSemaphoreIsInvoked_ThenAllThreadsShouldExecute()
    {
        ExampleWithSemaphore.AccessWithSemaphore();
        AssertAllThreadsExecuted();
    }

    [TestMethod]
    public async Task GivenSomeConcurrentCode_WhenAccessWithSemaphoreSlimAsyncIsInvoked_ThenAllThreadsShouldExecute()
    {
        await ExampleWithSemaphoreSlim.AccessWithSemaphoreSlimAsync();
        AssertAllThreadsExecuted();
    }

    private void AssertAllThreadsExecuted()
    {
        var result = ConsoleOutput.ToString();
        for (int i = 0;i < 10;i++)
        {
            Assert.IsTrue(result.Contains($"Thread {i}"));
        }
    }
}