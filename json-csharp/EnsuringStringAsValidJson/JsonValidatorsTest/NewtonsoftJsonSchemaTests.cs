namespace JsonValidatorsTest;

public class NewtonsoftJsonSchemaTests()
{
    private readonly IJsonValidator _sut = new NewtonsoftJsonSchemaUseCase();

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
    
    [Fact]
    public void WhenGivenInvalidJson_ThenIsValidReturnsFalse()
    {
        // Assign
        const string jsonString = "{'username': 'Sample Username', 'password': 'Sample Password'}";
        
        // Act
        var result = _sut.IsValid(jsonString);

        // Assert
        result.Should().BeFalse();
    }
}