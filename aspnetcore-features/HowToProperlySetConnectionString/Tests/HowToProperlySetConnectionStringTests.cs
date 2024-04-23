using Microsoft.Extensions.Configuration;

namespace Tests
{
    [TestClass]
    public class HowToProperlySetConnectionStringTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            var Connection = configuration.GetConnectionString("DefaultConnection");

            Assert.IsNotNull(configuration);
            Assert.Equals(Connection, configuration.GetConnectionString("DefaultConnection"));
        }

    }
}