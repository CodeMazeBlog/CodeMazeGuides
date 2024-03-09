namespace AwaitInForEachLoop
{
    public class TaskWhenAllInLoop
    {
        public static async Task<List<Task>> ResultAsync(int delayMilliseconds = 1000)
        {
            var numbers = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

            var result = new List<Task>();

            foreach (int number in numbers)
            {            
                result.Add(ProcessNumberAsync(number, delayMilliseconds));
            }

            await Task.WhenAll(result);

            Console.WriteLine("Done Processing");

            return result;
        }

        public static async Task ProcessNumberAsync(int number, int delayMilliseconds)
        {
            Console.WriteLine($"Processing {number}");
            // Simulate an asynchronous operation
            await Task.Delay(delayMilliseconds);

            Console.WriteLine($"Processed {number}");
        }
    }
}
