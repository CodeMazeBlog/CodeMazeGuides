namespace JsonValidatorsTest;

public class JTokenJArrayTests
{
    private readonly IJsonValidator _sut;

    public JTokenJArrayTests()
    {
        _sut = new JTokenJArrayUseCase();
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