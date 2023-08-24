using System;
using System.Data;
using DataTableOverview;
using Xunit;

namespace Tests
{
    public class ProgramTests
    {
        [Fact]
        public static void WhenCreateMainDataTable_ThenColumnsPopulateCorrectly()
        {
            var dt = Program.CreateMainDataTable();
            var expectedColumns = new string[] { "Ticker", "Date", "Price", "Key" };

            var actualColumns = dt.Columns.Cast<DataColumn>()
                .Select(x => x.ColumnName)
                .ToArray();

            Assert.Equal(expectedColumns, actualColumns);
        }

        [Fact]
        public static void WhenCreateMaindataTable_ThenPrimaryKeyEqualsKey()
        {
            var dt = Program.CreateMainDataTable();

            var pkActual = dt.PrimaryKey;

            Assert.Equal("Key", pkActual[0].Caption);
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
            var dt = Program.CreateMainDataTable();

            Program.AddNewRow(dt);

            Assert.Contains("AMZN", Convert.ToString(dt.Rows[0][0]));
        }

        [Fact]
        public static void WhenPrintConstraints_ThenReturnsConstraintOneUniqueConstraint()
        {
            var dt = Program.CreateMainDataTable();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.PrintConstraints(dt);
            var output = stringWriter.ToString();

            Assert.Contains("Constraint1", output);
            Assert.Contains("System.Data.UniqueConstraint", output);
        }

        [Fact]
        public static void WhenFilterDataTable_ThenPrintsAmznDataRow()
        {
            var dt = Program.CreateMainDataTable();
            Program.AddNewRow(dt);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.FilterDataTable(dt);
            var output = stringWriter.ToString();

            Assert.Contains("AMZN", output);
        }

        [Fact]
        public static void WhenPrintData_ThenPrintsExpectedData()
        {
            var dt = Program.CreateMainDataTable();
            Program.PopulateDataTable(dt);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.PrintData(dt);
            var output = stringWriter.ToString();

            Assert.Contains("MSFT", output);
            Assert.Contains(Convert.ToString(new DateTime(2023, 3, 3)), output);
            Assert.Contains("255.29", output);
            Assert.Contains("0", output);
        }
    }
}