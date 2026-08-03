using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using CommunityToolkit.HighPerformance.Buffers;

namespace FileToByteArray;

public class GiantFileBenchmarks
{
    private const long _3GB = 3L * 1024 * 1024 * 1024;

    private static readonly Random _rand = new(42);

    private string _tempFile = string.Empty;

    [GlobalSetup]
    public void GlobalSetup()
    {
        using var span = SpanOwner<byte>.Allocate(8 * 1024);
        _rand.NextBytes(span.Span);

        _tempFile = Path.GetTempFileName();
        using var fs = File.OpenWrite(_tempFile);

        var bytesWritten = 0L;
        while (bytesWritten < _3GB)
        {
            fs.Write(span.Span);
            bytesWritten += span.Length;
        }
    }

    [Benchmark]
    public async Task<byte[]> ReadFileWithMemoryMapped()
    {
        using var md5Hasher = MD5.Create();
        await foreach (var chunk in ToByteArrayMethods.ConvertInChunksMemoryMapped(_tempFile,
            ToByteArrayMethods.DefaultBufferSize))
        {
            md5Hasher.TransformBlock(chunk, 0,
                chunk.Length, null, 0);
        }

        md5Hasher.TransformFinalBlock([], 0, 0);

        return md5Hasher.Hash!;
    }

    [Benchmark]
    public async Task<byte[]> ReadFileWithFileStream()
    {
        using var md5Hasher = MD5.Create();
        await foreach (var chunk in ToByteArrayMethods.ConvertInChunksFileStream(_tempFile,
            ToByteArrayMethods.DefaultBufferSize))
        {
            md5Hasher.TransformBlock(chunk, 0,
                chunk.Length, null, 0);
        }

        md5Hasher.TransformFinalBlock([], 0, 0);

        return md5Hasher.Hash!;
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        if (!string.IsNullOrEmpty(_tempFile) && File.Exists(_tempFile))
        {
            File.Delete(_tempFile);
        }
    }
}