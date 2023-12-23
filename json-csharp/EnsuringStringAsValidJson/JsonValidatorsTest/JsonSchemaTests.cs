namespace JsonValidatorsTest;

public class JsonSchemaTests
{
    private readonly IJsonValidator _sut;

    public JsonSchemaTests()
    {
        _sut = new JsonSchemaSimpleValidationUseCase();
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