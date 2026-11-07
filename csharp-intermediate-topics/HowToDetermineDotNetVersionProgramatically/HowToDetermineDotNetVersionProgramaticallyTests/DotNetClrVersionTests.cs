namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetClrVersionTests
{
    [Fact]
    public void GivenAssemblyBuiltWithDotNet_WhenCallingGetEnvironmentVersion_ThenReturnVersion()
    {
        // Given
        var expectedVersion = "10.0";

        // When
        var actualVersion = DotNetClrVersion.GetEnvironmentVersion();

        // Then
        Assert.StartsWith(expectedVersion, actualVersion);
    }
    
    [Fact]
    public void GivenPathToDllBuiltWithDotNet_WhenCallingGetAssemblySupportedMinimumClrVersion_ThenReturnExpectedVersion()
    {
        // Given
        var path = typeof(DotNetClrVersionTests).Assembly.Location;
        var expectedVersion = "v4.0";
        
        // When
        var actualVersion = DotNetClrVersion.GetAssemblySupportedMinimumClrVersion(path);

        // Then
        Assert.StartsWith(expectedVersion, actualVersion);
    }
}
