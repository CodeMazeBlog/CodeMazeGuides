using Moq;
using ReturnFileWebApi.Controllers;
using ReturnFileWebApi.Interface;

namespace Tests
{
    public class Tests
    {
        private const string _base64Image = "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";
        private Mock<IFileService> _fileServiceMock;

        public Tests()
        {
            _fileServiceMock = new();

            SetupMocks();
        }

        private void SetupMocks()
        {
            _fileServiceMock.Setup(x => x.GetImageAsByteArray())
                .Returns(Convert.FromBase64String(_base64Image))
                .Verifiable();

            _fileServiceMock.Setup(x => x.GetImageAsStream())
                .Returns(new MemoryStream(Convert.FromBase64String(_base64Image)))
                .Verifiable();
        }

        [Fact]
        public void GivenAnImagesbyteRoute_WhenUsingByteArray_ThenReturnAFileToDownload()
        {
            var controller = new DownloadsController(_fileServiceMock.Object);

            var image = controller.ReturnByteArray();

            Assert.NotNull(image);
        }

        [Fact]

        public void GivenAnImagesStreamRoute_WhenUsingStream_ThenReturnAFileToDownload()
        {
            var controller = new DownloadsController(_fileServiceMock.Object);

            var image = controller.ReturnStream();

            Assert.NotNull(image);
        }
    }
}