using Microsoft.Extensions.DependencyInjection;

namespace DynamicTenantModule;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<DynamicTenantSetup>();
    }
}