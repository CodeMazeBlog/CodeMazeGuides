namespace ComparingTwoFiles;

public static class HashStore
{
    public static Dictionary<string, string> Hashes { get; } = new()
    {
        ["files/batch1/hello-world.txt"] = "A0752635617DC83B5858BEDC41E22F91",
        ["files/batch2/hello-world.txt"] = "4FCEE0F97E586FD2D9111397BC9D0440"
    };
}