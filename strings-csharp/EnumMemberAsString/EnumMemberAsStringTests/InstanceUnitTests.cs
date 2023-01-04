public class InstanceUnitTests
{
    Person bob = new Person("Bob", Country.USA);
    Person alice = new Person("Alice", Country.India);
    Person john = new Person("John", Country.Australia);

    [Fact]
    public void WhenUsingGetName_ThenReturnsString()
    {
        var usa = Enum.GetName(typeof(Country), bob.Country);
        var india = Enum.GetName(typeof(Country), alice.Country);
        var australia = Enum.GetName(typeof(Country), john.Country);

        Assert.Equal("USA", usa);
        Assert.Equal("India", india);
        Assert.Equal("Australia", australia);
    }

    [Fact]
    public void WhenUsingToString_ThenReturnsString()
    {
        var usa = bob.Country.ToString();
        var india = alice.Country.ToString();
        var australia = john.Country.ToString();

        Assert.Equal("USA", usa);
        Assert.Equal("India", india);
        Assert.Equal("Australia", australia);
    }

    [Fact]
    public void WhenUsingNameof_ThenDoesNotReturnString()
    {
        var usa = nameof(bob.Country);
        var india = nameof(alice.Country);
        var australia = nameof(john.Country);

        Assert.NotEqual("USA", usa);
        Assert.NotEqual("India", india);
        Assert.NotEqual("Australia", australia);
    }
}