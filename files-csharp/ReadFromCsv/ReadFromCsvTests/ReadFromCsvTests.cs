using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadFromCsv;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ReadFromCsvTests
{
    [TestClass]
    public class ReadFromCsvTests
    {
        [TestMethod]
        public void GivenCsvFile_WhenReadingPersonsFromCsv_ThenListOfPersonsIsPopulated()
        {
            string csvFile =
                @"1, John, True, 03/05/2006 00:00:00
2, Steve, False, 03/05/2006 00:00:00
3, James, True, 03/05/2006 00:00:00";

            var expectedPersons = new List<Person>()
            {
                new Person { Id = 1, IsLiving = true, Name = "John", DateOfBirth = Convert.ToDateTime("03/05/2006") },
                new Person { Id = 2, IsLiving = true, Name = "Steve", DateOfBirth = Convert.ToDateTime("03/09/1998") },
                new Person { Id = 3, IsLiving = true, Name = "James", DateOfBirth = Convert.ToDateTime("03/08/1994") }
            };

            using (var test_Stream = new MemoryStream(Encoding.UTF8.GetBytes(csvFile)))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };

                using (var reader = new StreamReader(test_Stream))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<Person>();

                    Assert.AreEqual(expectedPersons.Count, records.Count());
                }
            }
        }
    }
}