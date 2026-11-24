using CopyAllContentInDirectory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CopyAllContentInDirectoryTests;

[TestClass]
public class BuiltInCopyTests
{
    [TestMethod]
    public void GivenExistingDestination_WhenCopyingWithVisualBasic_ThenContentsAreMerged()
    {
        var testRoot = Path.Join(Path.GetTempPath(), "BuiltInCopy-" + Guid.NewGuid());
        var source = Path.Join(testRoot, "Source");
        var destination = Path.Join(testRoot, "Destination");
        Directory.CreateDirectory(Path.Join(source, "ChildDir"));
        File.WriteAllText(Path.Join(source, "ChildDir", "child.txt"), "new");
        Directory.CreateDirectory(Path.Join(destination, "ChildDir"));
        File.WriteAllText(Path.Join(destination, "ChildDir", "child.txt"), "old");
        File.WriteAllText(Path.Join(destination, "keep.txt"), "mine");

        try
        {
            BuiltInCopy.CopyWithVisualBasic(source, destination);

            Assert.AreEqual("new", File.ReadAllText(Path.Join(destination, "ChildDir", "child.txt")));
            Assert.IsTrue(File.Exists(Path.Join(destination, "keep.txt")));
        }
        finally
        {
            Directory.Delete(testRoot, true);
        }
    }

    [TestMethod]
    public void GivenDestinationInsideSource_WhenCopyingWithVisualBasic_ThenInvalidOperationExceptionIsThrown()
    {
        var source = Path.Join(Path.GetTempPath(), "BuiltInCopy-" + Guid.NewGuid());
        Directory.CreateDirectory(source);
        File.WriteAllText(Path.Join(source, "file.txt"), "file");

        try
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
                BuiltInCopy.CopyWithVisualBasic(source, Path.Join(source, "Backup")));
        }
        finally
        {
            Directory.Delete(source, true);
        }
    }
}
