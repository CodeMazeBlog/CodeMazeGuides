using System.Security.Cryptography;
using System.Text;
using CommunityToolkit.HighPerformance.Buffers;

namespace FileToByteArray.Test;

public sealed class TestFilesFixture : IDisposable
{
    private const string SmallTestFileText =
        "Hello from CodeMaze.\nThis is the text that we are outputting into our file for this test.";

    private static readonly Random Rand = new(42);

    public string SmallTestFile { get; } = Path.GetTempFileName();

    public string LargeTestFile { get; } = Path.GetTempFileName();

    public string GiantTestFile { get; } = Path.GetTempFileName();

    public byte[] SmallTestFileExpectedBytes { get; } = Encoding.UTF8.GetBytes(SmallTestFileText);

    public byte[] LargeTestFileExpectedBytes { get; private set; } = [];

    public byte[] GiantTestFileHash { get; private set; } = [];
    public byte[] SmallTestFileHash { get; private set; } = [];
    public byte[] LargeTestFileHash { get; private set; } = [];

    public TestFilesFixture()
    {
        var giantFileWrite =
            Task.Run(() => GiantTestFileHash = GenerateLargeTestFile(GiantTestFile, Array.MaxLength + 10));
        var largeFileWrite = Task
                             .Run(() => LargeTestFileHash = GenerateLargeTestFile(LargeTestFile,
                                 ToByteArrayMethods.DefaultBufferSize * 2 + 128))
                             .ContinueWith(_ => LargeTestFileExpectedBytes = File.ReadAllBytes(LargeTestFile));
        var smallFileWrite = Task.Run(() => File.WriteAllBytes(SmallTestFile, SmallTestFileExpectedBytes))
                                 .ContinueWith(_ => SmallTestFileHash = MD5.HashData(SmallTestFileExpectedBytes));

        Task.WaitAll([giantFileWrite, largeFileWrite, smallFileWrite]);
    }

    private static byte[] GenerateLargeTestFile(string fileName, long fileLength)
    {
        var span = SpanOwner<byte>.Allocate(ToByteArrayMethods.DefaultBufferSize);
        var buffer = span.Span[..(int) Math.Min(span.Length, fileLength)];

        using var hasher = MD5.Create();
        using var fs = File.OpenWrite(fileName);
        var count = 0L;
        while (count < fileLength)
        {
            Rand.NextBytes(buffer);
            fs.Write(buffer);
            hasher.TransformBlock(span.DangerousGetArray().Array!, 0, buffer.Length, null, 0);
            count += buffer.Length;
            if (fileLength - count < buffer.Length)
            {
                buffer = buffer[..(int) (fileLength - count)];
            }
        }

        hasher.TransformFinalBlock([], 0, 0);

        return hasher.Hash!;
    }

    private static void TryDeleteFile(string fileName)
    {
        try
        {
            File.Delete(fileName);
        }
        catch { }
    }

    public void Dispose()
    {
        TryDeleteFile(SmallTestFile);
        TryDeleteFile(LargeTestFile);
        TryDeleteFile(GiantTestFile);
    }
}