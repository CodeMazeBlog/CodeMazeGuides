namespace dotnet_console
{
    public static class Colors
    {
        public static void ShowColors()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hello, World!");
            Console.ResetColor();
        }

        public static async Task ShowColorsRotate()
        {
            for (int i = 2; i < 10; i++)
            {
                if (i != 0) await Task.Delay(10);

                Console.Clear();
                Console.ForegroundColor = (ConsoleColor)i;
                Console.WriteLine("Hello, World!");
            }
            Console.ResetColor();
        }
    }
}
