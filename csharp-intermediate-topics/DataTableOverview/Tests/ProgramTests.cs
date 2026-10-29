using System;
using System.Data;
using DataTableOverview;
using Xunit;

namespace Tests
{
    [Collection("Console output")]
    public class ProgramTests
    {
        private static DataTable CreateKeyedTable()
        {
            var dt = Program.CreateMainDataTable();
            Program.PopulateDataTable(dt);
            Program.AddPrimaryKey(dt);

            return dt;
        }

        [Fact]
        public static void WhenCreateMainDataTable_ThenColumnsPopulateCorrectly()
        {
            var dt = Program.CreateMainDataTable();
            var expectedColumns = new string[] { "Ticker", "Date", "Price" };

            var actualColumns = dt.Columns.Cast<DataColumn>()
                .Select(x => x.ColumnName)
                .ToArray();

            Assert.Equal(expectedColumns, actualColumns);
        }

        [Fact]
        public static void WhenAddPrimaryKey_ThenPrimaryKeyEqualsKey()
        {
            var dt = CreateKeyedTable();

            var pkActual = dt.PrimaryKey;

            Assert.Equal("Key", pkActual[0].Caption);
            Assert.Equal(0, dt.Rows[0]["Key"]);
        }

        [Fact]
        public static void WhenPrimaryKeySetOnColumnWithEmptyValues_ThenDataExceptionThrown()
        {
            var dt = Program.CreateMainDataTable();
            Program.PopulateDataTable(dt);
            var pkCol = new DataColumn("Key", typeof(int));
            dt.Columns.Add(pkCol);

            Assert.Throws<DataException>(() => dt.PrimaryKey = [pkCol]);
        }

        [Fact]
        public static void WhenPopulateDataTable_ThenDataTableContainsMsftRecord()
        {
            var dt = Program.CreateMainDataTable();

            Program.PopulateDataTable(dt);

            Assert.Contains("MSFT", Convert.ToString(dt.Rows[0][0]));
        }

        [Fact]
        public static void WhenAddNewRow_ThenDataTableContainsAmznRecord()
        {
            var dt = CreateKeyedTable();

            Program.AddNewRow(dt);

            Assert.Contains("AMZN", Convert.ToString(dt.Rows[1][0]));
        }

        [Fact]
        public static void WhenAddNewRowFromValues_ThenDataTableContainsAmznRecord()
        {
            var dt = CreateKeyedTable();

            Program.AddNewRowFromValues(dt);

            Assert.Equal("AMZN", dt.Rows[1]["Ticker"]);
            Assert.Equal(1, dt.Rows[1]["Key"]);
        }

        [Fact]
        public static void WhenRowAddedWithDuplicateKey_ThenConstraintExceptionThrown()
        {
            var dt = CreateKeyedTable();

            Assert.Throws<ConstraintException>(() => dt.Rows.Add("AMZN", new DateTime(2023, 3, 6), 93.75, 0));
        }

        [Fact]
        public static void WhenPrintConstraints_ThenReturnsConstraintOneUniqueConstraint()
        {
            var dt = CreateKeyedTable();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.PrintConstraints(dt);
            var output = stringWriter.ToString();

            Assert.Contains("Constraint1", output);
            Assert.Contains("System.Data.UniqueConstraint", output);
        }

        [Fact]
        public static void WhenCloneCalled_ThenAllColumnsAndNoRowsCopied()
        {
            var dt = CreateKeyedTable();

            var dtClone = dt.Clone();

            Assert.Equal(4, dtClone.Columns.Count);
            Assert.Empty(dtClone.Rows);
        }

        [Fact]
        public static void WhenFilterDataTable_ThenPrintsAmznDataRow()
        {
            var dt = CreateKeyedTable();
            Program.AddNewRow(dt);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.FilterDataTable(dt);
            var output = stringWriter.ToString();

            Assert.Contains("AMZN", output);
            Assert.DoesNotContain("MSFT", output);
        }

        [Fact]
        public static void WhenPrintData_ThenPrintsExpectedData()
        {
            var dt = CreateKeyedTable();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.PrintData(dt);
            var output = stringWriter.ToString();

            Assert.Contains("MSFT", output);
            Assert.Contains(Convert.ToString(new DateTime(2023, 3, 3)), output);
            Assert.Contains("255.29", output);
            Assert.Contains("Key: 0", output);
        }

        [Fact]
        public static void WhenPrintTable_ThenPrintsHeaderAndOneLinePerRow()
        {
            var dt = CreateKeyedTable();
            Program.AddNewRow(dt);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.PrintTable(dt);
            var lines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal("Ticker | Date | Price | Key", lines[0]);
            Assert.Equal(3, lines.Length);
            Assert.StartsWith("AMZN | ", lines[2]);
        }

        [Fact]
        public static void WhenGetTickersBelow_ThenReturnsOnlyCheaperTickers()
        {
            var dt = CreateKeyedTable();
            Program.AddNewRow(dt);

            var tickers = Program.GetTickersBelow(dt, 100);

            Assert.Equal(new[] { "AMZN" }, tickers);
        }
    }
}
