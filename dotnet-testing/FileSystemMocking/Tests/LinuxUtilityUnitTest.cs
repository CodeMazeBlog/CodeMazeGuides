using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using FileSystemMocking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class LinuxUtilityUnitTest
{
    private MockFileSystem fileSystem;
    private LinuxUtility util;

    [TestInitialize]
    public void TestSetup() 
    {
        this.fileSystem = new MockFileSystem();
        this.util = new LinuxUtility(this.fileSystem);
    }

    [TestMethod]
    public void GivenNonExistingPath_WhenWcRun_ThrowFileNotFound()
    {
        var path = Path.Combine("not", "available");

        Assert.ThrowsException<FileNotFoundException>(() => 
            this.util.Wc(path, Path.Combine("out_dir", "not_available.txt")));
    }

    [TestMethod]
    public void GivenExistingFileInCurrentDir_WhenWcRun_WriteStatsInCurrentDir()
    {
        var fileContent = "3 lines\n6 words\n24 bytes";
        var fileData = new MockFileData(fileContent);
        this.fileSystem.AddFile("file.txt", fileData);

        this.util.Wc("file.txt", "file_stats.txt");

        var outFileData = this.fileSystem.GetFile("file_stats.txt");
        Assert.AreEqual("3 6 24", outFileData.TextContents);
    }

    [TestMethod]
    public void GivenExistingFileInInputDir_WhenWcRun_WriteStatsInOutputDir()
    {
        var fileContent = "3 lines\n6 words\n24 bytes";
        var fileData = new MockFileData(fileContent);
        var inFilePath = Path.Combine("in_dir", "file.txt");
        var outFilePath = Path.Combine("out_dir", "file_stats.txt");
        this.fileSystem.AddDirectory("in_dir");
        this.fileSystem.AddDirectory("out_dir");
        this.fileSystem.AddFile(inFilePath, fileData);

        this.util.Wc(inFilePath, outFilePath);

        var outFileData = this.fileSystem.GetFile(outFilePath);
        Assert.AreEqual("3 6 24", outFileData.TextContents);
    }
}