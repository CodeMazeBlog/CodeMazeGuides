using EfCoreCodeFirstMigrationsInProd.Startup;

var startup = new StartupFactory().GetStartup(args);

await startup.StartAsync(args);