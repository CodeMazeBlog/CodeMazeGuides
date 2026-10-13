using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WritingCSV;

namespace WriteToCsvTests
{
    [TestClass]
    public class WriteMethodsTests
    {
        private static readonly string[] DataRows =
        {
            "1,True,John,2006-03-05",
            "2,True,Steve,1998-03-09",
            "3,True,James,1994-03-08"
        };

        private static string NewTempPath() =>
            Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

        [TestMethod]
        public void GivenPersons_WhenWritingWithDefaultSettings_ThenHeaderComesFromTheClass()
        {
            var path = NewTempPath();
            try
            {
                WriteMethods.WriteWithDefaultSettings(path);

                var expected = "Identifier,IsLiving,Name,DateOfBirth\r\n" + string.Join("\r\n", DataRows) + "\r\n";
                Assert.AreEqual(expected, File.ReadAllText(path));
            }
            finally
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        public void GivenNoHeaderConfig_WhenWriting_ThenFirstLineIsData()
        {
            var path = NewTempPath();
            try
            {
                WriteMethods.WriteWithoutHeader(path);

                CollectionAssert.AreEqual(DataRows, File.ReadAllLines(path));
            }
            finally
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        public void GivenClassMap_WhenWriting_ThenHeaderAndOrderFollowTheMap()
        {
            var path = NewTempPath();
            try
            {
                WriteMethods.WriteWithClassMap(path);

                var expected = "Identifier,IsLiving,Name\r\n1,True,John\r\n2,True,Steve\r\n3,True,James\r\n";
                Assert.AreEqual(expected, File.ReadAllText(path));
            }
            finally
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        public void GivenAFileWithoutHeader_WhenAppending_ThenRowsAreAddedAtTheEnd()
        {
            var path = NewTempPath();
            try
            {
                WriteMethods.WriteWithoutHeader(path);
                WriteMethods.AppendPersons(path);

                CollectionAssert.AreEqual(DataRows.Concat(DataRows).ToArray(), File.ReadAllLines(path));
            }
            finally
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        public void GivenTrickyValues_WhenWriting_ThenFieldsAreQuotedAndQuotesDoubled()
        {
            var expected = "Id,Name\r\n"
                + "1,\"Doe, John\"\r\n"
                + "2,\"He said \"\"hi\"\"\"\r\n"
                + "3,\"line1\nline2\"\r\n";

            Assert.AreEqual(expected, WriteMethods.WriteTrickyValues());
        }

        [TestMethod]
        public async Task GivenPersons_WhenWritingAsync_ThenFileMatchesTheSynchronousWrite()
        {
            var syncPath = NewTempPath();
            var asyncPath = NewTempPath();
            try
            {
                WriteMethods.WriteWithDefaultSettings(syncPath);
                await WriteMethods.WritePersonsAsync(asyncPath);

                CollectionAssert.AreEqual(File.ReadAllBytes(syncPath), File.ReadAllBytes(asyncPath));
            }
            finally
            {
                File.Delete(syncPath);
                File.Delete(asyncPath);
            }
        }

        [TestMethod]
        public void GivenAttributedEmployee_WhenWritingWithACulture_ThenClassLevelAttributesAreIgnored()
        {
            var csv = WriteMethods.WriteEmployees(new CsvConfiguration(CultureInfo.InvariantCulture));

            var expected = "Identifier,Full Name,Hired,Salary,Active,Region,Nickname\r\n"
                + "1,\"Doe, John\",2020-03-05,\"$1,234.50\",yes,EU,N/A\r\n";
            Assert.AreEqual(expected, csv);
        }

        [TestMethod]
        public void GivenAttributedEmployee_WhenWritingFromAttributes_ThenClassLevelAttributesApply()
        {
            var configuration = CsvConfiguration.FromAttributes<Employee>(CultureInfo.InvariantCulture);

            var csv = WriteMethods.WriteEmployees(configuration);

            Assert.AreEqual("1;Doe, John;2020-03-05;$1,234.50;yes;EU;N/A\r\n", csv);
        }
    }
}
