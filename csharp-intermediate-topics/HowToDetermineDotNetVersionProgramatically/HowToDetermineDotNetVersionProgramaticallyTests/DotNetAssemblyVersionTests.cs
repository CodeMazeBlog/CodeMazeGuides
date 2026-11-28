namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetAssemblyVersionTests
{
    [Fact]
    public void GivenPathToDllBuiltWithDotNet_WhenCallingGetAssemblyDotNetVersion_ThenReturnExpectedVersion()
    {
        // Given
        var path = typeof(DotNetAssemblyVersionTests).Assembly.Location;
        var expectedVersion = "10.0";
        
        // When
        var actualVersion = DotNetAssemblyVersion.GetAssemblyDotNetVersion(path);

        // Then
        Assert.StartsWith(expectedVersion, actualVersion);
    }
}
