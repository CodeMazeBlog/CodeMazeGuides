using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoApp.Application.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        return services;
    }
}