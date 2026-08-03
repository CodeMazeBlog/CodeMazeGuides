namespace StopWatchCSharpTests;

[TestClass]
public class StopWatchUnitTests
{
    [TestMethod]
    public void GivenAStopwatchInstance_WhenStopwatchMethodsInvoked_ThenVerifyReturnedResults()
    {
        var arraySize = 10;
        var stopWatch = StopWatchMethods.CreateRandomArray(arraySize);

        Assert.IsInstanceOfType(stopWatch, typeof(Stopwatch));
        Assert.IsInstanceOfType(stopWatch.Elapsed, typeof(TimeSpan));
        Assert.IsInstanceOfType(stopWatch.ElapsedMilliseconds, typeof(long));
        Assert.IsInstanceOfType(stopWatch.ElapsedTicks, typeof(long));
        Assert.IsFalse(stopWatch.IsRunning);
         
        stopWatch.Reset();

        Assert.AreEqual(stopWatch.Elapsed, TimeSpan.Zero);
        stopWatch.Restart();

        Assert.AreEqual(stopWatch.Elapsed.CompareTo(TimeSpan.Zero), 1);
        Assert.IsTrue(stopWatch.IsRunning);

        stopWatch.Stop();

        Assert.IsFalse(stopWatch.IsRunning);
    }
}