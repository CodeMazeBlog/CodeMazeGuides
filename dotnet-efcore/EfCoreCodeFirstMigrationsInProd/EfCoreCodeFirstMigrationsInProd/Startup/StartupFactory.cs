namespace EfCoreCodeFirstMigrationsInProd.Startup;

public class StartupFactory
{
    public IStartup GetStartup(IEnumerable<string> args)
    {
        return args.Contains("--migrate") ? new MigrationStartup() : new WebApiStartup();
    }
}