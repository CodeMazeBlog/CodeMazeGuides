using IntroductionToSemaphoreInCsharp;

const int SleepDelay = 2000;

Console.WriteLine("Executing with Semaphore...");
await ExampleWithSemaphore.AccessWithSemaphoreAsync(SleepDelay);

Console.WriteLine("Executing with SemaphoreSlim...");
await ExampleWithSemaphoreSlim.AccessWithSemaphoreSlimAsync(SleepDelay);