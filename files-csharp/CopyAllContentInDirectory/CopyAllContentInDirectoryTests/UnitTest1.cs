using CopyAllContentInDirectory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO.Abstractions.TestingHelpers;
using System.Runtime.InteropServices;

namespace CopyAllContentInDirectoryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WhenRunningMain_ThenDirectoryDeepCopyOccurs()
        {
            var mockFileSystem = new MockFileSystem();

            // Requires a using statement for System.Runtime.InteropServices;
            bool isExecutingOnWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            bool isExecutingOnLinuxOS = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

            if (isExecutingOnWindows)
            {
                Program.sourceDir = "C:\\Source";
                Program.destinationDir = "C:\\Destination";
                Program.fileSystem = mockFileSystem;

                mockFileSystem.AddDirectory("C:\\Source");
                mockFileSystem.AddDirectory("C:\\Destination");
                mockFileSystem.AddDirectory("C:\\Source\\ChildDir");
                mockFileSystem.AddDirectory("C:\\Source\\ChildDir\\ChildOfChildDir");

                mockFileSystem.AddFile("C:\\Source\\ChildDir\\childfile.txt", new MockFileData("childfile"));
                mockFileSystem.AddFile("C:\\Source\\ChildDir\\ChildOfChildDir\\childofchildfile.txt", new MockFileData("childofchildfile"));
            }
            else if (isExecutingOnLinuxOS)
            {
                Program.sourceDir = "/Source";
                Program.destinationDir = "/Destination";
                Program.fileSystem = mockFileSystem;

                mockFileSystem.AddDirectory("/Source");
                mockFileSystem.AddDirectory("/Destination");
                mockFileSystem.AddDirectory("/Source/ChildDir");
                mockFileSystem.AddDirectory("/Source/ChildDir/ChildOfChildDir");

                mockFileSystem.AddFile("/Source/ChildDir/childfile.txt", new MockFileData("childfile"));
                mockFileSystem.AddFile("/Source/ChildDir/ChildOfChildDir/childofchildfile.txt", new MockFileData("childofchildfile"));
            }

            Program.Main();

            if (isExecutingOnWindows)
            {
                Assert.IsTrue(mockFileSystem.AllDirectories.Contains("C:\\Destination"));
                Assert.IsTrue(mockFileSystem.AllDirectories.Contains("C:\\Destination\\ChildDir"));
                Assert.IsTrue(mockFileSystem.AllDirectories.Contains("C:\\Destination\\ChildDir\\ChildOfChildDir"));

                Assert.IsTrue(mockFileSystem.FileExists("C:\\Destination\\ChildDir\\childfile.txt"));
                Assert.IsTrue(mockFileSystem.FileExists("C:\\Destination\\ChildDir\\ChildOfChildDir\\childofchildfile.txt"));
            }
            else if (isExecutingOnLinuxOS)
            {
                Assert.IsTrue(mockFileSystem.AllDirectories.Contains("/Destination"));
                Assert.IsTrue(mockFileSystem.AllDirectories.Contains("/Destination/ChildDir"));
                Assert.IsTrue(mockFileSystem.AllDirectories.Contains("/Destination/ChildDir/ChildOfChildDir"));

                Assert.IsTrue(mockFileSystem.FileExists("/Destination/ChildDir/childfile.txt"));
                Assert.IsTrue(mockFileSystem.FileExists("/Destination/ChildDir/ChildOfChildDir/childofchildfile.txt"));
            }
        }
    }
}