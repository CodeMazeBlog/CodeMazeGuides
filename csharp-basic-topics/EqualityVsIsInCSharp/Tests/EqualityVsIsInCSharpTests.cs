using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using File = EqualityVsIsInCSharp.File;

namespace Tests
{
    [TestClass]
    public class EqualityVsIsInCSharpTests
    {
        [DataTestMethod]
        [DataRow("path", "path", true)]
        [DataRow("path1", "path2", false)]
        public void WhenCheckingFilesEquality_ResultIsReturnBasedOnPath(string path1, string path2, bool result)
        {
            var file1 = new File(path1);
            var file2 = new File(path2);
            var areFilesEqual = file1 == file2;

            Assert.AreEqual(areFilesEqual, result);
        }

        [TestMethod]
        public void WhenCheckingFilesEquality_ComparingToNullShouldThrowException()
        {
            var file = new File("path");

            Assert.ThrowsException<NullReferenceException>(() => file == null);
        }
    }
}