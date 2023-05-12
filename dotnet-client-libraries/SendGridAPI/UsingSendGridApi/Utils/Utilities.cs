using System.Diagnostics;
using CommunityToolkit.HighPerformance.Buffers;
using StuceSoftware.Utilities;

namespace UsingSendGridApi.Utils;

public static class Utilities
{
    public const long MaxAttachmentSize = 31_457_280;

    public static async Task<TemporaryFile> CreateTemporaryFileWithSpecifiedSize(int sizeInBytes, string extension)
    {
        // Fill buffer with random data
        using var buffer = MemoryOwner<byte>.Allocate(sizeInBytes);
        Random.Shared.NextBytes(buffer.Span);

        // Write the random data to the temporary file
        var tempFile = new TemporaryFile(extension);
        await using var fs = File.OpenWrite(tempFile.FileName);
        await fs.WriteAsync(buffer.Memory).ConfigureAwait(false);

        return tempFile;
    }

    public static async Task<string> GetAttachmentFileContentsAsBase64(string file)
    {
        var fi = new FileInfo(file);
        if (!fi.Exists)
            throw new FileNotFoundException("Attachment source not found.", $"{file}");
        if (fi.Length > MaxAttachmentSize)
            throw new ArgumentException("File size exceeds maximum attachment size limit. " +
                                        "Limit: {MaxAttachmentSize} bytes, Attachment size: {fi.Length}");

        using var buffer = MemoryOwner<byte>.Allocate((int) fi.Length);
        await using var fs = fi.OpenRead();
        var read = await fs.ReadAsync(buffer.Memory).ConfigureAwait(false);
        Debug.Assert(read == buffer.Length);

        return Convert.ToBase64String(buffer.Span);
    }
}