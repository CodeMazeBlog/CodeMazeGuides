using Microsoft.Extensions.Logging;

namespace FuncActionDelegatesInCSharp.UseCases;

public class AddingMultiplyActionDelegateUseCase
{
    private readonly ILogger<AddingMultiplyActionDelegateUseCase> _logger;

    public AddingMultiplyActionDelegateUseCase(ILogger<AddingMultiplyActionDelegateUseCase> logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        Action aggregateMessages = () =>
        {
            _logger.LogInformation("Action1: This is the first task.");
        };

        aggregateMessages += () =>
        {
            _logger.LogInformation("Action2: This is the second task.");
        };
        
        aggregateMessages += () =>
        {
            _logger.LogInformation("Action3: This is the third task.");
        };

        aggregateMessages();
    }
}