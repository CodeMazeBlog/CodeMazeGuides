namespace Tests;

public class RenameFilesUnitTests
{
    [Fact]
    public void GivenValidDirectoryPath_WhenFindingFiles_ThenReturnListOfFiles()
    {
        // Arrange
        string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(tempDirectory);

        // Act
        var files = FindingFilesInFolder.FindFilesInFolder(tempDirectory);

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
        string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(tempDirectory);

        string oldFilePath = Path.Combine(tempDirectory, "oldfile.txt");
        File.WriteAllText(oldFilePath, "content");
        string newFilePath = Path.Combine(tempDirectory, "newfile.txt");

        // Act
        RenameSingleFileInFolder.RenameFileInDirectory(oldFilePath, newFilePath);

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
        BatchRenameFiles.RenamePhotosWithDateTime(tempDirectory);

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
        BatchRenameFiles.RenamePhotosWithDateTime(tempDirectory);

        var updatedFiles = Directory.EnumerateFiles(tempDirectory);

        // Assert
        Assert.Equal(existingFiles, updatedFiles);

        // Clean up
        Directory.Delete(tempDirectory, true);
    }

    [Fact]
    public void WhenBatchRenamingPhotosWithDateTimeAndAllowedExtensionsExistWithErrorHandling_ThenPhotosShouldBeRenamed()
    {
        // Arrange
        var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDirectory);

        File.Create(Path.Combine(tempDirectory, "photo1.jpg")).Close();
        File.Create(Path.Combine(tempDirectory, "photo2.png")).Close();

        // Act
        BatchRenameFileWithErrorHandling.RenamePhotosWithDateTime(tempDirectory);

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
    public void WhenBatchRenamingPhotosWithDateTimeAndNoAllowedExtensionsExistWithErrorHandling_ThenNoPhotosShouldBeRenamed()
    {
        // Arrange
        var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDirectory);

        var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".gif" };
        var existingFiles = Directory.EnumerateFiles(tempDirectory);
        Assert.True(existingFiles.All(file => !allowedExtensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase)));

        // Act
        BatchRenameFileWithErrorHandling.RenamePhotosWithDateTime(tempDirectory);

        var updatedFiles = Directory.EnumerateFiles(tempDirectory);

        // Assert
        Assert.Equal(existingFiles, updatedFiles);

        // Clean up
        Directory.Delete(tempDirectory, true);
    }
}