using CommunityToolkit.HighPerformance.Buffers;

namespace UsingSendGridApi.Utils;

public static class Utilities
{
    public const long MaxAttachmentSize = 31_457_280;

    public static async Task FillFileWithRandomDataOfSpecifiedLength(string fileName, int sizeInBytes)
    {
        using var buffer = MemoryOwner<byte>.Allocate(Math.Min(sizeInBytes, 8192));
        await using var fs = File.OpenWrite(fileName);
        var memory = buffer.Memory;
        while (sizeInBytes > 0)
        {
            if (sizeInBytes < buffer.Length) memory = memory[..sizeInBytes];
            Random.Shared.NextBytes(memory.Span);
            await fs.WriteAsync(memory).ConfigureAwait(false);
            sizeInBytes -= buffer.Length;
        }
    }

    public static async Task<string> GetAttachmentContentsAsBase64(string file)
    {
        var fi = new FileInfo(file);

        if (!fi.Exists)
            throw new FileNotFoundException("Attachment source not found.", $"{file}");
        if (fi.Length > MaxAttachmentSize)
            throw new ArgumentException($"File size exceeds maximum attachment size limit. " +
                $"Limit: {MaxAttachmentSize} bytes, Attachment size: {fi.Length}");

        using var buffer = MemoryOwner<byte>.Allocate((int) fi.Length);
        await using var fs = fi.OpenRead();
        _ = await fs.ReadAsync(buffer.Memory).ConfigureAwait(false);

        return Convert.ToBase64String(buffer.Span);
    }
}