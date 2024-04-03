namespace AwaitInForEachLoop 
{ 
    public static class AwaitInLoops
    {
        public static async Task<List<int>> ResultAsync(int delayMilliseconds = 1000)
        {
            var numbers = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

            var result = new List<int>();

            foreach (var number in numbers)
            {
                Console.WriteLine($"Processing {number}");

                await Task.Delay(delayMilliseconds);

                Console.WriteLine($"Processed {number}");

                result.Add(number);
            }
            Console.WriteLine("Done Processing");

            return result;
        }
    }
}
