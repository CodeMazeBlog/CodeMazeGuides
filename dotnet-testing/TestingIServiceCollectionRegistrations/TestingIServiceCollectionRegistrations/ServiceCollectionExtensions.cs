namespace TestingIServiceCollectionRegistrations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IAnimalService, PetService>();

        return services;
    }
}