using CommunityToolkit.HighPerformance.Buffers;

namespace FileToByteArray.Test;

public static class TestUtilities
{
    public static GenericCollectionAssertions<T> Should<T>(this Span<T> span)
    {
        return span.ToArray().Should();
    }

    public static byte[] GenerateTestFile(string fileName, long fileLength)
    {
        using var span = SpanOwner<byte>.Allocate(1024 * 8);
        var buffer = span.Span[..(int)Math.Min(span.Length, fileLength)];

        using var hasher = MD5.Create();
        using var fs = File.OpenWrite(fileName);
        
        var count = 0L;
        while (count < fileLength)
        {
            Random.Shared.NextBytes(buffer);
            fs.Write(buffer);
            hasher.TransformBlock(span.DangerousGetArray().Array!, 0,
                buffer.Length, null, 0);
            
            count += buffer.Length;
            if (fileLength - count < buffer.Length)
                buffer = buffer[..(int)(fileLength - count)];
        }

        hasher.TransformFinalBlock([], 0, 0);

        return hasher.Hash!;
    }

    public static void TryDeleteFile(string fileName)
    {
        try
        {
            File.Delete(fileName);
        }
        catch
        {
        }
    }
}