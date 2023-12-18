namespace PeriodicTimerCSharpTests;

[TestClass]
public class PeriodicTimerUnitTests
{
    [TestMethod]
    public void GivenAnArrayWithSpecificElements_ThenValidateItsCreation()
    {
        var array = PeriodicTimerMethods.CreateRandomArray(20);

        Assert.IsNotNull(array);
        Assert.IsInstanceOfType(array, typeof(int[]));
        Assert.AreEqual(20, array.Length);
    }

    [TestMethod]
    public async Task GivenATimerTask_ThenValidateItHasNoExceptions()
    {
        var timeSpan = TimeSpan.FromSeconds(1);
        var size = 10;

        var periodicTimerMethods = new PeriodicTimerMethods(timeSpan, size);

        periodicTimerMethods.Start();
        await Task.Delay(5000);
        await periodicTimerMethods.StopTaskAsync();
    }
}