using IntroductionToSemaphoreInCsharp;

namespace Tests;

[TestClass]
public class UnitTests
{
    const int SleepDelay = 50;

    [TestMethod]
    public async Task GivenSomeConcurrentCode_WhenAccessWithSemaphoreAsyncIsInvoked_ThenAllThreadsShouldExecute()
    {
        var output = await ExampleWithSemaphore.AccessWithSemaphoreAsync(SleepDelay);

        Assert.AreEqual(Constants.NumberOfThreads, output.Count);
    }

    [TestMethod]
    public async Task GivenSomeConcurrentCode_WhenAccessWithSemaphoreSlimAsyncIsInvoked_ThenAllThreadsShouldExecute()
    {
        var output = await ExampleWithSemaphoreSlim.AccessWithSemaphoreSlimAsync(SleepDelay);

        Assert.AreEqual(Constants.NumberOfThreads, output.Count);
    }
}