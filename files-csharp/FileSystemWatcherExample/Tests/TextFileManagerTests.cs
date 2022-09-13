using System.Security.Cryptography;

namespace Tests;

public class TextFileManagerTests : IDisposable
{
    SHA1 _sha1;
    private readonly TextFileManager _textFileManager;
    private readonly string _testDirectory = Path.Combine(Directory.GetCurrentDirectory(), "bin", "TestDir");

    public TextFileManagerTests()
    {
        Directory.CreateDirectory(_testDirectory);
        _textFileManager = new TextFileManager(_testDirectory);
        _sha1 = SHA1.Create();
    }

    [Fact]
    public void GivenFilenameAndContent_WhenCreateIsInvoked_ThenFileIsCreated()
    {
        var fileName = $"{Guid.NewGuid()}.txt";
        var fullPath = Path.Combine(_testDirectory, fileName);
        var content = new string[] { "test" };
        _textFileManager.Create(fileName, content);

        Assert.True(File.Exists(fullPath));
    }

    [Fact]
    public void GivenFilenameAndContent_WhenUpdateIsInvoked_ThenFileIsUpdated()
    {
        var fileName = $"{Guid.NewGuid()}.txt";
        var fullPath = Path.Combine(_testDirectory, fileName);

        PrepareTestFile(fileName);

        var fileHash = _sha1.ComputeHash(File.ReadAllBytes(fullPath));
        var newContent = new string[] { "updated", "content" };

        _textFileManager.Update(fileName, newContent);

        var newFileHash = _sha1.ComputeHash(File.ReadAllBytes(fullPath));

        Assert.NotEqual(fileHash, newFileHash);
        Assert.True(File.Exists(fullPath));
    }

    [Fact]
    public void GivenFilename_WhenDeleteIsInvoked_ThenFileIsDeleted()
    {
        var fileName = $"{Guid.NewGuid()}.txt";
        var fullPath = Path.Combine(_testDirectory, fileName);

        PrepareTestFile(fileName);

        _textFileManager.Delete(fileName);

        Assert.False(File.Exists(fullPath));
    }

    [Fact]
    public void GivenFilenameAndNewFilename_WhenRenameIsInvoked_ThenFilenameIsRenamed()
    {
        var fileName = $"{Guid.NewGuid()}.txt";
        var fullPath = Path.Combine(_testDirectory, fileName);
        var newFileName = $"{Guid.NewGuid()}.txt";
        var newFullPath = Path.Combine(_testDirectory, newFileName);


        PrepareTestFile(fileName);

        var fileHash = _sha1.ComputeHash(File.ReadAllBytes(fullPath));

        _textFileManager.Rename(fileName, newFileName);

        var newFileHash = _sha1.ComputeHash(File.ReadAllBytes(newFullPath));

        Assert.False(File.Exists(fullPath));
        Assert.True(File.Exists(newFullPath));
        Assert.Equal(fileHash, newFileHash);
    }

    private void PrepareTestFile(string fileName)
    {
        var content = new string[] { "test" };
        _textFileManager.Create(fileName, content);
    }

    public void Dispose()
    {
        if (Directory.Exists(_testDirectory))
        {
            Directory.Delete(_testDirectory, true);
        }
        _textFileManager.Dispose();
        _sha1.Dispose();
    }
}