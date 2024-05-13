using Microsoft.Extensions.Logging;

namespace HowToUseFakeLogger;

public class FileManager(ILogger _logger)
{
    public string ReadFile(string fileName)
    {
        try
        {
            var extension = Path.GetExtension(fileName);
            var allowedExtensions = new string[] { ".pdf", ".txt" };

            if (!allowedExtensions.Contains(extension))
            {
                _logger.LogWarning("Invalid extension");
                return string.Empty;
            }

            _logger.LogInformation("Reading file: {FileName}", fileName);

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
            _logger.LogError(ex, "Error occurred");
            return string.Empty;
        }
    }
}
