namespace AwaitVsWait.Examples
{
    public class TaskWait
    {
        public int result;
        public void Execute()
        {
            var task = Task.Run(() =>
            PerformTask());

            task.Wait();

            Console.WriteLine("All tasks are completed.");
        }

        private void PerformTask()
        {
            for (result = 0; result < 5; result++)
            {
                Console.WriteLine($"Tasking Working at... {result}");
                Task.Delay(200).Wait(); // Wait for 1 second
            }
        }
    }
}