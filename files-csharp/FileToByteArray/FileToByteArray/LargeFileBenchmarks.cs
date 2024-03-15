using System.Buffers;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Order;
using CommunityToolkit.HighPerformance.Buffers;

namespace FileToByteArray;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class LargeFileBenchmarks
{
    private const long LargeFileSize = ToByteArrayMethods.DefaultBufferSize * 4 + 1024;

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
        while (bytesWritten < LargeFileSize)
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

    [Benchmark]
    public async Task<byte[]> ReadFileWithReadAllBytes()
    {
        var bytes = await File.ReadAllBytesAsync(_tempFile);

        return MD5.HashData(bytes);
    }

    [Benchmark]
    public async Task<byte[]> ReadFileWithMemoryStream()
    {
        var bytes = await ToByteArrayMethods.ConvertUsingMemoryStreamAsync(_tempFile);

        return MD5.HashData(bytes);
    }

    [Benchmark]
    public async Task<byte[]> ReadFileWithPooledArray()
    {
        byte[]? array = null;
        try
        {
            (array, var length) = await ToByteArrayMethods.ConvertToPooledArrayAsync(_tempFile);

            return MD5.HashData(array.AsSpan(length));
        }
        finally
        {
            if (array is not null)
                ArrayPool<byte>.Shared.Return(array);
        }

    }

    [Benchmark]
    public async Task<byte[]> ReadFileWithPooledWriter()
    {
        var bytes = await ToByteArrayMethods.ConvertUsingPooledWriterAsync(_tempFile);

        return MD5.HashData(bytes);
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