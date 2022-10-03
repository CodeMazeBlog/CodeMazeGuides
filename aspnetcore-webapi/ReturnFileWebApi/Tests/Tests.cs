using Moq;
using ReturnFileWebApi.Assets;
using ReturnFileWebApi.Controllers;
using ReturnFileWebApi.Interface;

namespace Tests
{
    public class Tests
    {
        private readonly Mock<IFileService> _fileServiceMock;

        public Tests()
        {
            _fileServiceMock = new();

            SetupMocks();
        }

        private void SetupMocks()
        {
            _fileServiceMock.Setup(x => x.GetImageAsByteArray())
                .Returns(Convert.FromBase64String(Image.Base64Image))
                .Verifiable();

            _fileServiceMock.Setup(x => x.GetImageAsStream())
                .Returns(new MemoryStream(Convert.FromBase64String(Image.Base64Image)))
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