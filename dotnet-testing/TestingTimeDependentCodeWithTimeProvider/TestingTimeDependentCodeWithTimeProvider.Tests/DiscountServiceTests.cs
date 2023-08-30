namespace TestingTimeDependentCodeWithTimeProvider.Tests;

public class DiscountServiceTests
{
    private readonly DiscountService _discountService;
    private readonly IDateTimeProvider _dateTimeProvider;

    public DiscountServiceTests()
    {
        _dateTimeProvider = Substitute.For<IDateTimeProvider>();
        _discountService = new DiscountService(_dateTimeProvider);
    }

    [Fact]
    public void GivenMonday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {
        // Arrange
        _dateTimeProvider.UtcNow.Returns(new DateTime(2023, 5, 1));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public void GivenTuesday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {
        // Arrange
        _dateTimeProvider.UtcNow.Returns(new DateTime(2023, 5, 2));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(2);
    }

    [Fact]
    public void GivenWednesday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {

        // Arrange
        _dateTimeProvider.UtcNow.Returns(new DateTime(2023, 5, 3));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(3);
    }

    [Fact]
    public void GivenThursday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {
        // Arrange
        _dateTimeProvider.UtcNow.Returns(new DateTime(2023, 5, 4));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(4);
    }

    [Fact]
    public void GivenFriday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {
        // Arrange
        _dateTimeProvider.UtcNow.Returns(new DateTime(2023, 5, 5));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(5);
    }

    [Fact]
    public void GivenSaturday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {
        // Arrange
        _dateTimeProvider.UtcNow.Returns(new DateTime(2023, 5, 6));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(6);
    }

    [Fact]
    public void GivenSunday_WhenCalculateDiscountIsInvoked_ThenValidDiscountIsReturned()
    {
        // Arrange
        _dateTimeProvider.UtcNow.Returns(new DateTime(2023, 5, 7));

        // Act
        var result = _discountService.CalculateDiscount();

        // Assert
        result.Should().Be(7);
    }
}