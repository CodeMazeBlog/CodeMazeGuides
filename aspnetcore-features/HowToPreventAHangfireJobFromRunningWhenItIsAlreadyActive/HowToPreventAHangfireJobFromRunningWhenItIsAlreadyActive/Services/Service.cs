using Microsoft.AspNetCore.Server.Kestrel.Transport.Quic;

namespace HowToPreventAHangfireJobFromRunningWhenItIsAlreadyActive.Services;

public class Service : IService
{
    private readonly ILogger<Service> _logger;

    public Service(ILogger<Service> logger)
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