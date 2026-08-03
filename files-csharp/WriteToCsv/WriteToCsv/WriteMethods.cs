using CsvHelper;
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
    }
}
