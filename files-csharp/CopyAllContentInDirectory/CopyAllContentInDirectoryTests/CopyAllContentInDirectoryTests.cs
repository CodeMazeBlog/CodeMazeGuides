using CopyAllContentInDirectory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO.Abstractions.TestingHelpers;
using System.Runtime.InteropServices;
using System.IO;
using System;

namespace CopyAllContentInDirectoryTests
{
    [TestClass]
    public class CopyAllContentInDirectoryTests
    {
        [TestMethod]
        public void GivenRunningOnWindows_WhenRunningMain_ThenDirectoryDeepCopyOccurs()
        {
            var mockFileSystem = new MockFileSystem();

            // Requires a using statement for System.Runtime.InteropServices;
            bool isExecutingOnWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if (!isExecutingOnWindows)
            {
                Assert.Inconclusive();
            }

            Program.SourceDir = "C:\\Source";
            Program.DestinationDir = "C:\\Destination";
            Program.FileSystem = mockFileSystem;

            mockFileSystem.AddDirectory("C:\\Source");
            mockFileSystem.AddDirectory("C:\\Destination");
            mockFileSystem.AddDirectory("C:\\Source\\ChildDir");
            mockFileSystem.AddDirectory("C:\\Source\\ChildDir\\ChildOfChildDir");

            mockFileSystem.AddFile("C:\\Source\\ChildDir\\childfile.txt", new MockFileData("childfile"));
            mockFileSystem.AddFile("C:\\Source\\ChildDir\\ChildOfChildDir\\childofchildfile.txt", new MockFileData("childofchildfile"));


            Program.Main();

            Assert.IsTrue(mockFileSystem.AllDirectories.Contains("C:\\Destination\\ChildDir\\ChildOfChildDir"));

            Assert.IsTrue(mockFileSystem.FileExists("C:\\Destination\\ChildDir\\childfile.txt"));
            Assert.IsTrue(mockFileSystem.FileExists("C:\\Destination\\ChildDir\\ChildOfChildDir\\childofchildfile.txt"));
        }

        [TestMethod]
        public void GivenRunningOnLinux_WhenRunningMain_ThenDirectoryDeepCopyOccurs()
        {
            var mockFileSystem = new MockFileSystem();
            bool isExecutingOnLinuxOS = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

            if (!isExecutingOnLinuxOS)
            {
                Assert.Inconclusive();
            }

            Program.SourceDir = "/Source";
            Program.DestinationDir = "/Destination";
            Program.FileSystem = mockFileSystem;

            mockFileSystem.AddDirectory("/Source");
            mockFileSystem.AddDirectory("/Destination");
            mockFileSystem.AddDirectory("/Source/ChildDir");
            mockFileSystem.AddDirectory("/Source/ChildDir/ChildOfChildDir");

            mockFileSystem.AddFile("/Source/ChildDir/childfile.txt", new MockFileData("childfile"));
            mockFileSystem.AddFile("/Source/ChildDir/ChildOfChildDir/childofchildfile.txt", new MockFileData("childofchildfile"));

            Program.Main();

            Assert.IsTrue(mockFileSystem.AllDirectories.Contains("/Destination/ChildDir/ChildOfChildDir"));

            Assert.IsTrue(mockFileSystem.FileExists("/Destination/ChildDir/childfile.txt"));
            Assert.IsTrue(mockFileSystem.FileExists("/Destination/ChildDir/ChildOfChildDir/childofchildfile.txt"));
        }

        [TestMethod]
        public void GivenDirectoryDoesNotExistOnWindows_WhenRunningMain_ThenExceptionIsThrown()
        {
            var mockFileSystem = new MockFileSystem();

            bool isExecutingOnWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if (!isExecutingOnWindows)
            {
                Assert.Inconclusive();
            }

            Program.SourceDir = "C:\\Source";
            Program.DestinationDir = "C:\\Destination";
            Program.FileSystem = mockFileSystem;

            Assert.ThrowsException<DirectoryNotFoundException>(() =>
            {
                Program.Main();
            });
        }

        [TestMethod]
        public void GivenDirectoryDoesNotExistOnLinux_WhenRunningMain_ThenExceptionIsThrown()
        {
            var mockFileSystem = new MockFileSystem();

            bool isExecutingOnLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

            if (!isExecutingOnLinux)
            {
                Assert.Inconclusive();
            }

            Program.SourceDir = "/Source";
            Program.DestinationDir = "/Destination";
            Program.FileSystem = mockFileSystem;

            Assert.ThrowsException<DirectoryNotFoundException>(() => 
            {
                Program.Main();
            });
        }

        [TestMethod]
        public void GivenFilePathIsInvalidOnWindows_WhenRunningMain_ThenExceptionIsThrown()
        {
            var mockFileSystem = new MockFileSystem();

            bool isExecutingOnWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if (!isExecutingOnWindows)
            {
                Assert.Inconclusive();
            }

            Program.SourceDir = "<>";
            Program.DestinationDir = "C:\\Destination";

            mockFileSystem.AddDirectory("C:\\Source");
            mockFileSystem.AddDirectory("C:\\Destination");
            mockFileSystem.AddFile("C:\\Source\\text.txt", new MockFileData("childfile"));

            Program.FileSystem = mockFileSystem;

            Assert.ThrowsException<ArgumentException>(() =>
            {
                Program.Main();
            });
        }
    }
}