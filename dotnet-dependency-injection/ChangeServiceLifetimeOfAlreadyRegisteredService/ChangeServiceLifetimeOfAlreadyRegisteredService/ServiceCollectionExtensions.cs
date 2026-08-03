using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ChangeServiceLifetimeOfAlreadyRegisteredService;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ReplaceWithSingleton<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
        => services.Replace(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));

    public static IServiceCollection ReplaceWithSingleton<TImplementation>(this IServiceCollection services)
       where TImplementation : class
       => services.Replace(new ServiceDescriptor(typeof(TImplementation), typeof(TImplementation), ServiceLifetime.Singleton));

    public static IServiceCollection ReplaceWithScoped<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
        => services.Replace(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Scoped));

    public static IServiceCollection ReplaceWithScoped<TImplementation>(this IServiceCollection services)
        where TImplementation : class
        => services.Replace(new ServiceDescriptor(typeof(TImplementation), typeof(TImplementation), ServiceLifetime.Scoped));

    public static IServiceCollection ReplaceWithTransient<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
        => services.Replace(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));

    public static IServiceCollection ReplaceWithTransient<TImplementation>(this IServiceCollection services)
        where TImplementation : class
        => services.Replace(new ServiceDescriptor(typeof(TImplementation), typeof(TImplementation), ServiceLifetime.Transient));
}