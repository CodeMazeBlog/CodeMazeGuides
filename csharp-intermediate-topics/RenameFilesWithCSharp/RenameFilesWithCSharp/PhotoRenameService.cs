namespace RenameFilesWithCSharp;

public static class PhotoRenameService
{
    public static void RenamePhotosWithDateTime(string directoryPath)
    {
        var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".gif" };

        // Gets a list of all the photo files in the specified directory and its subdirectories, filtering out files with other extensions.
        var photoFiles = Directory.EnumerateFiles(directoryPath)
            .Where(file => allowedExtensions.Contains(Path.GetExtension(file),
                                StringComparer.OrdinalIgnoreCase));

        foreach (var photoFile in photoFiles)
        {
            var creationTime = File.GetCreationTime(photoFile);

            var fileExtension = Path.GetExtension(photoFile);

            var newFileName = $"Image_{creationTime:yyyy-MM-dd_HHmmss}{fileExtension}";

            var newFilePath = Path.Combine(directoryPath, newFileName);

            File.Move(photoFile, newFilePath);
        }
    }
}