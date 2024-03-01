namespace DetectKeyPressInCSharp
{
    public class ConsoleService : IConsoleService
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public ConsoleKeyInfo ReadKey(bool intercept = false)
        {
            return Console.ReadKey(intercept);
        }

        public bool KeyAvailable
        {
            get
            {
                return Console.KeyAvailable;
            }
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
