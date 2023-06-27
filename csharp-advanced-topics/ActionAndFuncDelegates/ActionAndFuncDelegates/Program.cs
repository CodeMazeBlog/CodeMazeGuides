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

        Action<int, int> printSumAction = printRepository.DispalySum;

        var firstNumber = Convert.ToInt32(Console.ReadLine());

        var secondNumber = Convert.ToInt32(Console.ReadLine());

        printSumAction.Invoke(firstNumber, secondNumber);
    }
}