namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetRuntimeVersionLiveTests
{
    [Fact]
    public void
        GivenPlatformWithInstalledDotNetRuntimes_WhenCallingGetDotNetRuntimeVersionsInstalled_ThenReturnInstalledRuntimes()
    {
        // When
        var installedRuntimes = DotNetRuntimeVersion.GetDotNetRuntimeVersionsInstalled();

        // Then
        Assert.True(!string.IsNullOrWhiteSpace(installedRuntimes));
    }

    [Fact]
    public void
        GivenPlatformWithInstalledDotNetRuntimes_WhenCallingGetInstalledDotNetRuntimeVersionsCollection_ThenCollectionShouldNotBeEmpty()
    {
        // When
        var runtimeVersionsCollection = DotNetRuntimeVersion.GetInstalledDotNetRuntimeVersions();

        // Then
        Assert.True(runtimeVersionsCollection.Count > 0);
    }
}
