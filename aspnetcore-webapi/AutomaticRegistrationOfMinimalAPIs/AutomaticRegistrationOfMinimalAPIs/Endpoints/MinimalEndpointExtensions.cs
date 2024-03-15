using AutomaticRegistrationOfMinimalAPIs.Endpoints.Abstractions;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AutomaticRegistrationOfMinimalAPIs.Endpoints;

public static class MinimalEndpointExtensions
{
    public static IServiceCollection AddMinimalEndpoints(this IServiceCollection services)
    {
        var serviceDescriptors = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(type => !type.IsAbstract &&
                           !type.IsInterface &&
                           type.IsAssignableTo(typeof(IMinimalEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IMinimalEndpoint), type));

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    public static IApplicationBuilder RegisterMinimalEndpoints(this WebApplication app)
    {
        var endpoints = app.Services
            .GetRequiredService<IEnumerable<IMinimalEndpoint>>();

        foreach (var endpoint in endpoints)
        {
            endpoint.MapRoutes(app);
        }

        return app;
    }
}
