using log4net;

namespace LoggingInCSharp;

public static class Calculator
{
    private static readonly ILog log = LogManager.GetLogger(typeof(Calculator));

    public static int Add(int a, int b)
    {
        log.Debug($"Adding {a} and {b}");

        int result = a + b;

        log.Info($"Result of {a} + {b} = {result}");

        return result;
    }

    public static int Subtract(int a, int b)
    {
        log.Debug($"Subtracting {b} from {a}");

        if (b > a)
        {
            log.Warn($"Subtraction may result in a negative number: {a} - {b}");
        }

        int result = a - b;

        log.Info($"Result of {a} - {b} = {result}");

        return result;
    }

    public static int Multiply(int a, int b)
    {
        log.Debug($"Multiplying {a} and {b}");

        int result = a * b;

        if (result == 0)
        {
            log.Warn($"Multiplication resulted in zero: {a} * {b}");
        }
        else if (result < 0)
        {
            log.Warn($"Multiplication resulted in a negative number: {a} * {b} = {result}");
        }

        log.Info($"Result of {a} * {b} = {result}");

        return result;
    }

    public static int Divide(int a, int b)
    {
        log.Debug($"Dividing {a} by {b}");

        if (b == 0)
        {
            log.Error("Division by zero attempted");
            throw new DivideByZeroException("Cannot divide by zero");
        }

        int result = a / b;

        log.Info($"Result of {a} / {b} = {result}");

        return result;
    }
}




