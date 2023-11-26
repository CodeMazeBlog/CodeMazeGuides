using RetrievePropertyValuebyNameinCSharp;

namespace Tests;

public class PropertyRetrievalTests
{

    [Fact]
    public void WhenGetPropertyValue_ReturnsCorrectValue()
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
    public void WhenGetPropertyValue_PropertyNotFound_ReturnsNull()
    {
        // Arrange
        var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, IsDeleted = false };

        // Act
        var city = PropertyRetrieval.GetPropertyValue(person, "City");

        // Assert
        Assert.Null(city);
    }

    [Fact]
    public void WhenGetPropertyValue_TypeMismatch_ReturnsNull()
    {
        // Arrange
        var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, IsDeleted = false };

        // Act
        var ageAsText = PropertyRetrieval.GetPropertyValue(person, "Age", typeof(string));

        // Assert
        Assert.Null(ageAsText);
    }
}