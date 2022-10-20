using DataTableToJsonTests;
using System.Data;

namespace DataTableToJsonTestsTests
{
    [TestClass]
    public class DataTableToJsonTestsUnitTests
    {
        private static DataTableToJsonTestsMethods methods = new DataTableToJsonTestsMethods();


        [TestMethod]
        public void GivenDataTable_WhenUsingNewtonsoftJsonNet_VerifyResult()
        {
            var json = methods.DataTable_NewtonsoftJsonNet(methods.dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingSystemTextJson_VerifyResult()
        {
            var json = methods.DataTable_SystemTextJson(methods.dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingStringBuilder_VerifyResult()
        {
            var json = methods.DataTable_StringBuilder(methods.dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingLINQ_VerifyResult()
        {
            var json = methods.DataTable_Linq(methods.dataTable);
            Assert.IsTrue(ValidateJson(json));
        }


        private bool ValidateJson(string json)
        {
            var dt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(json);
            return dt?.Rows.Count == 1000;
        }
    }
}