using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.VisualBasic.FileIO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadFromCsv;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ReadFromCsvTests;

[TestClass]
public class ReadFromCsvTests
{
    private static CsvReader CreateReader(string csvContent, CsvConfiguration configuration, out StreamReader reader)
    {
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(csvContent));

        reader = new StreamReader(stream);

        return new CsvReader(reader, configuration);
    }

    [TestMethod]
    public void GivenHeaderlessCsvFile_WhenReadingPersons_ThenEveryFieldIsMapped()
    {
        var csvFile = "1,John,True,03/05/2006 00:00:00\n"
            + "2,Steve,False,03/05/2006 00:00:00\n"
            + "3,James,True,03/05/2006 00:00:00";

        var expectedPersons = new List<Person>
        {
            new() { Id = 1, Name = "John", IsLiving = true, DateOfBirth = DateTime.Parse("03/05/2006", CultureInfo.InvariantCulture) },
            new() { Id = 2, Name = "Steve", IsLiving = false, DateOfBirth = DateTime.Parse("03/05/2006", CultureInfo.InvariantCulture) },
            new() { Id = 3, Name = "James", IsLiving = true, DateOfBirth = DateTime.Parse("03/05/2006", CultureInfo.InvariantCulture) }
        };

        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        };

        using var csv = CreateReader(csvFile, configuration, out var reader);
        using (reader)
        {
            var persons = csv.GetRecords<Person>().ToList();

            Assert.AreEqual(expectedPersons.Count, persons.Count);

            for (var i = 0; i < expectedPersons.Count; i++)
            {
                Assert.AreEqual(expectedPersons[i].Id, persons[i].Id);
                Assert.AreEqual(expectedPersons[i].Name, persons[i].Name);
                Assert.AreEqual(expectedPersons[i].IsLiving, persons[i].IsLiving);
                Assert.AreEqual(expectedPersons[i].DateOfBirth, persons[i].DateOfBirth);
            }
        }
    }

    [TestMethod]
    public void GivenHeaderlessCsvFile_WhenTheConfigurationIsNotPassedToTheReader_ThenTheFirstRowIsLost()
    {
        var csvFile = "1,John,True,03/05/2006 00:00:00\n2,Steve,False,03/05/2006 00:00:00";

        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        };

        using (var csv = CreateReader(csvFile, configuration, out var withConfiguration))
        using (withConfiguration)
        {
            Assert.AreEqual(2, csv.GetRecords<Person>().ToList().Count);
        }

        var cultureOnly = new CsvConfiguration(CultureInfo.InvariantCulture);

        using (var csv = CreateReader(csvFile, cultureOnly, out var withCulture))
        using (withCulture)
        {
            var persons = csv.GetRecords<Person>().ToList();

            Assert.AreEqual(1, persons.Count);
            Assert.AreEqual(2, persons[0].Id);
        }
    }

    [TestMethod]
    public void GivenAQuotedComma_WhenReadingTheRow_ThenTheFieldSurvivesIntact()
    {
        var csvFile = "Id,Name,IsLiving,DateOfBirth\n1,\"Close, Josh\",true,03/05/2006 00:00:00";

        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture);

        using var csv = CreateReader(csvFile, configuration, out var reader);
        using (reader)
        {
            var persons = csv.GetRecords<Person>().ToList();

            Assert.AreEqual(1, persons.Count);
            Assert.AreEqual("Close, Josh", persons[0].Name);
        }
    }

    [TestMethod]
    public void GivenACommentLine_WhenAllowCommentsIsFalse_ThenTheCommentIsReadAsData()
    {
        var csvFile = "1;John;True;03/05/2006 00:00:00\n% a comment line\n2;Steve;False;03/05/2006 00:00:00";

        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            Delimiter = ";",
            Comment = '%'
        };

        Assert.IsFalse(configuration.AllowComments);

        using var csv = CreateReader(csvFile, configuration, out var reader);
        using (reader)
        {
            Assert.ThrowsExactly<TypeConverterException>(() => csv.GetRecords<Person>().ToList());
        }
    }

    [TestMethod]
    public void GivenACommentLine_WhenAllowCommentsIsTrue_ThenTheCommentIsSkipped()
    {
        var csvFile = "1;John;True;03/05/2006 00:00:00\n% a comment line\n2;Steve;False;03/05/2006 00:00:00";

        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            Delimiter = ";",
            Comment = '%',
            AllowComments = true
        };

        using var csv = CreateReader(csvFile, configuration, out var reader);
        using (reader)
        {
            var persons = csv.GetRecords<Person>().ToList();

            Assert.AreEqual(2, persons.Count);
            Assert.AreEqual("Steve", persons[1].Name);
        }
    }

    [TestMethod]
    public void GivenAQuotedComma_WhenSplittingTheLine_ThenSplitBreaksItAndTextFieldParserDoesNot()
    {
        var row = "1,\"Close, Josh\",true,03/05/2006 00:00:00";

        Assert.AreEqual(5, row.Split(',').Length);

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(row));
        using var parser = new TextFieldParser(stream)
        {
            TextFieldType = FieldType.Delimited,
            HasFieldsEnclosedInQuotes = true
        };

        parser.SetDelimiters(",");

        var fields = parser.ReadFields();

        Assert.IsNotNull(fields);
        Assert.AreEqual(4, fields.Length);
        Assert.AreEqual("Close, Josh", fields[1]);
    }

    [TestMethod]
    public void GivenAnUnconvertibleField_WhenReadingExceptionOccurredReturnsFalse_ThenTheBadRowIsSkipped()
    {
        var csvFile = "1,John,True,03/05/2006 00:00:00\n"
            + "2,Steve,notabool,03/05/2006 00:00:00\n"
            + "3,James,True,03/05/2006 00:00:00";

        var strict = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        };

        using (var csv = CreateReader(csvFile, strict, out var strictReader))
        using (strictReader)
        {
            Assert.ThrowsExactly<TypeConverterException>(() => csv.GetRecords<Person>().ToList());
        }

        var tolerant = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            ReadingExceptionOccurred = args => false
        };

        using (var csv = CreateReader(csvFile, tolerant, out var tolerantReader))
        using (tolerantReader)
        {
            var persons = csv.GetRecords<Person>().ToList();

            Assert.AreEqual(2, persons.Count);
            Assert.AreEqual(3, persons[1].Id);
        }
    }
}
