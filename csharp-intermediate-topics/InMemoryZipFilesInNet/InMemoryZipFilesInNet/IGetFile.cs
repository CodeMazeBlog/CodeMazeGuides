namespace InMemoryZipFilesInNet;

public interface IGetFile
{
    string ContentType { get; }

    string CreateNewFileOnDisk();

    Stream GenerateFileOnFlyReturnStream();

    byte[] GenerateFileOnFlyReturnBytes();

    Task<Stream> GenerateFileOnFlyReturnStreamAsync();
}