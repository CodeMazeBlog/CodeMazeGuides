using System.IO.Abstractions.TestingHelpers;
using FileSystemMocking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class FileStatsUtilityUnitTest
{
    private MockFileSystem _fileSystem = null!;
    private FileStatsUtility _util = null!;

    [TestInitialize]
    public void TestSetup() 
    {
        _fileSystem = new MockFileSystem();
        _util = new FileStatsUtility(_fileSystem);
    }

    [TestMethod]
    public void GivenNonExistingPath_WhenWriteFileStats_ThrowFileNotFound()
    {
        var path = Path.Combine("not", "available");

        Assert.ThrowsException<FileNotFoundException>(() => 
            _util.WriteFileStats(path, Path.Combine("out_dir", "not_available.txt")));
    }

    [TestMethod]
    public void GivenExistingFileInCurrentDir_WhenWriteFileStats_WriteStatsInCurrentDir()
    {
        var fileContent = $"3 lines{Environment.NewLine}6 words{Environment.NewLine}24 bytes";
        var fileData = new MockFileData(fileContent);
        _fileSystem.AddFile("file.txt", fileData);

        _util.WriteFileStats("file.txt", "file_stats.txt");

        var outFileData = _fileSystem.GetFile("file_stats.txt");
        Assert.AreEqual("3 6 24", outFileData.TextContents);
    }

    [TestMethod]
    public void GivenExistingFileInInputDir_WhenWriteFileStats_WriteStatsInOutputDir()
    {
        var fileContent = $"3 lines{Environment.NewLine}6 words{Environment.NewLine}24 bytes";
        var fileData = new MockFileData(fileContent);
        var inFilePath = Path.Combine("in_dir", "file.txt");
        var outFilePath = Path.Combine("out_dir", "file_stats.txt");
        _fileSystem.AddDirectory("in_dir");
        _fileSystem.AddDirectory("out_dir");
        _fileSystem.AddFile(inFilePath, fileData);

        _util.WriteFileStats(inFilePath, outFilePath);

        var outFileData = _fileSystem.GetFile(outFilePath);
        Assert.AreEqual("3 6 24", outFileData.TextContents);
    }
}