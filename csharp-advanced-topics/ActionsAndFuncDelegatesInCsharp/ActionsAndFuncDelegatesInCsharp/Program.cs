namespace ActionsAndFuncDelegatesInCsharp;

public class Program
{
    static void Main(string[] args)
    {
        var calculator = new Calculator();
        int result;

        calculator.Function = Sum;
        result = calculator.GetResult(2, 3);
        Console.WriteLine($"Result: {result} (Sum)");

        calculator.Function = Multiply;
        result = calculator.GetResult(2, 3);
        Console.WriteLine($"Result: {result} (Multiply)");

        calculator.Function = Sum;
        calculator.Action = DisplayBasic;
        calculator.DisplayResult(2, 3);

        calculator.Function = Multiply;
        calculator.Action = DisplayVerbose;
        calculator.DisplayResult(2, 3);
    }

    public static int Sum(int firstNumber, int secondNumber) { return firstNumber + secondNumber; }

    public static int Multiply(int firstNumber, int secondNumber) { return firstNumber * secondNumber; }

    public static void DisplayBasic(int result, string functionName)
    {
        Console.WriteLine($"Result: {result} ({functionName})");
    }

    public static void DisplayVerbose(int result, string functionName)
    {
        Console.WriteLine($"The result of this calculation ({functionName}) is " + result);
    }
}


