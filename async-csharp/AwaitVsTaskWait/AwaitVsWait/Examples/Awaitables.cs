namespace AwaitVsWait.Examples
{
	public class Awaitables
	{
        public int resultS = 0;
        public int resultL = 0;
        public void Execute()
        {
            ShortDelay();
            LongDelay();
        }

        private async Task<int> ShortDelay()
        {
            await Task.Run(() =>
            {
                while (resultS < 10)
                {
                    Console.WriteLine($"(ShortDelay)Tasking Working at... {resultS}");
                    // Do something
                    Task.Delay(100).Wait();
                    resultS++;
                }
            });
            return resultS;
        }

        private int LongDelay()
        {
            while (resultL < 5)
            {
                Console.WriteLine($"(LongDelay)Tasking Working at... {resultL}");
                // Do something
                Task.Delay(200).Wait();

                resultL++;
            }
            return resultL;
        }
    }
}