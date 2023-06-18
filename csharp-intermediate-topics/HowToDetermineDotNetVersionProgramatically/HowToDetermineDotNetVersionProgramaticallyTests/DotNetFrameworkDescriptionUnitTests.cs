namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetFrameworkDescriptionUnitTests
{
    [Fact]
    public void GivenAssemblyBuiltWithDotNet_WhenCallingGetFrameworkDescription_ThenReturnDescription()
    {
        // Given
        var expectedDescription = ".NET 7.";

        // When
        var actualDescription = DotNetFrameworkDescription.GetFrameworkDescription();

        // Then
        Assert.StartsWith(expectedDescription, actualDescription);
    }
}
