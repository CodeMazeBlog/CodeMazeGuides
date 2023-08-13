
using DynamicDbContextSwitching;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json");
var configuration = configurationBuilder.Build();
services.AddSingleton<IConfiguration>(configuration);

services.AddDbContext<PrimaryDbContext>(o => o.UseSqlite(configuration.GetConnectionString("Primary")));
services.AddDbContext<SecondaryDbContext>(o => o.UseSqlite(configuration.GetConnectionString("Secondary")));
services.AddSingleton<IDataSourceProvider, DataSourceProvider>();

services.AddTransient<IRepository, PrimaryRepository>();
services.AddTransient<IRepository, SecondaryRepository>();
services.AddTransient<IRepositoryFactory, RepositoryFactory>();

var serviceProvider = services.BuildServiceProvider();

var repositoryFactory = serviceProvider.GetRequiredService<IRepositoryFactory>();
var primaryRepository = repositoryFactory.GetRepository<PrimaryRepository>();
var secondaryRepository = repositoryFactory.GetRepository<SecondaryRepository>();

var primaryResult = await primaryRepository.TestConnection();
var secondaryResult = await secondaryRepository.TestConnection();
Console.WriteLine($"Primary connection result: {primaryResult}");
Console.WriteLine($"Secondary connection result: {secondaryResult}");

