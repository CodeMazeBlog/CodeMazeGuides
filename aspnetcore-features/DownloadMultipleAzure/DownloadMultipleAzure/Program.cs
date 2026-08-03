using Azure.Storage.Blobs;
using DownloadMultipleAzure;

var connectionString = "UseDevelopmentStorage=true";
var blobServiceClient = new BlobServiceClient(connectionString);

var multipleDownloadExamples = new MultipleDownloadExamples(blobServiceClient);

// Multiple download with parallel foreach async
await multipleDownloadExamples.DownloadMultipleFilesUsingParallelForEachAsync("multiple-files");

// Multiple download with semaphore slim and tasks
await multipleDownloadExamples.DownloadMultipleFilesUsingSemaphoreSlim("multiple-files");
