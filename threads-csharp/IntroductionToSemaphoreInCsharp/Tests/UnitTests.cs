using IntroductionToSemaphoreInCsharp;

namespace Tests;

[TestClass]
public class UnitTests
{
    const int SleepDelay = 50;

    [TestMethod]
    public async Task GivenSomeConcurrentCode_WhenAccessWithSemaphoreAsyncIsInvoked_ThenAllThreadsShouldExecute()
    {
        await ExampleWithSemaphore.AccessWithSemaphoreAsync(SleepDelay);
        var output = ExampleWithSemaphore.OutputQueue;

        Assert.AreEqual(Constants.NumberOfThreads, output.Count);
    }

    [TestMethod]
    public async Task GivenSomeConcurrentCode_WhenAccessWithSemaphoreSlimAsyncIsInvoked_ThenAllThreadsShouldExecute()
    {
        await ExampleWithSemaphoreSlim.AccessWithSemaphoreSlimAsync(SleepDelay);
        var output = ExampleWithSemaphoreSlim.OutputQueue;

        Assert.AreEqual(Constants.NumberOfThreads, output.Count);
    }
}