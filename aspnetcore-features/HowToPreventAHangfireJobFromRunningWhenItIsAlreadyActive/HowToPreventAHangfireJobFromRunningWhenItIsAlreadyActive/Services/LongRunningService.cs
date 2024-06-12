using Microsoft.AspNetCore.Server.Kestrel.Transport.Quic;

namespace HowToPreventAHangfireJobFromRunningWhenItIsAlreadyActive.Services;

public class LongRunningService : IILongRunningService
{
    private readonly ILogger<LongRunningService> _logger;

    public LongRunningService(ILogger<LongRunningService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    public Task ProcessAsync()
    {
        _logger.LogInformation("Processing started");
        
        Thread.Sleep(10000);
        
        _logger.LogInformation("Processing completed");
        
        return Task.CompletedTask;
    }
}