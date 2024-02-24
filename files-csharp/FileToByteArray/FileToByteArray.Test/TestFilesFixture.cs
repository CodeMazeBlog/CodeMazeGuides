namespace FileToByteArray.Test;

public sealed class TestFilesFixture : IDisposable
{
    public string SmallTestFile { get; } = Path.GetTempFileName();
    public byte[] SmallTestFileExpectedBytes { get; private set; } = [];
    public byte[] SmallTestFileHash { get; private set; } = [];

    public string LargeTestFile { get; } = Path.GetTempFileName();
    public byte[] LargeTestFileExpectedBytes { get; private set; } = [];
    public byte[] LargeTestFileHash { get; private set; } = [];

    public TestFilesFixture()
    {
        var largeFileWrite = Task
                             .Run(() => LargeTestFileHash = TestUtilities.GenerateTestFile(LargeTestFile,
                                 ToByteArrayMethods.DefaultBufferSize * 2 + 128))
                             .ContinueWith(_ => LargeTestFileExpectedBytes = File.ReadAllBytes(LargeTestFile));
        var smallFileWrite = Task.Run(() => SmallTestFileHash = TestUtilities.GenerateTestFile(SmallTestFile, 32))
                                 .ContinueWith(_ => SmallTestFileExpectedBytes = File.ReadAllBytes(SmallTestFile));

        Task.WaitAll([largeFileWrite, smallFileWrite]);
    }

    public void Dispose()
    {
        TestUtilities.TryDeleteFile(SmallTestFile);
        TestUtilities.TryDeleteFile(LargeTestFile);
    }
}