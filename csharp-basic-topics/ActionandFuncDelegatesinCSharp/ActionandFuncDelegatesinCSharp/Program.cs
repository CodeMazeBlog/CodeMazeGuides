namespace ActionandFuncDelegatesinCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ActionandFuncDelegatesinCSharpCode actionandFuncDelegatesinCSharp = new ActionandFuncDelegatesinCSharpCode();

            // Invoking the Action delegate
            actionandFuncDelegatesinCSharp.add(10, 20);

            // Invoking the Action delegate with no parameters
            actionandFuncDelegatesinCSharp.printMyName();

            // Invoking the Func delegate
            Console.WriteLine($"Square: {actionandFuncDelegatesinCSharp.square(5)}");

            // Invoking the Func delegate
            Console.WriteLine($"Product: {actionandFuncDelegatesinCSharp.multiply(5, 10)}");

            // Invoking the Action delegate
            actionandFuncDelegatesinCSharp.printArray(new int[] { 1, 2, 3, 4, 5 });

            // Invoking the Func delegate
            Console.WriteLine($"Maximum number: {actionandFuncDelegatesinCSharp.maxNumber(new int[] { 1, 2, 3, 4, 5 })}");

            // Log: This is a log message
            actionandFuncDelegatesinCSharp.logMessage("This is a log message");

            // Func delegate to check if a number is even
            Console.WriteLine($"Is 10 even? {actionandFuncDelegatesinCSharp.isEven(10)}");

            // Invoking the Action delegate
            actionandFuncDelegatesinCSharp.arithmeticOperation(10, 5);

            // Invoking the Func delegate
            Console.WriteLine($"Concatenated string: {actionandFuncDelegatesinCSharp.concatenate("Hello", "World")}");

        }
    }
}
