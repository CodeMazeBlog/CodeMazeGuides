namespace AwaitVsWait.Examples
{
    public class TaskWait
    {
        public void Execute()
        {
            Task task = Task.Run(() =>
            PerformTask(1));

            task.Wait();

            Console.WriteLine("All tasks are completed.");
        }

        void PerformTask(int id)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Tasking Working at... {i}");
                Task.Delay(1000).Wait(); // Wait for 1 second
            }
        }
    }
}