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
        var bytes1 = File.ReadAllBytes(file1);
        var bytes2 = File.ReadAllBytes(file2);

        if (bytes1.Length != bytes2.Length)
        {
            return false;
        }

        return Enumerable.SequenceEqual(bytes1, bytes2);
    }

    public static bool CompareByChecksum(string file1, string file2)
    {
        var hash1 = MD5.HashData(File.ReadAllBytes(file1));
        var hash2 = MD5.HashData(File.ReadAllBytes(file2));

        return Enumerable.SequenceEqual(hash1, hash2);
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