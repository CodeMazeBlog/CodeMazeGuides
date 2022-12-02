using ToStringMethod;

namespace Tests;

public class ToStringMethodUnitTests
{
    private readonly Person _person;
    private readonly Car _car;
    public ToStringMethodUnitTests()
    {
        _person = new Person("Jane Doe", 26, "Secretary");
        _car = new Car("Range Rover", "Vogue", 200000M, DateTime.Now);
    }

    [Fact]
    public void WhenPersonDetailsArePassed_TheReturnString()
    {
        var result = _person.ToString();
        
        Assert.NotNull(result);
    }

    [Theory]
    [InlineData("en-GB")]
    [InlineData("ja-JP")]
    [InlineData("fr-FR")]
    public void WhenCultureIsPassed_ThenReturnFormattedCurrency(string culture)
    {
        var result = _car.ToString(culture);

        Assert.NotEmpty(result);
        Assert.NotNull(result);
    }

    [Theory]
    [InlineData("en-GB", "dd/MM/yyyy")]
    [InlineData("en-US", "MM/dd/yyyy")]
    [InlineData("ja-JP", "yyyy-MMM-dd")]
    public void WhenCultureAndDateFormatIsSpecified_ThenReturnFormattedString(string culture, string dateFormat) 
    {
        var result = _car.ToString(culture, dateFormat);

        Assert.NotEmpty(result);
        Assert.NotNull(result);
    }
}