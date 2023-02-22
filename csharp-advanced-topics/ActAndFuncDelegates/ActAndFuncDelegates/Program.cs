namespace ActAndFuncDelegates;

// 1) Declare
delegate int MultDel(int inInt);

public class Program
{
    // 2) Method
    public static int SquareNumber(int inputInt)
    {
        return inputInt * inputInt;
    }

    public static void Main(string[] args)
    {
        // 3) Instantiate delegate
        MultDel powTwoDel = SquareNumber;

        // 4) Invoke
        Console.WriteLine(powTwoDel(2));

        // Declare and instantiate a Function delegate
        Func<int, int> powTwoFuncDel = SquareNumber;

        // Invoke
        Console.WriteLine(powTwoFuncDel(2));
    }
}

