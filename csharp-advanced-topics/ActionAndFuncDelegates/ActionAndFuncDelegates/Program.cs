using ActionAndFuncDelegates;

public class Program
{
    public static void Main(string[] args)
    {
        // Action examples

        var printRepository = new PrintRepository();

        Action<string> printAction = printRepository.DisplayInput;

        printAction(Console.ReadLine());

        printAction.Invoke(Console.ReadLine());

        Action<int, int> printSumAction = printRepository.DisplaySum;

        var firstNumber = Convert.ToInt32(Console.ReadLine());

        var secondNumber = Convert.ToInt32(Console.ReadLine());

        printSumAction.Invoke(firstNumber, secondNumber);

        // Func examples

        var mathOperations = new MathOperationsRepository();

        Func<int, bool> isEvenFunc = mathOperations.IsNumberEven;

        var number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(isEvenFunc(number));

        // Func lambda

        Func<int, int> squareFunc = x => x * x;

        int squareResult = squareFunc(number);

        Console.WriteLine(squareResult);

        // Action lambda

        Action<string> printMessageAction = message => Console.WriteLine(message);

        printMessageAction(Console.ReadLine());
    }
}