namespace Tests;

[TestClass]
public class GetZipFileTest
{
    [TestMethod]
    public void GivenZipService_WhenGettingContentType_ThenCorrectValue()
    {
        var sut = GetSut();

        var contentType = sut.ContentType;

        Assert.AreEqual("application/zip", contentType);
    }

    [TestMethod]
    public void GivenZipService_WhenExecutingGenerateOnFly_ThenExpectZipFile()
    {
        var sut = GetSut();

        Stream stream = sut.GenerateFileOnFlyReturnStream();

        AssertZipStreamContent(stream);
    }

    [TestMethod]
    public async Task GivenZipService_WhenExecutingGenerateOnFlyAsync_ThenExpectZipFile()
    {
        var sut = GetSut();

        Stream stream = await sut.GenerateFileOnFlyReturnStreamAsync();

        AssertZipStreamContent(stream);
    }

    [TestMethod]
    public void GivenZipService_WhenExecutingGenerateByteOnFly_ThenExpectZipFile()
    {
        var sut = GetSut();

        var byteArray = sut.GenerateFileOnFlyReturnBytes();

        Assert.IsNotNull(byteArray);
        var stream = new MemoryStream(byteArray);

        AssertZipStreamContent(stream);
    }

    private static GetZipFile GetSut()
    {
        return new GetZipFile(GetServices());
    }

    private static List<IService> GetServices()
    {
        return
        [
            new FileService(),
            new DbService(),
            new TimeService()
        ];
    }

    private static void AssertZipFileContent(string fileName)
    {
        Assert.IsNotNull(fileName);

        using var fileStream = File.OpenRead(fileName);
        using var archive = new ZipArchive(fileStream, ZipArchiveMode.Read);

        Assert.IsNotNull(archive);
    }

    private static void AssertZipStreamContent(Stream stream)
    {
        Assert.IsNotNull(stream);

        using var archive = new ZipArchive(stream, ZipArchiveMode.Read);

        Assert.IsNotNull(archive);
    }
}