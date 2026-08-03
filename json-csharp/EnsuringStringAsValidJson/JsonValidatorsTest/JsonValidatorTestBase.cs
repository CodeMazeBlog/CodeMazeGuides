namespace JsonValidatorsTest;

public abstract class JsonValidatorsTestBase(IJsonValidator sut)
{
    private const string SimpleValidJson = """{ "name": "Sample Name", "age": 18 }""";

    private const string SimpleInvalidJson = """{ "name": "Sample Name" "age": 18 }""";

    protected IJsonValidator _sut = sut;

    [Fact]
    public virtual void WhenGivenValidJson_ThenIsValidReturnsTrue()
    {
        // Act
        var result = _sut.IsValid(SimpleValidJson);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public virtual void WhenGivenInvalidJson_ThenIsValidReturnsFalse()
    {
        // Act
        var result = _sut.IsValid(SimpleInvalidJson);

        // Assert
        result.Should().BeFalse();
    }
}
