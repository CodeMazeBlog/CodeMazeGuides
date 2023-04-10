using UploadingLargeFiles.DTO;

namespace UploadingLargeFiles.Services
{
    public interface IFileService
    {
        Task<FileUploadSummary> UploadFileAsync(Stream files, string contentType);
    }
}
