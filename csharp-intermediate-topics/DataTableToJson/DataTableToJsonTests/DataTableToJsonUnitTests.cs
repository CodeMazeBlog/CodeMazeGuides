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
            var json = Methods.DataTableNewtonsoftJsonNet(benchmark.dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingSystemTextJson_VerifyResult()
        {
            var json = Methods.DataTableSystemTextJson(benchmark.dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingStringBuilder_VerifyResult()
        {
            var json = Methods.DataTableStringBuilder(benchmark.dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        [TestMethod]
        public void GivenDataTable_WhenUsingLINQ_VerifyResult()
        {
            var json = Methods.DataTableLinq(benchmark.dataTable);
            Assert.IsTrue(ValidateJson(json));
        }

        private bool ValidateJson(string json)
        {
            var dt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(json);
            return dt?.Rows.Count == benchmark.dataTable.Rows.Count;
        }
    }
}