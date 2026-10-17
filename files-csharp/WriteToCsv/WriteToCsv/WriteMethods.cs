using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingCSV
{
    public static class WriteMethods
    {

        public static void WritePersonsWithDoB()
        {
            var myPersons = new List<Person>()
            {
                new Person { Id = 1, IsLiving = true, Name = "John", DateOfBirth = Convert.ToDateTime("03/05/2006") },
                new Person { Id = 2, IsLiving = true, Name = "Steve", DateOfBirth = Convert.ToDateTime("03/09/1998") },
                new Person { Id = 3, IsLiving = true, Name = "James", DateOfBirth = Convert.ToDateTime("03/08/1994") }
            };

            using (var writer = new StreamWriter("filePersonsWithDoB.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(myPersons);
            }

        }

        public static List<Person> CreatePersons() => new()
        {
            new Person { Id = 1, IsLiving = true, Name = "John", DateOfBirth = Convert.ToDateTime("03/05/2006") },
            new Person { Id = 2, IsLiving = true, Name = "Steve", DateOfBirth = Convert.ToDateTime("03/09/1998") },
            new Person { Id = 3, IsLiving = true, Name = "James", DateOfBirth = Convert.ToDateTime("03/08/1994") }
        };

        public static void WriteWithDefaultSettings(string path = "filePersons.csv")
        {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(CreatePersons());
            }
        }

        public static void WriteWithoutHeader(string path = "filePersons.csv")
        {
            var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, configPersons))
            {
                csv.WriteRecords(CreatePersons());
            }
        }

        public static void WriteWithClassMap(string path = "filePersons.csv")
        {
            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<PersonMap>();
            csv.WriteRecords(CreatePersons());
        }

        public static void AppendPersons(string path = "filePersons.csv")
        {
            var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };

            using (var stream = File.Open(path, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, configPersons))
            {
                csv.WriteRecords(CreatePersons());
            }
        }

        public static string WriteTrickyValues()
        {
            var trickyContacts = new List<Contact>()
            {
                new Contact { Id = 1, Name = "Doe, John" },
                new Contact { Id = 2, Name = "He said \"hi\"" },
                new Contact { Id = 3, Name = "line1\nline2" }
            };

            using var writer = new StringWriter();
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(trickyContacts);
            }

            return writer.ToString();
        }

        public static async Task WritePersonsAsync(string path = "filePersons.csv")
        {
            await using var writer = new StreamWriter(path);
            await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            await csv.WriteRecordsAsync(CreatePersons());
        }

        public static string WriteEmployees(IWriterConfiguration configuration)
        {
            var employees = new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "Doe, John",
                    Hired = new DateTime(2020, 3, 5),
                    Salary = 1234.50m,
                    Active = true,
                    Region = "US",
                    Nickname = null,
                    Notes = "not written"
                }
            };

            using var writer = new StringWriter();
            using (var csv = new CsvWriter(writer, configuration))
            {
                csv.WriteRecords(employees);
            }

            return writer.ToString();
        }
    }
}
