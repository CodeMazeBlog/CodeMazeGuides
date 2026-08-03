namespace HowToMockIConfiguration.Tests.Services;

public class FinanceServiceTestsWithNSubstitute
{
    [Theory]
    [InlineData(1)]
    [InlineData(1.5)]
    [InlineData(1000)]
    public void WhenCalculateTotalAmountIsInvoked_ThenValidResultIsReturned(double hours)
    {
        // Arrange
        const string rate = "25.50";

        var mockedSection = Substitute.For<IConfigurationSection>();
        mockedSection.Value.Returns(rate);

        var configuration = Substitute.For<IConfiguration>();
        configuration.GetSection("FinanceSettings:HourlyRate")
            .Returns(mockedSection);

        var financeService = new FinanceService(configuration);

        // Act
        var result = financeService.CalculateTotalAmount(hours);

        // Assert
        result.Should().Be(hours * double.Parse(rate));
    }
}
