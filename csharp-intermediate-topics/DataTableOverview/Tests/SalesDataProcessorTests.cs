using DataTableOverview;
using Xunit;
using System;

namespace Tests
{
    [Collection("Console output")]
    public class SalesDataProcessorTests
    {
        [Fact]
        public void WhenCsvToDataTableCalled_ThenNonEmptyDataTableReturned()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "vegetable-sales.csv";

            var result = SalesDataProcessor.CsvToDataTable(filePath);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Rows);
        }

        [Fact]
        public void WhenProcessSales_ThenPrintsSelectedRows()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "vegetable-sales.csv";
            var veggieSales = SalesDataProcessor.CsvToDataTable(filePath);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            SalesDataProcessor.ProcessSales();
            var output = stringWriter.ToString();

            Assert.Contains("Carrot", output);
        }

        [Fact]
        public void WhenNumericFilterRunsOnCsvColumn_ThenEvaluateExceptionThrown()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "vegetable-sales.csv";
            var veggieSales = SalesDataProcessor.CsvToDataTable(filePath);

            Assert.Equal(typeof(string), veggieSales.Columns["Price"]!.DataType);
            Assert.Throws<System.Data.EvaluateException>(() => veggieSales.Select("Price > 1"));
        }
    }
}
