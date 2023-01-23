using HowToConvertJSONToDataTableInCSharp;
using System.Data;

namespace Tests
{
    public class ConvertMethodTests
    {
        [Fact]
        public void GivenJsonString_WhenUsingNewtonsoftJson_ThenDeserializeToADataTable()
        {
            var dataTable = ConvertMethods.UseNewtonsoftJson();

            Assert.IsType<DataTable>(dataTable);
            Assert.True(dataTable.Rows.Count > 0);
        }

        [Fact]
        public void GivenJsonString_WhenUsingSystemTextJson_ThenDeserializeToADataTable()
        {
            var dataTable = ConvertMethods.UseSystemTextJson();

            Assert.IsType<DataTable>(dataTable);
            Assert.True(dataTable.Rows.Count > 0);
        }

        [Fact]
        public void GivenJsonString_WhenManuallyConstructingADataTable_ThenDeserializeToADataTable()
        {
            var dataTable = ConvertMethods.ManuallyConvertJsonToDataTable();

            Assert.IsType<DataTable>(dataTable);
            Assert.True(dataTable.Rows.Count > 0);
        }
    }
}