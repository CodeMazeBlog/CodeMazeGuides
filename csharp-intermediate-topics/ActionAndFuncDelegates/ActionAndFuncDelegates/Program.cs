namespace ActionAndFuncDelegates;
public class Program
{
    public static void Main(string[] args)
    {
        var calc = new Calculator();

        Action printDelegate = calc.Print;
        Console.Write("Method:");
        calc.Print();
        Console.Write("Delegate:");
        printDelegate();
        Action<int> actionDelegate = calc.PrintResult;
        // Action<Type1, Type2, Type3, ..., Type16> actionDelegate = someMethod;

        Func<int> resultDelegate = calc.Result;
        var answer = resultDelegate();
        Console.WriteLine(answer);

        Func<int, int> exponentDelegate = calc.Exponent;
        var square = exponentDelegate(7);
        Console.WriteLine(square);


        // Func<Type1, Type2, Type3, ..., TResult> funcDelegate = someMethod2;

    }

}
