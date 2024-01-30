using System.Text;

namespace FileToByteArray.Test;

public sealed class TestFilesFixture : IDisposable
{
    private const string SmallTestFileText =
        "Hello from CodeMaze.\nThis is the text that we are outputting into our file for this test.";

    public string SmallTestFile { get; } = Path.GetTempFileName();
    public byte[] SmallTestFileExpectedBytes { get; } = Encoding.UTF8.GetBytes(SmallTestFileText);
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
        var smallFileWrite = Task.Run(() => File.WriteAllBytes(SmallTestFile, SmallTestFileExpectedBytes))
            .ContinueWith(_ => SmallTestFileHash = MD5.HashData(SmallTestFileExpectedBytes));

        Task.WaitAll([largeFileWrite, smallFileWrite]);
    }

    public void Dispose()
    {
        TestUtilities.TryDeleteFile(SmallTestFile);
        TestUtilities.TryDeleteFile(LargeTestFile);
    }
}