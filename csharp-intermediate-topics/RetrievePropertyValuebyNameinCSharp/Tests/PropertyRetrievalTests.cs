using RetrievePropertyValuebyNameinCSharp;

namespace Tests;

public class PropertyRetrievalTests
{

    [Fact]
    public void WhenObjectIsNull_ThenReturnsFalse()
    {
        // Arrange
        Person? person = null;

        //Act
        var result = PropertyRetrieval.TryGetPropertyValue<string, Person?>(person, "Name", out _);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void WhenPropertyDoesNotExist_ThenReturnsFalse()
    {
        // Arrange
        var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, IsDeleted = false };

        // Act
        var result = PropertyRetrieval.TryGetPropertyValue<string, Person>(person, "NonExistentProperty", out _);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void WhenPropertyExistsWrongType_ThenReturnsFalse()
    {
        // Arrange
        var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, IsDeleted = false };

        // Act
        var result = PropertyRetrieval.TryGetPropertyValue<int, Person>(person, "Name", out _);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void WhenPropertyExistsWithCorrectType_ThenReturnsTrue()
    {
        // Arrange
        var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, IsDeleted = false };

        // Act
        var result = PropertyRetrieval.TryGetPropertyValue<string, Person>(person, "FirstName", out string? value);

        // Assert
        Assert.True(result);
        Assert.Equal("John", value);
    }

    [Fact]
    public void WhenPropertyExistsNullableType_ThenReturnsTrue()
    {
        // Arrange
        var person = new Person { FirstName = "John", LastName = "Doe", Age = 30, IsDeleted = false };

        // Act
        var result = PropertyRetrieval.TryGetPropertyValue<int?, Person>(person, "Age", out int? value);

        // Assert
        Assert.True(result);
        Assert.Equal(30, value);
    }
}