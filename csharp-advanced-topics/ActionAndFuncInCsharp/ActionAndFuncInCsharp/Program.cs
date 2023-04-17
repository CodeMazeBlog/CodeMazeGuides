namespace ActionAndFuncInCsharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintSumUsingActionWithParameter();
            PrintGreetingUsingActionWithoutParameter();
            PrintSumUsingFuncWithParameter();
            PrintGreetingUsingFuncWithoutParameter();
        }

        static void PrintSumUsingActionWithParameter()
        {
            Action<int, int> printSum = (x, y) => Console.WriteLine($"Sum of {x} and {y} is {x + y}");
            printSum(10, 20); // Output: Sum of 10 and 20 is 30
        }

        static void PrintGreetingUsingActionWithoutParameter()
        {
            Action greet = () => Console.WriteLine("Hello, World!");
            greet(); // Output: Hello, World!
        }
        static void PrintSumUsingFuncWithParameter()
        {
            Func<int, int, int> add = (x, y) => x + y;
            int sum = add(10, 20);
            Console.WriteLine($"Sum of 10 and 20 is {sum}"); // Output: Sum of 10 and 20 is 30
        }

        static void PrintGreetingUsingFuncWithoutParameter()
        {
            Func<string> getMessage = () => "Hello, World!";
            string message = getMessage();
            Console.WriteLine(message); // Output: Hello, World!
        }
    }
}