namespace ComparingTwoFiles;

public static class FileUtils
{
    public static readonly string Files = Path.Combine(Directory.GetCurrentDirectory(), "files");
    public static class Batch1
    {
        public static readonly string Batch1Root = Path.Combine(Files, "batch1");
        public static readonly string HelloWorld = Path.Combine(Batch1Root, "hello-world.txt");
    }

    public static class Batch2
    {
        public static readonly string Batch2Root = Path.Combine(Files, "batch2");
        public static readonly string HelloWorld = Path.Combine(Batch2Root, "hello-world.txt");
    }
}