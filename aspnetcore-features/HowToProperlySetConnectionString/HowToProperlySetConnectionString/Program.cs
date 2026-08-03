using HowToProperlySetConnectionString.Data;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration configuration = builder.Build();

using (var context = new AppDbContext(configuration))
{
    var list = context.Countries.ToList();

    foreach (var country in list)
    {
        Console.WriteLine(country.CountryCode);
    }
}
