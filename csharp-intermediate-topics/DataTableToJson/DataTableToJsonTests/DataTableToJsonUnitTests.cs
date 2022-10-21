using DataTableToJsonTest;
using DataTableToJsonTests;
using System.Data;

namespace DataTableToJsonTestsTests
{
    [TestClass]
    public class DataTableToJsonTestsUnitTests
    {
        private static Benchmark benchmark = new Benchmark();

        [TestMethod]
        public void GivenDataTable_WhenUsingNewtonsoftJsonNet_VerifyResult()
        {
            var json = Methods.DataTable_NewtonsoftJsonNet(benchmark.dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingSystemTextJson_VerifyResult()
        {
            var json = Methods.DataTable_SystemTextJson(benchmark.dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingStringBuilder_VerifyResult()
        {
            var json = Methods.DataTable_StringBuilder(benchmark.dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingLINQ_VerifyResult()
        {
            var json = Methods.DataTable_Linq(benchmark.dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        private bool ValidateJson(string json)
        {
            var dt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(json);
            return dt?.Rows.Count == benchmark.dataTable.Rows.Count;
        }
    }
}