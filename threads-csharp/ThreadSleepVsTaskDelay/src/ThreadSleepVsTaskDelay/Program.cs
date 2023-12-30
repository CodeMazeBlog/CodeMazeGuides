Console.WriteLine("Starting Thread.Sleep test...");
UseThreadSleep();
Console.WriteLine("Thread.Sleep test completed.\n");

Console.WriteLine("Starting Task.Delay test...");
UseTaskDelay().Wait();
Console.WriteLine("Task.Delay test completed.");

static void UseThreadSleep()
{
    Console.WriteLine($"Before sleep: Thread id = {Environment.CurrentManagedThreadId}");
    Thread.Sleep(2000);
    Console.WriteLine($"After sleep: Thread id = {Environment.CurrentManagedThreadId}");
}

static async Task UseTaskDelay()
{
    Console.WriteLine($"Before delay: Thread id = {Environment.CurrentManagedThreadId}");
    await Task.Delay(2000);
    Console.WriteLine($"After delay: Thread id = {Environment.CurrentManagedThreadId}");
}
