using StopWatchCSharp;
using System.Diagnostics;

var stopWatch = StopWatchMethods.CreateRandomArray(1000);

Console.WriteLine($@"Elapsed Time: {stopWatch.Elapsed}
Elapsed Milliseconds: {stopWatch.ElapsedMilliseconds}
Elapsed Ticks: {stopWatch.ElapsedTicks}
Is Running: {stopWatch.IsRunning}
Frequency: {Stopwatch.Frequency}
Using High Resolution: {Stopwatch.IsHighResolution}");

Console.WriteLine($"One second in Stopwatch ticks: {Stopwatch.GetElapsedTime(0, Stopwatch.Frequency)}");

var twoIntervals = StopWatchMethods.MeasureTwoIntervals();
Console.WriteLine($"Two measured intervals: {twoIntervals.ElapsedMilliseconds} ms");

var elapsed = StopWatchMethods.CreateRandomArrayWithTimestamp(1000);
Console.WriteLine($"Elapsed with GetTimestamp: {elapsed.TotalMilliseconds} ms");
