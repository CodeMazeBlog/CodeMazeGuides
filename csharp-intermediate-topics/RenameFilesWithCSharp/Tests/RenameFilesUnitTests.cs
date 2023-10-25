namespace Tests
{
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
            Assert.True(File.Exists(Path.Combine(tempDirectory, $"Image_{DateTime.Now:yyyy-MM-dd_HHmmss}.jpg")));
            Assert.True(File.Exists(Path.Combine(tempDirectory, $"Image_{DateTime.Now:yyyy-MM-dd_HHmmss}.png")));

            // Clean up
            Directory.Delete(tempDirectory, true);
        }


        [Fact]
        public void WhenBatchRenamingPhotosWithDateTimeAndNoAllowedExtensionsExist_ThenNoPhotosShouldBeRenamed()
        {
            // Arrange
            var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);

            File.Create(Path.Combine(tempDirectory, "document.docx")).Close();

            // Act
            BatchRenameFiles.RenamePhotosWithDateTime(tempDirectory);

            // Assert
            Assert.False(File.Exists(Path.Combine(tempDirectory, $"Image_{DateTime.Now:yyyy-MM-dd_HHmmss}.jpg")));
            Assert.False(File.Exists(Path.Combine(tempDirectory, $"Image_{DateTime.Now:yyyy-MM-dd_HHmmss}.png")));

            // Clean up
            Directory.Delete(tempDirectory, true);
        }


        [Fact]
        public void WhenRenamingPhotosWithDateTimeAllowedExtensionsExist_ThenPhotosShouldBeRenamed()
        {
            // Arrange
            var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);

            File.Create(Path.Combine(tempDirectory, "photo1.jpg")).Close();
            File.Create(Path.Combine(tempDirectory, "photo2.png")).Close();

            // Act
            BatchRenameFileWithErrorHandling.RenamePhotosWithDateTime(tempDirectory);

            // Assert
            Assert.True(File.Exists(Path.Combine(tempDirectory, $"Image_{DateTime.Now:yyyy-MM-dd_HHmmss}.jpg")));
            Assert.True(File.Exists(Path.Combine(tempDirectory, $"Image_{DateTime.Now:yyyy-MM-dd_HHmmss}.png")));

            // Clean up
            Directory.Delete(tempDirectory, true);
        }

        [Fact]
        public void WhenRenamingPhotosWithDateTimeAndNoAllowedExtensionsExist_ThenNoPhotosShouldBeRenamed()
        {
            // Arrange
            var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);

            File.Create(Path.Combine(tempDirectory, "document.docx")).Close();

            // Act
            BatchRenameFileWithErrorHandling.RenamePhotosWithDateTime(tempDirectory);

            // Assert
            Assert.False(File.Exists(Path.Combine(tempDirectory, $"Image_{DateTime.Now:yyyy-MM-dd_HHmmss}.jpg")));
            Assert.False(File.Exists(Path.Combine(tempDirectory, $"Image_{DateTime.Now:yyyy-MM-dd_HHmmss}.png")));

            // Clean up
            Directory.Delete(tempDirectory, true);
        }


    }
}
