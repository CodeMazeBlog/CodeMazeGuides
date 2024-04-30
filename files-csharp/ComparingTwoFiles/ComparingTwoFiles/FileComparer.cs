namespace ComparingTwoFiles;

public static class HashStore
{
    public static Dictionary<string, string> Hashes { get; } = new()
    {
        ["files/batch1/hello-world.txt"] = "A0752635617DC83B5858BEDC41E22F91",
        ["files/batch2/hello-world.txt"] = "4FCEE0F97E586FD2D9111397BC9D0440"
    };
}

public class FileComparer
{
    public static bool CompareByNameAndSize(string file1, string file2)
    {
        var fileInfo1 = new FileInfo(file1);
        var fileInfo2 = new FileInfo(file2);

        return fileInfo1.Name == fileInfo2.Name && fileInfo1.Length == fileInfo2.Length;
    }

    public static bool CompareByBytes(string file1, string file2)
    {
        const int bufferSize = 1024;
        using var stream1 = new FileStream(file1, FileMode.Open, FileAccess.Read);
        using var stream2 = new FileStream(file2, FileMode.Open, FileAccess.Read);

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

            if (bytesRead1 == bytesRead2 && bytesRead1 == 0)
            {
                return true;
            }

            if (!buffer1.SequenceEqual(buffer2))
            {
                return false;
            }
        }
    }

    public static bool CompareByChecksum(string file1, string file2)
    {
        using var stream1 = new FileStream(file1, FileMode.Open, FileAccess.Read);
        using var stream2 = new FileStream(file2, FileMode.Open, FileAccess.Read);

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

    public static bool CompareByChecksumWithCache(string file1, string file2)
    {
        return HashStore.Hashes[file1] == HashStore.Hashes[file2];
    }

    public static List<DiffPiece> ComputeDiff(string file1, string file2)
    {
        var text1 = File.ReadAllText(file1);
        var text2 = File.ReadAllText(file2);

        return InlineDiffBuilder.Diff(text1, text2).Lines;
    }

}