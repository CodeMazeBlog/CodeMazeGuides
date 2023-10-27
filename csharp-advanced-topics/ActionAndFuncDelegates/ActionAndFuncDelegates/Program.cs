using ActionAndFuncDelegates;

public class Program
{
    public static void Main(string[] args)
    {
        // Action example
        var printRepository = new PrintRepository();

        Action<string> printAction = printRepository.DisplayInput;

        printAction("Hello, world!");

        printAction.Invoke("Hello, world!");

        // Action anonymous
        Action<string> printActionByDelegate = delegate (string input)
        {
            Console.WriteLine(input);
        };

        printActionByDelegate("Hello, world!");

        printActionByDelegate.Invoke("Hello, world!");

        // Action lambda
        Action<string> printActionByLambda = message => Console.WriteLine(message);

        printActionByLambda("Hello, world!");

        printActionByLambda.Invoke("Hello, world!");

        // Func example
        var funcRepository = new FuncRepository();

        Func<int, bool> isEvenFunc = funcRepository.IsNumberEven;

        var isEven = isEvenFunc(10);

        Console.WriteLine(isEven);

        var isEvenByInvoke = isEvenFunc.Invoke(10);

        Console.WriteLine(isEvenByInvoke);

        // Func delegate
        Func<int, bool> isEvenFuncByAnonymous = delegate (int x)
        {
            return x % 2 == 0;
        };

        var isEvenAnonymous = isEvenFuncByAnonymous(10);

        Console.WriteLine(isEvenAnonymous);

        var isEvenAnonymousByInvoke = isEvenFuncByAnonymous.Invoke(10);

        Console.WriteLine(isEvenAnonymousByInvoke);

        // Func lambda
        Func<int, bool> isEvenFuncByLambda = x => x % 2 == 0;

        var isEvenLambda = isEvenFuncByLambda(10);

        Console.WriteLine(isEvenLambda);

        var isEvenLambdaByInvoke = isEvenFuncByLambda.Invoke(10);

        Console.WriteLine(isEvenLambdaByInvoke);
    }
}