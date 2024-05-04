namespace ComparingTwoFiles;

public class FileComparer
{
    public static bool CompareByNameAndSize(string firstFilePath, string secondFilePath)
    {
        var fileInfo1 = new FileInfo(firstFilePath);
        var fileInfo2 = new FileInfo(secondFilePath);

        return fileInfo1.Name == fileInfo2.Name && fileInfo1.Length == fileInfo2.Length;
    }

    public static bool CompareByBytes(string firstFilePath, string secondFilePath)
    {
        const int bufferSize = 1024;
        using var stream1 = new FileStream(firstFilePath, FileMode.Open, FileAccess.Read);
        using var stream2 = new FileStream(secondFilePath, FileMode.Open, FileAccess.Read);

        if (stream1.Length != stream2.Length)
        {
            return false;
        }

        Span<byte> buffer1 = new byte[bufferSize];
        Span<byte> buffer2 = new byte[bufferSize];

        while (true)
        {
            var bytesRead1 = stream1.Read(buffer1);
            var bytesRead2 = stream2.Read(buffer2);

            if (bytesRead1 != bytesRead2)
            {
                return false;
            }

            if (bytesRead1 == 0)
            {
                return true;
            }

            if (!buffer1.SequenceEqual(buffer2))
            {
                return false;
            }
        }
    }

    public static bool CompareByChecksum(string firstFilePath, string secondFilePath)
    {
        using var stream1 = new FileStream(firstFilePath, FileMode.Open, FileAccess.Read);
        using var stream2 = new FileStream(secondFilePath, FileMode.Open, FileAccess.Read);

        if (stream1.Length != stream2.Length)
        {
            return false;
        }

        Span<byte> hash1 = stackalloc byte[16];
        Span<byte> hash2 = stackalloc byte[16];

        MD5.HashData(stream1, hash1);
        MD5.HashData(stream2, hash2);

        return hash1.SequenceEqual(hash2);
    }

    public static List<DiffPiece> ComputeDiff(string firstFilePath, string secondFilePath)
    {
        var text1 = File.ReadAllText(firstFilePath);
        var text2 = File.ReadAllText(secondFilePath);

        return InlineDiffBuilder.Diff(text1, text2).Lines;
    }
}