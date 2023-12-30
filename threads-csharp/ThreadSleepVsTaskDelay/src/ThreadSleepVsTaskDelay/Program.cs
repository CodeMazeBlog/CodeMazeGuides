namespace ThreadSleepVsTaskDelay
{
    public class Program
    {
        public static async Task UseTaskDelay()
        {
            Console.WriteLine($"Before delay: Thread id = {Environment.CurrentManagedThreadId}");
            await Task.Delay(2000);
            Console.WriteLine($"After delay: Thread id = {Environment.CurrentManagedThreadId}");
        }

        public static void UseThreadSleep()
        {
            Console.WriteLine($"Before sleep: Thread id = {Environment.CurrentManagedThreadId}");
            Thread.Sleep(2000);
            Console.WriteLine($"After sleep: Thread id = {Environment.CurrentManagedThreadId}");
        }

        private static async Task Main(string[] args)
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
