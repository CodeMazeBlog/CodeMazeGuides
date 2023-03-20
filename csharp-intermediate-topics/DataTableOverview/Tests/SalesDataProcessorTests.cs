using DataTableOverview;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
using System;

namespace Tests
{
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
    }
}

