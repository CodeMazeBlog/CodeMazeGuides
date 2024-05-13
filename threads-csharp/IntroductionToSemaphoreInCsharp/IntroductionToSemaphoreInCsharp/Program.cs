using IntroductionToSemaphoreInCsharp;

const int SleepDelay = 2000;

Console.WriteLine("Executing with Lock...");
ExampleWithLock.AccessWithLock(SleepDelay);

Console.WriteLine("Executing with Mutex...");
ExampleWithMutex.AccessWithMutex(SleepDelay);

Console.WriteLine("Executing with Semaphore...");
ExampleWithSemaphore.AccessWithSemaphore(SleepDelay);

Console.WriteLine("Executing with SemaphoreSlim...");
await ExampleWithSemaphoreSlim.AccessWithSemaphoreSlimAsync(SleepDelay);