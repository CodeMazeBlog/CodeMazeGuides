namespace ActionandFuncDelegatesinCSharp
{
    public class ActionandFuncDelegatesinCSharpCode
    {
        // Simple Action delegate
        public Action<int, int> add = (a, b) => Console.WriteLine($"Sum: {a + b}");

        // Action delegate with no parameters
        public Action printMyName = () => Console.WriteLine("Sardar Mudassar Ali Khan!");

        // Func delegate to calculate square
        public Func<int, int> square = x => x * x;

        // Func delegate with multiple parameters
        public Func<int, int, int> multiply = (x, y) => x * y;

        // Action delegate to print elements of an array
        public Action<int[]> printArray = (arr) =>
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        };

        // Func delegate to find the maximum value in an array
        public Func<int[], int> maxNumber = arr => arr.Max();

        // Action delegate to log messages
        public Action<string> logMessage = msg => Console.WriteLine($"Log: {msg}");

        // Func delegate to check if a number is even
        public Func<int, bool> isEven = num => num % 2 == 0;

        // Action delegate to perform arithmetic operations
        public Action<int, int> arithmeticOperation = (x, y) =>
        {
            Console.WriteLine($"Addition: {x + y}");
            Console.WriteLine($"Subtraction: {x - y}");
            Console.WriteLine($"Multiplication: {x * y}");
            Console.WriteLine($"Division: {x / y}");
        };

        // Func delegate to concatenate strings
        public Func<string, string, string> concatenate = (s1, s2) => s1 + s2;

    }
}

