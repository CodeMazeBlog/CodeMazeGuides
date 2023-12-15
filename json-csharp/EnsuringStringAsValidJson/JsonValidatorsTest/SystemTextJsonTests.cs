using FluentAssertions;
using JsonValidators;
using JsonValidators.Abstracts;

namespace JsonValidatorsTest;

public class SystemTextJsonTests
{
    private readonly IJsonValidator _sut;

    public SystemTextJsonTests()
    {
        _sut = new SystemTextJsonUseCase();
    }

    [Fact]
    public void IsActive_ShouldReturnsTrue_WhenGivenValidJson()
    {
        // Assign
        string jsonString = "{ \"name\": \"Sample Name\", \"age\": 18 }";
        
        // Act
        var result = _sut.IsValid(jsonString);

        // Assert
        result.Should().BeTrue();
    }
}