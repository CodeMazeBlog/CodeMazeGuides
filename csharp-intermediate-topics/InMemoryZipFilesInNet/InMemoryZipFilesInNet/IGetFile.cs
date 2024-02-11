namespace InMemoryZipFilesInNet;

public interface IGetFile
{
    string ContentType { get; }

    string CreatingNewFileOnDisk();

    Stream GenerateFileOnFlyReturnStream();

    byte[] GenerateFileOnFlyReturnBytes();
}