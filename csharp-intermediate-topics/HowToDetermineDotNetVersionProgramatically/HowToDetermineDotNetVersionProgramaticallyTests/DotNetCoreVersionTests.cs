namespace HowToDetermineDotNetVersionProgramaticallyTests;

public class DotNetCoreVersionTests
{
    [Fact]
    public void GivenCurrentProcessGarbageCollectionSettings_WhenCallingGetNetCoreVersion_ThenReturnExpectedVersion()
    {
        // Given
        var expectedVersion = "10.0";

        // When
        var actualVersion = DotNetCoreVersion.GetNetCoreVersion();

        // Then
        Assert.StartsWith(expectedVersion, actualVersion);
    }
}
