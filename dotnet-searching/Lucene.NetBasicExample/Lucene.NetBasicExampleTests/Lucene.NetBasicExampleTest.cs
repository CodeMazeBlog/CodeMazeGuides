using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Lucene.NetBasicExample.SearchEngine;

namespace Lucene.NetBasicExampleTests
{
    [TestClass]
    public class LuceneDotNetBasicExamplesTest
    {
        [TestMethod]
        public void Test1_WhenCallingGetData_ThenNotNull()
        {
            GetData();
            Assert.IsNotNull(Data);
        }

        [TestMethod]
        public void Test2_WhenCallingIndex_ThenWriterNumDocsGreaterThanZero()
        {
            Index();
            Assert.IsTrue(Writer.NumDocs > 0);
        }

        [TestMethod]
        public void Test3_WhenCallingAddToIndex_ThenResultCountIsGreaterThanZero()
        {
            AddToIndex();
            var result = Search("AddedFirstName");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Test4_WhenCallingChangeInIndex_ThenResultCountGreaterThanZero()
        {
            ChangeInIndex();
            var result = Search("UpdateFirstName");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Test5_WhenCallingDeleteFromIndex_ThenResultCountLessThanOne()
        {
            DeleteFromIndex();
            var result = Search("TestFirstName");
            Assert.IsTrue(result.Count < 1);
        }

        [TestMethod]
        public void Test6_WhenCallingDispose_ThenWriterIsClosed()
        {
            Dispose();
            Assert.IsTrue(Writer.IsClosed);
        }
    }
}