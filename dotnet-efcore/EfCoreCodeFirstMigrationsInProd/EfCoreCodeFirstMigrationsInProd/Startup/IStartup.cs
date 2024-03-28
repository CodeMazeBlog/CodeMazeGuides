namespace EfCoreCodeFirstMigrationsInProd.Startup;

public interface IStartup
{
    Task StartAsync(string[] args);
}