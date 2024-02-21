namespace AwaitVsWait.Examples
{
	public class Awaitables
	{
        public void Execute()
        {
            ShortDelay();
            LongDelay();
        }

        private async Task ShortDelay()
        {
            await Task.Run(() =>
            {
                int i = 0;
                while (i < 10)
                {
                    Console.WriteLine($"(ShortDelay)Tasking Working at... {i}");
                    // Do something
                    Task.Delay(100).Wait();
                    i++;
                }
            });
        }

        private void LongDelay()
        {
            int i = 0;
            while (i < 5)
            {
                Console.WriteLine($"(LongDelay)Tasking Working at... {i}");
                // Do something
                Task.Delay(200).Wait();

                i++;
            }
        }
    }
}