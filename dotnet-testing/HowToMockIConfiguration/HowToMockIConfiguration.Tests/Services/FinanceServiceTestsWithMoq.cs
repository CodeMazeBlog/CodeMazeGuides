namespace HowToMockIConfiguration.Tests.Services;

public class FinanceServiceTestsWithMoq
{
    [Theory]
    [InlineData(1)]
    [InlineData(1.5)]
    [InlineData(1000)]
    public void WhenCalculateTotalAmountIsInvoked_ThenValidResultIsReturned(double hours)
    {
        // Arrange
        const string rate = "25.50";

        var mockedSection = new Mock<IConfigurationSection>();
        mockedSection.Setup(x => x.Value)
            .Returns(rate);

        var configuration = new Mock<IConfiguration>();
        configuration.Setup(x => x.GetSection("FinanceSettings:HourlyRate"))
            .Returns(mockedSection.Object);

        var financeService = new FinanceService(configuration.Object);

        // Act
        var result = financeService.CalculateTotalAmount(hours);

        // Assert
        result.Should().Be(hours * double.Parse(rate));
    }
}
