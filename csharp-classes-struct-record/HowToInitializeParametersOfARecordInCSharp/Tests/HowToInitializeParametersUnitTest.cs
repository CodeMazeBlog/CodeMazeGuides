using HowToInitializeParametersOfARecordInCSharp;
using Xunit;

namespace Tests;

public class HowToInitializeParametersUnitTest
{
    [Fact]
    public void WhenInitializingPerson_ThenPropertiesSet()
    {
        // Arrange
        var person = new Person("Joe", "Bloggs");

        // Assert
        Assert.Equal("Joe", person.FirstName);
        Assert.Equal("Bloggs", person.LastName);
    }

    [Fact]
    public void WhenInitializingPerson2_ThenPropertiesSet()
    {
        // Arrange
        var person = new Person2("Joe", "Bloggs");

        // Assert
        Assert.Equal("Joe", person.FirstName);
        Assert.Equal("Bloggs", person.LastName);
    }

    [Fact]
    public void WhenInitializingPerson3WithNoFriends_ThenPropertiesSet()
    {
        // Arrange
        var person = new Person3("Joe", "Bloggs");

        // Assert
        Assert.Equal("Joe", person.FirstName);
        Assert.Equal("Bloggs", person.LastName);
        Assert.Empty(person.Friends);
    }

    [Fact]
    public void WhenInitializingPerson3WithFriends_ThenPropertiesSet()
    {
        // Arrange
        var person = new Person3("Joe", "Bloggs", new List<string> { "Alice", "Bob" });

        // Assert
        Assert.Equal("Joe", person.FirstName);
        Assert.Equal("Bloggs", person.LastName);
        Assert.Equal(2, person.Friends.Count());
    }

    [Fact]
    public void WhenInitializingPerson4WithNoFriends_ThenPropertiesSet()
    {
        // Arrange
        var person = new Person4("Joe", "Bloggs");

        // Assert
        Assert.Equal("Joe", person.FirstName);
        Assert.Equal("Bloggs", person.LastName);
        Assert.Empty(person.Friends);
    }

    [Fact]
    public void WhenInitializingPerson4WithFriends_ThenPropertiesSet()
    {
        // Arrange
        var person = new Person4("Joe", "Bloggs", new List<string> { "Alice", "Bob" });

        // Assert
        Assert.Equal("Joe", person.FirstName);
        Assert.Equal("Bloggs", person.LastName);
        Assert.Equal(2, person.Friends.Count());
    }
}