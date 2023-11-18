namespace FuncAndActionsInCsharp
{
    public static class Program
    {
        public static void Main()
        {
            // Using Action Delegates
            ActionDelegates.DisplayMessage();
            ActionDelegates.GreetAnonymous("Hello from anonymous method!");
            ActionDelegates.GreetLambda("Hello from lambda expression!");

            // Using Func Delegates
            Console.WriteLine($"Random number: {FuncDelegates.GetRandomNumber()}");
            Console.WriteLine($"Sum: {FuncDelegates.Add(10, 5)}");
            Console.WriteLine($"Product: {FuncDelegates.Multiply(3, 4)}");
        }
    }
}