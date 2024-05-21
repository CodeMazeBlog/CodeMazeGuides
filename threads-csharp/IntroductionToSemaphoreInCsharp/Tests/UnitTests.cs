using IntroductionToSemaphoreInCsharp;
using System.Text;

namespace Tests;

[TestClass]
public class UnitTests
{
    private StringBuilder ConsoleOutput { get; } = new StringBuilder();
    const int SleepDelay = 50;

    [TestInitialize]
    public void Init()
    {
        Console.SetOut(new StringWriter(this.ConsoleOutput));
        this.ConsoleOutput.Clear();
    }

    [TestMethod]
    public async Task GivenSomeConcurrentCode_WhenAccessWithLockAsyncIsInvoked_ThenAllThreadsShouldExecute()
    {
        await ExampleWithLock.AccessWithLockAsync(SleepDelay);
        AssertAllThreadsExecuted();
    }

    [TestMethod]
    public async Task GivenSomeConcurrentCode_WhenAccessWithMutexAsyncIsInvoked_ThenAllThreadsShouldExecute()
    {
        await ExampleWithMutex.AccessWithMutexAsync(SleepDelay);
        AssertAllThreadsExecuted();
    }

    [TestMethod]
    public async Task GivenSomeConcurrentCode_WhenAccessWithSemaphoreAsyncIsInvoked_ThenAllThreadsShouldExecute()
    {
        await ExampleWithSemaphore.AccessWithSemaphoreAsync(SleepDelay);
        AssertAllThreadsExecuted();
    }

    [TestMethod]
    public async Task GivenSomeConcurrentCode_WhenAccessWithSemaphoreSlimAsyncIsInvoked_ThenAllThreadsShouldExecute()
    {
        await ExampleWithSemaphoreSlim.AccessWithSemaphoreSlimAsync(SleepDelay);
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