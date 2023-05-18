using CommunityToolkit.HighPerformance.Buffers;

namespace UsingSendGridApi.Utils;

public static class Utilities
{
    public const long MaxAttachmentSize = 31_457_280;

    public static async Task FillFileWithRandomDataOfSpecifiedLength(string fileName, int sizeInBytes)
    {
        using var buffer = MemoryOwner<byte>.Allocate(sizeInBytes);
        Random.Shared.NextBytes(buffer.Span);

        await using var fs = File.OpenWrite(fileName);
        await fs.WriteAsync(buffer.Memory).ConfigureAwait(false);
    }

    public static async Task<string> GetFileContentsAsBase64(string file)
    {
        var fi = new FileInfo(file);

        if (!fi.Exists)
            throw new FileNotFoundException("Attachment source not found.", $"{file}");
        if (fi.Length > MaxAttachmentSize)
            throw new ArgumentException("File size exceeds maximum attachment size limit. " +
                $"Limit: {MaxAttachmentSize} bytes, Attachment size: {fi.Length}");

        using var buffer = MemoryOwner<byte>.Allocate((int) fi.Length);
        await using var fs = fi.OpenRead();
        _ = await fs.ReadAsync(buffer.Memory).ConfigureAwait(false);

        return Convert.ToBase64String(buffer.Span);
    }
}