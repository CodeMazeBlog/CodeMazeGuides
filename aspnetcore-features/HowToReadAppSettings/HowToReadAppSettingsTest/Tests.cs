using Microsoft.Extensions.Configuration;

namespace HowToReadAppSettingsTest
{
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
            var connectionStringFromAppSettings = _configuration["ConnectionStrings:DefaultConnection"];
            var connectionStringValue = "Server=10.1.1.120;Database=Database;User=Admin;Password=MyStrongPassword;";

            Assert.AreEqual(connectionStringFromAppSettings, connectionStringValue);
        }

        [TestMethod]
        public void GivenSettings_WhenRequestingSettings1_ReturnsValue()
        {
            var settings1FromAppSettings = _configuration["Settings1"];
            var settings1 = "Hello there";

            Assert.AreEqual(settings1FromAppSettings, settings1);
        }

        [TestMethod]
        public void GivenSettings_WhenRequestingSettings2_ReturnsValue()
        {
            var settings1FromAppSettings = _configuration["AppSettings:Settings2"];
            var settings1 = "Hello from nested configuration section!";

            Assert.AreEqual(settings1FromAppSettings, settings1);
        }
    }
}