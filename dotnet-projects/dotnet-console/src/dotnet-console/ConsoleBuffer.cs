namespace dotnet_console
{
    public static class ConsoleBuffer
    {
        public static void ChangeHeightAndBuffer()
        {
            Console.WindowHeight = 10;
            Console.BufferHeight = 30;

            for (int i = 0; i < 100; i++)
                Console.WriteLine($"Line {i}");
        }
    }
}
