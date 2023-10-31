namespace Tests;

public class RenameFilesUnitTests
{
    [Fact]
    public void GivenValidDirectoryPath_WhenFindingFiles_ThenReturnListOfFiles()
    {
        // Arrange
        var tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(tempDirectory);

        // Act
        var files = FileFinderService.FindFilesInFolder(tempDirectory);

        // Assert
        Assert.NotNull(files);
        Assert.IsType<List<string>>(files);

        // Clean up
        Directory.Delete(tempDirectory);
    }

    [Fact]
    public void GivenExistingFileAndNewFileName_WhenRenamingFile_ThenOldFileIsRenamedToNewFile()
    {
        // Arrange
        var tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(tempDirectory);

        var oldFilePath = Path.Combine(tempDirectory, "oldfile.txt");
        File.WriteAllText(oldFilePath, "content");
        var newFilePath = Path.Combine(tempDirectory, "newfile.txt");

        // Act
        FileRenameService.RenameFileWithFileClass(oldFilePath, newFilePath);

        // Assert
        Assert.True(File.Exists(newFilePath));
        Assert.False(File.Exists(oldFilePath));

        // Clean up
        Directory.Delete(tempDirectory, true);
    }

    [Fact]
    public void GivenExistingFileAndNewFileName_WhenRenamingFileWithFileInfoClass_ThenOldFileIsRenamedToNewFile()
    {
        // Arrange
        var tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(tempDirectory);

        var oldFilePath = Path.Combine(tempDirectory, "oldfile.txt");
        File.WriteAllText(oldFilePath, "content");
        var newFilePath = Path.Combine(tempDirectory, "newfile.txt");

        // Act
        FileInfoRenameService.RenameFileWithFileInfoClass(oldFilePath, newFilePath);

        // Assert
        Assert.True(File.Exists(newFilePath));
        Assert.False(File.Exists(oldFilePath));

        // Clean up
        Directory.Delete(tempDirectory, true);
    }

    [Fact]
    public void WhenBatchRenamingPhotosWithDateTimeAndAllowedExtensionsExist_ThenPhotosShouldBeRenamed()
    {
        // Arrange
        var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDirectory);

        File.Create(Path.Combine(tempDirectory, "photo1.jpg")).Close();
        File.Create(Path.Combine(tempDirectory, "photo2.png")).Close();

        // Act
        PhotoRenameService.RenamePhotosWithDateTime(tempDirectory);

        // Assert
        var photoFiles = Directory.EnumerateFiles(tempDirectory);

        foreach (var photoFile in photoFiles)
        {
            var creationTime = File.GetCreationTime(photoFile);

            Assert.True(File.Exists(Path.Combine(tempDirectory, $"Image_{creationTime:yyyy-MM-dd_HHmmss}.jpg")));
            Assert.True(File.Exists(Path.Combine(tempDirectory, $"Image_{creationTime:yyyy-MM-dd_HHmmss}.png")));
        }

        // Clean up
        Directory.Delete(tempDirectory, true);
    }

    [Fact]
    public void WhenBatchRenamingPhotosWithDateTimeAndNoAllowedExtensionsExist_ThenNoPhotosShouldBeRenamed()
    {
        // Arrange
        var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDirectory);

        var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".gif" };
        var existingFiles = Directory.EnumerateFiles(tempDirectory);
        Assert.True(existingFiles.All(file => !allowedExtensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase)));

        // Act
        PhotoRenameService.RenamePhotosWithDateTime(tempDirectory);

        var updatedFiles = Directory.EnumerateFiles(tempDirectory);

        // Assert
        Assert.Equal(existingFiles, updatedFiles);

        // Clean up
        Directory.Delete(tempDirectory, true);
    }
}