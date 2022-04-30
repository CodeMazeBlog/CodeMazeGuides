using CopyAllContentInDirectory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO.Abstractions.TestingHelpers;

namespace CopyAllContentInDirectoryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WhenRunningMain_ThenDirectoryDeepCopyOccurs()
        {
            var mockFileSystem = new MockFileSystem();

            Program.sourceDir = "C:\\Source";
            Program.destinationDir = "C:\\Destination";
            Program.fileSystem = mockFileSystem;

            mockFileSystem.AddDirectory("C:\\Source");
            mockFileSystem.AddDirectory("C:\\Destination");
            mockFileSystem.AddDirectory("C:\\Source\\ChildDir");
            mockFileSystem.AddDirectory("C:\\Source\\ChildDir\\ChildOfChildDir");

            mockFileSystem.AddFile("C:\\Source\\ChildDir\\childfile.txt", new MockFileData("childfile"));
            mockFileSystem.AddFile("C:\\Source\\ChildDir\\ChildOfChildDir\\childofchildfile.txt", new MockFileData("childofchildfile"));

            Program.Main();

            Assert.IsTrue(mockFileSystem.AllDirectories.Contains("C:\\Destination"));
            Assert.IsTrue(mockFileSystem.AllDirectories.Contains("C:\\Destination\\ChildDir"));
            Assert.IsTrue(mockFileSystem.AllDirectories.Contains("C:\\Destination\\ChildDir\\ChildOfChildDir"));
            
            Assert.IsTrue(mockFileSystem.FileExists("C:\\Destination\\ChildDir\\childfile.txt"));
            Assert.IsTrue(mockFileSystem.FileExists("C:\\Destination\\ChildDir\\ChildOfChildDir\\childofchildfile.txt"));
        }
    }
}