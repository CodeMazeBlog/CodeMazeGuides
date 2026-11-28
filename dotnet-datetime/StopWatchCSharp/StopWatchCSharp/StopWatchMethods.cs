using System.Diagnostics;

namespace StopWatchCSharp;

public static class StopWatchMethods
{
    public static Stopwatch CreateRandomArray(int size)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var array = new int[size];

        for (int i = 0; i < size; i++)
            array[i] = Random.Shared.Next();

        stopWatch.Stop();

        return stopWatch;
    }

    public static Stopwatch MeasureTwoIntervals()
    {
        var stopWatch = Stopwatch.StartNew();
        Thread.Sleep(100);
        stopWatch.Stop();

        Thread.Sleep(100);

        stopWatch.Start();
        Thread.Sleep(100);
        stopWatch.Stop();

        return stopWatch;
    }

    public static TimeSpan CreateRandomArrayWithTimestamp(int size)
    {
        var startTimestamp = Stopwatch.GetTimestamp();
        var array = new int[size];

        for (int i = 0; i < size; i++)
            array[i] = Random.Shared.Next();

        return Stopwatch.GetElapsedTime(startTimestamp);
    }
}
