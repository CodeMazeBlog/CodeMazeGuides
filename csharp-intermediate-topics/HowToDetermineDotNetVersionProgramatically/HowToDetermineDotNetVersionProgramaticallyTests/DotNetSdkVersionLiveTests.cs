namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetSdkVersionLiveTests
{
    [Fact]
    public void GivenPlatformWithInstalledDotNetSdks_WhenCallingGetDotNetSdkVersionsInstalled_ThenReturnInstalledSdks()
    {
        // When
        var installedSdks = DotNetSdkVersion.GetDotNetSdkVersionsInstalled();

        // Then
        Assert.True(!string.IsNullOrWhiteSpace(installedSdks));
    }

    [Fact]
    public void
        GivenPlatformWithInstalledDotNetSdks_WhenCallingGetInstalledSdkVersionsCollection_ThenCollectionShouldNotBeEmpty()
    {
        // When
        var sdkVersionsCollection = DotNetSdkVersion.GetInstalledSdkVersions();

        // Then
        Assert.True(sdkVersionsCollection.Count > 0);
    }
}
