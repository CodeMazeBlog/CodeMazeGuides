namespace WithDelegate
{
    public class WithDelegate
    {
        private static Dictionary<string, Func<int, int, int>> _handlers
            = new Dictionary<string, Func<int, int, int>>
            {
                { "add", Addition },
                { "subtract", Subtraction },
                { "multiply", Multiplication },
                // and so on...
            };

        public static int Addition(int x, int y)
        {
            return x + y;
        }

        public static int Subtraction(int x, int y)
        {
            return x - y;
        }

        public static int Multiplication(int x, int y)
        {
            return x * y;
        }

        public static void Operation(string input)
        {
            Func<int, int, int> handler;

            if (_handlers.TryGetValue(input, out handler))
            {
                handler(10, 5);
            }
        }

        public static void Main(string[] args)
        {
            Operation("add");
            Operation("subtract");
            Operation("multiply");
        }
    }
}