using HowToReadAppSettings;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfigurationRoot configuration = builder.Build();

#region Bind configuration to strongly-typed object
var appSettings = new AppSettings();
configuration.GetSection("AppSettings").Bind(appSettings);
Console.WriteLine(appSettings.Settings2);
#endregion Bind configuration to strongly-typed object

#region Nested example
var example1 = configuration["Settings1"];
Console.WriteLine(example1);

var example1UsingSection = configuration.GetSection("Settings1");
Console.WriteLine(example1UsingSection.Value);

var settings = configuration["AppSettings:Settings2"];
Console.WriteLine(settings);

var settings2 = configuration.GetSection("AppSettings");
Console.WriteLine(settings2.GetSection("Settings2").Value);
#endregion Nested example

#region Connection String
var connectionString = configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(connectionString);
#endregion Connection String
