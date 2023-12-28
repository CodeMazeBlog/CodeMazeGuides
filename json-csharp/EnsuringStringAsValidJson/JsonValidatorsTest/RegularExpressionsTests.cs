namespace JsonValidatorsTest;

public class RegularExpressionsTests() : JsonValidatorsTestBase(new RegularExpressionsUseCase())
{
    public override void WhenGivenInvalidJson_ThenIsValidReturnsFalse()
    {
        // Arrange
        const string invalidJson = """{ "name": "Sample Name", "age": 18 """;

        // Act
        var result = _sut.IsValid(invalidJson);

        // Assert
        result.Should().BeFalse();
    }
}