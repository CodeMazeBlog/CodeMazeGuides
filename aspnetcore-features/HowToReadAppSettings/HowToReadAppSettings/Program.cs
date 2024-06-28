using HowToReadAppSettings;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfigurationRoot configuration = builder.Build();

// Bind configuration to strongly-typed object
var appSettings = new AppSettings();
configuration.GetSection("AppSettings").Bind(appSettings);
Console.WriteLine(appSettings.Settings2);

var example1 = configuration["Settings1"];
Console.WriteLine(example1);

var example1UsingSection = configuration.GetSection("Settings1");
Console.WriteLine(example1UsingSection.Value);

// Nested example
var settings = configuration["AppSettings:Settings2"];
Console.WriteLine(settings);

var settings2 = configuration.GetSection("AppSettings");
Console.WriteLine(settings2["Settings2"]);

// Connection String
var connectionString = configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(connectionString);
