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
            Assert.IsTrue(ValidateJson(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingStringBuilder_VerifyResult()
        {
            var json = methods.DataTable_StringBuilder(dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingLINQ_VerifyResult()
        {
            var json = methods.DataTable_LINQ(dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingNewtonsoftJsonNet_VerifyResult()
        {
            var json = methods.DataTable_NewtonsoftJsonNet(dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        private bool ValidateJson(string json)
        {
            var dt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(json);
            return dt?.Rows.Count == 1000;
        }
    }
}