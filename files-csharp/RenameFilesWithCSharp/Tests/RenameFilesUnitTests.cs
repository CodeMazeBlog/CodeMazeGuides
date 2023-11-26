namespace Tests;

public class RenameFilesUnitTests : IDisposable
{
    private readonly string _tempDirectory;

    public RenameFilesUnitTests()
    {
        _tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(_tempDirectory);
    }

    public void Dispose()
    {
        try
        {
            Directory.Delete(_tempDirectory, true);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [Fact]
    public void GivenValidDirectoryPath_WhenFindingFiles_ThenReturnListOfFiles()
    {
        // Act
        var files = FileFinderService.FindFilesInFolder(_tempDirectory);

        // Assert
        Assert.NotNull(files);
        Assert.IsAssignableFrom<IEnumerable<string>>(files);
    }

    [Fact]
    public void GivenExistingFileAndNewFileName_WhenRenamingFile_ThenOldFileIsRenamedToNewFile()
    {
        var oldFilePath = Path.Combine(_tempDirectory, "oldfile.txt");
        File.WriteAllText(oldFilePath, "content");
        var newFilePath = Path.Combine(_tempDirectory, "newfile.txt");

        // Act
        FileRenameService.RenameFileWithFileClass(oldFilePath, newFilePath);

        // Assert
        Assert.True(File.Exists(newFilePath));
        Assert.False(File.Exists(oldFilePath));
    }

    [Fact]
    public void GivenExistingFileAndNewFileName_WhenRenamingFileWithFileInfoClass_ThenOldFileIsRenamedToNewFile()
    {
        var oldFilePath = Path.Combine(_tempDirectory, "oldfile.txt");
        File.WriteAllText(oldFilePath, "content");
        var newFilePath = Path.Combine(_tempDirectory, "newfile.txt");

        // Act
        FileInfoRenameService.RenameFileWithFileInfoClass(oldFilePath, newFilePath);

        // Assert
        Assert.True(File.Exists(newFilePath));
        Assert.False(File.Exists(oldFilePath));
    }

    [Fact]
    public void WhenBatchRenamingPhotosWithDateTimeAndAllowedExtensionsExist_ThenPhotosShouldBeRenamed()
    {
        File.Create(Path.Combine(_tempDirectory, "photo1.jpg")).Close();
        File.Create(Path.Combine(_tempDirectory, "photo2.png")).Close();

        // Act
        ImageRenameService.RenameImagesWithDateTime(_tempDirectory);

        // Assert
        var imageFiles = Directory.EnumerateFiles(_tempDirectory);

        foreach (var imageFile in imageFiles)
        {
            var creationTime = File.GetCreationTime(imageFile);

            Assert.True(File.Exists(Path.Combine(_tempDirectory, $"Image_{creationTime:yyyy-MM-dd_HHmmss}.jpg")));
            Assert.True(File.Exists(Path.Combine(_tempDirectory, $"Image_{creationTime:yyyy-MM-dd_HHmmss}.png")));
        }
    }

    [Fact]
    public void WhenBatchRenamingPhotosWithDateTimeAndNoAllowedExtensionsExist_ThenNoPhotosShouldBeRenamed()
    {
        var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".gif" };
        var existingFiles = Directory.EnumerateFiles(_tempDirectory);
        Assert.True(existingFiles.All(file => !allowedExtensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase)));

        // Act
        ImageRenameService.RenameImagesWithDateTime(_tempDirectory);

        var updatedFiles = Directory.EnumerateFiles(_tempDirectory);

        // Assert
        Assert.Equal(existingFiles, updatedFiles);
    }
}