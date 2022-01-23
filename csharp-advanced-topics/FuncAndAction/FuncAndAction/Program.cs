
DelegateMethod d1 = new DelegateMethod(DisplayResult);
var result = d1(3, 5);
Console.WriteLine(result);

var func = new Func<int, int, int>(CalculateValue);   
Console.WriteLine(func(2, 5));

var action = new Action<int>(PrintValue);
// it prints the "123" value on the screen
action(123);

// Also we can use this calling format
action.Invoke(123);

public partial class Program
{
    public delegate int DelegateMethod(int a, int b);
    public static int DisplayResult(int a, int b)
    {
        return a + b;
    }

    public static int CalculateValue(int a, int b)
    {
        return a * b;
    }

    public static void PrintValue(int number)
    {
        Console.WriteLine(number);
    }

}
