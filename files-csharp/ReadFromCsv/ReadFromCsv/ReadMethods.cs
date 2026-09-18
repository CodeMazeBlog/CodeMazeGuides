using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace ReadFromCsv;

public static class ReadMethods
{
    public static List<Person> ReadPersons()
    {
        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",",
            Comment = '#',
            HasHeaderRecord = false
        };

        using var reader = new StreamReader("filePersons.csv");
        using var csv = new CsvReader(reader, configuration);

        csv.Context.RegisterClassMap<PersonMap>();

        return csv.GetRecords<Person>().ToList();
    }
}
