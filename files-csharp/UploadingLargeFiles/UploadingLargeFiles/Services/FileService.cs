using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using UploadingLargeFiles.DTO;

namespace UploadingLargeFiles.Services
{
    public class FileService : IFileService
    {
        private const string SubDirectory = "FilesUploaded";

        public async Task<FileUploadSummary> UploadFileAsync(Stream files, string contentType)
        {
            var count = 0;
            var totalSize = 0L;
            var boundary = GetBoundary(MediaTypeHeaderValue.Parse(contentType));
            var reader = new MultipartReader(boundary, files);
            var section = await reader.ReadNextSectionAsync();
            do
            {
                var fileSection = section?.AsFileSection();
                if (fileSection != null)
                {
                    totalSize += await SaveFileAsync(fileSection);
                    count++;
                }

                section = await reader.ReadNextSectionAsync();
            } while (section != null);

            var result = new FileUploadSummary
            {
                TotalFilesUploaded = count, 
                TotalSizeUploaded = SizeConverter(totalSize)
            };

            return await Task.FromResult(result);
        }

        private async Task<long> SaveFileAsync(FileMultipartSection fileSection)
        {
            Directory.CreateDirectory(SubDirectory);

            var filePath = Path.Combine(SubDirectory, fileSection?.FileName);

            await using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 1024);
            await fileSection.FileStream?.CopyToAsync(stream)!;

            return fileSection.FileStream.Length;
        } 

        private string SizeConverter(long bytes)
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
