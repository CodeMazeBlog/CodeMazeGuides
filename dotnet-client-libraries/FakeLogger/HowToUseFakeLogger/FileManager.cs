using Microsoft.Extensions.Logging;

namespace HowToUseFakeLogger;

public class FileManager(ILogger logger)
{
    public string ReadFile(string fileName)
    {
        try
        {
            var extension = Path.GetExtension(fileName);
            var allowedExtensions = new string[] { ".pdf", ".txt" };

            if (!allowedExtensions.Contains(extension))
            {
                logger.LogWarning("Invalid extension");
                return string.Empty;
            }

            logger.LogInformation("Reading file: {FileName}", fileName);

            var filePath = Path.Combine("./files/", fileName);
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else
            {
                throw new FileNotFoundException("File not found.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred");
            return string.Empty;
        }
    }
}
