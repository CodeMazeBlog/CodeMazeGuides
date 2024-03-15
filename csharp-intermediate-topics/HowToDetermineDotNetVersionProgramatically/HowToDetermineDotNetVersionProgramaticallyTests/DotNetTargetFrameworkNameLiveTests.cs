namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetTargetFrameworkNameLiveTests
{
    /* for use in library build on .NET Framework
    [Fact]
    public void GivenThisProcessBuiltWithDotNetFramework_WhenCallingGetTargetFrameworkName_ThenReturnExpectedFrameworkName()
    {
        // Given
        var expectedFrameworkName = ".NETFramework,Version=v";

        // When
        var actualFrameworkName = DotNetTargetFrameworkName.GetTargetFrameworkName();

        // Then
        Assert.StartsWith(expectedFrameworkName, actualFrameworkName);
    }
    */

    [Fact]
    public void GivenThisProcessBuiltWithDotNetCore_WhenCallingGetTargetFrameworkName_ThenReturnExpectedFrameworkName()
    {
        // Given
        var expectedFrameworkName = ".NETCoreApp,Version=v";

        // When
        var actualFrameworkName = DotNetTargetFrameworkName.GetTargetFrameworkName();

        // Then
        Assert.StartsWith(expectedFrameworkName, actualFrameworkName);
    }
}
