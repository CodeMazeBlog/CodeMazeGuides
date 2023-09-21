using Microsoft.Extensions.Time.Testing;

namespace TestingTimeDependentCodeWithTimeProvider.Tests;

public class DiscountServiceTests
{
    private readonly FakeTimeProvider _timeProvider;
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

    [Fact]
    public void WhenTimePasses_ThenSpecialDiscountIsUpdatedAccordingly()
    {
        _discountService.SpecialDiscount.Should().Be(0);

        _timeProvider.SetUtcNow(new DateTime(2023, 5, 1, 0, 0, 0));
        _timeProvider.Advance(TimeSpan.FromSeconds(10));

        // 00:00:10
        _discountService.SpecialDiscount.Should().Be(5);

        _timeProvider.Advance(TimeSpan.FromHours(6));

        // 06:00:10
        _discountService.SpecialDiscount.Should().Be(4);

        _timeProvider.Advance(TimeSpan.FromHours(6));

        // 12:00:10
        _discountService.SpecialDiscount.Should().Be(3);

        _timeProvider.Advance(TimeSpan.FromHours(6));

        // 18:00:10
        _discountService.SpecialDiscount.Should().Be(2);

        _timeProvider.Advance(TimeSpan.FromHours(6));

        // 00:00:10
        _discountService.SpecialDiscount.Should().Be(5);
    }
}