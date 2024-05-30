using IntroductionToSemaphoreInCsharp;

const int SleepDelay = 50;

Console.WriteLine("Executing with Semaphore...");
await ExampleWithSemaphore.AccessWithSemaphoreAsync(SleepDelay);

Console.WriteLine("Executing with SemaphoreSlim...");
await ExampleWithSemaphoreSlim.AccessWithSemaphoreSlimAsync(SleepDelay);