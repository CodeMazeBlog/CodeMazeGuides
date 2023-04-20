using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using UploadingLargeFiles.DTO;

namespace UploadingLargeFiles.Services
{
    public class FileService : IFileService
    {
        private const string UploadsSubDirectory = "FilesUploaded";

        private readonly IEnumerable<string> allowedExtensions = new List<string> { ".zip", ".bin", ".png", ".jpg" };

        public async Task<FileUploadSummary> UploadFileAsync(Stream fileStream, string contentType)
        {
            var fileCount = 0;
            long totalSizeInBytes = 0;

            var boundary = GetBoundary(MediaTypeHeaderValue.Parse(contentType));
            var multipartReader = new MultipartReader(boundary, fileStream);
            var section = await multipartReader.ReadNextSectionAsync();

            var filePaths = new List<string>();
            var notUploadedFiles = new List<string>();
            while (section != null)
            {
                var fileSection = section.AsFileSection();
                if (fileSection != null)
                {
                    totalSizeInBytes += await SaveFileAsync(fileSection, filePaths, notUploadedFiles);
                    fileCount++;
                }

                section = await multipartReader.ReadNextSectionAsync();
            }

            return new FileUploadSummary
            {
                TotalFilesUploaded = fileCount,
                TotalSizeUploaded = ConvertSizeToString(totalSizeInBytes),
                FilePaths = filePaths,
                NotUploadedFiles = notUploadedFiles
            };
        }

        private async Task<long> SaveFileAsync(FileMultipartSection fileSection, IList<string> filePaths, IList<string> notUploadedFiles)
        {
            var extension = Path.GetExtension(fileSection.FileName);
            if (!allowedExtensions.Contains(extension))
            {
                notUploadedFiles.Add(fileSection.FileName);
                return 0;
            }

            Directory.CreateDirectory(UploadsSubDirectory);

            var filePath = Path.Combine(UploadsSubDirectory, fileSection?.FileName);

            await using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 1024);
            await fileSection.FileStream?.CopyToAsync(stream);

            filePaths.Add(GetFullFilePath(fileSection));

            return fileSection.FileStream.Length;
        }

        private string GetFullFilePath(FileMultipartSection fileSection)
        {
            return !string.IsNullOrEmpty(fileSection.FileName)
                ? Path.Combine(Directory.GetCurrentDirectory(), UploadsSubDirectory, fileSection.FileName)
                : string.Empty;
        }

        private string ConvertSizeToString(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            return fileSize switch
            {
                _ when fileSize < kilobyte => "Less then 1KB",
                _ when fileSize < megabyte =>
                    $"{Math.Round(fileSize / kilobyte, fileSize < 10 * kilobyte ? 2 : 1, MidpointRounding.AwayFromZero):##,###.##}KB",
                _ when fileSize < gigabyte =>
                    $"{Math.Round(fileSize / megabyte, fileSize < 10 * megabyte ? 2 : 1, MidpointRounding.AwayFromZero):##,###.##}MB",
                _ when fileSize >= gigabyte =>
                    $"{Math.Round(fileSize / gigabyte, fileSize < 10 * gigabyte ? 2 : 1, MidpointRounding.AwayFromZero):##,###.##}GB",
                _ => "n/a"
            };
        }

        private string GetBoundary(MediaTypeHeaderValue contentType)
        {
            var boundary = HeaderUtilities.RemoveQuotes(contentType.Boundary).Value;

            if (string.IsNullOrWhiteSpace(boundary))
            {
                throw new InvalidDataException("Missing content-type boundary.");
            }

            return boundary;
        }
    }
}
