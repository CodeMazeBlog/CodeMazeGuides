using IntroductionToSemaphoreInCsharp;
using System.Diagnostics;

const int SleepDelay = 50;

Console.WriteLine("Executing with Semaphore...");
var stopwatch = Stopwatch.StartNew();
var semaphoreTask = ExampleWithSemaphore.AccessWithSemaphoreAsync(SleepDelay);
var semaphoreBlockedMs = stopwatch.ElapsedMilliseconds;
var outputQueue = await semaphoreTask;
foreach (var output in outputQueue)
{
    Console.WriteLine(output);
}

Console.WriteLine("Executing with SemaphoreSlim...");
stopwatch.Restart();
var semaphoreSlimTask = ExampleWithSemaphoreSlim.AccessWithSemaphoreSlimAsync(SleepDelay);
var semaphoreSlimBlockedMs = stopwatch.ElapsedMilliseconds;
outputQueue = await semaphoreSlimTask;
foreach (var output in outputQueue)
{
    Console.WriteLine(output);
}

Console.WriteLine($"Semaphore kept the caller busy for {semaphoreBlockedMs} ms");
Console.WriteLine($"SemaphoreSlim kept the caller busy for {semaphoreSlimBlockedMs} ms");

Console.WriteLine("Calling Release multiple times...");
try
{
    ExampleWithSemaphore.ReleaseMultipleTimes();
}
catch (SemaphoreFullException ex)
{
    Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
}
