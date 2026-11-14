using CopyAllContentInDirectory;
using CopyAllContentInDirectory.Extensions;
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

            Assert.ThrowsExactly<DirectoryNotFoundException>(() =>
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

            Assert.ThrowsExactly<DirectoryNotFoundException>(() => 
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

            Assert.ThrowsExactly<ArgumentException>(() =>
            {
                Program.Main();
            });
        }
        private static string Root => OperatingSystem.IsWindows() ? @"C:\" : "/";

        [TestMethod]
        public void GivenFolderNameStartsWithSourceName_WhenRunningMain_ThenNameIsKept()
        {
            var mockFileSystem = new MockFileSystem();
            Program.SourceDir = Path.Join(Root, "data");
            Program.DestinationDir = Path.Join(Root, "backup");
            Program.FileSystem = mockFileSystem;
            mockFileSystem.AddFile(Path.Join(Root, "data", "database", "notes.txt"), new MockFileData("notes"));

            Program.Main();

            Assert.IsTrue(mockFileSystem.FileExists(Path.Join(Root, "backup", "database", "notes.txt")));
        }

        [TestMethod]
        public void GivenSourceWithTrailingSeparator_WhenRunningMain_ThenSubfolderLandsUnderDestination()
        {
            var mockFileSystem = new MockFileSystem();
            Program.SourceDir = Path.Join(Root, "Source") + Path.DirectorySeparatorChar;
            Program.DestinationDir = Path.Join(Root, "Destination");
            Program.FileSystem = mockFileSystem;
            mockFileSystem.AddFile(Path.Join(Root, "Source", "ChildDir", "childfile.txt"), new MockFileData("childfile"));

            Program.Main();

            Assert.IsTrue(mockFileSystem.FileExists(Path.Join(Root, "Destination", "ChildDir", "childfile.txt")));
        }

        [TestMethod]
        public void GivenSourceWithoutSubfolders_WhenDestinationIsMissing_ThenFilesAreCopied()
        {
            var mockFileSystem = new MockFileSystem();
            Program.SourceDir = Path.Join(Root, "Source");
            Program.DestinationDir = Path.Join(Root, "Destination");
            Program.FileSystem = mockFileSystem;
            mockFileSystem.AddFile(Path.Join(Root, "Source", "file.txt"), new MockFileData("file"));

            Program.Main();

            Assert.IsTrue(mockFileSystem.FileExists(Path.Join(Root, "Destination", "file.txt")));
        }

        [TestMethod]
        public void GivenExistingFile_WhenOverwriteIsFalse_ThenIOExceptionIsThrown()
        {
            var mockFileSystem = new MockFileSystem();
            Program.FileSystem = mockFileSystem;
            mockFileSystem.AddFile(Path.Join(Root, "Source", "file.txt"), new MockFileData("new"));
            mockFileSystem.AddFile(Path.Join(Root, "Destination", "file.txt"), new MockFileData("old"));

            Assert.ThrowsExactly<IOException>(() =>
                Program.CopyDirectory(Path.Join(Root, "Source"), Path.Join(Root, "Destination"), false));
        }

        [TestMethod]
        public void GivenRealDirectory_WhenCallingDeepCopy_ThenTreeIsCopied()
        {
            var testRoot = Path.Join(Path.GetTempPath(), "CopyAllContentInDirectory-" + Guid.NewGuid());
            var source = Path.Join(testRoot, "Source");
            var destination = Path.Join(testRoot, "Destination");
            Directory.CreateDirectory(Path.Join(source, "ChildDir", "Empty"));
            File.WriteAllText(Path.Join(source, "top.txt"), "top");
            File.WriteAllText(Path.Join(source, "ChildDir", "child.txt"), "child");

            try
            {
                new DirectoryInfo(source).DeepCopy(destination, true);

                Assert.AreEqual("top", File.ReadAllText(Path.Join(destination, "top.txt")));
                Assert.AreEqual("child", File.ReadAllText(Path.Join(destination, "ChildDir", "child.txt")));
                Assert.IsTrue(Directory.Exists(Path.Join(destination, "ChildDir", "Empty")));
            }
            finally
            {
                Directory.Delete(testRoot, true);
            }
        }
    }
}
