namespace TestingIServiceCollectionRegistrations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IPetService, PetService>();
        services.AddTransient<IWildAnimalService, WildAnimalService>();
        services.AddScoped<IMarineAnimalsService, MarineAnimalsService>();

        return services;
    }
}