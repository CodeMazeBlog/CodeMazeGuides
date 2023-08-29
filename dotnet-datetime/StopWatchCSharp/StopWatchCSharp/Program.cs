using StopWatchCSharp;

var stopWatchInstance = new StopWatchMethods();
var stopWatch = stopWatchInstance.CreateRandomArray(1000);

Console.WriteLine($@"Elapsed Time: {stopWatch.Elapsed}
Elapsed Milliseconds: {stopWatch.ElapsedMilliseconds}
Elapsed Ticks: {stopWatch.ElapsedTicks}
Is Running: {stopWatch.IsRunning}");