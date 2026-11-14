using HowToConvertAStreamToAFileInCSharp;

namespace Tests;

[TestClass]
public class ConvertAStreamToAFileInCSharpTests
{
    private static readonly string FilesPath = Path.Combine(AppContext.BaseDirectory, "Files");
    private static readonly string SourceFile = Path.Combine(FilesPath, "source.png");

    [TestMethod]
    public void WhenCopyToFile_ThenFileHasTheSourceBytes()
    {
        var path = Path.Combine(FilesPath, "CopyTo.png");
        using var memoryStream = GetMemoryStream();

        ConvertAStreamToAFileInCSharp.CopyToFile(memoryStream, path);

        CollectionAssert.AreEqual(File.ReadAllBytes(SourceFile), File.ReadAllBytes(path));
    }

    [TestMethod]
    public async Task WhenCopyToFileAsync_ThenFileHasTheSourceBytes()
    {
        var path = Path.Combine(FilesPath, "CopyToAsync.png");
        using var memoryStream = GetMemoryStream();

        await ConvertAStreamToAFileInCSharp.CopyToFileAsync(memoryStream, path);

        CollectionAssert.AreEqual(File.ReadAllBytes(SourceFile), File.ReadAllBytes(path));
    }

    [TestMethod]
    public void WhenWriteToFile_ThenFileHasTheSourceBytes()
    {
        var path = Path.Combine(FilesPath, "WriteTo.png");
        using var memoryStream = GetMemoryStream();

        ConvertAStreamToAFileInCSharp.WriteToFileStream(memoryStream, path);

        CollectionAssert.AreEqual(File.ReadAllBytes(SourceFile), File.ReadAllBytes(path));
    }

    [TestMethod]
    public void WhenWriteByteToFile_ThenFileHasTheSourceBytes()
    {
        var path = Path.Combine(FilesPath, "WriteByte.png");
        using var memoryStream = GetMemoryStream();

        ConvertAStreamToAFileInCSharp.WriteByteToFileStream(memoryStream, path);

        CollectionAssert.AreEqual(File.ReadAllBytes(SourceFile), File.ReadAllBytes(path));
    }

    [TestMethod]
    public void WhenWriteAllBytesToFile_ThenFileHasTheSourceBytes()
    {
        var path = Path.Combine(FilesPath, "WriteAllBytes.png");
        using var memoryStream = GetMemoryStream();

        ConvertAStreamToAFileInCSharp.WriteAllBytesFile(memoryStream, path);

        CollectionAssert.AreEqual(File.ReadAllBytes(SourceFile), File.ReadAllBytes(path));
    }

    [TestMethod]
    public void GivenAStreamAtItsEnd_WhenCopyToWithoutRewinding_ThenFileIsEmpty()
    {
        var path = Path.Combine(FilesPath, "NoRewind.png");
        using var memoryStream = GetMemoryStream();
        Assert.AreEqual(memoryStream.Length, memoryStream.Position);

        using (var fileStream = File.Create(path))
        {
            memoryStream.CopyTo(fileStream);
        }

        Assert.AreEqual(0, new FileInfo(path).Length);
    }

    [TestMethod]
    public void WhenCopyTo_ThenBothPositionsEndAfterTheCopiedBytes()
    {
        using var memoryStream = GetMemoryStream();
        memoryStream.Position = 0;
        using var destination = new MemoryStream();

        memoryStream.CopyTo(destination);

        Assert.AreEqual(memoryStream.Length, memoryStream.Position);
        Assert.AreEqual(memoryStream.Length, destination.Position);
    }

    private static MemoryStream GetMemoryStream()
    {
        using var fileStream = new FileStream(SourceFile, FileMode.Open, FileAccess.Read);
        var memoryStream = new MemoryStream();
        fileStream.CopyTo(memoryStream);

        return memoryStream;
    }
}
