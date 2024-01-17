namespace ActionFuncDelegateInCsharp
{
    public class ActionDelegate
    {
        public static void MethodToBeCalled()
        {
            Console.WriteLine("MethodToBeCalled() was called.");
        }

        public static void AddNumbers(int a, int b)
        {
            var sum = a + b;

            Console.WriteLine($"Sum of {a} and {b} is: {sum}");
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine($"Message: {message}");
        }
    }
}
