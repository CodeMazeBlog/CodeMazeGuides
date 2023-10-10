using FuncActionDelegatesInCSharp.Loggign;
using Microsoft.Extensions.Logging;

namespace FuncActionDelegatesInCSharp.UseCases;

public class AddingMultipleActionDelegateUseCase
{
    private readonly ILogger<AddingMultipleActionDelegateUseCase> Logger;

    public AddingMultipleActionDelegateUseCase()
    {
        Logger = LoggingFactory<AddingMultipleActionDelegateUseCase>.Create();
    }

    public void Run()
    {
        Action aggregateMessages = () =>
        {
            Logger.LogInformation("Action1: This is the first task.");
        };

        aggregateMessages += () =>
        {
            Logger.LogInformation("Action2: This is the second task.");
        };
        
        aggregateMessages += () =>
        {
            Logger.LogInformation("Action3: This is the third task.");
        };

        aggregateMessages();
    }
}