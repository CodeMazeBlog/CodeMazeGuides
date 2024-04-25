using IntroductionToSemaphoreInCsharp;

Console.WriteLine("Executing with Lock...");
ExampleWithLock.AccessWithLock();

Console.WriteLine("Executing with Mutex...");
ExampleWithMutex.AccessWithMutex();

Console.WriteLine("Executing with Semaphore...");
ExampleWithSemaphore.AccessWithSemaphore();

Console.WriteLine("Executing with SemaphoreSlim...");
await ExampleWithSemaphoreSlim.AccessWithSemaphoreSlimAsync();