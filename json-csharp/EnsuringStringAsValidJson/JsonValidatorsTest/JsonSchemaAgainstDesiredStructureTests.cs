namespace JsonValidatorsTest;

public class JsonSchemaAgainstDesiredStructureTests
{
    private readonly IJsonValidator _sut;

    public JsonSchemaAgainstDesiredStructureTests()
    {
        _sut = new JsonSchemaAgainstDesiredStructureUseCase();
    }

    [Fact]
    public void IsActive_ShouldReturnsTrue_WhenGivenValidJson()
    {
        // Assign
        var jsonString = @"{'username': 'Sample Username', 'addresses': ['Street 1', 'Street 2']}";
        
        // Act
        var result = _sut.IsValid(jsonString);

        // Assert
        result.Should().BeTrue();
    }
}