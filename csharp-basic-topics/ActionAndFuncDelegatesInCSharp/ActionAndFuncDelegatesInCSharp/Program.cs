namespace ActionAndFuncDelegatesInCSharp;

public static class Program
{
    public static void Main()
    {
        PrintNumberWithAction();

        var two = AddOneWithFunc();
        Console.WriteLine(two);

        var three = AddNumbersWithFunc();
        Console.WriteLine(three);

        var customTwo = AddOneWithCustomFunc();
        Console.WriteLine(customTwo);
    }

    public static void PrintNumberWithAction()
    {
        Action<int> printNumberAction;
        printNumberAction = number => Console.WriteLine(number);
        printNumberAction(10);
    }

    public static int AddOneWithFunc()
    {
        Func<int, int> addOneFunc;
        addOneFunc = number => number + 1;
        var two = addOneFunc(1);

        return two;
    }

    public static int AddNumbersWithFunc()
    {
        Func<int, int, int> addNumbersFunc;
        addNumbersFunc = (number1, number2) => number1 + number2;
        var three = addNumbersFunc(1, 2);

        return three;
    }

    delegate TReturn MyFunc<TParam1, TReturn>(TParam1 param1);

    public static int AddOneWithCustomFunc()
    {
        MyFunc<int, int> addOneFunc;
        addOneFunc = number => number + 1;
        var two = addOneFunc(1);

        return two;
    }
}
