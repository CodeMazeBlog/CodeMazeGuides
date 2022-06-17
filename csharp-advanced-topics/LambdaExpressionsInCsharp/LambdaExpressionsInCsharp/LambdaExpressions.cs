namespace LambdaExpressionsInCsharp;
public class LambdaExpressions
{
    public static void ExpressionLambdaWithNoReturnTypeAndNoParameters()
    {
        Action sayHello = () => Console.WriteLine("Hello!");
        sayHello();
    }

    public static void ExpressionLambdaWithNoReturnTypeAndWithParameters()
    {
        Action<string> sayName = (name) => Console.WriteLine($"Hello {name}");
        sayName("CodeMaze");
    }

    public static void ExpressionLambdaWithReturnTypeAndWithNoParameters()
    {
        Func<int> sum = () => 1 + 1;
        Console.WriteLine("Sum of two numbers is {0}", sum());
    }

    public static void ExpressionLambdaWithReturnTypeAndWithParameters()
    {
        Func<int, int> square = (number) => number * 2;
        Console.WriteLine("Square of 2 is: {0}", square(2));
    }

    public static void StatementLambdaWithNoReturnTypeAndNoParameters()
    {
        Action sayHello = () =>
        {
            Console.WriteLine("Hello!");
        };
        sayHello();
    }

    public static void StatementLambdaWithNoReturnTypeAndWithParameters()
    {
        Action<string> sayName = (name) =>
        {
            Console.WriteLine($"Hello {name}");
        };
        sayName("CodeMaze");
    }

    public static void StatementLambdaWithReturnTypeAndWithNoParameters()
    {
        Func<int> sum = () =>
        {
            return 1 + 1;
        };
        Console.WriteLine("Sum of two numbers is {0}", sum());
    }

    public static void StatementLambdaWithReturnTypeAndWithParameters()
    {
        Func<int, int> square = (number) =>
        {
            return number * 2;
        };
        Console.WriteLine("Square of 2 is: {0}", square(2));
    }

    public static void LambdaWithExplicitReturnType()
    {
        Func<int, object?> returnNullOrNumber = object? (number) =>
        {
            return number > 0 ? number : null;
        };
        Console.WriteLine("Number is: {0}", returnNullOrNumber(2));
    }

    public static void LambdaNaturalType()
    {
        var sayHello = () => Console.WriteLine("Hello!");
        sayHello();
    }
}