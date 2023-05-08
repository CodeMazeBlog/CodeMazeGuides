namespace ActionAndFuncDelegatesInCSharp;

public class ActionDelegates
{
    public static void ActionDelegatesUsage()
    {
        Action<int, int> addNumbersFirst = new Action<int, int>(AddNumbers);
        addNumbersFirst(5, 2);
        Action<int, int> addNumbersSecond = AddNumbers;
        addNumbersSecond(2, 5);
    }
    public static void AddNumbers(int firstNumber, int secondNumber)
    {
        int sum = firstNumber + secondNumber;
        Console.WriteLine($"The sum is: {sum}");
    }
}