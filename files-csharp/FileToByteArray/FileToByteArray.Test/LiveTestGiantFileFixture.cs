namespace FileToByteArray.Test;

public sealed class LiveTestGiantFileFixture : IDisposable
{
    public string GiantTestFile { get; } = Path.GetTempFileName();

    public byte[] GiantTestFileHash { get; }

    public LiveTestGiantFileFixture() =>
        GiantTestFileHash = TestUtilities.GenerateTestFile(GiantTestFile, Array.MaxLength + 10);

    public void Dispose()
    {
        TestUtilities.TryDeleteFile(GiantTestFile);
    }
}