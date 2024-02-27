

namespace AwaitInForEachLoop
{
    public class TaskWhenAllInLoop
    {
        public static async Task<List<Task>> ResultAsync()
        {
            var numbers = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

            var processingTasks = new List<Task>();

            foreach (int number in numbers)
            {
            
                processingTasks.Add(ProcessNumberAsync(number));
            }

            await Task.WhenAll(processingTasks);

            Console.WriteLine("Done Processing");

            return processingTasks;
        }

        public static async Task ProcessNumberAsync(int number)
        {
            // Simulate an asynchronous operation
            await Task.Delay(1000);

            Console.WriteLine($"Processed {number}");
        }

    }
}
