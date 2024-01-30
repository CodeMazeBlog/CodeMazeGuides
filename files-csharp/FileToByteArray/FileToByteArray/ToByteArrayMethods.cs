using System.Buffers;
using System.IO.MemoryMappedFiles;
using System.Runtime.CompilerServices;
using CommunityToolkit.HighPerformance;
using CommunityToolkit.HighPerformance.Buffers;

namespace FileToByteArray;

public static class ToByteArrayMethods
{
    public const int DefaultBufferSize = 1024 * 4;

    public static byte[] ConvertUsingMemoryStream(string filePath)
    {
        var fileInfo = new FileInfo(filePath);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(fileInfo.Length, Array.MaxLength, "File length");

        using var ms = new MemoryStream(DefaultBufferSize);
        using var fs = File.OpenRead(filePath);

        fs.CopyTo(ms);

        return ms.ToArray();
    }

    public static async Task<byte[]> ConvertUsingMemoryStreamAsync(string filePath)
    {
        var fileInfo = new FileInfo(filePath);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(fileInfo.Length, Array.MaxLength, "File length");

        await using var ms = new MemoryStream(DefaultBufferSize);
        await using var fs = File.OpenRead(filePath);

        await fs.CopyToAsync(ms);

        return ms.ToArray();
    }

    public static (byte[] rentedBuffer, int length) ConvertToPooledArray(string filePath)
    {
        var fileInfo = new FileInfo(filePath);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(fileInfo.Length, Array.MaxLength, "File length");

        var length = (int) fileInfo.Length;
        var array = ArrayPool<byte>.Shared.Rent(length);
        var span = array.AsSpan(0, length);

        using var fs = fileInfo.OpenRead();
        fs.ReadExactly(span);

        return (array, length);
    }

    public static async Task<(byte[] rentedArray, int length)> ConvertToPooledArrayAsync(string filePath)
    {
        var fileInfo = new FileInfo(filePath);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(fileInfo.Length, Array.MaxLength, "File length");

        var length = (int) fileInfo.Length;
        var array = ArrayPool<byte>.Shared.Rent(length);
        var memory = array.AsMemory(0, length);
        await using var fs = fileInfo.OpenRead();
        await fs.ReadExactlyAsync(memory);

        return (array, length);
    }

    public static byte[] ConvertUsingPooledWriter(string filePath)
    {
        var fileInfo = new FileInfo(filePath);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(fileInfo.Length, Array.MaxLength, "File length");

        using var writer = new ArrayPoolBufferWriter<byte>(DefaultBufferSize);
        using var stream = writer.AsStream();
        using var fs = File.OpenRead(filePath);

        fs.CopyTo(stream);

        return writer.WrittenSpan.ToArray();
    }

    public static async Task<byte[]> ConvertUsingPooledWriterAsync(string filePath)
    {
        var fileInfo = new FileInfo(filePath);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(fileInfo.Length, Array.MaxLength, "File length");

        using var writer = new ArrayPoolBufferWriter<byte>(DefaultBufferSize);
        await using var stream = writer.AsStream();
        await using var fs = File.OpenRead(filePath);

        await fs.CopyToAsync(stream);

        return writer.WrittenSpan.ToArray();
    }

    public static async IAsyncEnumerable<byte[]> ConvertInChunks(string filePath, int chunkSize,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(chunkSize, Array.MaxLength);

        var rentedBuffer = ArrayPool<byte>.Shared.Rent(chunkSize);
        try
        {
            var memory = rentedBuffer.AsMemory(0, chunkSize);

            var fileLength = new FileInfo(filePath).Length;
            using var mm = MemoryMappedFile.CreateFromFile(filePath);
            await using var accessor = mm.CreateViewStream(0, fileLength);

            int bytesRead;
            while ((bytesRead = await accessor.ReadAsync(memory, cancellationToken)) != 0)
            {
                yield return memory[..bytesRead].ToArray();
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(rentedBuffer);
        }
    }
}