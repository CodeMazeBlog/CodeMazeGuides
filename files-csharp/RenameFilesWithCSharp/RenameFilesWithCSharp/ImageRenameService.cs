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

            var baseName = $"Image_{creationTime:yyyy-MM-dd_HHmmss}";

            var newFilePath = Path.Combine(directoryPath, $"{baseName}{fileExtension}");

            for (var copy = 1; File.Exists(newFilePath) && newFilePath != imageFile; copy++)
            {
                newFilePath = Path.Combine(directoryPath, $"{baseName}_{copy}{fileExtension}");
            }

            File.Move(imageFile, newFilePath);
        }
    }

    public static void RenameImagesWithDateTimeUsingFileInfo(string directoryPath)
    {
        var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".gif" };

        var imageFiles = Directory.EnumerateFiles(directoryPath)
            .Where(file => allowedExtensions.Contains(Path.GetExtension(file),
                                StringComparer.OrdinalIgnoreCase));

        foreach (var imageFile in imageFiles)
        {
            var file = new FileInfo(imageFile);

            var creationTime = file.CreationTime;

            var fileExtension = file.Extension;

            var baseName = $"Image_{creationTime:yyyy-MM-dd_HHmmss}";

            var newFilePath = Path.Combine(directoryPath, $"{baseName}{fileExtension}");

            for (var copy = 1; File.Exists(newFilePath) && newFilePath != imageFile; copy++)
            {
                newFilePath = Path.Combine(directoryPath, $"{baseName}_{copy}{fileExtension}");
            }

            file.MoveTo(newFilePath);
        }
    }
}
