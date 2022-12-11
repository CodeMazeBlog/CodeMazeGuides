using ToStringMethod;

namespace Tests;

public class ToStringMethodUnitTests
{
    private readonly Person _person;
    private readonly Person _secondPerson;
    private readonly Car _car;
    private readonly Car _secondCar;

    public ToStringMethodUnitTests()
    {
        _person = new Person("Jane Doe", 26, "Secretary");
        _car = new Car("Range Rover", "Vogue", 200000M, new DateTime(2022, 12, 02, 20, 50, 10));
        _secondPerson = new Person();
        _secondCar = new Car();
    }

    [Fact]
    public void WhenPersonDetailsArePassed_TheReturnString()
    {
        const string expected = "Jane Doe is 26 years old, and is a Secretary";
        var result = _person.ToString();

        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("en-GB", "Range Rover Vogue costs £200,000.00 and was sold on 12/02/2022 20:50:10")]
    [InlineData("ja-JP", "Range Rover Vogue costs ￥200,000 and was sold on 12/02/2022 20:50:10")]
    public void WhenCultureIsPassed_ThenReturnFormattedCurrency(string culture, string expected)
    {
        var result = _car.ToString(culture);

        Assert.NotEmpty(result);
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("en-GB", "dd/MM/yyyy", "Range Rover Vogue costs £200,000.00 and was sold on 02/12/2022")]
    [InlineData("en-US", "MM/dd/yyyy", "Range Rover Vogue costs $200,000.00 and was sold on 12/02/2022")]
    [InlineData("ja-JP", "yyyy-MMM-dd", "Range Rover Vogue costs ￥200,000 and was sold on 2022-Dec-02")]
    public void WhenCultureAndDateFormatIsSpecified_ThenReturnFormattedString(string culture, string dateFormat,
        string expected)
    {
        var result = _car.ToString(culture, dateFormat);

        Assert.NotEmpty(result);
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void WhenPersonObjectIsNull_ThenReturnFallbackValue()
    {
        var result = _secondPerson.ToString();

        Assert.Equal(string.Empty, result);
    } 
    
    [Fact]
    public void WhenCultureIsPassedAndCarIsNull_ThenReturnFallbackValue()
    {
        var cultureFormattedString = _secondCar.ToString("en-US");
        var dateFormattedString = _secondCar.ToString("en-US", "dd-MM-yyyy");

        Assert.Equal(string.Empty, cultureFormattedString); 
    }

    [Fact]
    public void WhenDateIsPassedAndCarIsNull_ThenReturnFallbackValue()
    {
        var dateFormattedString = _secondCar.ToString("en-US", "dd-MM-yyyy");

        Assert.Equal(string.Empty, dateFormattedString); 
    }   
}