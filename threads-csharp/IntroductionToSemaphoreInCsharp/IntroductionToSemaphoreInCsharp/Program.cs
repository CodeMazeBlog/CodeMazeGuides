using IntroductionToSemaphoreInCsharp;

const int SleepDelay = 50;

Console.WriteLine("Executing with Semaphore...");
await ExampleWithSemaphore.AccessWithSemaphoreAsync(SleepDelay);
foreach(var output in ExampleWithSemaphore.OutputQueue)
{
    Console.WriteLine(output);
}

Console.WriteLine("Executing with SemaphoreSlim...");
await ExampleWithSemaphoreSlim.AccessWithSemaphoreSlimAsync(SleepDelay);
foreach (var output in ExampleWithSemaphoreSlim.OutputQueue)
{
    Console.WriteLine(output);
}