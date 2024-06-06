using IntroductionToSemaphoreInCsharp;

const int SleepDelay = 50;

Console.WriteLine("Executing with Semaphore...");
var outputQueue = await ExampleWithSemaphore.AccessWithSemaphoreAsync(SleepDelay);
foreach(var output in outputQueue)
{
    Console.WriteLine(output);
}

Console.WriteLine("Executing with SemaphoreSlim...");
outputQueue = await ExampleWithSemaphoreSlim.AccessWithSemaphoreSlimAsync(SleepDelay);
foreach (var output in outputQueue)
{
    Console.WriteLine(output);
}

Console.WriteLine("Calling Release multiple times...");
await ExampleWithSemaphore.ReleaseMultipleTimesAsync(SleepDelay);