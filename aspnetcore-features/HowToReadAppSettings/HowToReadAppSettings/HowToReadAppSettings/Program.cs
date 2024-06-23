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
var Example1 = configuration["Settings1"];
Console.WriteLine(Example1);

var Example1UsingSection = configuration.GetSection("Settings1");
Console.WriteLine(Example1UsingSection.Value);

var Settings = configuration["AppSettings:Settings2"];
Console.WriteLine(Settings);

var Settings2 = configuration.GetSection("AppSettings");
Console.WriteLine(Settings2.GetSection("Settings2").Value);
#endregion Nested example

#region Connection String
var ConnectionString = configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(ConnectionString);
#endregion Connection String
