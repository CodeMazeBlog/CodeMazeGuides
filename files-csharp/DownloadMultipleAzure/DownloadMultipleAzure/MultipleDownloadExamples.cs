using Azure.Storage.Blobs;

namespace DownloadMultipleAzure
{
    public class MultipleDownloadExamples
    {
        private readonly BlobServiceClient _blobServiceClient;

        public MultipleDownloadExamples(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task DownloadMultipleFilesUsingParallelForEachAsync(string containerName)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobPages = blobContainerClient.GetBlobsAsync().AsPages();

            await Parallel.ForEachAsync(blobPages, new ParallelOptions { MaxDegreeOfParallelism = 2 }, async (blobPage, token) =>
            {
                await Parallel.ForEachAsync(blobPage.Values, new ParallelOptions { MaxDegreeOfParallelism = 2 }, async (blob, token) =>
                {
                    var blobClient = blobContainerClient.GetBlobClient(blob.Name);
                    using var file = File.Create(blob.Name);
                    await blobClient.DownloadToAsync(file);
                });
            });
        }

        public async Task DownloadMultipleFilesUsingSemaphoreSlim(string containerName)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobPages = blobContainerClient.GetBlobsAsync().AsPages();

            var semaphore = new SemaphoreSlim(4);
            var tasks = new List<Task>();

            await foreach (var blobPage in blobPages)
            {
                foreach (var blob in blobPage.Values)
                {
                    await semaphore.WaitAsync();

                    tasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            var blobClient = blobContainerClient.GetBlobClient(blob.Name);
                            using var file = File.Create(blob.Name);
                            await blobClient.DownloadToAsync(file);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    }));
                }

                await Task.WhenAll(tasks);
                tasks.Clear();
            }
        }
    }
}
