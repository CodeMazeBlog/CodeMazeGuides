namespace Tests;

public class RenameFilesUnitTests: IDisposable
{
    private readonly string tempDirectory;
    public RenameFilesUnitTests()
    {
        tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(tempDirectory);
    }
    public void Dispose()
    {
        Directory.Delete(tempDirectory, true);
    }

    [Fact]
    public void GivenValidDirectoryPath_WhenFindingFiles_ThenReturnListOfFiles()
    {
        // Act
        var files = FileFinderService.FindFilesInFolder(tempDirectory);

        // Assert
        Assert.NotNull(files);
        Assert.IsAssignableFrom<IEnumerable<string>>(files);
    }

    [Fact]
    public void GivenExistingFileAndNewFileName_WhenRenamingFile_ThenOldFileIsRenamedToNewFile()
    {
        var oldFilePath = Path.Combine(tempDirectory, "oldfile.txt");
        File.WriteAllText(oldFilePath, "content");
        var newFilePath = Path.Combine(tempDirectory, "newfile.txt");

        // Act
        FileRenameService.RenameFileWithFileClass(oldFilePath, newFilePath);

        // Assert
        Assert.True(File.Exists(newFilePath));
        Assert.False(File.Exists(oldFilePath));
    }

    [Fact]
    public void GivenExistingFileAndNewFileName_WhenRenamingFileWithFileInfoClass_ThenOldFileIsRenamedToNewFile()
    {
        var oldFilePath = Path.Combine(tempDirectory, "oldfile.txt");
        File.WriteAllText(oldFilePath, "content");
        var newFilePath = Path.Combine(tempDirectory, "newfile.txt");

        // Act
        FileInfoRenameService.RenameFileWithFileInfoClass(oldFilePath, newFilePath);

        // Assert
        Assert.True(File.Exists(newFilePath));
        Assert.False(File.Exists(oldFilePath));
    }

    [Fact]
    public void WhenBatchRenamingPhotosWithDateTimeAndAllowedExtensionsExist_ThenPhotosShouldBeRenamed()
    {
        File.Create(Path.Combine(tempDirectory, "photo1.jpg")).Close();
        File.Create(Path.Combine(tempDirectory, "photo2.png")).Close();

        // Act
        PhotoRenameService.RenamePhotosWithDateTime(tempDirectory);

        // Assert
        var imageFiles = Directory.EnumerateFiles(tempDirectory);

        foreach (var imageFile in imageFiles)
        {
            var creationTime = File.GetCreationTime(imageFile);

            Assert.True(File.Exists(Path.Combine(tempDirectory, $"Image_{creationTime:yyyy-MM-dd_HHmmss}.jpg")));
            Assert.True(File.Exists(Path.Combine(tempDirectory, $"Image_{creationTime:yyyy-MM-dd_HHmmss}.png")));
        }
    }

    [Fact]
    public void WhenBatchRenamingPhotosWithDateTimeAndNoAllowedExtensionsExist_ThenNoPhotosShouldBeRenamed()
    {
        var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".gif" };
        var existingFiles = Directory.EnumerateFiles(tempDirectory);
        Assert.True(existingFiles.All(file => !allowedExtensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase)));

        // Act
        PhotoRenameService.RenamePhotosWithDateTime(tempDirectory);

        var updatedFiles = Directory.EnumerateFiles(tempDirectory);

        // Assert
        Assert.Equal(existingFiles, updatedFiles);
    }
}