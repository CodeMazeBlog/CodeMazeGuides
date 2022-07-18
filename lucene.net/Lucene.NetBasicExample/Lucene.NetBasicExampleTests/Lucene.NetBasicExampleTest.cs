using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Lucene.NetBasicExample.Program;

namespace Lucene.NetBasicExampleTests
{
    [TestClass]
    public class LuceneDotNetBasicExamplesTest
    {
        [TestMethod]
        public void TestLuceneDotNextBasicExample()
        {
            try
            {
                TestIndexing();
                TestMaintaining();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        private static void TestIndexing()
        {
            var data = GetData();
            Assert.IsNotNull(data);
            Index(data);
            Assert.IsTrue(Writer.NumDocs > 0);
        }

        private static void TestMaintaining()
        {
            var guid = Guid.NewGuid().ToString();
            var guidField = new Net.Documents.StringField("GUID", guid, Net.Documents.Field.Store.YES);
            var fNameField = new Net.Documents.TextField("FirstName", "TestFirstName", Net.Documents.Field.Store.YES);
            var mNameField = new Net.Documents.TextField("MiddleName", "TestMiddleName", Net.Documents.Field.Store.YES);
            var lNameField = new Net.Documents.TextField("LastName", "TestLastName", Net.Documents.Field.Store.YES);
            var descriptionField = new Net.Documents.TextField("Description", "Test Description", Net.Documents.Field.Store.YES);
            var d = new Net.Documents.Document()
            {
                guidField,
                fNameField,
                mNameField,
                lNameField,
                descriptionField
            };
            AddToIndex(d);
            var result = Search("TestFirstName");
            Assert.IsTrue(result.Count > 0);

            fNameField.SetStringValue("UpdatedTestFirstName");
            mNameField.SetStringValue("UpdatedTestMiddleName");
            lNameField.SetStringValue("UpdatedTestLastName");
            descriptionField.SetStringValue("Updated Test Description");
            ChangeInIndex(d, guid);
            result = Search("UpdatedTestFirstName");
            Assert.IsTrue(result.Count > 0);

            DeleteFromIndex(guid);
            result = Search("TestFirstName");
            Assert.IsTrue(result.Count < 1);
        }
    }
}