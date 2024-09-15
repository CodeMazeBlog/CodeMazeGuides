namespace CountFilesInaFolderTests;
public class FileCounterFixture : IDisposable
{
    public string TempDirectory { get; private set; }

    public FileCounterFixture()
    {
        TempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(TempDirectory);

        for (var i = 0; i < 1000; i++)
        {
            File.Create(Path.Combine(TempDirectory, $"file{i}.txt")).Dispose();
        }
    }

    public void Dispose()
    {
        Directory.Delete(TempDirectory, true);
    }
}
