using FuncActionDelegatesInCSharp.UseCases;
using FuncActionDelegatesInCSharp.UseCases.CalculatorUseCase;
using Microsoft.Extensions.Logging;

namespace FuncActionDelegatesInCSharp;

public class Program
{
    public static void Main(string[] args)
    {
        // Initializing
        var loggerFactory = new LoggerFactory();
        var actionDelegateUseCase = new ActionDelegateUseCase(loggerFactory.CreateLogger<ActionDelegateUseCase>());
        var funcDelegateUseCase = new FuncDelegateUseCase(loggerFactory.CreateLogger<FuncDelegateUseCase>());
        var addingMultiplyActionDelegateUseCase = 
            new AddingMultiplyActionDelegateUseCase(loggerFactory.CreateLogger<AddingMultiplyActionDelegateUseCase>());
        var calculator = new Calculator(new IoHandler(), loggerFactory.CreateLogger<Calculator>());
        
        // Running all use-cases
        actionDelegateUseCase.Run();
        funcDelegateUseCase.Run(5, 10);
        addingMultiplyActionDelegateUseCase.Run();
        calculator.Run();
        
        Console.ReadLine();
    }
}
