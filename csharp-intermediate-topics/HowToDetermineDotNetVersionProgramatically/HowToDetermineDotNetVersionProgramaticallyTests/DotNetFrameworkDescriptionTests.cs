namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetFrameworkDescriptionTests
{
    [Fact]
    public void GivenAssemblyBuiltWithDotNet_WhenCallingGetFrameworkDescription_ThenReturnDescription()
    {
        // Given
        var expectedDescription = ".NET 10.";

        // When
        var actualDescription = DotNetFrameworkDescription.GetFrameworkDescription();

        // Then
        Assert.StartsWith(expectedDescription, actualDescription);
    }
}
