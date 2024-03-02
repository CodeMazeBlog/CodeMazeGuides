using EfCoreCodeFirstMigrationsInProd.Startup;

namespace EfCoreCodeFirstMigrationsInProdTests;

public class StartupFactoryTests
{
    [Test]
    public void GivenStartupFactory_WhenMigrationArgIsPresent_ThenReturnMigrationStartup()
    {
        var args = new[] {"--migrate"};
        var factory = new StartupFactory();
        
        var startup = factory.GetStartup(args);
        
        Assert.That(startup, Is.InstanceOf<MigrationStartup>());
    }
    
    [Test]
    public void GivenStartupFactory_WhenNoArgIsPresent_ThenReturnWebApiStartup()
    {
        var args = Array.Empty<string>();
        var factory = new StartupFactory();
        
        var startup = factory.GetStartup(args);
        
        Assert.That(startup, Is.InstanceOf<WebApiStartup>());
    }
    
    [Test]
    public void GivenStartupFactory_WhenNoMigrationArgIsPresent_ThenReturnWebApiStartup()
    {
        var args = new[] {"arg1", "--arg2", "migrate", "--migration"};
        var factory = new StartupFactory();
        
        var startup = factory.GetStartup(args);
        
        Assert.That(startup, Is.InstanceOf<WebApiStartup>());
    }
    
    [Test]
    public void GivenStartupFactory_WhenMultipleArgsArePresentWithMigrationArg_ThenReturnMigrationStartup()
    {
        var args = new[] {"arg1", "--arg2", "--migrate"};
        var factory = new StartupFactory();
        
        var startup = factory.GetStartup(args);
        
        Assert.That(startup, Is.InstanceOf<MigrationStartup>());
    }
}