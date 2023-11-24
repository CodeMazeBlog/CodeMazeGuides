using System.Collections.Concurrent;

namespace ExampleApp.ConcurrentBagExamples;

public class StorageConcurrentBag
{
    private readonly ConcurrentBag<string> _files;

    public StorageConcurrentBag()
    {
        _files = new();
    }

    public void AddNew(string fileName)
    {
        _files.Add(fileName);
    }

    public bool TryRemove(out string? removedFileName)
    {
        return _files.TryTake(out removedFileName);
    }

    public bool TryGet(out string? fileName)
    {
        return _files.TryPeek(out fileName);
    }

    public int CountFiles()
    {
        return _files.Count();
    }
}