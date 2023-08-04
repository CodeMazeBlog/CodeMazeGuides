using Microsoft.Extensions.Options;
using MockingIOptions.Configuration;
using MockingIOptions.Services;
using Moq;

namespace MockingIOptionsTests
{
    public class CustomerServiceTests
    {
        private const string _connectionString = "TestConnectionString";
        private DatabaseConfiguration _configData;

        [SetUp]
        public void Setup()
        {
            _configData = new DatabaseConfiguration { ConnectionString = _connectionString };
        }

        [Test]
        public void WhenMockingIOptionsWithMoq_ThenCorrectConnectionStringIsReturned()
        {
            var configMock = new Mock<IOptions<DatabaseConfiguration>>();
            configMock.Setup(x => x.Value).Returns(_configData);
            var sut = new CustomerService(configMock.Object);
            var result = sut.GetConnectionString();

            Assert.That(result, Is.EqualTo(_connectionString));
        }

        [Test]
        public void WhenMockingIOptionsWithOptionsWrapper_ThenCorrectConnectionStringIsReturned()
        {
            var configWrapper = new OptionsWrapper<DatabaseConfiguration>(_configData);
            var sut = new CustomerService(configWrapper);
            var result = sut.GetConnectionString();

            Assert.That(result, Is.EqualTo(_connectionString));
        }

        [Test]
        public void WhenMockingIOptionsWithOptionsHelper_ThenCorrectConnectionStringIsReturned()
        {
            var configWrapperUsingHelper = Options.Create(_configData);
            var sut = new CustomerService(configWrapperUsingHelper);
            var result = sut.GetConnectionString();

            Assert.That(result, Is.EqualTo(_connectionString));
        }
    }
}