using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace HowToProperlySetConnectionStringTests;

[TestClass]
public class Tests
{
    private IConfiguration _configuration { get; set; }

    public Tests()
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        _configuration = builder.Build();
    }

    [TestMethod]
    public void GivenConnectionString_WhenRequestingConnectionString_ReturnsConnectionString()
    {        
        var ConnectionStringFromAppSettings = _configuration["ConnectionString:DefaultConnection"];
        var ConnectionStringValue = "Server=10.1.1.120;Database=Database;User=Admin;Password=MyStrongPassword;";

        Assert.AreEqual(ConnectionStringFromAppSettings, ConnectionStringValue);
    }
}