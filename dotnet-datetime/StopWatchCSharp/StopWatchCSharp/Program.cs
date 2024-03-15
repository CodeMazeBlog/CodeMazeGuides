using StopWatchCSharp;
using System.Diagnostics;

var stopWatch = StopWatchMethods.CreateRandomArray(1000);

Console.WriteLine($@"Elapsed Time: {stopWatch.Elapsed}
Elapsed Milliseconds: {stopWatch.ElapsedMilliseconds}
Elapsed Ticks: {stopWatch.ElapsedTicks}
Is Running: {stopWatch.IsRunning}
Frequency: {Stopwatch.Frequency}
Using High Resolution: {Stopwatch.IsHighResolution}");