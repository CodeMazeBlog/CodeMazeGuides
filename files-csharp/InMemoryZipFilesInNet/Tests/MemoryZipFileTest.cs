namespace Tests;

[TestClass]
public class MemoryZipFileTest
{
    [TestMethod]
    public void GivenContent_WhenExecutingCreateZipFileInMemory_ThenExpectZipFile()
    {
        using Stream stream = MemoryZipFile.Create("content");

        AssertZipStreamContent(stream);
    }

    private static void AssertZipStreamContent(Stream stream)
    {
        Assert.IsNotNull(stream);

        using var archive = new ZipArchive(stream, ZipArchiveMode.Read);

        Assert.IsNotNull(archive);
    }
}