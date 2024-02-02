using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CountFilesInaFolderLibrary.AdvancedApproach.UsingLINQWithDirectoryEnumerateFiles;
using CountFilesInaFolderLibrary.AdvancedApproach.UsingWinAPI;
using CountFilesInaFolderLibrary.BasicApproach;

namespace CountFilesInaFolderBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class FileCountingBenchmark
{
    [Params(1000, 5000, 10000)]
    public int FileCount;

    private string? _tempDirectoryPath;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _tempDirectoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(_tempDirectoryPath);

        for (int i = 0; i < FileCount; i++)
        {
            var filePath = Path.Combine(_tempDirectoryPath, $"File{i}.txt");
            File.Create(filePath).Dispose();
        }
    }

    [Benchmark]
    public int DirectoryGetFiles_InMemory()
    {
        return FileCounterUsingGetFiles.CountFilesUsingGetFiles(_tempDirectoryPath!);
    }

    [Benchmark]
    public int DirectoryEnumerateFiles_InMemory()
    {
        return FileCounterUsingLINQ.CountFilesUsingLINQEnumerateFiles(_tempDirectoryPath!);
    }

    [Benchmark]
    public int WinAPICount_InMemory()
    {
        return FileCounterUsingWinAPI.CountFilesUsingWinAPI(_tempDirectoryPath!);
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        CleanDirectory();
    }

    private void CleanDirectory()
    {
        if (Directory.Exists(_tempDirectoryPath))
            Directory.Delete(_tempDirectoryPath, true);
    }
}