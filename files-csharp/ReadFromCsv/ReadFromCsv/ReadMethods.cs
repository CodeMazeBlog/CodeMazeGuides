using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var persons = csv.GetRecords<Person>();
            }

        }
    }
}
