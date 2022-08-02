using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using DownloadMultipleAzure;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class MultipleDownloadExamplesTest
    {
        [Fact]
        public async Task GivenMultipleFilesSetup_WhenFilesAreDownloadUsingParallelForEachAsync_ThenAllMethodsAreCalled()
        {
            // Given
            var mockContainerName = "mock-container";

            var mockRepository = new MockRepository(MockBehavior.Strict);
            var mockBlobServiceClient = MockSetup(mockRepository);

            var multipleDownloadExamples = new MultipleDownloadExamples(mockBlobServiceClient.Object);

            // When
            await multipleDownloadExamples.DownloadMultipleFilesUsingParallelForEachAsync(mockContainerName);

            // Then
            mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GivenMultipleFilesSetup_WhenFilesAreDownloadUsingSemaphoreSlim_ThenAllMethodsAreCalled()
        {
            // Given
            var mockContainerName = "mock-container";

            var mockRepository = new MockRepository(MockBehavior.Strict);
            var mockBlobServiceClient = MockSetup(mockRepository);

            var multipleDownloadExamples = new MultipleDownloadExamples(mockBlobServiceClient.Object);

            // When
            await multipleDownloadExamples.DownloadMultipleFilesUsingSemaphoreSlim(mockContainerName);

            // Then
            mockRepository.VerifyAll();
        }

        private static Mock<BlobServiceClient> MockSetup(MockRepository mockRepository)
        {
            var mockBlobServiceClient = mockRepository.Create<BlobServiceClient>();
            var mockContainerClient = mockRepository.Create<BlobContainerClient>();
            var mockPageableBlobItem = mockRepository.Create<AsyncPageable<BlobItem>>();
            var mockPages = mockRepository.Create<IAsyncEnumerable<Page<BlobItem>>>();
            var mockEnumerator = mockRepository.Create<IAsyncEnumerator<Page<BlobItem>>>();

            mockEnumerator.Setup(x => x.MoveNextAsync())
                .Returns(new System.Threading.Tasks.ValueTask<bool>());

            mockEnumerator.Setup(x => x.DisposeAsync())
                .Returns(new System.Threading.Tasks.ValueTask());

            mockPages.Setup(x => x.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
                .Returns(mockEnumerator.Object);

            mockPageableBlobItem.Setup(x => x.AsPages(It.IsAny<string?>(), It.IsAny<int?>()))
                .Returns(mockPages.Object);

            mockContainerClient.Setup(x => x.GetBlobsAsync(It.IsAny<BlobTraits>(), It.IsAny<BlobStates>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(mockPageableBlobItem.Object);

            mockBlobServiceClient.Setup(x => x.GetBlobContainerClient(It.IsAny<string>()))
                .Returns(mockContainerClient.Object);

            return mockBlobServiceClient;
        }
    }
}