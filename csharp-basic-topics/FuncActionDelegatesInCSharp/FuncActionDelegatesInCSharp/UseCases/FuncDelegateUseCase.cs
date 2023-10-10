using Microsoft.Extensions.Logging;

namespace FuncActionDelegatesInCSharp.UseCases;

public class FuncDelegateUseCase
{
    private readonly ILogger<FuncDelegateUseCase> _logger;

    private readonly Func<int, int, int> Add = (x, y) => x + y;

    private readonly Func<int, int, int> Multiply = (x, y) => x * y;

    public FuncDelegateUseCase(ILogger<FuncDelegateUseCase> logger)
    {
        _logger = logger;
    }
    
    public void Run(int a, int b)
    {
        var addResult = Add(a, b);
        var multiplyResult = Multiply(a, b);
        
        _logger.LogInformation($"The adding result is: {addResult}");
        _logger.LogInformation($"The multiplying result is: {multiplyResult}");
    }
}