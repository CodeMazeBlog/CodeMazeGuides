
namespace AwaitInForEachLoop
{
    public static class AwaitInLoop
    {
        public static void PrepNumbers()
        {
            Console.WriteLine("Incoming number");
        }
        public static async Task<List<int>> ResultAsync()
        {
            List<int> numbers = [10, 20, 30, 40, 50, 60, 70, 80, 90];

            foreach (var number in numbers)
            {
                PrepNumbers();

                Console.WriteLine($"Processed {number}");

                await Task.Delay(1000);

            }

            Console.WriteLine("Done Processing");

            return numbers;
        }
    }
}

