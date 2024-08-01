using System.Reflection;
using HowToConvertAStreamToAFileInCSharp;

namespace Tests;

[TestClass]
public class ConvertAStreamToAFileInCSharpTests
{
    [TestMethod]
    public void WhenCopyToFile_FileExists()
    {
        var destinationPath = GetPath();
        var memoryStream = GetMemoryStream();
        ConvertAStreamToAFileInCSharp.CopyToFile(memoryStream, Path.Combine([destinationPath, "CopyTo.png"]));

        Assert.IsTrue(File.Exists(Path.Combine([destinationPath, "CopyTo.png"])));
    }

    [TestMethod]
    public void WhenWriteToFile_FileExists()
    {
        var destinationPath = GetPath();
        var memoryStream = GetMemoryStream();
        ConvertAStreamToAFileInCSharp.WriteToFileStream(memoryStream, Path.Combine([destinationPath, "WriteTo.png"]));

        Assert.IsTrue(File.Exists(Path.Combine([destinationPath, "WriteTo.png"])));
    }

    [TestMethod]
    public void WhenWriteByteToFile_FileExists()
    {
        var destinationPath = GetPath();
        var memoryStream = GetMemoryStream();
        ConvertAStreamToAFileInCSharp.WriteByteToFileStream(memoryStream, Path.Combine([destinationPath, "WriteByte.png"]));

        Assert.IsTrue(File.Exists(Path.Combine([destinationPath, "WriteByte.png"])));
    }

    [TestMethod]
    public void WhenWriteAllBytesToFile_FileExists()
    {
        var destinationPath = GetPath();
        var memoryStream = GetMemoryStream();
        ConvertAStreamToAFileInCSharp.WriteAllBytesFile(memoryStream, Path.Combine([destinationPath, "WriteAllBytes.png"]));

        Assert.IsTrue(File.Exists(Path.Combine([destinationPath, "WriteAllBytes.png"])));
    }

    private string GetPath()
    {
        var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!Directory.Exists(directory))
        {
            return string.Empty;
        }

        var destinationPath = Path.Combine([directory, "Files"]);

        return destinationPath;
    }

    private MemoryStream GetMemoryStream()
    {
        var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!Directory.Exists(directory))
        {
            return null!;
        }

        var sourceFile = Path.Combine([directory, "Files", "source.png"]);

        using var fileStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
        var memoryStream = new MemoryStream();
        fileStream.CopyTo(memoryStream);

        return memoryStream;
    }
}