namespace Tests
{
    public class RenameFilesUnitTests
    {
        [Fact]
        public void GivenValidDirectoryPath_WhenFindingFiles_ThenReturnListOfFiles()
        {
            // Arrange
            var directoryPath = @"C:\Users\HP\Desktop\MyDirectory"; //Enter valid directory path

            // Act
            List<string> files = FindingFilesInFolder.FindFilesInFolder();

            // Assert
            Assert.NotNull(files);
            Assert.All(files, file => Assert.True(File.Exists(file))); // Check if each file exists
            Assert.All(files, file => Assert.Contains(directoryPath, file)); // Check if each file is within the specified directory
        }


        [Fact]
        public void GivenExistingFileAndNewFileName_WhenRenamingFile_ThenOldFileIsRenamedToNewFile()
        {
            // Arrange
            var oldFile = @"C:\Users\HP\Desktop\MyDirectory\FileOne.txt"; //Enter valid directory path

            var newFile = @"C:\Users\HP\Desktop\MyDirectory\File_v1.txt"; //Enter valid directory path

            // Act
            RenameSingleFileInFolder.RenameFileInDirectory();

            // Assert
            Assert.True(File.Exists(newFile));
            Assert.False(File.Exists(oldFile));
        }


        [Fact]
        public void GivenPhotos_WhenRenamedByCreationTime_ThenHaveCorrectNames()
        {
            // Arrange
            var directoryPath = @"C:\Users\HP\Desktop\MyDirectory2"; //Enter valid directory path

            string[] allowedExtensions = { ".jpg", ".png", ".jpeg", ".gif" };

            // Act
            BatchRenameFiles.RenamePhotosWithDateTime();

            // Assert
            var photoFiles = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories)
                                     .Where(file => allowedExtensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
                                     .ToList();

            foreach (var photoFile in photoFiles)
            {
                // Get the expected filename based on the file's creation time
                var creationTime = File.GetCreationTime(photoFile);
                var expectedFileName = $"Image_{creationTime:yyyy-MM-dd_HHmmss}{Path.GetExtension(photoFile)}";

                // Check if the actual filename matches the expected format
                Assert.True(Path.GetFileName(photoFile) == expectedFileName, $"File '{photoFile}' has incorrect name '{Path.GetFileName(photoFile)}'. Expected: '{expectedFileName}'");
            }
        }



        [Fact]
        public void GivenPhotos_WhenRenamedByCreationTimeWithErrorsHandled_ThenHaveCorrectNames()
        {
            // Arrange
            var directoryPath = @"C:\Users\HP\Desktop\MyDirectory2"; //Enter valid directory path

            string[] allowedExtensions = { ".jpg", ".png", ".jpeg", ".gif" };

            // Act
            BatchRenameFileWithErrorHandling.RenamePhotosWithDateTime();

            // Assert
            var photoFiles = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories)
                                     .Where(file => allowedExtensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
                                     .ToList();

            foreach (var photoFile in photoFiles)
            {
                // Get the expected filename based on the file's creation time
                var creationTime = File.GetCreationTime(photoFile);
                var expectedFileName = $"Image_{creationTime:yyyy-MM-dd_HHmmss}{Path.GetExtension(photoFile)}";

                // Check if the actual filename matches the expected format
                Assert.True(Path.GetFileName(photoFile) == expectedFileName, $"File '{photoFile}' has incorrect name '{Path.GetFileName(photoFile)}'. Expected: '{expectedFileName}'");
            }
        }


    }
}
