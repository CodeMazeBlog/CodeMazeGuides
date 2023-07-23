namespace ITextBasics.ConsoleManager
{
    internal class RealConsole : IConsole
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }
    }
}
