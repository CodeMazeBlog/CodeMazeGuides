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

        Assert.AreEqual(TimeSpan.Zero, stopWatch.Elapsed);
        Assert.IsFalse(stopWatch.IsRunning);
        stopWatch.Restart();

        Assert.IsTrue(stopWatch.Elapsed > TimeSpan.Zero);
        Assert.IsTrue(stopWatch.IsRunning);

        stopWatch.Stop();

        Assert.IsFalse(stopWatch.IsRunning);
    }

    [TestMethod]
    public void GivenAStoppedStopwatch_WhenStartedAgain_ThenElapsedTimeKeepsAccumulating()
    {
        var stopWatch = Stopwatch.StartNew();
        Thread.Sleep(10);
        stopWatch.Stop();
        var firstInterval = stopWatch.Elapsed;

        stopWatch.Start();
        Thread.Sleep(10);
        stopWatch.Stop();

        Assert.IsTrue(stopWatch.Elapsed > firstInterval);
    }

    [TestMethod]
    public void GivenTwoIntervals_WhenMeasured_ThenOnlyTheMeasuredTimeIsCounted()
    {
        var stopWatch = StopWatchMethods.MeasureTwoIntervals();

        Assert.IsFalse(stopWatch.IsRunning);
        Assert.IsTrue(stopWatch.Elapsed >= TimeSpan.FromMilliseconds(150));
    }

    [TestMethod]
    public void GivenFrequencyTicks_WhenConvertedWithGetElapsedTime_ThenResultIsOneSecond()
    {
        Assert.AreEqual(TimeSpan.FromSeconds(1), Stopwatch.GetElapsedTime(0, Stopwatch.Frequency));
    }

    [TestMethod]
    public void GivenATimestamp_WhenGetElapsedTimeCalled_ThenReturnsElapsedTimeSpan()
    {
        var elapsed = StopWatchMethods.CreateRandomArrayWithTimestamp(10);

        Assert.IsTrue(elapsed >= TimeSpan.Zero);
    }
}
