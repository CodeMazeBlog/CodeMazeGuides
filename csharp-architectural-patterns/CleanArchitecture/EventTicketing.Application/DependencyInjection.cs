using Microsoft.Extensions.DependencyInjection;

namespace EventTicketing.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ReserveTicketsHandler>();
        services.AddScoped<GetEventAvailabilityHandler>();

        return services;
    }
}
