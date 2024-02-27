

namespace AwaitInForEachLoop
{
    public static class AwaitInLoops
    {
        public static async Task<List<int>> ResultAsync()
        {
            var numbers = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

            var result = new List<int>();

            foreach (var number in numbers)
            {
                result.Add(number);

                Console.WriteLine($"Processed {number}");

                await Task.Delay(1000);

            }
            Console.WriteLine("Done Processing");

            return numbers;
        }
    }
}
