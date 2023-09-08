namespace Tests
{
    // Helper class to simulate console input
    public class ConsoleInput : IDisposable
    {
        private readonly TextReader originalInput;
        private readonly StringReader stringReader;

        public ConsoleInput(string input)
        {
            originalInput = Console.In;
            stringReader = new StringReader(input);
            Console.SetIn(stringReader);
        }

        public void Dispose()
        {
            Console.SetIn(originalInput);
            stringReader.Dispose();
        }      
    }
}
