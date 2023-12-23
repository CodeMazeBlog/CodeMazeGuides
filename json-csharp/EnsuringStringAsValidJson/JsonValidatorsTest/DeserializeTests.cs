namespace JsonValidatorsTest;

public class DeserializeTests
{
    private readonly IJsonValidator _sut;

    public DeserializeTests()
    {
        _sut = new DeserializeUseCase();
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