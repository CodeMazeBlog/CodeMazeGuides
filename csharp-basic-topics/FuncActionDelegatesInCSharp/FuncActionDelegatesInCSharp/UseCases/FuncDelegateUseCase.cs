using FuncActionDelegatesInCSharp.Loggign;
using Microsoft.Extensions.Logging;

namespace FuncActionDelegatesInCSharp.UseCases;

public class FuncDelegateUseCase
{
    private readonly ILogger<FuncDelegateUseCase> Logger;

    private readonly Func<int, int, int> Add = (x, y) => x + y;

    private readonly Func<int, int, int> Multiply = (x, y) => x * y;

    public FuncDelegateUseCase()
    {
        Logger = LoggingFactory<FuncDelegateUseCase>.Create();
    }
    
    public void Run()
    {
        var x = 3;
        var y = 5;

        var addResult = Add(x, y);
        var multiplyResult = Multiply(x, y);
        
        Logger.LogInformation($"The adding result is: {addResult}");
        Logger.LogInformation($"The multiplying result is: {multiplyResult}");
    }
}