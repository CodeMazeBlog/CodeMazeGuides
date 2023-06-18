namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetClrVersionUnitTests
{
    [Fact]
    public void GivenAssemblyBuiltWithDotNet_WhenCallingGetEnvironmentVersion_ThenReturnVersion()
    {
        // Given
        var expectedVersion = "7.0";

        // When
        var actualVersion = DotNetClrVersion.GetEnvironmentVersion();

        // Then
        Assert.StartsWith(expectedVersion, actualVersion);
    }
}
