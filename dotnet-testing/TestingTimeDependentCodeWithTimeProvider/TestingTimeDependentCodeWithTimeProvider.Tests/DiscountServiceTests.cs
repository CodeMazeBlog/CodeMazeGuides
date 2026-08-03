namespace TestingTimeDependentCodeWithTimeProvider.Tests;

public class DiscountServiceTests : IDisposable
{
#pragma warning disable EXTEXP0004 //'Microsoft.Extensions.Time.Testing.FakeTimeProvider' is for evaluation purposes only and is subject to change or removal in future updates.
    private readonly FakeTimeProvider _timeProvider;
#pragma warning restore EXTEXP004
    private readonly DiscountService _discountService;

    public DiscountServiceTests()
    {
        _timeProvider = new FakeTimeProvider();
        _discountService = new DiscountService(_timeProvider);
    }

    [Fact]
    public void GivenMonday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {
        // Arrange
        _timeProvider.SetUtcNow(new DateTime(2023, 5, 1));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public void GivenTuesday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {
        // Arrange
        _timeProvider.SetUtcNow(new DateTime(2023, 5, 2));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(2);
    }

    [Fact]
    public void GivenWednesday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {
        // Arrange
        _timeProvider.SetUtcNow(new DateTime(2023, 5, 3));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(3);
    }

    [Fact]
    public void GivenThursday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {
        // Arrange
        _timeProvider.SetUtcNow(new DateTime(2023, 5, 4));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(4);
    }

    [Fact]
    public void GivenFriday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {
        // Arrange
        _timeProvider.SetUtcNow(new DateTime(2023, 5, 5));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(5);
    }

    [Fact]
    public void GivenSaturday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {
        // Arrange
        _timeProvider.SetUtcNow(new DateTime(2023, 5, 6));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(6);
    }

    [Fact]
    public void GivenSunday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {
        // Arrange
        _timeProvider.SetUtcNow(new DateTime(2023, 5, 7));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(7);
    }

    [Theory]
    [InlineData(0, 5.0)]
    [InlineData(6, 4.0)]
    [InlineData(12, 3.0)]
    [InlineData(18, 2.0)]
    [InlineData(24, 5.0)]
    public void WhenTimePasses_ThenSpecialDiscountIsUpdatedAccordingly(int hoursToAdvance, double expectedDiscount)
    {
        //Act
        _discountService.SpecialDiscount.Should().Be(0);
        _timeProvider.SetUtcNow(new DateTime(2023, 5, 1, 0, 0, 0));

        //Arrange
        _timeProvider.Advance(TimeSpan.FromHours(hoursToAdvance) + TimeSpan.FromSeconds(10));

        // Assert
        _discountService.SpecialDiscount.Should().Be(expectedDiscount);
    }

    public void Dispose()
    {
        _discountService?.Dispose();
    }
}