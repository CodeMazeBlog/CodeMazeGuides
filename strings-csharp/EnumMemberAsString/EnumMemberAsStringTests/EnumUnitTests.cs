public class EnumUnitTests
{
    [Fact]
    public void WhenUsingGetName_ThenReturnsString()
    {
        var usa = Enum.GetName<Country>(Country.USA);
        var india = Enum.GetName<Country>(Country.India);
        var australia = Enum.GetName<Country>(Country.Australia);

        Assert.Equal("USA", usa);
        Assert.Equal("India", india);
        Assert.Equal("Australia", australia);
    }

    [Fact]
    public void WhenEnumTypeIsOnlyKnownAtRuntime_ThenGetNameStillReturnsString()
    {
        Type enumType = typeof(Country);

        var usa = Enum.GetName(enumType, 0);

        Assert.Equal("USA", usa);
    }

    [Fact]
    public void WhenUsingToString_ThenReturnsString()
    {
        var usa = Country.USA.ToString();
        var india = Country.India.ToString();
        var australia = Country.Australia.ToString();

        Assert.Equal("USA", usa);
        Assert.Equal("India", india);
        Assert.Equal("Australia", australia);
    }

    [Fact]
    public void WhenUsingNameof_ThenReturnsString()
    {
        var usa = nameof(Country.USA);
        var india = nameof(Country.India);
        var australia = nameof(Country.Australia);

        Assert.Equal("USA", usa);
        Assert.Equal("India", india);
        Assert.Equal("Australia", australia);
    }

    [Fact]
    public void WhenUsingFormatSpecifiers_ThenReturnsExpectedText()
    {
        var country = Country.Australia;

        Assert.Equal("Australia", country.ToString("G"));
        Assert.Equal("2", country.ToString("D"));
        Assert.Equal("00000002", country.ToString("X"));
        Assert.Equal("Australia", country.ToString("F"));
        Assert.Equal("0", Country.USA.ToString("D"));
        Assert.Equal("00000000", Country.USA.ToString("X"));
    }

    [Fact]
    public void WhenValueIsNotDefined_ThenGetNameIsNullAndToStringIsTheNumber()
    {
        var undefined = (Country)20;

        Assert.Null(Enum.GetName<Country>(undefined));
        Assert.Equal("20", undefined.ToString());
    }
}
