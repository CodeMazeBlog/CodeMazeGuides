namespace FileUploadValidation
{
    public static class FileValidator
    {
        public static bool IsFileExtensionAllowed(IFormFile file, string[] allowedExtensions)
        {
            var extension = Path.GetExtension(file.FileName);

            return allowedExtensions.Contains(extension);
        }

        public static bool IsFileSizeWithinLimit(IFormFile file, long maxSizeInBytes)
        {
            return file.Length <= maxSizeInBytes;
        }

        public static bool FileWithSameNameExists(IFormFile fileName)
        {
            // Implement logic to check if a file with the same name exists in the system
            return false;
        }
    }
}
