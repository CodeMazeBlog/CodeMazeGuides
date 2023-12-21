namespace ActionAndFuncDelegates
{
    public class Program
    {
        private static void Main()
        {
            // Greeting with an Action delegate
            Action<string> greet = (name) => Console.WriteLine($"Hello, {name}!");
            greet("Fred");

            // Executing an action with multiple parameters
            Action<int, int> add = (a, b) => Console.WriteLine($"Sum: {a + b}");
            add(2, 9);

            // Multiplying with Func delegate
            Func<int, int, int> multiply = (a, b) => a * b;
            int product = multiply(2, 9);
            Console.WriteLine($"Multiplied Result: {product}");

            // Determining string length with Func delegate
            Func<string, int> stringLength = (str) => str.Length;
            int length = stringLength("Love Func!");
            Console.WriteLine($"Length of the string: {length}");

            // Using Action to process elements in a collection
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            Action<int> processNumber = (number) => Console.WriteLine($"Processing: {number}");
            numbers.ForEach(processNumber);

            // Applying Func to handle exceptions gracefully
            Func<int, int, int> safeDivision = (a, b) => b != 0 ? a / b : 0;
            int divisionResult = safeDivision(20, 5);
            Console.WriteLine($"Safe Division Result: {divisionResult}");

            ExecuteActionCallback(AddAction, 5, 6);

            int result = ExecuteFuncCallback(AddFunc, 5, 6);
            Console.WriteLine("Result from ExecuteFuncCallback: {result}");
        }

        // Using Action as a callback
        public static void ExecuteActionCallback(Action<int, int> callback, int a, int b)
        {
            Console.WriteLine("Executing callback...");
            callback(a, b);
        }

        // Using Func as a callback with a return value
        public static int ExecuteFuncCallback(Func<int, int, int> callback, int a, int b)
        {
            Console.WriteLine("Executing callback with result...");
            return callback(a, b);
        }

        // Add method to act as a callback
        public static int AddFunc(int a, int b)
        {
            int result = a + b;
            Console.WriteLine($"Result of operation: {result}");
            return result;
        }

        // Add method to act as a callback
        public static void AddAction(int a, int b)
        {
            int result = a + b;
            Console.WriteLine($"Result of operation: {result}");
        }
    }
}