namespace FileUploadValidation
{
    public static class FileValidator
    {
        public static bool IsFileExtensionAllowed(string fileName, string[] allowedExtensions)
        {
            var extension = Path.GetExtension(fileName);

            return allowedExtensions.Contains(extension);
        }

        public static bool IsFileSizeWithinLimit(IFormFile file, long maxSizeInBytes)
        {
            return file.Length <= maxSizeInBytes;
        }

        public static bool FileWithSameNameExists(string fileName)
        {
            return false;
        }
    }
}
