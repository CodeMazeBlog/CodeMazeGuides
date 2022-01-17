namespace ActionAndFunc
{

    public static class Program
    {
        
        private static readonly Action<string, string> sayMyName = new(SayMyName);

        private static readonly Action<string> sayHello = new(SayHello);

        private static readonly Func<int, bool> isEven = new(IsEven);

        private static readonly Func<string> getQuote = new(GetQuote);

        public static void Main()
        {

            sayHello(String.Empty);

            sayMyName(string.Empty, "Heisenberg");

            string result = isEven(2) ? "It is even number" : "It is odd number";

            string quote = getQuote();

            Console.WriteLine(result);

            Console.WriteLine(quote);

        }

        public static void SayHello(string message) =>
            
            Console.WriteLine($"Hello {(string.IsNullOrWhiteSpace(message) ? "Code Maze" : message)}");

        public static void SayMyName(string name, string lastName) => Console.WriteLine($"You are {name + " " + lastName}.");

        public static bool IsEven(int number) => number % 2 == 0;

        public static string GetQuote() => "I am the one who knocks.";
    }
    
}
