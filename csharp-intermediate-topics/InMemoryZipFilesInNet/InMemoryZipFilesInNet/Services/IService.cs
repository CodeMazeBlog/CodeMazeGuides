namespace InMemoryZipFilesInNet.Services;

public interface IService
{
    public string Name { get; }

    public string GetData();
}
