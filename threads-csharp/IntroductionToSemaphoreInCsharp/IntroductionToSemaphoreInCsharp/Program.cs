using IntroductionToSemaphoreInCsharp;

const int SleepDelay = 2000;

Console.WriteLine("Executing with Lock...");
await ExampleWithLock.AccessWithLockAsync(SleepDelay);

Console.WriteLine("Executing with Mutex...");
await ExampleWithMutex.AccessWithMutexAsync(SleepDelay);

Console.WriteLine("Executing with Semaphore...");
await ExampleWithSemaphore.AccessWithSemaphoreAsync(SleepDelay);

Console.WriteLine("Executing with SemaphoreSlim...");
await ExampleWithSemaphoreSlim.AccessWithSemaphoreSlimAsync(SleepDelay);