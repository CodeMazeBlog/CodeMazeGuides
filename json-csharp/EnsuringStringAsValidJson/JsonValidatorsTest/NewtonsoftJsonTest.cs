namespace JsonValidatorsTest;

public class NewtonsoftJsonTest
{
    private readonly IJsonValidator _sut;

    public NewtonsoftJsonTest()
    {
        _sut = new NewtonsoftUseCase();
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