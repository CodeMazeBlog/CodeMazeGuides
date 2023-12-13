using RetrievePropertyValuebyNameinCSharp;

namespace Tests;

public class PropertyRetrievalTests
{

    [Fact]
    public void WhenGetPropertyValue_ThenReturnPropertyValue()
    {
        // Arrange
        var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, IsDeleted = false };

        // Act
        var firstName = PropertyRetrieval.GetPropertyValue(person, "FirstName");
        var age = PropertyRetrieval.GetPropertyValue(person, "Age");

        // Assert
        Assert.Equal("John", firstName);
        Assert.Equal(30, age);
    }

    [Fact]
    public void WhenGetUnkownPropertyValue_ThenReturnNull()
    {
        // Arrange
        var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, IsDeleted = false };

        // Act
        var city = PropertyRetrieval.GetPropertyValue(person, "City");

        // Assert
        Assert.Null(city);
    }

    [Fact]
    public void WhenGetWrongTypePropertyValue_ThenReturnNull()
    {
        // Arrange
        var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, IsDeleted = false };

        // Act
        var ageAsText = PropertyRetrieval.GetPropertyValue(person, "Age", typeof(string));

        // Assert
        Assert.Null(ageAsText);
    }
}