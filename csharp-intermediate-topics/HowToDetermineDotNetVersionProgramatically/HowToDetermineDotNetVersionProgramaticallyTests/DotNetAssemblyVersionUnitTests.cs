namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetAssemblyVersionUnitTests
{
    [Fact]
    public void GivenPathToDllBuiltWithDotNet_WhenCallingGetAssemblyDotNetVersion_ThenReturnExpectedVersion()
    {
        // Given
        var path = typeof(DotNetAssemblyVersionUnitTests).Assembly.Location;
        var expectedVersion = "7.0";
        
        // When
        var actualVersion = DotNetAssemblyVersion.GetAssemblyDotNetVersion(path);

        // Then
        Assert.StartsWith(expectedVersion, actualVersion);
    }
}
