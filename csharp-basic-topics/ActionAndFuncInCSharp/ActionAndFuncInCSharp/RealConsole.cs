namespace ActionAndFuncInCSharp
{
    public class RealConsole : IConsole
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine(int message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine(bool message)
        {
            Console.WriteLine(message);
        }
    }
}
