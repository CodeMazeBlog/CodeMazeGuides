using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace ServerSentEventsForRealtimeUpdates.Test;

public class MockWebApplicationFactory(Action<IServiceCollection>? overrideDependencies = null)
    : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services => overrideDependencies?.Invoke(services));
    }
}
