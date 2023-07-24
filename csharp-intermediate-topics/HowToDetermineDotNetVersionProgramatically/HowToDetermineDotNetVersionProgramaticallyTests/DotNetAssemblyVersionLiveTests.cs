namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetAssemblyVersionLiveTests
{
    [Fact]
    public void GivenPathToDllBuiltWithDotNet_WhenCallingGetAssemblyDotNetVersion_ThenReturnExpectedVersion()
    {
        // Given
        var path = typeof(DotNetAssemblyVersionLiveTests).Assembly.Location;
        var expectedVersion = "7.0";
        
        // When
        var actualVersion = DotNetAssemblyVersion.GetAssemblyDotNetVersion(path);

        // Then
        Assert.StartsWith(expectedVersion, actualVersion);
    }
}
