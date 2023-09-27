using System.Data;
using Microsoft.VisualBasic.FileIO;

namespace DataTableOverview
{
    public static class SalesDataProcessor
    {
        public static void ProcessSales()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vegetable-sales.csv");
            DataTable veggieSales = CsvToDataTable(filePath);

            DataRow[] carrotSales = veggieSales.Select("Vegetable='Carrot'");
            Program.PrintSelectedRows(carrotSales, veggieSales);
        }

        public static DataTable CsvToDataTable(string filePath)
        {
            DataTable dtRes = new DataTable();
            using (var parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.TrimWhiteSpace = true;
                parser.SetDelimiters(",");

                var columns = parser.ReadFields();

                foreach (var col in columns)
                    dtRes.Columns.Add(col);

                while (!parser.EndOfData)
                {
                    var row = parser.ReadFields();
                    dtRes.LoadDataRow(row, true);
                }
            }
            return dtRes;
        }
    }
}