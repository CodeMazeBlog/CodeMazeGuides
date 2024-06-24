namespace LocalFunctionsVsLambdaExpressionsInCSharp;

public class Recursivity
{
    public static int FactorialAsLocalFunction(int input)
    {
        int Factorial(int n)
        {
            if (n <= 1) return 1;

            return n * Factorial(n - 1);
        }

        int result = Factorial(input);

        return result;
    }

    public static int FactorialAsLambdaExpression(int input)
    {
        Func<int, int> factorial = null!;

        factorial = (int n) =>
        {
            if (n <= 1) return 1;

            return n * factorial(n - 1);
        };

        int result = factorial(input);
        
        return result;
    }
}
