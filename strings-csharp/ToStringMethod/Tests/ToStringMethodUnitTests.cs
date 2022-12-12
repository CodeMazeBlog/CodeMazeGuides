using ToStringMethod;

namespace Tests;

public class ToStringMethodUnitTests
{
    private Person _person;
    private Car _car;

    public ToStringMethodUnitTests()
    {
        _person = new Person("Jane Doe", 26, "Secretary");
        _car = new Car("Range Rover", "Vogue", 200000M, new DateTime(2022, 12, 02, 20, 50, 10));

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
    public void WhenNullCarObjectIsConvertedToString_ThenThrowAnException()
    {
        _car = null;

        void Action() => _car.ConvertNullObjectToString();

        Assert.Throws<NullReferenceException>(Action);
    }

    [Fact]
    public void WhenNullPersonObjectIsConvertedToString_ThenThrowAnException()
    {
        _person = null;

        void Action() => _person.ConvertNullObjectToString();

        Assert.Throws<NullReferenceException>(Action);
    }

    [Fact]
    public void WhenNullCarObjectIsConvertedToString_ThenReturnEmptyString()
    {
        _car = null;

        var result = _car.HandleNullException();

        Assert.Empty(result);
    }

    [Fact]
    public void WhenNullPersonObjectIsConvertedToString_ThenReturnEmptyString()
    {
        _person = null;

        var result = _person.HandleNullException();

        Assert.Empty(result);
    }

    [Theory]
    [InlineData("en-GB", "dd/MM/yyyy")]
    public void WhenCarObjectHasNullProperty_ThenReturnEmptyString(string culture, string dateFormat)
    {
        _car.Make = null;
        _car.Model = null;

        var result = _car.ToString(culture, dateFormat);

        Assert.Empty(result);
    }

    [Fact]
    public void WhenPersonObjectHasNullProperty_ThenReturnEmptyString()
    {
        _person.Name = null;

        var result = _person.ToString();

        Assert.Empty(result);
    }
}