namespace FileToByteArray.Test;

public sealed class LiveTestGiantFileFixture : IDisposable
{
    public LiveTestGiantFileFixture()
    {
        GiantTestFileHash = TestUtilities.GenerateTestFile(GiantTestFile, Array.MaxLength + 10);
    }

    public string GiantTestFile { get; } = Path.GetTempFileName();

    public byte[] GiantTestFileHash { get; }

    public void Dispose()
    {
        TestUtilities.TryDeleteFile(GiantTestFile);
    }
}