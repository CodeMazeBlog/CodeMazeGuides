namespace ActionFuncDelegateInCsharp
{
    public class ActionDelegate
    {
        // A method that matches the signature of the Action delegate
        public static void MethodToBeCalled()
        {
            Console.WriteLine("MethodToBeCalled() was called.");
        }

        // Another method that matches the signature of the Action delegate
        public static void AddNumbers(int a, int b)
        {
            int sum = a + b;
            Console.WriteLine($"Sum of {a} and {b} is: {sum}");
        }

        // Method with a string parameter
        public static void DisplayMessage(string message)
        {
            Console.WriteLine($"Message: {message}");
        }
    }
}
