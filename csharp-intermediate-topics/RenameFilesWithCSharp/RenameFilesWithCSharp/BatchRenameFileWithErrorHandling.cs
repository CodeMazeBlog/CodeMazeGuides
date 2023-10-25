namespace RenameFilesWithCSharp
{
    public class BatchRenameFileWithErrorHandling
    {
        public static void RenamePhotosWithDateTime(string directoryPath)
        {
            try
            {

                string[] allowedExtensions = { ".jpg", ".png", ".jpeg", ".gif" };

                var photoFiles = Directory.GetFiles(directoryPath)
                                        .Where(file => allowedExtensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
                                        .ToList();

                foreach (var photoFile in photoFiles)
                {
                    DateTime creationTime = File.GetCreationTime(photoFile);

                    var fileExtension = Path.GetExtension(photoFile);

                    var newFileName = $"Image_{creationTime:yyyy-MM-dd_HHmmss}{fileExtension}";

                    var newFilePath = Path.Combine(directoryPath, newFileName);

                    File.Move(photoFile, newFilePath);
                }
            }

            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        private static void HandleException(Exception ex)
        {
            switch (ex)
            {
                case UnauthorizedAccessException uaEx:
                    Console.WriteLine($"Unauthorized access: {uaEx.Message}");
                    break;
                case DirectoryNotFoundException dnEx:
                    Console.WriteLine($"Directory not found: {dnEx.Message}");
                    break;
                case FileNotFoundException fnEx:
                    Console.WriteLine($"File not found: {fnEx.Message}");
                    break;
                case IOException ioEx:
                    Console.WriteLine($"There was an error renaming file: {ioEx.Message}");
                    break;
                default:
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    break;
            }
        }
    }
}
