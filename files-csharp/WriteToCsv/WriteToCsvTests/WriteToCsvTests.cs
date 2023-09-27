using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using WritingCSV;

namespace WriteToCsvTests
{
    [TestClass]
    public class WriteToCsvTests
    {
        [TestMethod]
        public void givenListOfPersons_whenWritingPersonsToCsv_ThenOutputShouldHaveCorrectFormat()
        {
            var myPersons = new List<Person>()
            {
                new Person { Id = 1, IsLiving = true, Name = "John", DateOfBirth = Convert.ToDateTime("03/05/2006") },
                new Person { Id = 2, IsLiving = true, Name = "Steve", DateOfBirth = Convert.ToDateTime("03/09/1998") },
                new Person { Id = 3, IsLiving = true, Name = "James", DateOfBirth = Convert.ToDateTime("03/08/1994") }
            };

            string outputString;
            using( var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(myPersons);
                }

                outputString = Encoding.ASCII.GetString(memoryStream.ToArray());
            }

            //remove newlines (either \r\n or \n for win resp linux) as it might issues when comparing
            outputString = outputString.Replace("\n", "").Replace("\r","");
            var expectedString = @"Identifier,IsLiving,Name,DateOfBirth
1,True,John,2006-03-05
2,True,Steve,1998-03-09
3,True,James,1994-03-08
".Replace("\n", "").Replace("\r", "");

            Assert.AreEqual(expectedString, outputString, ignoreCase: false, CultureInfo.InvariantCulture);

        }
    }
}