using DataTableToJsonTests;
using System.Data;

namespace DataTableToJsonTestsTests
{
    [TestClass]
    public class DataTableToJsonTestsUnitTests
    {
        private static DataTableToJsonTestsMethods methods = new DataTableToJsonTestsMethods();
        DataTable dataTable = methods.GenerateDummyDataTable();

        [TestMethod]
        public void GivenDataTable_WhenUsingSystemTextJson_VerifyResult()
        {
            var json = methods.DataTable_SystemTextJson(dataTable);
            Console.Write(json);
            Assert.IsFalse(string.IsNullOrEmpty(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingStringBuilder_VerifyResult()
        {
            var json = methods.DataTable_StringBuilder(dataTable);
            Console.Write(json);
            Assert.IsFalse(string.IsNullOrEmpty(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingLINQ_VerifyResult()
        {
            var json = methods.DataTable_LINQ(dataTable);
            Console.Write(json);
            Assert.IsFalse(string.IsNullOrEmpty(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingNewtonsoftJsonNet_VerifyResult()
        {
            var json = methods.DataTable_NewtonsoftJsonNet(dataTable);
            Console.Write(json);
            Assert.IsFalse(string.IsNullOrEmpty(json));
        }
    }
}