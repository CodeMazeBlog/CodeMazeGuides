namespace HowToGetAnInstanceOfIServiceProvider.Services;

public class ExampleBackgroundService(IServiceProvider ServiceProvider) : BackgroundService
{
    private readonly IServiceProvider _serviceProvider = ServiceProvider;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IExampleService>();

        return Task.CompletedTask;
    }
}