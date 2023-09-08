namespace Tests
{
    // Helper class to simulate console input
    public class ConsoleInput
    {
        private readonly TextReader originalInput;
        private readonly StringReader stringReader;

        public ConsoleInput(string input)
        {
            originalInput = Console.In;
            stringReader = new StringReader(input);
            Console.SetIn(stringReader);
        }
 
    }
}
