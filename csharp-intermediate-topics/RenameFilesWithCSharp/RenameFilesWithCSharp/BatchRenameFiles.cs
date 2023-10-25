namespace RenameFilesWithCSharp
{
    public class BatchRenameFiles
    {
        public static void RenamePhotosWithDateTime(string directoryPath)
        {

            // An array of allowed file extensions.
            string[] allowedExtensions = { ".jpg", ".png", ".jpeg", ".gif" };

            // Gets a list of all the photo files in the specified directory and its subdirectories, filtering out files with other extensions.
            var photoFiles = Directory.GetFiles(directoryPath)
                                    .Where(file => allowedExtensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
                                    .ToList();

            // Iterates over the list of photo files and renames each file using its creation time and the desired file extension.
            foreach (var photoFile in photoFiles)
            {
                // Gets the creation time of the photo file.
                DateTime creationTime = File.GetCreationTime(photoFile);

                // Gets the file extension of the photo file.
                var fileExtension = Path.GetExtension(photoFile);

                // Creates the new file name.
                var newFileName = $"Image_{creationTime:yyyy-MM-dd_HHmmss}{fileExtension}";

                // Creates the new file path.
                var newFilePath = Path.Combine(directoryPath, newFileName);

                // Renames the photo file to the new file path.
                File.Move(photoFile, newFilePath);
            }
        }

    }
}
