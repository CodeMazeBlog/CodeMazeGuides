namespace RenameFilesWithCSharp;

public static class ImageRenameService
{
    public static void RenameImagesWithDateTime(string directoryPath)
    {
        var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".gif" };

        var imageFiles = Directory.EnumerateFiles(directoryPath)
            .Where(file => allowedExtensions.Contains(Path.GetExtension(file),
                                StringComparer.OrdinalIgnoreCase));

        foreach (var imageFile in imageFiles)
        {
            var creationTime = File.GetCreationTime(imageFile);

            var fileExtension = Path.GetExtension(imageFile);

            var newFileName = $"Image_{creationTime:yyyy-MM-dd_HHmmss}{fileExtension}";

            var newFilePath = Path.Combine(directoryPath, newFileName);

            File.Move(imageFile, newFilePath);
        }
    }
}