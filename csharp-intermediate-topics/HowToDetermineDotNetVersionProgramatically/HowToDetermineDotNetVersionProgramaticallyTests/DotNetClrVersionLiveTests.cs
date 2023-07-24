namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetClrVersionLiveTests
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
    
    [Fact]
    public void GivenPathToDllBuiltWithDotNet_WhenCallingGetAssemblySupportedMinimumClrVersion_ThenReturnExpectedVersion()
    {
        // Given
        var path = typeof(DotNetClrVersionLiveTests).Assembly.Location;
        var expectedVersion = "v4.0";
        
        // When
        var actualVersion = DotNetClrVersion.GetAssemblySupportedMinimumClrVersion(path);

        // Then
        Assert.StartsWith(expectedVersion, actualVersion);
    }
}
