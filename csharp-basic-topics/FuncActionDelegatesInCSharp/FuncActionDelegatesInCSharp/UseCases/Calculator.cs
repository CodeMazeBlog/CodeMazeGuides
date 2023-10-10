using FuncActionDelegatesInCSharp.Loggign;
using Microsoft.Extensions.Logging;

namespace FuncActionDelegatesInCSharp.UseCases;

public class Calculator
{
    private readonly ILogger<Calculator> Logger;

    public Calculator()
    {
        Logger = LoggingFactory<Calculator>.Create();
    }
    
    private int Add(int a, int b)
    {
        return a + b;
    }

    private int Subtract(int a, int b)
    {
        return a - b;
    }

    private int Multiply(int a, int b)
    {
        return a * b;
    }

    public void Run()
    {
        Logger.LogInformation("Enter two numbers:");
        var inputNumber1 = Console.ReadLine();
        var inputNumber2 = Console.ReadLine();
        var num1 = Convert.ToInt32(inputNumber1);
        var num2 = Convert.ToInt32(inputNumber2);

        Logger.LogInformation("Choose an operation (1: Add, 2: Subtract, 3: Multiply):");
        var selectedOperation = Convert.ToInt32(Console.ReadLine());

        Func<int, int, int> operation = selectedOperation switch
        {
            1 => Add,
            2 => Subtract,
            3 => Multiply,
            _ => throw new AggregateException("Invalid selected operation.")
        };
        
        var result = operation(num1, num2);
        Logger.LogInformation($"Result: {result}");
    }
}