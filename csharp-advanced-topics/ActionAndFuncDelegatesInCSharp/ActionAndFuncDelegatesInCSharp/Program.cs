namespace ActionAndDelegatesInCSharp;

public static class Program
{
    public delegate int OperateDelegate(int firstNumber, int secondNumber);

    public static Func<int, int, int> Operate;

    public static Action<int> Display;

    public static void Main(string[] args)
    {
        var operateDelegate = new OperateDelegate(Add);

        var delegateExecutionResult = operateDelegate(1, 2);

        Console.WriteLine($"The result of operatedelegate operation is {delegateExecutionResult}.");

        Operate = Add;

        var result = Operate(1, 2);

        Display = DisplayOnConsole;

        Display(result);
    }
    public static int Add(int firstNumber, int secondNumber)
    {
        return firstNumber + secondNumber;
    }

    public static void DisplayOnConsole(int result)
    {
        Console.WriteLine($"The result of delegate operation is {result}.");
    }
}
