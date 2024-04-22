namespace InMemoryZipFilesInNet;

public interface IGetFile
{
    string ContentType { get; }

    Stream GenerateFileOnFlyReturnStream();

    byte[] GenerateFileOnFlyReturnBytes();

    Task<Stream> GenerateFileOnFlyReturnStreamAsync();
}