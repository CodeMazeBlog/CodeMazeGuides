public class EnumUnitTests
{
    [Fact]
    public void WhenUsingGetName_ThenReturnsString()
    {
        var usa = Enum.GetName(typeof(Country), Country.USA);
        var india = Enum.GetName(typeof(Country), Country.India);
        var australia = Enum.GetName(typeof(Country), Country.Australia);

        Assert.Equal("USA", usa);
        Assert.Equal("India", india);
        Assert.Equal("Australia", australia);
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
}