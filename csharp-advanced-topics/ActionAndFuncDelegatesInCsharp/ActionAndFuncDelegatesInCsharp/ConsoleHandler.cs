namespace ActionAndFuncDelegatesInCsharp
{
    public static class ConsoleHandler
    {
        public static void Write(string message)
        {
            Console.WriteLine(message);
        }

        public static int Read()
        {
            return Console.Read();
        }
    }
}
