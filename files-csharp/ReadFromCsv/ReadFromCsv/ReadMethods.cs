using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace ReadFromCsv
{
    public static class ReadMethods
    {
        public static void ReadPersons()
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                Comment = '#',
                HasHeaderRecord = false
            };

            using (var reader = new StreamReader("filePersons.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<PersonMap>();
                var persons = csv.GetRecords<Person>();
            }

        }
    }
}
