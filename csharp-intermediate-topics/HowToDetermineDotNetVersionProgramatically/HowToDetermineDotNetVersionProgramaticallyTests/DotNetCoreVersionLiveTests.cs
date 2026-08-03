namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetCoreVersionLiveTests
{
    [Fact]
    public void GivenCurrentProcessGarbageCollectionSettings_WhenCallingGetNetCoreVersion_ThenReturnExpectedVersion()
    {
        // Given
        var expectedVersion = "7.0";

        // When
        var actualVersion = DotNetCoreVersion.GetNetCoreVersion();

        // Then
        Assert.StartsWith(expectedVersion, actualVersion);
    }
}
