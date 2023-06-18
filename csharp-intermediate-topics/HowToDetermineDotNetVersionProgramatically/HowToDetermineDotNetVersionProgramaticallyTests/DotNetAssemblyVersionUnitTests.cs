namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetAssemblyVersionUnitTests
{
    [Fact]
    public void GivenPathToDllBuiltWithDotNet_WhenCallingGetAssemblyDotNetVersion_ThenReturnExpectedVersion()
    {
        // Given
        var path = "/usr/local/share/dotnet/shared/Microsoft.NETCore.App/6.0.8/System.dll";
        var expectedVersion = "6.0.8";

        // When
        var actualVersion = DotNetAssemblyVersion.GetAssemblyDotNetVersion(path);

        // Then
        Assert.StartsWith(expectedVersion, actualVersion);
    }
}