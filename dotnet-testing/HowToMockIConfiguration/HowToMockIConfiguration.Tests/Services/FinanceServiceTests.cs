namespace HowToMockIConfiguration.Tests.Services;

public class FinanceServiceTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(1.5)]
    [InlineData(1000)]
    public void WhenCalculateTotalAmountIsInvoked_ThenValidResultIsReturned(double hours)
    {
        // Arrange
        const string rate = "25.50";
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                {"FinanceSettings:HourlyRate", rate}
            })
            .Build();

        var financeService = new FinanceService(configuration);

        // Act
        var result = financeService.CalculateTotalAmount(hours);

        // Assert
        result.Should().Be(hours * double.Parse(rate));
    }
}
