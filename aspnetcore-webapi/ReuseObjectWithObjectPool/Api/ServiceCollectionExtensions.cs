using Microsoft.Extensions.ObjectPool;
namespace Api;

public static class ServiceCollectionExtensions
{
    public static void AddObjectPool<T>(this IServiceCollection services, Func<IPooledObjectPolicy<T>> policyFactory) where T : class
    {
        services.AddSingleton<ObjectPool<T>>(_ => new DefaultObjectPool<T>(policyFactory(), Environment.ProcessorCount * 2));
    }
}