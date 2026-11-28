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
        catch
        { }
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

    [Fact]
    public void WhenTwoPhotosShareACreationSecond_ThenBothAreRenamedWithoutCollision()
    {
        var first = Path.Combine(_tempDirectory, "a.jpg");
        var second = Path.Combine(_tempDirectory, "b.jpg");
        File.Create(first).Close();
        File.Create(second).Close();
        var sameSecond = new DateTime(2025, 6, 1, 10, 30, 0);
        File.SetCreationTime(first, sameSecond);
        File.SetCreationTime(second, sameSecond);

        // Act
        ImageRenameService.RenameImagesWithDateTime(_tempDirectory);

        // Assert
        var names = Directory.GetFiles(_tempDirectory).Select(f => Path.GetFileName(f)).Order(StringComparer.Ordinal).ToArray();
        Assert.Equal(["Image_2025-06-01_103000.jpg", "Image_2025-06-01_103000_1.jpg"], names);
    }

    [Fact]
    public void WhenBatchRenameRunsTwice_ThenSecondRunChangesNothing()
    {
        var sameSecond = new DateTime(2025, 6, 1, 10, 30, 0);
        foreach (var name in new[] { "a.jpg", "b.jpg" })
        {
            var path = Path.Combine(_tempDirectory, name);
            File.Create(path).Close();
            File.SetCreationTime(path, sameSecond);
        }
        ImageRenameService.RenameImagesWithDateTimeUsingFileInfo(_tempDirectory);
        var afterFirstRun = Directory.GetFiles(_tempDirectory).Order().ToArray();

        // Act
        ImageRenameService.RenameImagesWithDateTimeUsingFileInfo(_tempDirectory);

        // Assert
        Assert.Equal(afterFirstRun, Directory.GetFiles(_tempDirectory).Order().ToArray());
    }

    [Fact]
    public void GivenExistingFolder_WhenRenamingFolder_ThenContentMovesWithIt()
    {
        var oldFolder = Path.Combine(_tempDirectory, "Invoices2025");
        Directory.CreateDirectory(oldFolder);
        File.WriteAllText(Path.Combine(oldFolder, "invoice-001.pdf"), "content");
        var newFolder = Path.Combine(_tempDirectory, "Invoices-2025");

        // Act
        FolderRenameService.RenameFolder(oldFolder, newFolder);

        // Assert
        Assert.False(Directory.Exists(oldFolder));
        Assert.True(File.Exists(Path.Combine(newFolder, "invoice-001.pdf")));
    }

    [Fact]
    public void GivenTextFile_WhenChangingExtension_ThenOnlyExtensionChanges()
    {
        var filePath = Path.Combine(_tempDirectory, "notes.txt");
        File.WriteAllText(filePath, "content");

        // Act
        var newFilePath = FileRenameService.ChangeExtension(filePath, ".md");

        // Assert
        Assert.Equal(Path.Combine(_tempDirectory, "notes.md"), newFilePath);
        Assert.True(File.Exists(newFilePath));
        Assert.False(File.Exists(filePath));
    }

    [Fact]
    public void GivenExistingDestination_WhenMovingWithoutOverwrite_ThenIOException()
    {
        var source = Path.Combine(_tempDirectory, "a.txt");
        var destination = Path.Combine(_tempDirectory, "b.txt");
        File.WriteAllText(source, "new");
        File.WriteAllText(destination, "old");

        Assert.Throws<IOException>(() => File.Move(source, destination));

        File.Move(source, destination, overwrite: true);
        Assert.Equal("new", File.ReadAllText(destination));
    }
}
