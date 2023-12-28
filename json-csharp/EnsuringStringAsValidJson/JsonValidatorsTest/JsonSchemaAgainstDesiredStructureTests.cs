namespace JsonValidatorsTest;

public class JsonSchemaAgainstDesiredStructureTests()
{
    private readonly IJsonValidator _sut = new JsonSchemaAgainstDesiredStructureUseCase();

    [Fact]
    public void WhenGivenValidJson_ThenIsValidReturnsTrue()
    {
        // Assign
        const string jsonString = "{'username': 'Sample Username', 'addresses': ['Street 1', 'Street 2']}";
        
        // Act
        var result = _sut.IsValid(jsonString);

        // Assert
        result.Should().BeTrue();
    }
}