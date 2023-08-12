namespace ActionFuncDelegates;
public class ActionFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Action delegate example
            Action<string> printMessage = message => Console.WriteLine(message);
            printMessage("Hello, Action!");

            // Func delegate example
            Func<int, int, int> add = (a, b) => a + b;
            int result = add(5, 7);
            Console.WriteLine($"Addition result: {result}");
        }

        public static void ExecuteActionDelegate()
        {
            Action<string> printMessage = message => Console.WriteLine(message);
            printMessage("Hello, Action!");
        }

        public static int ExecuteFuncDelegate()
        {
            Func<int, int, int> add = (a, b) => a + b;
            return add(5, 7);
        }
    }
}
