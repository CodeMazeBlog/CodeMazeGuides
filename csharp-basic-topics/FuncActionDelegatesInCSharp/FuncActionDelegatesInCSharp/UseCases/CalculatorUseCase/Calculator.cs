using Microsoft.Extensions.Logging;

namespace FuncActionDelegatesInCSharp.UseCases.CalculatorUseCase;

public class Calculator
{
    private readonly ILogger<Calculator> _logger;
    private readonly IIoHandler _ioHandler;
    
    public Calculator(IIoHandler ioHandler, ILogger<Calculator> logger)
    {
        _ioHandler = ioHandler;
        _logger = logger;
    }
    
    private static int Add(int a, int b) => a + b;
    private static int Subtract(int a, int b) => a - b;
    private static int Multiply(int a, int b) => a * b;

    public void Run()
    {
        _logger.LogInformation("Enter two numbers:");
        var num1 = _ioHandler.GetUserInput();
        var num2 = _ioHandler.GetUserInput();

        _logger.LogInformation("Choose an operation (1: Add, 2: Subtract, 3: Multiply):");
        var selectedOperation = Convert.ToInt32(_ioHandler.GetUserInput());

        Func<int, int, int> operation = selectedOperation switch
        {
            1 => Add,
            2 => Subtract,
            3 => Multiply,
            _ => throw new AggregateException("Invalid selected operation.")
        };
        
        var result = operation(num1, num2);
        _logger.LogInformation($"Result: {result}");
    }
}