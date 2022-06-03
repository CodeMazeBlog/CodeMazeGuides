namespace dotnet_console
{
    public static class Sound
    {
        public static async Task Run()
        {
            Console.Beep(500, 1000);
            await Task.Delay(50);
            Console.Beep(1000, 500);
            Console.Beep(1500, 500);
            Console.Beep(1200, 500);
            Console.Beep(200, 600);
            Console.Beep(1000, 500);
        }
    }
}
