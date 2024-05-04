namespace ComparingTwoFiles.Benchmark;

[MemoryDiagnoser]
public class FileComparerBenchmark
{
    [Benchmark]
    public void CompareByNameAndSize()
    {
        FileComparer.CompareByNameAndSize("files/batch1/hello-world.txt", "files/batch2/hello-world.txt");
    }

    [Benchmark]
    public void CompareByBytes()
    {
        FileComparer.CompareByBytes("files/batch1/hello-world.txt", "files/batch2/hello-world.txt");
    }

    [Benchmark]
    public void CompareByChecksum()
    {
        FileComparer.CompareByChecksum("files/batch1/hello-world.txt", "files/batch2/hello-world.txt");
    }
}