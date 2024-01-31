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
    private string _directoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

    [Params(1000, 5000, 10000)]
    public int FileCount;

    public DirectoryInfo CreateSimulatedDirectory(int fileCount)
    {
        var directory = Directory.CreateDirectory(_directoryPath);

        for (int i = 0; i < fileCount; i++)
        {
            var filePath = Path.Combine(directory.FullName, $"File{i}.txt");
            File.WriteAllText(filePath, "Test content");
        }

        return directory;
    }

    [Benchmark]
    public int DirectoryGetFiles_InMemory()
    {
        var directory = CreateSimulatedDirectory(FileCount);

        return FileCounterUsingGetFiles.CountFilesUsingGetFiles(directory.FullName);
    }

    [Benchmark]
    public int DirectoryEnumerateFiles_InMemory()
    {
        var directory = CreateSimulatedDirectory(FileCount);

        return FileCounterUsingLINQ.CountFilesUsingLINQEnumerateFiles(directory.FullName);
    }

    [Benchmark]
    public int WinAPICount_InMemory()
    {
        var directory = CreateSimulatedDirectory(FileCount);

        return FileCounterUsingWinAPI.CountFilesUsingWinAPI(directory.FullName);
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        CleanDirectory();
    }

    private void CleanDirectory()
    {
        if (_directoryPath is not null)
        {
            foreach (var filePath in Directory.EnumerateFiles(_directoryPath))
            {
                File.Delete(filePath);
            }

            if (Directory.Exists(_directoryPath))
            {
                Directory.Delete(_directoryPath, true);
            }
        }
    }
}