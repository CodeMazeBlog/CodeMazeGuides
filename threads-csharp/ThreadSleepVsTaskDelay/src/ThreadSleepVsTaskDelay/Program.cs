using System.Diagnostics;

namespace ThreadSleepVsTaskDelay
{
    public class Program
    {
        public static async Task UseTaskDelay(int sleepMilliseconds = 2000)
        {
            Console.WriteLine($"Before delay: Thread id = {Environment.CurrentManagedThreadId}");
            await Task.Delay(sleepMilliseconds);
            Console.WriteLine($"After delay: Thread id = {Environment.CurrentManagedThreadId}");
        }

        public static void UseThreadSleep(int delayMilliseconds = 2000)
        {
            Console.WriteLine($"Before sleep: Thread id = {Environment.CurrentManagedThreadId}");
            Thread.Sleep(delayMilliseconds);
            Console.WriteLine($"After sleep: Thread id = {Environment.CurrentManagedThreadId}");
        }

        private static async Task Main()
        {
            Console.WriteLine("Starting Thread.Sleep test...");
            UseThreadSleep();
            Console.WriteLine("Thread.Sleep test completed.\n");

            Console.WriteLine("Starting Task.Delay test...");
            await UseTaskDelay();
            Console.WriteLine("Task.Delay test completed.");
        }
    }
}
