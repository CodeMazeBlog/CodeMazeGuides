using Microsoft.Extensions.Logging;

namespace FuncActionDelegatesInCSharp.UseCases;

public class ActionDelegateUseCase
{
    private readonly ILogger<ActionDelegateUseCase> _logger;
    public ActionDelegateUseCase(ILogger<ActionDelegateUseCase> logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        Action<string> showMessage = (msg) => _logger.LogInformation(msg);
        showMessage("Welcome to amazing Code-Maze");
    }
}